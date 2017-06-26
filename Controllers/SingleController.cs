using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MazeLib;
using Models;
using Newtonsoft.Json.Linq;

namespace Controllers
{
    public class SingleController : ApiController
    {
        private static SingleModel m = new SingleModel();

        [Route("api/Single/{name}/{row}/{col}")]
        public JObject GetMaze(string name, int row, int col)
        {
            Maze maze = m.GenerateMaze(name, row, col);
            if (maze != null)
            {
                JObject obj = JObject.Parse(maze.ToJSON());
                //return new Class1(maze);
                return obj;
            }
            return null;
        }
        


        public Class1 GetMaze(string name)
        {

            Maze maze = m.GenerateMaze(name, 3, 3);
            return new Class1(maze);
        }
        [Route("api/Single/{name}")]
        public string GetSolveMaze(string name)
        {
            return m.SolveMaze(name, 0).solv.ToString();
        }
        public Class1 GetMaze11()
        {
            Maze maze = m.GenerateMaze("aa", 3, 3);
            return new Class1(maze);
        }
    }
}