
using System.Collections.Generic;
using System.Text;
using MazeGeneratorLib;
using MazeLib;
using System.Net.Sockets;
using SearchAlgorithmsLib;
using System;
namespace Models
{
    /// <summary>
    /// the model of the project that has the 'data base'
    /// </summary>
    public class SingleModel : IModelSingle
    {
        //the games
        //  public Dictionary<string, Game> games { get; set; }
        //which client participate in which game 
        // public Dictionary<ICClientHandler, string> clientInGames { get; set; }
        //the mazes
        public Dictionary<string, Maze> Mazes { get; set; }
        //the solution to the mazes
        public Dictionary<string, SolutionDetails<Direction>> Sol { get; set; }
        // public Controller.Controller controller { get; set; }
        const int BFS = 0;
        const int DFS1 = 1;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="conr">controller</param>
        public SingleModel()
        {
            Mazes = new Dictionary<string, Maze>();
            //  games = new Dictionary<string, Game>();
            Sol = new Dictionary<string, SolutionDetails<Direction>>();
            // clientInGames = new Dictionary<ICClientHandler, string>();
            // controller = conr;
        }

        /// <summary>
        /// create a maze, save and return it
        /// </summary>
        /// <param name="name">the name of the maze</param>
        /// <param name="rows">num of rows</param>
        /// <param name="cols">num of column</param>
        /// <returns></returns>
        public Maze GenerateMaze(string name, int rows, int cols)
        {
            Maze m;
            if (Mazes.ContainsKey(name))
            {
                //print error - this maze exist
                return null;
            }
            else
            {
                IMazeGenerator mg = new DFSMazeGenerator();
                m = mg.Generate(rows, cols);
                m.Name = name;
                this.Mazes.Add(name, m);
                return m;
            }
        }

        public SolutionDetails<Direction> SolveMaze(string name, int algo)
        {
            SolutionDetails<Direction> sol_det;
            Searcher<Position, Direction> s;
            //this solve exist
            if (Sol.TryGetValue(name, out sol_det))
            {
                return sol_det;
            }
            Maze maze;
            Mazes.TryGetValue(name, out maze);
            if (maze == null)
            {
                return null;
            }
            if (algo == BFS)
            {
                s = new BestFS();
            }
            else
            {
                s = new DFS();
            }
            sol_det = s.search(new SearchableMaze(maze));
            Sol.Add(name, sol_det);
            return sol_det;
        }
    }
}