namespace GridMazeSolverApplication.Model
{
    class Maze
    {
        int[,] grid;
        //Need path class?
        public int GridWidth { get; private set; }
        public int GridHeight { get; private set; }

        //startpoint
        //endpoint
        public Maze(int width, int height)
        {
            GridWidth = width;
            GridHeight = height;
            grid = new int[width, height];
        }
        //Load grid values 0 = open, 1 = wall
        public void LoadGridCellValues()
        {
            /*
            if(grid == null)
            {
                throw new Exception("Grid points to null");
            }
            if(grid.Length == 0)
            {
                throw new Exception("Grid contains no elements");
            }
            */
            for (int ii = 0; ii < GridWidth; ii++)
            {
                for (int jj = 0; jj < GridHeight; jj++)
                {
                    grid[ii, jj] = 0;
                }
            }
        }
    }
}
