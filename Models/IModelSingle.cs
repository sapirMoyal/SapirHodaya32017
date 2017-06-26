using System;
using System.Net.Sockets;
using MazeLib;
using SearchAlgorithmsLib;

//using server.Controller;
namespace Models
{
    public interface IModelSingle
    {
        /// <summary>
        /// creat a maze, and save it
        /// </summary>
        /// <param name="name">the name of the maze</param>
        /// <param name="rows">num of rows</param>
        /// <param name="cols">num of columns</param>
        /// <returns></returns>
        Maze GenerateMaze(string name, int rows, int cols);
        /// <summary>
        /// return the solve of the maze
        /// </summary>
        /// <param name="name">the name of the maze we want his solution</param>
        /// <param name="algo">0 - bestFS, 1- DFS</param>
        /// <returns></returns>
        SolutionDetails<Direction> SolveMaze(string name, int algo);

        }
}