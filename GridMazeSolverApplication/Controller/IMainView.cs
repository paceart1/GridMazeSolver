using System;

namespace GridMazeSolverApplication.Controller
{
    public interface IMainView
    {
        event EventHandler OnGenerateMazeSelected;
        event EventHandler OnShowMazeSolutionSelected;
        event EventHandler OnCellSelected;
        event EventHandler OnShowAlgorithmGraphicsCheckedChanged;
        event System.Windows.Forms.PaintEventHandler OnPaintGridControl;

        //Properties
        bool ShowAlgorithmGraphics { get; set; }
        int MazeDimensionsSelected { get; set; }
        int CurrentAlgorithmTypeSelected { get; set; }
        int CurrentMazeTypeSelected { get; set; }
        //Methods
        
        void AddAlgorithmToList(string algorithm);
        void AddMazeTypeToList(string type);
        void UpdateAllCellsType(int type);
        void UpdateCellType(int x, int y, int t);
        void UpdateSolutionPath(int x, int y);
        void ShowAlgorithmCurrentCellAnalyzed(int x, int y);
        void ShowAlgorithmCurrentNeighborAnalyzed(int x, int y);
        void UpdateStart(int x, int y);
        void UpdateEnd(int x, int y);
        void DrawGridLines();
        int GetGridPositionX();
        int GetGridPositionY();
        void DisplayErrorDetailsDebugging(Exception ex);
        void DisplayMessageToUser(string s); //temp
    }
}
