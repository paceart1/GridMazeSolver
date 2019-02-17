namespace GridMazeSolverApplication.Model.Interfaces
{
    public interface IMaze
    {
        //public Properties
        INodeMatrix MazeGrid { get; }
        IMazeSolution MazeSolution { get; }
        INode Start { get; set; }
        INode End { get; set; }

        //public Methods
        string ToString();
    }
}
