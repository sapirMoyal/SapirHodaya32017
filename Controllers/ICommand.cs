using System.Net.Sockets;

namespace Controllers
{
    /// <summary>
    ///  command pattern that just execute a method by order name
    /// </summary>
    interface ICommand
    {
        
        /// <summary>
        /// execute the command and return the result
        /// </summary>
        /// <param name="args">the argument to the command</param>
        /// <param name="client">the client that ask the command</param>
        /// <returns></returns>
        string Execute(string[] args, string client = null);
    }
}
