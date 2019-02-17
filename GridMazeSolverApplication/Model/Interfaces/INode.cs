namespace GridMazeSolverApplication.Model

{
    public interface INode
    {
        INode PreviousNodeToCurrent { get; set; }
        MazeCellTypeValues TypeValue { get; set; }
        MazeCellWeightValues DistanceWeightValue { get; set; }
        double DistanceToNodeFromStart { get; set; }
        int XPosition { get;  }
        int YPosition { get;  }

        //Public Methods

        //void SetNodeAsPathToCurrent(INode n);
        string ToString();
    }
}
