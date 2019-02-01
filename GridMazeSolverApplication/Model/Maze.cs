using System;
using System.Collections.Generic;
namespace GridMazeSolverApplication.Model
{
    public class Maze
    {
        //RandomizeStart()
        //RandomizeStop
        private int GetNodeIndex(int xGridPosition, int yGridPosition, int xDimensionOfGrid)
        {
            return (xGridPosition + (yGridPosition * xDimensionOfGrid));
        }
        
        //public Properties
        
        public List<Node> MazeGrid { get; private set; } //not safe
        public List<Node> MazeSolution { get; private set; } //not safe
        public Node Start { get; private set; }
        public Node End { get; private set; }
        public int XDimension { get; private set; }
        public int YDimension { get; private set; }

        //public Methods
        public bool CheckCellInRange(int xGridPosition, int yGridPosition)
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
        public void InitializeKnownDistancesFromstart(double infinityValue)
        {
            if (MazeGrid == null) { throw new ArgumentNullException("MazeGrid cannot be null."); }
            //Handle Error: what if MazeGrid length is 0?
            foreach (Node n in MazeGrid)
            {
                n.DistanceToNodeFromStart = infinityValue;
            }
        }
        public int GetNodeIndexFrom2DGrid(int xGridPosition, int yGridPosition)
        {
            if (!CheckCellInRange(xGridPosition, yGridPosition))
            {
                throw new ArgumentOutOfRangeException();
            }
            return GetNodeIndex(xGridPosition, yGridPosition, XDimension);
        }
        public void SetGridCellStart(int x, int y)
        {
            //need to add : Reset old start to open
            //need to add : cannot be same as end
            if (x < 0 || y < 0) { throw new ArgumentOutOfRangeException("Argument value cannot be negative"); }
            int pos = GetNodeIndex(x, y, XDimension);
            if(!MazeGrid.Contains(MazeGrid[pos])){ throw new IndexOutOfRangeException("Node position does not exist"); }
            if (Start != null) { Start.SetMazeTypeValue((int)MazeCellTypeValues.open); }
            Start = MazeGrid[pos];
            Start.SetMazeTypeValue((int)MazeCellTypeValues.start);
        }
        public void SetGridCellStart(Node newStartNode)
        {
            if (!MazeGrid.Contains(newStartNode)) { throw new ArgumentOutOfRangeException("Node does not exist in the Maze"); }
            if (Start != null) { Start.SetMazeTypeValue((int)MazeCellTypeValues.open); }
            Start = newStartNode;
            Start.SetMazeTypeValue((int)MazeCellTypeValues.start);
        }
        public void SetGridCellEnd(int x, int y)
        {
            if (x < 0 || y < 0) { throw new ArgumentOutOfRangeException("Argument value cannot be negative"); }
            int pos = GetNodeIndex(x, y, XDimension);
            if (!MazeGrid.Contains(MazeGrid[pos])) { throw new IndexOutOfRangeException("Node position does not exist"); }
            if (End != null) { End.SetMazeTypeValue((int)MazeCellTypeValues.open); }
            End = MazeGrid[pos];
            End.SetMazeTypeValue((int)MazeCellTypeValues.end);
        }
        public void SetGridCellEnd(Node newEndNode)
        {
            if (!MazeGrid.Contains(newEndNode)) { throw new ArgumentOutOfRangeException("Node does not exist in the Maze"); }
            if (End != null) { End.SetMazeTypeValue((int)MazeCellTypeValues.open); }
            End = newEndNode;
            End.SetMazeTypeValue((int)MazeCellTypeValues.end);
        }
        public void SetCellTypeValue(int x, int y, int value)
        {
            int pos = GetNodeIndex(x, y, XDimension);
            MazeGrid[pos].SetMazeTypeValue(value);
        }
        public int GetCellTypeValue(int x, int y)
        {
            int pos = GetNodeIndex(x, y, XDimension);
            return MazeGrid[pos].TypeValue;
        }
        public void SetNewMazeGrid(List<Node> newMaze, int xDimension, int yDimension)
        {
            MazeGrid = newMaze;
            XDimension = xDimension;
            YDimension = yDimension;
     
        }
        public void SetNewMazeGrid(List<Node> newMaze, int dimensions )
        {
            MazeGrid = newMaze;
            XDimension = dimensions;
            YDimension = dimensions;
     
        }
        //public void DeleteMazeGrid() {MazeGrid = null; }
        /*public void SetMazeSolution(List<Node> mazeSolution)
        {
            MazeSolution = mazeSolution;
        }
        */
        //public void DeleteMazeSolution(){}
        public override string ToString()
        {
            return base.ToString();
        }
        public Maze()
        {
            
            
        }
    }
}
