using Models;
namespace Controllers
{
    public class CloseCommand : ICommand
    {
        private IModel model;
        /// <summary>
        /// send to both client to close the connection
        /// </summary>
        /// <param name="model"></param>
        public CloseCommand(IModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// close the game
        /// </summary>
        /// <param name="args">the name of the game</param>
        /// <param name="client">the client that ask this</param>
        /// <returns></returns>
        public string Execute(string[] args, string client)
        {
            if (args.Length > 0)
            {
                string name = args[0];
                string ans = model.Close(name, client);
                return ans;
            }
            else
            {
                return "error";
            }
        }
    }
}