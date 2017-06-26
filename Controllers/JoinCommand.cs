using System.Net.Sockets;
using Models;

namespace Controllers
{
    /// <summary>
    /// add a client to game
    /// </summary>
    public class JoinCommand : ICommand
    {
        private IModel model;
        public JoinCommand(IModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// join the client to the game
        /// </summary>
        /// <param name="args">name of the game</param>
        /// <param name="client">the client</param>
        /// <returns>the game in json format</returns>
        public string Execute(string[] args, string client)
        {
            if (args.Length > 0)
            {
                string name = args[0];
                //ask the model to ad this client
                Game g = model.JoinGame(name, client);
                if (g != null)
                {
                    return g.ToJSON();
                }
                else
                {
                    return "error";
                }
            }
            else
            {
                //missing argument
                return "error";
            }
        }
    }
}