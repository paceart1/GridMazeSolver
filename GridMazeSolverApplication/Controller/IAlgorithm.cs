using GridMazeSolverApplication.Model;
using System.Collections.Generic;

namespace GridMazeSolverApplication.Controller
{
    interface IAlgorithm
    {
        string Name { get; }
        List<Node> GetMazeSolution(Maze m);
    }
}
