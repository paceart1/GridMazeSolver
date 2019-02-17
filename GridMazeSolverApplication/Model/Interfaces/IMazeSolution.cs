using System.Collections.Generic;
namespace GridMazeSolverApplication.Model.Interfaces
{
    public interface IMazeSolution
    {
        List<INode> Solution { get; set; }
    }
}
