using GridMazeSolverApplication.Controller;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GridMazeSolverApplication.View
{
    public partial class MainForm : Form, IMainView
    {
        //
        //private Methods
        private Color GetTypeColor(int type)
        {
            Color c;
            switch (type)
            {
                case 0:
                    c = DisplayColors.OpenColor;
                    break;
                case 1:
                    c = DisplayColors.WallColor;
                    break;
                default:
                    c = DisplayColors.UnknownTypeColor;
                    break;
            }
            return c;
        }
        private Color GetAlgorithmColor(int type)
        {
            Color c;
            switch (type)
            {
                case 0:
                    c = DisplayColors.CurrentNodeAnalyzed;
                    break;
                default:
                    c = DisplayColors.UnknownTypeColor;
                    break;
            }
            return c;
        }
        //Private EventArgs

        private void UpdateVisualGridDimensions(object sender, EventArgs e)
        {
            Grid_UIVisualGrid.SetGridDimensions((int)MazeDimensions_UINumeric.Value);

        }

        public MainForm()
        {
            InitializeComponent();
            OnMazeDimensionsChanged += UpdateVisualGridDimensions;
            Grid_UIVisualGrid.GridLineColor = DisplayColors.GridColor;
        }

        //Event Handlers
        public event EventHandler OnShowAlgorithmGraphicsCheckedChanged
        {
            add { chkShowAlgorithGraphics.CheckedChanged += value; }
            remove { chkShowAlgorithGraphics.CheckedChanged -= value; }
        }
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
        public event EventHandler OnCellSelected
        {
            add { Grid_UIVisualGrid.Click += value; }
            remove { Grid_UIVisualGrid.Click -= value; }
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
        public bool ShowAlgorithmGraphics
        {
            get { return chkShowAlgorithGraphics.Checked; }
            set { chkShowAlgorithGraphics.Checked = value; }
        }
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
            get { return SetMazeType_UIComboBox.SelectedIndex; }
            set { SetMazeType_UIComboBox.SelectedIndex = value; }
        }


        //UI Methods
        public void AddAlgorithmToList(string algorithmName) { SetAlgorithm_UICombobox.Items.Add(algorithmName); }
        public void AddMazeTypeToList(string typeName) { SetMazeType_UIComboBox.Items.Add(typeName); }
        public void UpdateAllCellsType(int type)
        {
            Color c = GetTypeColor(type);
            Grid_UIVisualGrid.FillGrid(c);
        }
        public void UpdateCellType(int x, int y, int type)
        {
            Color c = GetTypeColor(type);
            Grid_UIVisualGrid.FillGridCell(x, y, c);
        }
        public void ShowAlgorithmCurrentCellAnalyzed(int x, int y)
        {
            Color c = DisplayColors.CurrentNodeAnalyzed;
            Grid_UIVisualGrid.FillGridCell(x, y, c);
        } //<----------------------
        public void ShowAlgorithmCurrentNeighborAnalyzed(int x, int y)
        {
            Color c = DisplayColors.CurrentNeighborAnalyzed;
            Grid_UIVisualGrid.FillGridCell(x, y, c);
        }
        public void UpdateSolutionPath(int x, int y)
        {
            Color c = DisplayColors.PathColor;
            Grid_UIVisualGrid.FillGridCell(x, y, c);
        }
        public void UpdateStart(int x, int y)
        {
            Grid_UIVisualGrid.FillGridCell(x, y, DisplayColors.StartColor);
        }
        public void UpdateEnd(int x, int y)
        {
            Grid_UIVisualGrid.FillGridCell(x, y, DisplayColors.EndColor);
        }
        public int GetGridPositionX()
        {
            int mouseX = Grid_UIVisualGrid.PointToClient(MousePosition).X;
            return Grid_UIVisualGrid.GetCurrentCell(mouseX);
        }
        public int GetGridPositionY()
        {
            int mouseY = Grid_UIVisualGrid.PointToClient(MousePosition).Y;
            return Grid_UIVisualGrid.GetCurrentCell(mouseY);
        }
        public void DrawGridLines()
        {
            Grid_UIVisualGrid.DisplayGridLines();
        }

        public void DisplayErrorDetailsDebugging(Exception ex)
        {
            string message = "StackTrace:\n" + ex.StackTrace + "\n\n" 
                +"Message:\n" + ex.Message;
            string title = "Exception Handled:";
            MessageBox.Show(message, title);
        }
        public void DisplayMessageToUser(string s)
        {
            MessageBox.Show(s);
        }
    }
}
