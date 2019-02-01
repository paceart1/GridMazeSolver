using System;
using System.Collections.Generic;
namespace GridMazeSolverApplication.Model
{
    public static class MazeBuilder
    {
       
        public static List<Node> GenerateBlankMaze(int dimensions)
        {
            List<Node> maze = new List<Node>();
            
            for (int ii = 0; ii < dimensions; ii++)
            {
                for (int jj = 0; jj < dimensions; jj++)
                {
                    Node n = new Node(jj, ii);
                    n.SetMazeTypeValue((int)MazeCellTypeValues.open);
                    n.DistanceWeightValue = (double)MazeWeightValues.open;
                    maze.Add(n);
                    
                }
            }
            return maze;
        }
        public static List<Node> GenerateScatterMaze(int dimensions)
        {
            //tempcode
           
            Random gen = new Random();
            int randVal;
            List<Node> maze = new List<Node>();
            for (int ii = 0; ii < dimensions; ii++)
            {
                for (int jj = 0; jj < dimensions; jj++)
                {
                    randVal = gen.Next(1, 11);
                    Node n = new Node(jj, ii);
                    if (randVal >= 9)
                    {
                        n.SetMazeTypeValue((int)MazeCellTypeValues.wall);
                        n.DistanceWeightValue = (int)MazeWeightValues.wall;
                    }
                    else
                    {
                        n.SetMazeTypeValue((int)MazeCellTypeValues.open); //using method then property. confusing.
                        n.DistanceWeightValue = (int)MazeWeightValues.open;
                    }
                    maze.Add(n);
                }
              
            }
            

            return maze;
        }
        public static List<Node> GenerateTraditionalMaze() { throw new NotImplementedException(); }
    }
}
