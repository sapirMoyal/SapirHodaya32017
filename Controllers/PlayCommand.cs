using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using Newtonsoft.Json;
//using System.Web.Script.Serialization;
using MazeLib;
using MazeGeneratorLib;
using System.Net.Sockets;
using Models;
namespace Controllers
{
    /// <summary>
    /// get a move from one client ans send it to the second player
    /// </summary>
    public class PlayCommand : ICommand
    {
        private IModel model;
        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="model">the model</param>
        public PlayCommand(IModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// play command
        /// </summary>
        /// <param name="args">the direction</param>
        /// <param name="client">the client that move</param>
        /// <returns></returns>
        public string Execute(string[] args, string client)
        {
            if (args.Length > 0)
            {
                string move = args[0];
                String s = model.Play(move, client);
                return s;
            }
            else
            {
                //missing argument
                return "error";
            }
        }
    }
}