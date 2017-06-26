using System;
using System.Net.Sockets;
using Models;

namespace Controllers
{
    public class ListCommand : ICommand
    {
        private IModel model;
        public ListCommand(IModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// the list of open game with one client
        /// </summary>
        /// <param name="args">nothing</param>
        /// <param name="client">the client that ask the list</param>
        /// <returns>the list of open game with one client</returns>
        public string Execute(string[] args, string client)
        {
            String ans = model.list();
            return ans;
        }
    }
}