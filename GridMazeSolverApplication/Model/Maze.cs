using GridMazeSolverApplication.Model.Interfaces;
using System;
namespace GridMazeSolverApplication.Model
{
    public class Maze :IMaze
    {
        //Private Fields
        INodeMatrix mazeGrid;
        IMazeSolution mazeSolution;
        INode start;
        INode end;

        //private Methods

        //public Properties
        public INodeMatrix MazeGrid
        {
            get { return mazeGrid; }
            private set { mazeGrid = value; }
        }
        public IMazeSolution MazeSolution
        {
            get { return mazeSolution; }
            private set { mazeSolution = value; }
        }
        public INode Start
        {
            get { return start; }
            set
            {
                if (value == null) { throw new NullReferenceException("Start was set to null."); }
                if (!MazeGrid.Contains(value)) { throw new ArgumentOutOfRangeException("Node does not exist in the Maze"); }
                if (value.TypeValue == MazeCellTypeValues.wall) { throw new Exception("Starting Node cannot be set to a cell with type 'Wall'"); }
                if (value == End) { throw new Exception("Start cannot be set to same Node as End."); }
                if (start != value)
                {
                    start = value;
                }
            }
        }
        public INode End
        {
            get
            {
                return end;
            }
            set
            {
                if (value == null) { throw new NullReferenceException("End Node cannot be set to null."); }
                if (!MazeGrid.Contains(value)) { throw new ArgumentOutOfRangeException("Node does not exist in the Maze"); }
                if (value.TypeValue == MazeCellTypeValues.wall) { throw new Exception("Ending Node cannot be set to a cell with type 'Wall'"); }
                if (value == Start) { throw new Exception("End cannot be set to same Node as Start."); }
                if (end != value)
                {
                    end = value;
                }
            }
        }

        //public Methods      
        public override string ToString()
        {
            return base.ToString();
        }

        //Constructor
        public Maze(INodeMatrix grid, IMazeSolution solution)
        {
            if(grid == null) { throw new ArgumentNullException("Object implimenting INodeMatrix cannot be null."); }
            if(solution == null) { throw new ArgumentNullException("Object implimenting IMazeSolution cannot be null."); }
            MazeGrid = grid;
            MazeSolution = solution;
        }
    }
}
