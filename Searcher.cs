using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
namespace SearchAlgorithmsLib
{
    public abstract class Searcher<T, S> : ISearcher<T, S>
    {
        protected MyQueue<State<T>> openList;
        //number of node that evaluated
        public int evaluatedNodes { get; set; }
        //search solution
        public abstract SolutionDetails<S> search(ISearchable<T> searchable);
        //reverse solution (that present from start point the path to goal point) and
        //convert to solution
        public void ConvertToDirection(State<Position> n, Solution<Direction> s)
        {

            State<Position> pre;
            Stack<State<Position>> stack = new Stack<State<Position>>();
            while (n != null)
            {
                stack.Push(n);
                n = n.cameFrom;
            }
            n = stack.Pop();
            while (stack.Count != 0)
            {
                pre = n;
                n = stack.Pop();
                int dif = pre.state.Row - n.state.Row;
                if (dif == -1)
                {
                    s.addNode(Direction.Down);
                }
                else if (dif == 1)
                {
                    s.addNode(Direction.Up);
                }
                else
                {
                    dif = pre.state.Col - n.state.Col;
                    if (dif == -1)
                    {
                        s.addNode(Direction.Right);
                    }
                    else if (dif == 1)
                    {
                        s.addNode(Direction.Left);
                    }
                }
            }
        }
    }
}