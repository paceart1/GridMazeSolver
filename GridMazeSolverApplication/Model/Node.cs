using System;
using System.Collections.Generic;
namespace GridMazeSolverApplication.Model
{
    public class Node
    {
        private void InitializeDefaultPropertyValues()
        {
            PreviousNodeToCurrent = null;
        }
        public List<Node> ConnectedNodes { get; }
        public Node PreviousNodeToCurrent { get; private set; }
       
        public int TypeValue { get; private set; }
        public bool OpenNode { get; set; }
        public double DistanceWeightValue { get; set; }
        public double DistanceToNodeFromStart { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public void SetMazeTypeValue(int typeVal)
        {
            //Validate
            TypeValue = typeVal;
        }
        public void AddConnectedNode(Node n)
        {
            if (n == null) { throw new ArgumentNullException("Passed Node cannot be null."); }
            if (n == this) { throw new ArgumentException("Circular Reference. Cannot connect to self."); } 
            ConnectedNodes.Add(n);
        }
        public void SetNodeAsPathToCurrent(Node n)
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
            ConnectedNodes = new List<Node>();
            X = x;
            Y = y;
            InitializeDefaultPropertyValues();
        }
        
    }
}
