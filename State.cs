using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
namespace SearchAlgorithmsLib
{
    public class State<T> : ICostable
    {
        //private T state;
        //private double cost;
        //private State<T> cameFrom;

        public T state
        {
            get; set;
        }    // the state represented by a string private
        public double cost
        {
            get; set;
        }   // cost to reach this state (set by a setter)
        public State<T> cameFrom
        {
            get; set;
        }
        // the state we came from to this state (setter)
        public State(T state)
        {
            this.state = state;
        }
        // we override Object's Equals method 
        public override bool Equals(object obj)
        {
            return state.Equals((obj as State<T>).state);
        }
        public override int GetHashCode()
        {
            return state.ToString().GetHashCode();
        }

        public double GetCost()
        {
            return this.cost;
        }
    }
}