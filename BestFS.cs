using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
namespace SearchAlgorithmsLib
{
    public class BestFS : Searcher<Position, Direction>
    {
        /// <summary>
        /// constructor of best first 
        /// search   
        /// </summary>
        public BestFS()
        {
            openList = new MyPriorityQueue<State<Position>>();
            evaluatedNodes = 0;
        }
        // a property of openList
        public int OpenListSize()
        {
            return openList.Count();
        }
        /// <summary>
        /// search the shortest way to end of the maze
        /// </summary>
        /// <param name="searchable">searchable maze we can check for wanted way</param>
        /// <returns>shorted way fron start to end of maze</returns>
        public override SolutionDetails<Direction> search(ISearchable<Position> searchable)
        {
            Solution<Direction> s = new Solution<Direction>();

            State<Position> n = new State<Position>(searchable.getInitialState().state);
            n.cost = 0;
            n.cameFrom = null;
            this.openList.Add(n);
            HashSet<State<Position>> closed = new HashSet<State<Position>>();
            while (OpenListSize() > 0)
            {
                n = this.openList.Pop();
                this.evaluatedNodes += 1;
                closed.Add(n);
                if (n.state.Equals(searchable.getGoalState().state))
                {
                    ConvertToDirection(n, s);
                    break;
                }
                List<State<Position>> l = searchable.getAllPossibleStates(n);
                foreach (var x in l)
                {
                    
                    if ((!(closed.Contains(x)))
                       && !(openList.Contains(x)))
                    {
                        
                        x.cost = n.cost + 1;
                        x.cameFrom = n;
                        openList.Add(x);
                    }
                    else if ((!(closed.Contains(x))) && (x.cost > n.cost + 1))
                    {//
                       
                        x.cost = n.cost + 1;
                        x.cameFrom = n;
                        openList.remove(x);
                        openList.Add(x);
                    }
                }
            }
            SolutionDetails<Direction> solv = new SolutionDetails<Direction>(s, this.evaluatedNodes);
            return solv;
        }
    }
}