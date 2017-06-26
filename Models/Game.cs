using System.Text;
using MazeLib;
using MazeGeneratorLib;
using System.Net.Sockets;

namespace Models
{
    public class Game
    {
        public Maze myMaze { get; set; }
        public int numOfClient { get; set; }
        string client1;
        string client2;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name">the name of the game</param>
        /// <param name="row">num of rows</param>
        /// <param name="col">num of columns</param>
        public Game(string name, int row, int col)
        {
            DFSMazeGenerator dfs = new DFSMazeGenerator();
            myMaze = dfs.Generate(row, col);
            myMaze.Name = name;
        }
        
        /// <summary>
        /// add client to the game
        /// </summary>
        /// <param name="c"></param>
        public void AddClient(string c)
        {
            //the first client
            if (numOfClient == 0)
            {
                client1 = c;
                numOfClient++;
            }
            else if (numOfClient == 1)
            {
                //the second client
                client2 = c;
                numOfClient++;
            }
           
        }
        /// <summary>
        /// getter
        /// </summary>
        /// <returns>the name of the game</returns>
        public string GetName()
        {
            return this.myMaze.Name;
        }
        /// <summary>
        /// convert to JSON string
        /// </summary>
        /// <returns>JSON string</returns>
        public string ToJSON()
        {
            return myMaze.ToJSON();
        }
        
        public string GetSecondPlayer(string client)
        {
            if (client1.Equals(client))
            {
               return client2;
            }
            return client1;
        }
        
        public string Play(string move, string client)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\n");
            sb.Append("\"Name\": " + "\"" + this.myMaze.Name + "\",\n");
            sb.Append("\"Direction\": " + move + "\n");
            sb.Append("}");
            return sb.ToString();
        }
    }
}