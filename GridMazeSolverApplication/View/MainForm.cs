using GridMazeSolverApplication.Controller;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GridMazeSolverApplication.View
{
    public partial class MainForm : Form, IMainView
    {
        public MainForm()
        {
            InitializeComponent();
            OnCellSelected += FillCellColor;
            OnMazeDimensionsChanged += UpdateVisualGridDimensions;
        }

        //Event Handlers
        public event EventHandler OnGenerateMazeSelected
        {
            add { GenerateMaze_UIButton.Click += value; }
            remove { GenerateMaze_UIButton.Click -= value; }
        }
        public event EventHandler OnShowMazeSolutionSelected
        {
            add { SolveMaze_UIButton.Click += value; }
            remove { SolveMaze_UIButton.Click -= value; }
        }
        public event EventHandler OnCancelSolveMazeSelected
        {
            add { CancelSolveMaze_UIButton.Click += value; }
            remove { CancelSolveMaze_UIButton.Click -= value; }
        }
        public event EventHandler OnMazeContainerActivated
        {
            add { MazeContainer_UIGroupbox.MouseEnter += value; }
            remove { MazeContainer_UIGroupbox.MouseEnter -= value; }
        }
        public event EventHandler OnMazeContainerDeactivated
        {
            add { MazeContainer_UIGroupbox.MouseLeave += value; }
            remove { MazeContainer_UIGroupbox.MouseLeave -= value; }
        }
        public event PaintEventHandler OnPaintGridControl
        {
            add { Grid_UIVisualGrid.Paint += value; }
            remove { Grid_UIVisualGrid.Paint -= value; }
        }
                        //OnCellClick
        public event MouseEventHandler OnCellSelected
        {
            add { Grid_UIVisualGrid.MouseDown += value; }
            remove { Grid_UIVisualGrid.MouseDown -= value; }
        }
        public event MouseEventHandler OnCellRangeCelected
        {
            add { Grid_UIVisualGrid.MouseMove += value; }
            remove { Grid_UIVisualGrid.MouseMove -= value; }
        }
        public event EventHandler OnSelectedAlgorithmChanged
        {
            add { SetAlgorithm_UICombobox.SelectedIndexChanged += value; }
            remove { SetAlgorithm_UICombobox.SelectedIndexChanged -= value; }
        }
        private event EventHandler OnMazeDimensionsChanged
        {
            add { MazeDimensions_UINumeric.ValueChanged += value; }
            remove { MazeDimensions_UINumeric.ValueChanged -= value; }
        }

        //UI Properties
        public int MazeDimensionsSelected
        {
            get { return (int)MazeDimensions_UINumeric.Value; }
            set { MazeDimensions_UINumeric.Value = value; }
        }
        public int CurrentAlgorithmTypeSelected
        {
            get { return SetAlgorithm_UICombobox.SelectedIndex; }
            set { SetAlgorithm_UICombobox.SelectedIndex = value; }
        }
        public int CurrentMazeTypeSelected
        {
            get { return MazeType_UIComboBox.SelectedIndex; }
            set { MazeType_UIComboBox.SelectedIndex = value; }
        }

        // public int MouseLocationX{get { }}
        // public int MouseLocationY { get; }

        //UI Methods
        public void AddAlgorithmToList(string a) { SetAlgorithm_UICombobox.Items.Add(a); }
        public void UpdateCellType(int x, int y, int type)
        {
            Color c;
            switch(type)
            {
                case 0:
                    c = DisplayColors.OpenColor;
                    break;
                case 1:
                    c = DisplayColors.WallColor;
                    break;
                case 2:
                    c = DisplayColors.StartColor;
                    break;
                case 3:
                    c = DisplayColors.EndColor;
                    break;
                case 4:
                    c = DisplayColors.PathColor;
                    break;
                default:
                    c = DisplayColors.UnknownTypeColor;
                    break;
            }

            Grid_UIVisualGrid.FillGridCell(x, y, c);
        }
        //public void DrawPath() { }
        public void DrawGrid()
        {
            Grid_UIVisualGrid.DisplayGrid();
        }
        public void UpdateCellDisplay()
        {

        }
        private void FillCellColor(object sender, MouseEventArgs e)
        {
            int xPos = e.Location.X;
            int yPos = e.Location.Y;
            int x = Grid_UIVisualGrid.GetCurrentCell(xPos);
            int y = Grid_UIVisualGrid.GetCurrentCell(yPos);
            Grid_UIVisualGrid.FillGridCell(x, y, System.Drawing.Color.Gray);
            Grid_UIVisualGrid.DisplayGrid();
        }
        private void UpdateVisualGridDimensions(object sender, EventArgs e)
        {
            Grid_UIVisualGrid.SetGridDimensions((int)MazeDimensions_UINumeric.Value);
            
        }
    }
}
