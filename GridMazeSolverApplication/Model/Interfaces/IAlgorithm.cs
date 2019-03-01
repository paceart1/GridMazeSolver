using GridMazeSolverApplication.Model.Interfaces;
using System;
using System.Collections.Generic;

namespace GridMazeSolverApplication.Model
{
    public interface IAlgorithm
    {
        string Name { get; }
        List<INode> GetMazeSolution(IMaze m);
        INode CurrentNode{get;}
        List<INode> CurrentNeighbors { get; }
        event EventHandler CurrentNodeChanged;
        event EventHandler CurrentNeighborsChanged;
    }
}
