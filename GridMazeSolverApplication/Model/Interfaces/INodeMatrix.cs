using System.Collections.Generic;
namespace GridMazeSolverApplication.Model.Interfaces
{
    public interface INodeMatrix
    {
        //Properties
        int XDimension { get; set; }
        int YDimension { get; set; }
        int Count { get; }
        List<INode> Grid { get; }
        //Methods
        bool Contains(INode n);
        INode GetNode(int xPosition, int yPosition);
        void InitializeKnownDistancesFromstart(double infinityValue);
        void InitializeNodeConnectionsToNull();
        void SetNewMazeGrid(List<INode> newMaze, int xDimension, int yDimension);
        void SetNewMazeGrid(List<INode> newMaze, int dimensions);
        
    }
}
