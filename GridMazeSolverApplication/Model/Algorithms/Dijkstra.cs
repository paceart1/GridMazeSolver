using GridMazeSolverApplication.Controller;
using System;
using System.Collections.Generic;

namespace GridMazeSolverApplication.Model.Algorithms
{
    public class Dijkstra : IAlgorithm
    {
        List<Node> Solution;
        List<Node> Frontier;
        List<Node> UnProcessedNodes;
        List<Node> CurrentNeighbors;
        Maze Maze;

        List<Node> CalculateMazeSolution(Maze maze)
        {
            if (maze == null) { throw new ArgumentNullException("maze cannot be null."); }
            if (maze.Start == null) { throw new ArgumentNullException("Start Node cannot be null."); }
            if (maze.End == null) { throw new ArgumentNullException("End Node cannot be null."); }
            if (maze.End == maze.Start){ throw new Exception("Maze start node cannot be the same as it's end node."); }
            if (maze.MazeGrid.Count < 2) { throw new Exception("Maze must have at least 2 cells"); }

            Solution = new List<Node>();
            Frontier = new List<Node>();
            UnProcessedNodes = new List<Node>();
            CurrentNeighbors = new List<Node>();
            Maze = maze;

            double startingDistanceVal = 0;
            double UnknownDistanceVal = double.PositiveInfinity;

            Maze.InitializeKnownDistancesFromstart(UnknownDistanceVal);
            Maze.Start.DistanceToNodeFromStart = startingDistanceVal; ;

            //Add nodes to unproceddedList
            foreach (Node n in Maze.MazeGrid) { UnProcessedNodes.Add(n); }

            Frontier.Add(Maze.Start);
            Node currentNode = null;
            
            bool finished = false;

            while (!finished)
            {
                if (Frontier.Count > 0)
                {
                    currentNode = Frontier[0];
                    UnProcessedNodes.Remove(currentNode);
                    CurrentNeighbors = GetNeighborNodes(currentNode, Maze);
                        foreach (Node neighbor in CurrentNeighbors)
                        {
                            UpdateAdjacentDistancesFromStart(currentNode, neighbor);
                            if (!Frontier.Contains(neighbor))
                            {
                                Frontier.Add(neighbor);
                            }
                        }
                    
                    Frontier.Remove(currentNode);
                    //*********sort frontier
                    Frontier.Sort(delegate (Node x, Node y)
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
        List<Node> GetFullPathToNode(Node n)
        {
            if (n == null) { throw new ArgumentNullException("Passed node cannot be null."); }
            List<Node> path = new List<Node>();
            Node currentNode = n;
            do
            {
                path.Add(currentNode);
                currentNode = currentNode.PreviousNodeToCurrent;
            }
            while (currentNode != null);
            return path;
        }
        List<Node> GetNeighborNodes(Node n, Maze maze)
        {
            
            int[,] adjacentIndexes = new int[,] { { n.X, n.Y-1 }, { n.X+1, n.Y }, { n.X, n.Y+1 }, { n.X-1, n.Y } };
            List<Node> neighbors = new List<Node>();
            for (int ii = 0; ii < adjacentIndexes.GetLength(0); ii++)
            {
                if (!maze.CheckCellInRange(adjacentIndexes[ii, 0], adjacentIndexes[ii, 1]))
                {
                    continue;
                }
                int pos = maze.GetNodeIndexFrom2DGrid(adjacentIndexes[ii, 0], adjacentIndexes[ii, 1]);
                if (!UnProcessedNodes.Contains(maze.MazeGrid[pos])){continue; } //<--crash when check (out of range)
                
                if (maze.MazeGrid[pos].TypeValue == (int)MazeCellTypeValues.wall) { continue; }
                neighbors.Add(maze.MazeGrid[pos]);
            }
            return neighbors;
        }
        void UpdateAdjacentDistancesFromStart(Node currentNode, Node neighborNode)
        {
            double currentDistanceVal = neighborNode.DistanceToNodeFromStart;
            double newDistanceVal = currentNode.DistanceToNodeFromStart + neighborNode.DistanceWeightValue;
            if (currentDistanceVal > newDistanceVal)
            {
                neighborNode.DistanceToNodeFromStart = newDistanceVal;
                neighborNode.SetNodeAsPathToCurrent(currentNode);
            }
        }
        
        /*
        void LinkNodeToNeighbor(Node currentNode, Node neighborNode)
        {
            currentNode.AddConnectedNode(neighborNode);
        }
        void LinkToAdjacentNeighbors(Node currentNode, Maze maze)
        {
            Node current = currentNode;
            int pos;
            pos= maze.GetNodeIndexFrom2DGrid(current.X + 1, current.Y);
            LinkNodeToNeighbor(current, maze.MazeGrid[pos]);
            pos = maze.GetNodeIndexFrom2DGrid(current.X, current.Y + 1);
            LinkNodeToNeighbor(current, maze.MazeGrid[pos]);
            pos = maze.GetNodeIndexFrom2DGrid(current.X-1, current.Y);
            LinkNodeToNeighbor(current, maze.MazeGrid[pos]);
            pos = maze.GetNodeIndexFrom2DGrid(current.X, current.Y - 1);
            LinkNodeToNeighbor(current, maze.MazeGrid[pos]);
        }
        */
       
        //Public
        public string Name { get; private set; }

        public List<Node> GetMazeSolution(Maze passedMaze)
        {
            List<Node> solution = CalculateMazeSolution(passedMaze);
            return solution;
        }
        public Dijkstra()
        {
            Name = "Dijkstra";

            
        }
    }
}
