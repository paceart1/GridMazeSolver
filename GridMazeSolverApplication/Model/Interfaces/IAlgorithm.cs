using GridMazeSolverApplication.Model.Interfaces;
using System.Collections.Generic;

namespace GridMazeSolverApplication.Model
{
    public interface IAlgorithm
    {
        string Name { get; }
        List<INode> GetMazeSolution(IMaze m);
    }
}
