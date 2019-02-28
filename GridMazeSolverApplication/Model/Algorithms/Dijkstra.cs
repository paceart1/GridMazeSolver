using GridMazeSolverApplication.Model.Interfaces;
using System;
using System.Collections.Generic;

namespace GridMazeSolverApplication.Model.Algorithms
{
    public class Dijkstra : IAlgorithm
    {
        List<INode> Solution;
        List<INode> Frontier;
        List<INode> UnProcessedNodes;
        List<INode> CurrentNeighbors;
        INode currentNode;
        //IMaze Maze;

        //Main Loop that calculates Solution
        List<INode> CalculateMazeSolution(IMaze maze)
        {
            //Validate passed maze
            if (maze == null) { throw new ArgumentNullException("maze cannot be null."); }
            if (maze.MazeGrid.Count < 2) { throw new Exception("Maze must have at least 2 cells"); }

            //Create and initializes variables
            double startingDistanceVal = 0;
            double UnknownDistanceVal = double.PositiveInfinity;
            CurrentNode = null;
            bool finished = false;

            //Initialize Objects
            Solution = new List<INode>();
            Frontier = new List<INode>();
            UnProcessedNodes = new List<INode>();
            CurrentNeighbors = new List<INode>();
            
            //Initialize Grid to default values
            maze.MazeGrid.InitializeNodeConnectionsToNull();
            maze.MazeGrid.InitializeKnownDistancesFromstart(UnknownDistanceVal);
            maze.Start.DistanceToNodeFromStart = startingDistanceVal; 

            //Initializes unprocessedList to reference all nodes in maze
            foreach (INode n in maze.MazeGrid.Grid) { UnProcessedNodes.Add(n); }

            //Initialize Frontier to contain starting position
            Frontier.Add(maze.Start);

            //update to stop when end is processed
            //Loop calculates solution using flood fill.  Distance from start is calculated
            //for Nodes adjacent to current Node in Frontier.  Current node is removed from 
            //frontier, Neighbors are added to frontier, Neighbors are removed from Unchecked set.
            //frontier is sorted and the process repeats until Frontier is empty.
            while (!finished)
            {
                if (Frontier.Count > 0)
                {
                    CurrentNode = Frontier[0];                    
                    UnProcessedNodes.Remove(CurrentNode);
                    CurrentNeighbors = GetAdjacentNeighborNodes(CurrentNode, maze);
                    //Loop calculates and sets the new shortest distance to each of the current Node's neighbors
                    foreach (INode neighbor in CurrentNeighbors)
                    {
                        UpdateAdjacentDistanceFromStart(CurrentNode, neighbor);
                        if (!Frontier.Contains(neighbor))
                        {
                            Frontier.Add(neighbor);
//***To Add: Fire function CurrentNeighborUpdatedForDisplay create listener
                        }
                    }
                    //Remove curent Node from Frontier.  This node is Complete.
                    Frontier.Remove(CurrentNode);
                    //Sort frontier so that the Node with the shortes current path will be next to be checked
                    Frontier.Sort(delegate (INode x, INode y)
                    {
                        return x.DistanceToNodeFromStart.CompareTo(y.DistanceToNodeFromStart);
                    });
                    if (CurrentNode == maze.End) { finished = true; }
                }
                else
                {
                    finished = true;
                }
            }

            if (maze.End.PreviousNodeToCurrent == null) { return null; }
            Solution = GetFullPathToNode(maze.End);
            Solution.Reverse();
            return Solution;
        }

        
        List<INode> GetFullPathToNode(INode n)
        {
            if (n == null) { throw new ArgumentNullException("Passed node cannot be null."); }
            List<INode> path = new List<INode>();
            INode CurrentNode = n;
            do
            {
                path.Add(CurrentNode);
                CurrentNode = CurrentNode.PreviousNodeToCurrent;
            }
            while (CurrentNode != null);
            return path;
        }
        //returns a list of the nodes adjacent(Top, Bottom, Left, Right) to the passed node in a maze
        List<INode> GetAdjacentNeighborNodes(INode n, IMaze maze)
        {
            if (!maze.MazeGrid.Contains(n)) { throw new Exception("Passed Node does not exist as part of the passed Maze."); }
            int[,] adjacentIndexes = new int[,] { { n.XPosition, n.YPosition-1 }, { n.XPosition+1, n.YPosition }, { n.XPosition, n.YPosition+1 }, { n.XPosition-1, n.YPosition } };
            List<INode> neighbors = new List<INode>();
            for (int ii = 0; ii < adjacentIndexes.GetLength(0); ii++)
            {
                INode CurrentNode = maze.MazeGrid.GetNode(adjacentIndexes[ii, 0], adjacentIndexes[ii, 1]);
                if (!UnProcessedNodes.Contains(CurrentNode)){continue; } 
                if (CurrentNode.TypeValue == MazeCellTypeValues.wall) { continue; }
                neighbors.Add(CurrentNode);
            }
            return neighbors;
        }

        //Calculates the distance from the start to the passed neighbor Node through the current node.
        //Updates the value if the calculated distance is shorter than the current value.
        void UpdateAdjacentDistanceFromStart(INode CurrentNode, INode neighborNode)
        {
            double currentDistanceVal = neighborNode.DistanceToNodeFromStart;
            double newDistanceVal = CurrentNode.DistanceToNodeFromStart + (int)neighborNode.DistanceWeightValue;
            if (currentDistanceVal > newDistanceVal)
            {
                neighborNode.DistanceToNodeFromStart = newDistanceVal;
                neighborNode.PreviousNodeToCurrent = CurrentNode;
            }
        }

        //Public Events
        public event EventHandler CurrentNodeChanged;
        
        //Public Properties
        public string Name { get; private set; }
        public INode CurrentNode
        {
            get { return currentNode; }
            private set
            {
                currentNode = value;
                if (value != null)
                {
                    OnCurrentNodeChanged();
                }
                
            }
        }
        //Public Methods
        public void OnCurrentNodeChanged()
        {
            
            EventHandler handler = CurrentNodeChanged;
            handler(this, EventArgs.Empty);
        }
        public List<INode> GetMazeSolution(IMaze passedMaze)
        {
            List<INode> solution = CalculateMazeSolution(passedMaze);
            return solution;
        }
        public List<INode> GetCurrentNeighbors() { return this.CurrentNeighbors; }
        public Dijkstra()
        {
            Name = "Dijkstra";    
        }

    }
}
