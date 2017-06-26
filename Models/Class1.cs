using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MazeLib;
namespace Models
{
    public class Class1
    {
         
        public int cols { get; set; }
        public int rows { get; set; }
        public string name { get; set; }
        public int startRow { get; set; }
        public int startCol { get; set; }
        public string mazeString { get; set; }
        public Class1 (Maze m)
        {
            if (m == null)
            {
                cols = 0;
                rows = 0;
                name = "";
                startCol = 0;
                startRow = 0;
                this.mazeString = "";
            }
            else
            {
                cols = m.Cols;
                rows = m.Rows;
                name = m.Name;
                startCol = m.InitialPos.Row;
                startRow = m.InitialPos.Col;
                this.mazeString = m.ToString();
            }
        }
    }
}