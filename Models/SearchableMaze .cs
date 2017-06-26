using System.Collections.Generic;
using MazeLib;
using SearchAlgorithmsLib;
namespace Models
{
    public class SearchableMaze : ISearchable<Position>
    {
        private Maze myMaze;
        public SearchableMaze(Maze maze)
        {
            this.myMaze = maze;
        }

        /// <summary>
        /// return the state that we can go to them from the given state
        /// </summary>
        /// <param name="s">the current state</param>
        /// <returns></returns>
        public List<State<Position>> getAllPossibleStates(State<Position> s)
        {
            //neghboor up
            List<State<Position>> list = new List<State<Position>>();
            if ((s.state.Row) + 1 < myMaze.Rows)
            {
                Position p = new Position(s.state.Row + 1, s.state.Col);

                if (myMaze[p.Row, p.Col].Equals(CellType.Free))
                    //list.Add(StatePool<Position>.getState(p, s, s.cost + 1));
                    list.Add(new State<Position>(p));
            }
            //neghboor left
            if (s.state.Col - 1 >= 0)
            {
                Position p = new Position(s.state.Row, s.state.Col - 1);
                if (myMaze[p.Row, p.Col].Equals(CellType.Free))
                    //list.Add(StatePool<Position>.getState(p, s, s.cost + 1));
                    list.Add(new State<Position>(p));
            }
            //right neghboor
            if (s.state.Col + 1 < myMaze.Cols)
            {
                Position p = new Position(s.state.Row, s.state.Col + 1);
                if (myMaze[p.Row, p.Col].Equals(CellType.Free))
                    // list.Add(StatePool<Position>.getState(p, s, s.cost + 1));
                    list.Add(new State<Position>(p));

            }
            //down neghbhor
            if (s.state.Row - 1 >= 0)
            {
                Position p = new Position(s.state.Row - 1, s.state.Col);
                if (myMaze[p.Row, p.Col].Equals(CellType.Free))
                    //list.Add(StatePool<Position>.getState(p, s, s.cost + 1));
                    list.Add(new State<Position>(p));
            }
            return list;
        }
        /// <summary>
        /// return the goal state
        /// </summary>
        /// <returns>the goal state</returns>
        public State<Position> getGoalState()
        {
            return new State<Position>(this.myMaze.GoalPos);
        }

        /// <summary>
        /// return the initial state
        /// </summary>
        /// <returns>the initial state</returns>
        public State<Position> getInitialState()
        {
            return new State<Position>(this.myMaze.InitialPos);
        }
    }
}