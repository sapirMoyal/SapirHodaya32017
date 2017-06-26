using System.Collections.Generic;
using System.Text;
using MazeGeneratorLib;
using MazeLib;
using System.Net.Sockets;
using SearchAlgorithmsLib;
using System;
using Controllers;
namespace Models
{
    /// <summary>
    /// the model of the project that has the 'data base'
    /// </summary>
    public class MazeModel : IModel
    {
        //the games
        public Dictionary<string, Game> games { get; set; }
        //which client participate in which game 
        public Dictionary<string, string> clientInGames { get; set; }
        //the mazes
        public Dictionary<string, Maze> Mazes { get; set; }
        //the solution to the mazes
        public Dictionary<string, SolutionDetails<Direction>> Sol { get; set; }
        public MultiHub hub { get; set; }
        const int BFS = 0;
        const int DFS1 = 1;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="conr">controller</param>
        public MazeModel()
        {
            Mazes = new Dictionary<string, Maze>();
            games = new Dictionary<string, Game>();
            Sol = new Dictionary<string, SolutionDetails<Direction>>();
            clientInGames = new Dictionary<string, string>();

        }
        public void AddHub(MultiHub hub1)
        {
            this.hub = hub1;
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


        public string StartGame(string name, int rows, int cols, string client)
        {
            if (games.ContainsKey(name))
            {
                return "there is such game";
            }
            else
            {
                Game g = new Game(name, rows, cols);
                g.AddClient(client);
                clientInGames.Add(client, name);
                this.games.Add(name, g);
                return "wait for the second player";
            }
        }

        public string list()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (Game g in games.Values)
            {
                if (g.numOfClient == 1)
                {
                    sb.Append(g.GetName() + ",");
                }
            }
            sb.Append("]");
            return sb.ToString();
        }

         /// <summary>
         /// join to exist game as the second player
         /// </summary>
         /// <param name="name">the name of the game</param>
         /// <param name="client">the client</param>
         /// <returns></returns>
         public Game JoinGame(string name, string client)
         {
             Game g;
             //we can join only to exist game that have one player
             if (games.TryGetValue(name, out g))
             {
                 if (g.numOfClient == 1)
                 {
                     g.AddClient(client);
                     this.clientInGames.Add(client, name);
                     hub.sendMazeToClient(g.GetSecondPlayer(client), g.myMaze);
                     hub.sendMazeToClient(client, g.myMaze);
                     return g;
                 }
                 else
                 {
                     return null;
                 }
             }
             else
             {
                 return null;
             }
         }


        /// <summary>
        /// play
        /// </summary>
        /// <param name="move">the direction</param>
        /// <param name="client">the client</param>
        /// <returns></returns>
        public string Play(string move, string client)
         {
             string name;
             Game g;
             //this command is only in games that have two participate
             if (clientInGames.TryGetValue(client, out name))
             {
                 if (games.TryGetValue(name, out g))
                 {
                     if (g.numOfClient == 2)
                     {
                         string s = g.Play(move, client);
                         hub.sendMessageToClient(g.GetSecondPlayer(client), s);
                         return "got your move, and sent it to the second client";
                     }
                     else
                     {
                         return "not an active game";
                     }
                 }
             }
             return "the game not found";
         }

        /// <summary>
        /// close a game
        /// </summary>
        /// <param name="name">the name of the game</param>
        /// <param name="client"></param>
        /// <returns></returns>
         public string Close(string name, string client)
          {
              Game g;
              string secondClient = null;
              if (games.TryGetValue(name, out g))
              {
                  if (g.numOfClient == 2)
                  {
                      secondClient = g.GetSecondPlayer(client);
                      hub.sendMessageToClient(secondClient, "close");
                  }
                  else
                  {
                      this.games.Remove(name);
                      this.clientInGames.Remove(client);
                      return "close";
                  }
              }
              //update the DB
              this.games.Remove(name);
              this.clientInGames.Remove(client);
              this.clientInGames.Remove(secondClient);
              return "close";
          }
    }
}
