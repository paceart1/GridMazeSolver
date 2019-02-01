using System;

namespace GridMazeSolverApplication.Controller
{
    public interface IMainView
    {
        event EventHandler OnGenerateMazeSelected;
        event EventHandler OnShowMazeSolutionSelected;
        event System.Windows.Forms.PaintEventHandler OnPaintGridControl;

        int MazeDimensionsSelected { get; set; }
        int CurrentAlgorithmTypeSelected { get; set; }
        int CurrentMazeTypeSelected { get; set; }

        void AddAlgorithmToList(string a);
        void UpdateCellType(int x, int y, int t);
        void DrawGrid();
    }
}
