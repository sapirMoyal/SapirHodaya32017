using System;
using System.Net.Sockets;
using MazeLib;
using SearchAlgorithmsLib;
//using server.Controller;
namespace Models
{
    public interface IModel
    {
        /// <summary>
        /// open game
        /// </summary>
        /// <param name="name">the name of the client</param>
        /// <param name="rows">num of rows</param>
        /// <param name="cols">num of colummnts</param>
        /// <param name="client">a controller class that save the client</param>
        /// <returns></returns>
        string StartGame(string name, int rows, int cols, string client);
        /// <summary>
        /// the list of the open game with only one player
        /// </summary>
        /// <returns>the list of the open game with only one player</returns>
        String list();
        /// <summary>
        /// join the client to the wanted game
        /// </summary>
        /// <param name="name">the name of the game</param>
        /// <param name="client">a controller class that save the client</param>
        /// <returns></returns>
        Game JoinGame(string name, string client);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="move">the direction</param>
        /// <param name="client">a controller class that save the client</param>
        /// <returns></returns>
        string Play(string move, string client);
        /// <summary>
        /// close the game
        /// </summary>
        /// <param name="name">the name of the game</param>
        /// <param name="client">a controller class that save the client</param>
        /// <returns></returns>
        string Close(string name, string client);

    }
}