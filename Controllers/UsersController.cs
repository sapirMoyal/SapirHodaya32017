using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Models;
using System.Security.Cryptography;

namespace Controllers
{
    public class UsersController : ApiController
    {
        private UsersContext db = new UsersContext();

        // GET: api/Users
        //public IQueryable<User> GetUsers()
        //{
        //    return db.Users;
        //}
        // [Route("api/Users")]
        // GET: api/Users
      private  string ComputeHash(string input)
        {
            SHA1 sha = SHA1.Create();
            byte[] buffer = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = sha.ComputeHash(buffer);
            string hash64 = Convert.ToBase64String(hash);
            return hash64;
        }
        public RankData[] GetArrayUsers()
        {
            IQueryable<User> users = db.Users;
            var i = 0;
            RankData[] arrayUsers = new RankData[users.Count()];
            foreach (var r in users)
            {
                arrayUsers[i] = new RankData(r.win - r.lose, r.UserName, r.win, r.lose);
                i++;
            }
            // for (var j=0;j<users.Len)
            return arrayUsers;

        }
        /*
         * public async IEnumerable<User> GetUser(string UserName)
        {
           User user= db.Users.Where(m => m.UserName == UserName);
         **/
        
        [Route("api/Users/{name}/{password}")]
        [ResponseType(typeof(User))]
        public async Task<string> GetUser(string name,string password)
        {
           // db.Users.Where(m => m.UserName == m);
            User user = await db.Users.FindAsync(name);
            if (user == null)
            {
                return "You didnt registered!!";
            }

            else
            {
                var pass = user.UserPassword;
                var logPass = ComputeHash(password);
                if (pass != logPass)
                    return "The password Mistake -try again";
                return "connected";
             }
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(string name, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (name != user.UserName)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(name))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route("api/Users/PostWin")]
        public async Task<IHttpActionResult> PostWin(User user1)
        {
            User user = await db.Users.FindAsync(user1.UserName);
            if (user == null)
            {
                return NotFound();
            }
            db.Entry(user).Entity.win++;
            db.Entry(user).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpPost]
        [Route("api/Users/PostLose")]
        public async Task<IHttpActionResult> PostLose(User username)
        {
            User user = await db.Users.FindAsync(username.UserName);
            if (user == null)
            {
                return Ok();
            }
            db.Entry(user).Entity.lose++;
            db.Entry(user).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok();
        }
        
        // POST: api/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
              string newPass= ComputeHash(user.UserPassword);
               user.UserPassword = newPass;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Users.Add(user);
            await db.SaveChangesAsync();
             return CreatedAtRoute("DefaultApi", new { id = user.UserName }, user);
            //return Ok();
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(string id)
        {
            return db.Users.Count(e => e.UserName == id) > 0;
        }

    }
}