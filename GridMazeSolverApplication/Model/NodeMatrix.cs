using GridMazeSolverApplication.Model.Interfaces;
using System;
using System.Collections.Generic;
namespace GridMazeSolverApplication.Model
{
    public class NodeMatrix : INodeMatrix
    {
        //private fields
        private List<INode> grid;
        int xDimension;
        int yDimension;

        //Private methods
        //Calculates the 1D index position based on the passed 2D position and the X dimension of the 2D matrix
        private int CalculateNodeIndexPosition(int xGridPosition, int yGridPosition, int xDimensionOfGrid)
        {
            //Flattens a 2d matrix position and returns the flat index position
            return (xGridPosition + (yGridPosition * xDimensionOfGrid));
        }
        //Checks if the passed x, y position is within the defined dimensions of the  Node matrix
        private bool CheckCellInRange(int xGridPosition, int yGridPosition)
        {
            if (xGridPosition < 0 || xGridPosition >= XDimension)
            {
                return false;
            }
            if (yGridPosition < 0 || yGridPosition >= YDimension)
            {
                return false;
            }
            return true;
        }
        
        //public Properties
        public List<INode> Grid
        {
            get
            {
                return grid;
            }
            private set
            {
                grid = value;
            }
        }
        public int XDimension
        {
            get { return xDimension; }
            set
            {
                if (value < 0) { throw new Exception("Cannot set X Dimension of Maze to negative value."); }
                xDimension = value;
            }
        }
        public int YDimension
        {
            get { return yDimension; }
            set
            {
                if (value < 0) { throw new Exception("Cannot set Y Dimension of Maze to negative value."); }
                yDimension = value;
            }
        }
        public int Count
        {
            get { return Grid.Count; }
        }

        //public methods
        public INode GetNode(int xPosition, int yPosition)
        {
            if (!CheckCellInRange(xPosition, yPosition)) { return null; }
            int position = CalculateNodeIndexPosition(xPosition, yPosition, XDimension);
            return Grid[position];
        }
        //Initializes the known distance values of all Nodes in the Grid to a value that represents 'unknown'
        public void InitializeKnownDistancesFromstart(double infinityValue)
        {
            if (Grid == null) { throw new ArgumentNullException("MazeGrid cannot be initialized with values when null."); }
            foreach (INode n in Grid)
            {
                n.DistanceToNodeFromStart = infinityValue;
            }
        }
        //Initializes all Node connections in the Grid to Null
        public void InitializeNodeConnectionsToNull()
        {
            if (Grid == null) { throw new ArgumentNullException("MazeGrid connections cannot be initialized with values when null."); }
            foreach (INode n in Grid)
            {
                n.PreviousNodeToCurrent = null;
            }
        }
        public void SetNewMazeGrid(List<INode> newMaze, int xDimension, int yDimension)
        {
            if (newMaze == null)
            {
                Grid = null;
                XDimension = 0;
                YDimension = 0;
                return;
            }
            int expectedCellCount = xDimension * yDimension;
            if (newMaze.Count != expectedCellCount) { throw new ArgumentException("Passed maze dimensions does not match passed maze cell count"); }
            Grid = newMaze;
            XDimension = xDimension;
            YDimension = yDimension;

        }
        public void SetNewMazeGrid(List<INode> newMaze, int dimensions)
        {
            if (newMaze == null)
            {
                Grid = null;
                XDimension = 0;
                YDimension = 0;
                
                return;
            }
            int expectedCellCount = dimensions * dimensions;
            if (newMaze.Count != expectedCellCount) { throw new ArgumentException("Passed maze dimensions does not match passed maze cell count"); }
            Grid = newMaze;
            XDimension = dimensions;
            YDimension = dimensions;

        }
        public List<INode> GetGrid() { return grid; }
        public bool Contains(INode node)
        {
            return Grid.Contains(node);
        }
        //Constructor
        public NodeMatrix()
        {

        }
    }
}
