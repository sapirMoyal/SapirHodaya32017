using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
namespace SearchAlgorithmsLib
{
    public class DFS : Searcher<Position, Direction>
    {
        private Stack<State<Position>> reverseStack;
        private Stack<State<Position>> stack;
        public DFS()
        {
            reverseStack = new Stack<State<Position>>();
            stack = new Stack<State<Position>>();
        }
        public override SolutionDetails<Direction> search(ISearchable<Position> searchable)
        {

            Solution<Direction> solv = new Solution<Direction>();
            //push to stack the start point in the maze
            State<Position> n = searchable.getInitialState();
            // State<Position> n = new State<Position>(searchable.getInitialState().state);
            stack.Push(n);
            Dictionary<int, State<Position>> grayList = new Dictionary<int, State<Position>>();
            Dictionary<int, State<Position>> BlackList = new Dictionary<int, State<Position>>();
            while (stack.Count > 0)
            {
                //get out the last element in the stack
                State<Position> s = stack.Pop();
                this.evaluatedNodes += 1;

                grayList.Add(s.state.ToString().GetHashCode(), s);
                if (s.Equals(searchable.getGoalState()))
                {
                    reverseStack.Push(s);
                    while (s.cameFrom != null)
                    {

                        reverseStack.Push(s.cameFrom);
                        s = s.cameFrom;
                    }
                    while (reverseStack.Count > 0)
                    {
                        State<Position> val = reverseStack.Pop();
                        State<Position> prev = val.cameFrom;
                        if (prev != null)
                        {
                            int difRow = prev.state.Row - val.state.Row;
                            if (difRow == -1)
                            {
                                solv.addNode(Direction.Down);
                            }
                            else if (difRow == 1)
                            {
                                solv.addNode(Direction.Up);
                            }
                            else
                            {
                                int difCol = prev.state.Col - n.state.Col;
                                if (difCol == -1)
                                {
                                    solv.addNode(Direction.Right);
                                }
                                else
                                {
                                    solv.addNode(Direction.Left);
                                }

                            }

                        }
                    }

                    return new SolutionDetails<Direction>(solv, this.evaluatedNodes);

                }
                List<State<Position>> l = searchable.getAllPossibleStates(s);
                foreach (State<Position> neg in l)
                {
                    if (!grayList.ContainsKey(neg.state.ToString().GetHashCode()) && !BlackList.ContainsKey(neg.state.ToString().GetHashCode()))
                    {
                        neg.cameFrom = s;
                        neg.cost = ++s.cost;
                        stack.Push(neg);
                    }
                }
                BlackList.Add(s.state.ToString().GetHashCode(), s);
            }
            return new SolutionDetails<Direction>(solv, this.evaluatedNodes);
        }
    }
}