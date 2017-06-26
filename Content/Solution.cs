using System.Collections.Generic;
using System.Text;
namespace SearchAlgorithmsLib
{
    /// <summary>
    /// save the path of the maze
    /// </summary>
    public class Solution<T>
    {
        public List<T> solve { get; set; }
        /// <summary>
        /// constructor 
        /// </summary>
        public Solution()
        {
            this.solve = new List<T>();
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="list"></param>
        public Solution(List<T> list)
        {
            this.solve = list;
        }
        /// <summary>
        /// get the solition
        /// </summary>
        /// <returns></returns>
        public List<T> getSolve()
        {
            return this.solve;
        }
        /// <summary>
        /// add node to solition 
        /// </summary>
        /// <param name="node"></param>
        public void addNode(T node)
        {
            this.solve.Add(node);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            solve.ForEach(item => sb.Append(item.ToString() + ","));
            return sb.ToString();
        }
    }
}