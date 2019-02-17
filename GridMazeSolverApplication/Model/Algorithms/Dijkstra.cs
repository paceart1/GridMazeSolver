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
            //update to stop when end is processed
            if (maze == null) { throw new ArgumentNullException("maze cannot be null."); }
            if (maze.MazeGrid.Count < 2) { throw new Exception("Maze must have at least 2 cells"); }

            maze.MazeGrid.InitializeNodeConnectionsToNull();
            Solution = new List<INode>();
            Frontier = new List<INode>();
            UnProcessedNodes = new List<INode>();
            CurrentNeighbors = new List<INode>();
            

            double startingDistanceVal = 0;
            double UnknownDistanceVal = double.PositiveInfinity;

            maze.MazeGrid.InitializeKnownDistancesFromstart(UnknownDistanceVal);
            maze.Start.DistanceToNodeFromStart = startingDistanceVal; ;

            //Adds nodes to unproceddedList
            foreach (INode n in maze.MazeGrid.Grid) { UnProcessedNodes.Add(n); }

            Frontier.Add(maze.Start);
            INode currentNode = null;
            
            bool finished = false;

            //Loop calculates solution
            while (!finished)
            {
                if (Frontier.Count > 0)
                {
                    currentNode = Frontier[0];
                    //Fire function CurrentNodeUpdatedForDisplay create listner
                    UnProcessedNodes.Remove(currentNode);
                    CurrentNeighbors = GetAdjacentNeighborNodes(currentNode, maze);
                        foreach (INode neighbor in CurrentNeighbors)
                        {
                            UpdateAdjacentDistanceFromStart(currentNode, neighbor);
                            if (!Frontier.Contains(neighbor))
                            {
                                Frontier.Add(neighbor);
                                //Fire function CurrentNeighborUpdatedForDisplay create listner
                            }
                        }
                    
                    Frontier.Remove(currentNode);
                    //*********sort frontier
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
        List<INode> GetAdjacentNeighborNodes(INode n, IMaze maze)
        {
            
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
