using System.Net.Sockets;
using Models;
namespace Controllers
{
    /// <summary>
    /// open a game
    /// </summary>
    public class StartCommand : ICommand
    {
        private IModel model;
        public StartCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, string client)
        {
            if (args.Length > 2)
            {
                string name = args[0];
                int rows = int.Parse(args[1]);
                int cols = int.Parse(args[2]);
                string ans = model.StartGame(name, rows, cols, client);
                return ans;
            }
            else
            {
                //missing argument
                return "error";
            }
        }
    }
}