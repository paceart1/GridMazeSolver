using System;
using System.Drawing;
using System.Windows.Forms;

namespace GridMazeSolverApplication.CustomControls
{
    public partial class VisualGrid : UserControl
    {
        int[,] GridValues = new int[0,0];
        float cellWidth;
        int gridLineWeight;
        void SetCellWidth()
        {
            cellWidth = (float)this.Size.Width / cellCountX;
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
        public void DisplayGrid()
        {
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Color.DarkGray);
            pen.Width = (float)gridLineWeight;

            for (int ii = 1; ii < cellCountX; ii++)
            {
                g.DrawLine(pen, cellWidth * ii, 0, cellWidth * ii, this.Height);
            }
            for (int ii = 1; ii < cellCountY; ii++)
            {
                g.DrawLine(pen, 0, cellWidth * ii, this.Width, cellWidth * ii);
            }
        }
      /*  void DrawGrid(Object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.DarkGray);
            pen.Width = (float)gridLineWeight;

            for (int ii = 1; ii < cellCountX; ii++)
            {
                g.DrawLine(pen, cellWidth * ii, 0, cellWidth * ii, this.Height);
            }
            for (int ii = 1; ii < cellCountY; ii++)
            {
                g.DrawLine(pen, 0, cellWidth * ii, this.Width, cellWidth * ii);
            }
        }
        */
        public int cellCountX { get; set; }
        public int cellCountY { get; set; }
        public bool VisibleGridLines { get; set; } //activate gridlines
        public int GetCurrentCell(int loc)
        {
            return (int)Math.Floor(loc / cellWidth);
        }
        public void FillGridCell(int x, int y, Color c)
        {
            PaintCell(x, y, c);
        }
        public void SetGridDimensions(int cellCount)
        {
            cellCountX = cellCount;
            cellCountY = cellCount;
            SetCellWidth();
        }
        public VisualGrid()
        {

            InitializeComponent();
            
            SetGridDimensions(5);
            gridLineWeight = 1;
           // this.Paint += DrawGrid;
           
        }
    }
}
