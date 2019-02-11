
namespace GridMazeSolverApplication.Model
{
    public class Node: INode
    {
        //Private Fields
        INode previosNodeToCurrent;
        int typeValue;
        double distanceWeightValue;
        double distanceToNodeFromStart;
        int xPosition;
        int yPosition;
        //Private Functions
        private void InitializeDefaultPropertyValues()
        {
            PreviousNodeToCurrent = null;
        }

        //Public Properties
        public INode PreviousNodeToCurrent
        {
            get { return previosNodeToCurrent; }
            set { previosNodeToCurrent = value; }
        }
        public MazeCellTypeValues TypeValue
        {
            get { return (MazeCellTypeValues)typeValue; }
            set { typeValue = (int)value; }
        }
        public MazeCellWeightValues DistanceWeightValue
        {
            get
            {
                return (MazeCellWeightValues)distanceWeightValue;
            }
            set
            {
                int distanceValue = (int)value;
                if(distanceValue < 0) { throw new System.Exception("Distance weight value cannot be negative"); }
                distanceWeightValue = distanceValue;
            }
        }
        public double DistanceToNodeFromStart
        {
            get { return distanceToNodeFromStart; }
            set { distanceToNodeFromStart = value; }
        }
        public int XPosition
        {
            get { return xPosition; }
            private set { xPosition = value; }
        }
        public int YPosition
        {
            get { return yPosition; }
            private set { yPosition = value; }
        }

        //Public Methods

        public void SetNodeAsPathToCurrent(INode n)
        {
            PreviousNodeToCurrent = n;
        }
        public override string ToString()
        {
            return base.ToString();
        }
        //Constructors
        public Node(int x, int y)
        {
            XPosition = x;
            YPosition = y;
            InitializeDefaultPropertyValues();
        }
        
    }
}
