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
        IMaze Maze;

        List<INode> CalculateMazeSolution(IMaze maze)
        {
            if (maze == null) { throw new ArgumentNullException("maze cannot be null."); }
            if (maze.Start == null) { throw new ArgumentNullException("Start Node cannot be null."); }
            if (maze.End == null) { throw new ArgumentNullException("End Node cannot be null."); }
            if (maze.End == maze.Start){ throw new Exception("Maze start node cannot be the same as it's end node."); }
            if (maze.MazeGrid.Count < 2) { throw new Exception("Maze must have at least 2 cells"); }

            Solution = new List<INode>();
            Frontier = new List<INode>();
            UnProcessedNodes = new List<INode>();
            CurrentNeighbors = new List<INode>();
            Maze = maze;

            double startingDistanceVal = 0;
            double UnknownDistanceVal = double.PositiveInfinity;

            Maze.InitializeKnownDistancesFromstart(UnknownDistanceVal);
            Maze.Start.DistanceToNodeFromStart = startingDistanceVal; ;

            //Add nodes to unproceddedList
            foreach (INode n in Maze.MazeGrid) { UnProcessedNodes.Add(n); }

            Frontier.Add(Maze.Start);
            INode currentNode = null;
            
            bool finished = false;

            while (!finished)
            {
                if (Frontier.Count > 0)
                {
                    currentNode = Frontier[0];
                    UnProcessedNodes.Remove(currentNode);
                    CurrentNeighbors = GetNeighborNodes(currentNode, Maze);
                        foreach (INode neighbor in CurrentNeighbors)
                        {
                            UpdateAdjacentDistanceFromStart(currentNode, neighbor);
                            if (!Frontier.Contains(neighbor))
                            {
                                Frontier.Add(neighbor);
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
            //Solution = GetFullPathToNode(currentNode);
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
        List<INode> GetNeighborNodes(INode n, IMaze maze)
        {
            
            int[,] adjacentIndexes = new int[,] { { n.XPosition, n.YPosition-1 }, { n.XPosition+1, n.YPosition }, { n.XPosition, n.YPosition+1 }, { n.XPosition-1, n.YPosition } };
            List<INode> neighbors = new List<INode>();
            for (int ii = 0; ii < adjacentIndexes.GetLength(0); ii++)
            {
                INode currentNode = maze.GetNode(adjacentIndexes[ii, 0], adjacentIndexes[ii, 1]);
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
                neighborNode.SetNodeAsPathToCurrent(currentNode);
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
