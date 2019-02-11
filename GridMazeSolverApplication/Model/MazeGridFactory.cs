using GridMazeSolverApplication.Model.EnumDefinedValues;
using System;
using System.Collections.Generic;
namespace GridMazeSolverApplication.Model
{
    public static class MazeGridFactory
    {
        private static List<INode> GenerateBlankMaze(int dimensions)
        {
            List<INode> maze = new List<INode>();

            for (int ii = 0; ii < dimensions; ii++)
            {
                for (int jj = 0; jj < dimensions; jj++)
                {
                    INode n = new Node(jj, ii);
                    n.TypeValue = MazeCellTypeValues.open;
                    n.DistanceWeightValue = MazeCellWeightValues.open;
                    maze.Add(n);

                }
            }
            return maze;
        }
        private static List<INode> GenerateScatterMaze(int dimensions)
        {
            Random gen = new Random();
            int randVal;
            List<INode> maze = new List<INode>();
            for (int ii = 0; ii < dimensions; ii++)
            {
                for (int jj = 0; jj < dimensions; jj++)
                {
                    randVal = gen.Next(1, 11);
                    INode n = new Node(jj, ii);
                    if (randVal >= 9)
                    {
                        n.TypeValue = MazeCellTypeValues.wall;
                        n.DistanceWeightValue = MazeCellWeightValues.wall;
                    }
                    else
                    {
                        n.TypeValue = MazeCellTypeValues.open; //using method then property. confusing.
                        n.DistanceWeightValue = MazeCellWeightValues.open;
                    }
                    maze.Add(n);
                }

            }


            return maze;
        }
        private static List<INode> GenerateTraditionalMaze() { throw new NotImplementedException(); }
        public static List<INode> GenerateMaze(MazeTypes type, int mazeDimension)
        {
            List<INode> mazeGrid = new List<INode>();
            switch (type)
            {
                case MazeTypes.Blank:
                    mazeGrid = MazeGridFactory.GenerateBlankMaze(mazeDimension);
                    break;
                case MazeTypes.Scatter:
                    mazeGrid = MazeGridFactory.GenerateScatterMaze(mazeDimension);
                    break;
                case MazeTypes.Traditional:
                    mazeGrid = null;
                    break;
                default:
                    mazeGrid = null;
                    break;
            }
            return mazeGrid;
        } 
    }
}
