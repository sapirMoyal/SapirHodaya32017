using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
namespace SearchAlgorithmsLib
{
    public static class StatePool<T>
    {
        static Dictionary<int, State<T>> dictionary = new Dictionary<int, State<T>>();
        public static State<T> getState(T t, State<T> comeFrom, double cost) {
            State<T> s;
            //save state acoording posion
            if (dictionary.ContainsKey(t.ToString().GetHashCode())) {
                dictionary.TryGetValue(t.ToString().GetHashCode(), out s);
                s.cameFrom = comeFrom;
                s.cost = cost;

            }
            else
            {
                s = new State<T>(t);
                s.cameFrom = comeFrom;
                s.cost = cost;
                dictionary.Add(s.GetHashCode(),s);
            }
            return s;
        }
    }
}
