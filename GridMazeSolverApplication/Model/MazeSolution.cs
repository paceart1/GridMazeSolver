using GridMazeSolverApplication.Model.Interfaces;
using System.Collections.Generic;
namespace GridMazeSolverApplication.Model
{
    public class MazeSolution : IMazeSolution
    {
        public List<INode> Solution { get; set; }

        public MazeSolution()
        {
            Solution = null;
        }
    }
}
