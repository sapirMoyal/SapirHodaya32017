using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
namespace SearchAlgorithmsLib
{
    public interface ISearcher<T, S>
    {
        // the search method
        int evaluatedNodes { get; set; }
        SolutionDetails<S> search(ISearchable<T> searchable);
    }

}
