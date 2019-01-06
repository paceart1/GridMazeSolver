using GridMazeSolverApplication.Controller;
using System;
using System.Windows.Forms;

namespace GridMazeSolverApplication.View
{
    public partial class MainForm : Form, IMainView
    {
        public MainForm()
        {
            InitializeComponent();
            GridUI grid = new GridUI();
            OnPaintGrid += grid.DisplayGrid;
        }
        //Event Handlers
        public event EventHandler OnGenerateMazeButton_Click
        {
            add { GenerateMazeButton.Click += value; }
            remove { GenerateMazeButton.Click -= value; }
        }
        public event EventHandler OnShowSolutionButton_Click
        {
            add { ShowSolutionButton.Click += value; }
            remove { ShowSolutionButton.Click -= value; }
        }
        public event PaintEventHandler OnPaintGrid
        {
            add { MazeContainer.Paint += value; }
            remove { MazeContainer.Paint -= value; }
        }
        //OnGridActive
        public event EventHandler OnMazeContainer_MouseEnter
        {
            add { MazeContainer.MouseEnter += value; }
            remove { MazeContainer.MouseEnter -= value; }
        }
        //OnGridDeactive
        public event EventHandler OnMazeContainer_MouseLeave
        {
            add { MazeContainer.MouseLeave += value; }
            remove { MazeContainer.MouseLeave -= value; }
        }
        //OnCellClick
        //UI Properties

        public void UpdateCell() { }
        public void DrawPath() { }
        public void FillCellColor() { }
    }
}
