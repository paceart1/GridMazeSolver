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
        //IMaze Maze;

        List<INode> CalculateMazeSolution(IMaze maze)
        {
            //Validate passed maze
            if (maze == null) { throw new ArgumentNullException("maze cannot be null."); }
            if (maze.MazeGrid.Count < 2) { throw new Exception("Maze must have at least 2 cells"); }

            //Create and initializes variables
            double startingDistanceVal = 0;
            double UnknownDistanceVal = double.PositiveInfinity;
            INode currentNode = null;
            bool finished = false;

            //Initialize Objects
            Solution = new List<INode>();
            Frontier = new List<INode>();
            UnProcessedNodes = new List<INode>();
            CurrentNeighbors = new List<INode>();
            
            //Initialize Grid to default values
            maze.MazeGrid.InitializeNodeConnectionsToNull();
            maze.MazeGrid.InitializeKnownDistancesFromstart(UnknownDistanceVal);
            maze.Start.DistanceToNodeFromStart = startingDistanceVal; ;

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
                    currentNode = Frontier[0];
                           //ToAdd: Fire function CurrentNodeUpdatedForDisplay create listner
                    UnProcessedNodes.Remove(currentNode);
                    CurrentNeighbors = GetAdjacentNeighborNodes(currentNode, maze);
                    //Loop calculates and sets the new shortest distance to each of the current Node's neighbors
                    foreach (INode neighbor in CurrentNeighbors)
                    {
                        UpdateAdjacentDistanceFromStart(currentNode, neighbor);
                        if (!Frontier.Contains(neighbor))
                        {
                            Frontier.Add(neighbor);
                                      //To Add: Fire function CurrentNeighborUpdatedForDisplay create listner
                        }
                    }
                    //Remove curent Node from Frontier.  This node is Complete.
                    Frontier.Remove(currentNode);
                    //Sort frontier so that the Node with the shortes current path will be next to be checked
                    Frontier.Sort(delegate (INode x, INode y)
                    {
                        return x.DistanceToNodeFromStart.CompareTo(y.DistanceToNodeFromStart);
                    });
                }
                else
                {
                    finished = true;
                }
            }

            if (maze.End.PreviousNodeToCurrent == null) { return null; }
            Solution = GetFullPathToNode(maze.End);
            return Solution;
        }

        //used for calculating solution
        List<INode> GetFullPathToNode(INode n)
        {
            if (n == null) { throw new ArgumentNullException("Passed node cannot be null."); }
            List<INode> path = new List<INode>();
            INode currentNode = n;
            do
            {
                path.Add(currentNode);
                currentNode = currentNode.PreviousNodeToCurrent;
            }
            while (currentNode != null);
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
                INode currentNode = maze.MazeGrid.GetNode(adjacentIndexes[ii, 0], adjacentIndexes[ii, 1]);
                if (!UnProcessedNodes.Contains(currentNode)){continue; } 
                if (currentNode.TypeValue == MazeCellTypeValues.wall) { continue; }
                neighbors.Add(currentNode);
            }
            return neighbors;
        }

        //Calculates the distance from the start to the passed neighbor Node through the current node.
        //Updates the value if the calculated distance is shorter than the current value.
        void UpdateAdjacentDistanceFromStart(INode currentNode, INode neighborNode)
        {
            double currentDistanceVal = neighborNode.DistanceToNodeFromStart;
            double newDistanceVal = currentNode.DistanceToNodeFromStart + (int)neighborNode.DistanceWeightValue;
            if (currentDistanceVal > newDistanceVal)
            {
                neighborNode.DistanceToNodeFromStart = newDistanceVal;
                neighborNode.PreviousNodeToCurrent = currentNode;
            }
        }
        
        //Public
        public string Name { get; private set; }
        public List<INode> GetMazeSolution(IMaze passedMaze)
        {
            List<INode> solution = CalculateMazeSolution(passedMaze);
            return solution;
        }
        public Dijkstra()
        {
            Name = "Dijkstra";    
        }

    }
}
