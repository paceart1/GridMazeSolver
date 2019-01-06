using System;
using System.Drawing;
using System.Windows.Forms;

namespace GridMazeSolverApplication.View
{
    class GridUI
    {
        public GridUI()
        {

        }

        private double CalculateCellWidth()
        {
            //  Grid/count
            throw new NotImplementedException();
        }
        private void ActivateGridForEdit() { } //add listner for click event - call get grid location
        private void DeActivateGridForEdit() { } //remove
        public bool GridActiveForEdit { get; set; }
        public int GridWidth { get; set; }
        public int GridHeight { get; set; }
        public void DisplayGrid(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.DarkGray);
            pen.Width = 2.0f;
            int width = 350;
            int height = 350;
            int count = 5;
            int cellWidth = width / count;
            g.DrawRectangle(pen, 10, 20, width, height);
            for (int ii = 1; ii < count; ii++)
            {
                g.DrawLine(pen, cellWidth * ii + 10, 20, cellWidth * ii + 10, height + 20);
            }
        }
    }
}
