using System;

namespace GridMazeSolverApplication.Controller
{
    public interface IMainView
    {
        event EventHandler OnGenerateMazeSelected;
        event EventHandler OnShowMazeSolutionSelected;
        event System.Windows.Forms.PaintEventHandler OnPaintGridControl;

        //Properties
        int MazeDimensionsSelected { get; set; }
        int CurrentAlgorithmTypeSelected { get; set; }
        int CurrentMazeTypeSelected { get; set; }

        //Methods
        void AddAlgorithmToList(string algorithm);
        void AddMazeTypeToList(string type);
        void UpdateCellType(int x, int y, int t);
        void UpdateSolutionPath(int x, int y);
        void UpdateStart(int x, int y);
        void UpdateEnd(int x, int y);
        void DrawGrid();
        void DisplayErrorDetails(Exception ex);
    }
}
