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
        public INodeMatrix MazeGrid { get; private set; }
        public IMazeSolution MazeSolution { get; private set; }
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
        public Maze()
        {
            MazeGrid = new NodeMatrix();
            MazeSolution = new MazeSolution(); //pass through constructor
            
        }
    }
}
