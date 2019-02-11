using GridMazeSolverApplication.Model.Interfaces;
using System;
using System.Collections.Generic;
namespace GridMazeSolverApplication.Model
{
    public class Maze :IMaze
    {
        //Private Fields
        List<INode> mazeGrid;
        List<INode> mazeSolution;
        INode start;
        INode end;
        int xDimension;
        int yDimension;
        //private Methods
        
        private int CalculateNodeIndexPosition(int xGridPosition, int yGridPosition, int xDimensionOfGrid)
        {
            //Flattens a 2d matrix position and returns the flat index position
            return (xGridPosition + (yGridPosition * xDimensionOfGrid));
        }
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
        public List<INode> MazeGrid
        {
            get { return mazeGrid; }
            private set { mazeGrid = value; }
        }
        public List<INode> MazeSolution
        {
            get
            {
                return mazeSolution;
            }
            private set
            {
                MazeSolution = value;
            }
        }
        public INode Start
        {
            get { return start; }
            set
            {
                if (value == null) { throw new NullReferenceException("Start was set to null."); }
                if (!MazeGrid.Contains(value)) { throw new ArgumentOutOfRangeException("Node does not exist in the Maze"); }
                if (value.TypeValue == MazeCellTypeValues.wall) { throw new Exception("Starting Node cannot be set to a cell with type 'Wall'"); }
                if (start != value)
                {
                    start = value;
                }
            }
        }
        public INode End {
            get
            {
                return end;
            }
            set
            {
                if (value == null) { throw new NullReferenceException("End Node cannot be set to null."); }
                if (!MazeGrid.Contains(value)) { throw new ArgumentOutOfRangeException("Node does not exist in the Maze"); }
                if (value.TypeValue == MazeCellTypeValues.wall) { throw new Exception("Ending Node cannot be set to a cell with type 'Wall'"); }
                if (end != value)
                {
                    end = value;
                }
            }
                }
        public int XDimension
        {
            get { return xDimension; }
            private set
            {
                if(value < 0) { throw new Exception("Cannot set X Dimension of Maze to negative value."); }
                xDimension = value;
            }
        }
        public int YDimension
        {
            get { return yDimension; }
            private set
            {
                if(value < 0) { throw new Exception("Cannot set Y Dimension of Maze to negative value."); }
                yDimension = value;
            }
        }

        //public Methods
        public INode GetNode(int xPosition, int yPosition)
        {
            if (!CheckCellInRange(xPosition, yPosition)) { return null; }
            int position = CalculateNodeIndexPosition(xPosition, yPosition, XDimension);
            return mazeGrid[position];
        }
        public void InitializeKnownDistancesFromstart(double infinityValue)
        {
            if (MazeGrid == null) { throw new ArgumentNullException("MazeGrid cannot be null."); }
            foreach (INode n in MazeGrid)
            {
                n.DistanceToNodeFromStart = infinityValue;
            }
        }     
        public void SetNewMazeGrid(List<INode> newMaze, int xDimension, int yDimension)
        {
            MazeGrid = newMaze;
            XDimension = xDimension;
            YDimension = yDimension;
     
        }
        public void SetNewMazeGrid(List<INode> newMaze, int dimensions )
        {
            MazeGrid = newMaze;
            XDimension = dimensions;
            YDimension = dimensions;
     
        }
       
        public override string ToString()
        {
            return base.ToString();
        }
        public Maze()
        {
          
            
        }
    }
}
