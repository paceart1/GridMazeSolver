using System;
using System.Drawing;
using System.Windows.Forms;

namespace GridMazeSolverApplication.CustomControls
{
    public partial class VisualGrid : UserControl
    {
        int[,] GridValues = new int[0,0];
        int cellCountX;
        int cellCountY;
        float cellWidth;
        float gridLineWeight;
        void SetCellWidth()
        {
            cellWidth = (float)this.Size.Width / CellCountX;
        }        
        void PaintCell(int x, int y, Color c)
        {
            int cellX = x;
            int cellY = y;
            float startX = cellX * cellWidth ;
            float startY = cellY * cellWidth ;
            float stopX = cellWidth ;
            float stopY = cellWidth ;

            Graphics g = this.CreateGraphics();
            SolidBrush brush = new SolidBrush(c);
            g.FillRectangle(brush, startX, startY, stopX, stopY);
        }

        //Public Properties
        public int CellCountX
        {
            get { return cellCountX; }
            set
            {
                if (value < 1) { throw new Exception("Cell count cannot be set to a value less than 1."); }
                cellCountX = value;
            }
        }
        public int CellCountY {
            get { return cellCountY; }
            set
            {
                if (value < 1) { throw new Exception("Cell count cannot be set to a value less than 1."); }
                cellCountY = value;
            }
        }
        public Color GridLineColor { get; set; }
        public bool VisibleGridLines { get; set; } //activate gridlines (Not implimented)

        //Public Methods
        public void DisplayGridLines()
        {
            // if(VisibleGridLines == false) { return; }
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(GridLineColor);
            pen.Width = gridLineWeight;

            for (int ii = 1; ii < CellCountX; ii++)
            {
                g.DrawLine(pen, cellWidth * ii, 0, cellWidth * ii, this.Height);
            }
            for (int ii = 1; ii < CellCountY; ii++)
            {
                g.DrawLine(pen, 0, cellWidth * ii, this.Width, cellWidth * ii);
            }
        }
        public int GetCurrentCell(int loc)
        {
            if (loc < 0) { throw new Exception("Passed loc value cannot be negative."); }
            if (cellWidth <= 0) { throw new Exception("Cell width cannot be less than or equal to 0"); }
            return (ushort)Math.Floor(loc / cellWidth);
        }
        public void FillGridCell(int x, int y, Color c)
        {
            PaintCell(x, y, c);
        }
        public void FillGrid(Color c)
        {
            Graphics g = this.CreateGraphics();
            SolidBrush brush = new SolidBrush(c);
            g.FillRectangle(brush, 0, 0, this.Size.Width, this.Size.Height);
        }
        public void SetGridDimensions(int cellCount)
        {
            CellCountX = cellCount;
            CellCountY = cellCount;
            SetCellWidth();
        }
        public VisualGrid()
        {

            InitializeComponent();
            
            SetGridDimensions(5);
            gridLineWeight = 1f;
            GridLineColor = Color.DarkGray;


        }
    }
}
