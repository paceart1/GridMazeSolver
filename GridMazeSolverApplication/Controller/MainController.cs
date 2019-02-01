using GridMazeSolverApplication.Model;
using GridMazeSolverApplication.Model.Algorithms;
using System;
using System.Collections.Generic;
namespace GridMazeSolverApplication.Controller
{
    public class MainController
    {
        IMainView View;
        List<IAlgorithm> Algorithms;
        IAlgorithm CurrentAlgorithm;
        Maze Maze;
        //List<Node> MazeSolution; //Need to refactor to keep solution persistant
        
        //Control Methods
        private void InitializeProgramValues()
        {
            Algorithms.Add(new Dijkstra());
            UpdateCurrentAlgorithm(Algorithms[0]);
            UpdateViewDisplayAlgorithms(Algorithms);
            UpdateViewDisplayCurrentAlgorithm(CurrentAlgorithm, Algorithms);

            UpdateViewDisplayCurrentMazeDimensions(10); //need to update
            UpdateViewDisplayCurrentMazeType(0); //need to update
        }     
        private List<Node> GetMazeSolutionFromAlgorithm(Maze maze, IAlgorithm algorithm)
        {
          //  currentAlgorithm.LoadGridTable(maze.MazeGrid, maze.Start, maze.End);
            List<Node> newSolution = algorithm.GetMazeSolution(maze);
            //Write condition for unsolvable maze : (End's previous is null)
            return newSolution;
          
        }
        private void ClearMazeSolution()
        {
            //MazeSolution = null;
        }
        private void UpdateCurrentAlgorithm(IAlgorithm algorithm)
        {
            CurrentAlgorithm = algorithm;
        }
        private List<Node> CreateNewMaze(int mazeType, int mazeDimensions)
        {
            //Temp code
            int mazeDimension = mazeDimensions;
            List<Node> newMaze;
            switch (mazeType)
            {
                case 0:
                    newMaze = MazeBuilder.GenerateBlankMaze(mazeDimension);
                    break;
                case 1:
                    newMaze = MazeBuilder.GenerateScatterMaze(mazeDimension);
                    break;
                default:
                    newMaze = null;
                    break;
            }
           
            return newMaze;
        }
        private void ConnectEventMethodsToView()
        {
            View.OnGenerateMazeSelected += EventCreateNewMaze;
            View.OnShowMazeSolutionSelected += EventSetCurrectAlgorithmSelected;
            View.OnShowMazeSolutionSelected += EventDisplaySolutionSelected;
            View.OnPaintGridControl += EventPaintGrid;
        }
        
        
        //Event Methods
        private void EventDisplaySolutionSelected(Object sender, EventArgs e)
        {
                UpdateViewDisplayMazeSolutionPath(GetMazeSolutionFromAlgorithm(Maze, CurrentAlgorithm));
  
        }
        private void EventSetCurrectAlgorithmSelected(Object sender, EventArgs e)
        {
            try
            {
                UpdateCurrentAlgorithm(Algorithms[View.CurrentAlgorithmTypeSelected]);
            }
            catch(Exception)
            {

            }
        }
        private void EventCreateNewMaze(object sender, EventArgs e)
        {
            try
            {
                int newMazeDimension = View.MazeDimensionsSelected;
                int newMazeType = View.CurrentMazeTypeSelected;
               // Maze.DeleteMazeGrid();
                Maze.SetNewMazeGrid(CreateNewMaze(newMazeType, newMazeDimension), newMazeDimension);
                Maze.SetGridCellStart(0, 0); //refactor
                Maze.SetGridCellEnd(newMazeDimension - 1, newMazeDimension - 1);
                //Update View to display maze
                UpdateViewDisplayMaze(Maze.MazeGrid);
                UpdateViewDrawGrid();
            }
            catch(Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        private void EventUpdateMazeCellTypeValue(object sender, EventArgs e)
        {
            
        }
        private void EventPaintGrid(object sender, EventArgs e)
        {
            UpdateViewDrawGrid();
        }

        //Update View methods
        private void UpdateViewDisplayMaze(List<Node> mazeNodeList)
        {
            if(mazeNodeList == null) { throw new ArgumentNullException("passedMazeGrid cannot be null."); }
            foreach (Node n in mazeNodeList)
            {
                View.UpdateCellType(n.X, n.Y, n.TypeValue);
            }
        }
        private void UpdateViewDisplayAlgorithms(List<IAlgorithm> algorithmsList)
        {
            foreach (IAlgorithm a in algorithmsList)
            {
                View.AddAlgorithmToList(a.Name);
            }
        }
        private void UpdateViewDisplayCurrentAlgorithm(IAlgorithm algorithm, List<IAlgorithm> algorithmList)
        {
            if (algorithm == null) { return; }
            View.CurrentAlgorithmTypeSelected = algorithmList.IndexOf(algorithm);
        }
        private void UpdateViewDisplayCurrentMazeDimensions(int mazeDimensions)
        {
            View.MazeDimensionsSelected = mazeDimensions;
        }
        private void UpdateViewDisplayCurrentMazeType(int mazeTypeValue)
        {
            View.CurrentMazeTypeSelected = mazeTypeValue;
        }
        private void UpdateViewDisplayMazeSolutionPath(List<Node> mazeSolution)
        {
            //test code for path
            //make async?? 
            for(int ii = 1; ii < mazeSolution.Count - 1; ii++)
            {
                int x = mazeSolution[ii].X;
                int y = mazeSolution[ii].Y;
                View.UpdateCellType(x, y, (int)MazeCellTypeValues.path);
            }
            /*foreach (Node n in mazeSolution)
            {
                int x = n.X;
                int y = n.Y;
                View.UpdateCellType(x, y, (int)MazeCellTypeValues.path);
            }*/
        }
        private void UpdateViewDrawGrid()
        {
            View.DrawGrid();
        }
        
        //Constructor
        public MainController(IMainView passedView)
        {
            View = passedView;
            Maze = new Maze();//temp
            Algorithms = new List<IAlgorithm>();
            InitializeProgramValues();
            ConnectEventMethodsToView();
        }
    }
}
