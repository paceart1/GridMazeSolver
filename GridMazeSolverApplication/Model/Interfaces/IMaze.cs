using System.Collections.Generic;
namespace GridMazeSolverApplication.Model.Interfaces
{
    public interface IMaze
    {
        //public Properties
        List<INode> MazeGrid { get; }
        List<INode> MazeSolution { get; }
        INode Start { get; set; }
        INode End { get; set; }
        int XDimension { get; }
        int YDimension { get; }

        //public Methods
        INode GetNode(int xPosition, int yPosition);
        void InitializeKnownDistancesFromstart(double infinityValue);
        void SetNewMazeGrid(List<INode> newMaze, int xDimension, int yDimension); 
        void SetNewMazeGrid(List<INode> newMaze, int dimensions);
        string ToString();
    }
}
