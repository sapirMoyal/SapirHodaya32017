namespace SearchAlgorithmsLib
{
    public class SolutionDetails<T>
    {
        public int NodesEvaluated { get; set; }
        public Solution<T> solv { get; }
        public SolutionDetails(Solution<T> s, int numberOfNode)
        {
            this.solv = s;
            this.NodesEvaluated = numberOfNode;
        }
        public void addNode(T node)
        {
            this.solv.addNode(node);
        }
    }
}