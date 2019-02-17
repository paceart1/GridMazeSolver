using GridMazeSolverApplication.Model;
using GridMazeSolverApplication.Model.Algorithms;
using GridMazeSolverApplication.Model.EnumDefinedValues;
using GridMazeSolverApplication.Model.Interfaces;
using System;
using System.Collections.Generic;
namespace GridMazeSolverApplication.Controller
{
    public class MainController
    {
        IMainView View;
        List<IAlgorithm> Algorithms;
        IAlgorithm CurrentAlgorithm;
        IMaze Maze;
      //  List<INode> MazeSolution; //Need to refactor to keep solution persistant
        
        //Local Control Methods
        private void InitializeProgramValues()
        {
            Algorithms.Add(new Dijkstra());
            UpdateCurrentAlgorithm(Algorithms[0]);
            UpdateViewLoadAlgorithmsList(Algorithms);
            UpdateViewLoadMazeTypesList(); 
            UpdateViewDisplayCurrentAlgorithm(CurrentAlgorithm, Algorithms);

            UpdateViewDisplayCurrentMazeDimensions(10); //need to update
            UpdateViewDisplayCurrentMazeType(0); //need to update
        }     
        private List<INode> GetMazeSolutionFromAlgorithm(IMaze maze, IAlgorithm algorithm)
        {
          //  currentAlgorithm.LoadGridTable(maze.MazeGrid, maze.Start, maze.End);
            List<INode> newSolution = algorithm.GetMazeSolution(maze);
            //Write condition for unsolvable maze : (End's previous is null)
            return newSolution;
          
        }
        private void DeleteMazeSolution()
        {
            Maze.MazeSolution.Solution = null;
        }
        private void UpdateCurrentAlgorithm(IAlgorithm algorithm)
        {
            CurrentAlgorithm = algorithm;
        }
        private List<INode> GenerateNewMaze(MazeTypes mazeType, int mazeDimensions)
        {
            List<INode> newMaze;
            newMaze = MazeGridFactory.GenerateMaze(mazeType, mazeDimensions);
            return newMaze;
        }
        private void SetMazeGrid(MazeTypes type, int dimensions)
        {
            Maze.MazeGrid.SetNewMazeGrid(GenerateNewMaze(type, dimensions), dimensions);
        }
        private void SetMazeStart()
        {
            INode start = Maze.MazeGrid.GetNode(0, 0);
            start.TypeValue = MazeCellTypeValues.open;
            Maze.Start = start;
        }
        private void SetMazeEnd(int mazeDimension)
        {
            INode end = Maze.MazeGrid.GetNode(mazeDimension - 1, mazeDimension - 1);
            end.TypeValue = MazeCellTypeValues.open;
            Maze.End = end;
        }
        private void ConnectEventMethodsToView()
        {
            View.OnGenerateMazeSelected += EventCreateNewMaze;
            View.OnShowMazeSolutionSelected += EventSetCurrectAlgorithmSelected;
            View.OnShowMazeSolutionSelected += EventDisplaySolutionSelected;
            View.OnCellSelected += EventCellSelected;
            View.OnPaintGridControl += EventPaintMazeGrid;

            
        }
         
        //Event Methods
        private void EventDisplaySolutionSelected(Object sender, EventArgs e)
        {
            try
            {
                Maze.MazeSolution.Solution  = GetMazeSolutionFromAlgorithm(Maze, CurrentAlgorithm); //<--Should be CurrentAlgorith.Solve(Maze)
                UpdateViewDisplayMazeSolutionPath(Maze.MazeSolution.Solution);
            }
            catch(Exception ex)
            {
                  if(Maze.MazeGrid.Grid == null)
                  {
                      View.DisplayMessageToUser("Please generate a new maze before attempting to solve.");
                      return;
                  }
                  if (Maze.MazeSolution.Solution == null)
                  {
                      View.DisplayMessageToUser("Maze is unsolvable.");
                      return;
                  }
                  
                View.DisplayErrorDetailsDebugging(ex);
            }
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
                MazeTypes newMazeType = (MazeTypes)View.CurrentMazeTypeSelected;

                SetMazeGrid(newMazeType, newMazeDimension);
                SetMazeStart();
                SetMazeEnd(newMazeDimension);
                
                //Update View to display maze
                UpdateViewDisplayMaze(Maze.MazeGrid.Grid);
                UpdateViewDisplayStart(Maze.Start);
                UpdateViewDisplayEnd(Maze.End);
                UpdateViewDrawGrid();
            }
            catch(Exception ex)
            {
                View.DisplayErrorDetailsDebugging(ex);
            }

        }
        private void EventUpdateMazeCellTypeValue(object sender, EventArgs e)
        {
            
        }
        private void EventPaintMazeGrid(object sender, EventArgs e)
        {
            if(Maze.MazeGrid.Grid != null)
            {
                UpdateViewDisplayMaze(Maze.MazeGrid.Grid);
                UpdateViewDisplayStart(Maze.Start);
                UpdateViewDisplayEnd(Maze.End);
            }
            if (Maze.MazeSolution.Solution!= null)
            {
                UpdateViewDisplayMazeSolutionPath(Maze.MazeSolution.Solution);
            }
            UpdateViewDrawGrid();
        }
        private void EventCellSelected(object sender, EventArgs e)
        {
            int x = View.GetGridPositionX();
            int y = View.GetGridPositionY();
            INode currentNode = Maze.MazeGrid.GetNode(x, y);
            if (currentNode == null) { return; }
            MazeCellTypeValues type = currentNode.TypeValue;
            if(currentNode == Maze.Start || currentNode == Maze.End) { return; }
            if(Maze.MazeSolution.Solution != null)
            {
                UpdateViewClearMazeSolutionPath(Maze.MazeSolution.Solution);
                DeleteMazeSolution();
                UpdateViewDisplayStart(Maze.Start);
                UpdateViewDisplayEnd(Maze.End);
            }
            if (type == MazeCellTypeValues.open)
            {
                currentNode.TypeValue = MazeCellTypeValues.wall;
            }
            else if(type == MazeCellTypeValues.wall)
            {
                currentNode.TypeValue = MazeCellTypeValues.open;
            }
            View.UpdateCellType(x, y, (int)currentNode.TypeValue);//Create Method for this
            UpdateViewDrawGrid();
        }

        //Update View methods
        private void UpdateViewDisplayMaze(List<INode> mazeNodeList)
        {
            if(mazeNodeList == null) { throw new ArgumentNullException("passedMazeGrid cannot be null."); }
            View.UpdateAllCells((int)MazeCellTypeValues.open);
            foreach (INode n in mazeNodeList)
            {
                if(n.TypeValue == MazeCellTypeValues.wall) //Make more efficient by keeping a collection of wall cells
                {
                    View.UpdateCellType(n.XPosition, n.YPosition, (int)n.TypeValue);
                }  
            }
        }
        private void UpdateViewDisplayStart(INode start)
        {
            View.UpdateStart(start.XPosition, start.YPosition);
        }
        private void UpdateViewDisplayEnd(INode end)
        {
            View.UpdateEnd(end.XPosition, end.YPosition);
        }
        private void UpdateViewLoadAlgorithmsList(List<IAlgorithm> algorithmsList)
        {
            foreach (IAlgorithm a in algorithmsList)
            {
                View.AddAlgorithmToList(a.Name);
            }
        }
        private void UpdateViewLoadMazeTypesList()
        {
            //tempCode
            
            View.AddMazeTypeToList(MazeTypes.Blank.ToString());
            View.AddMazeTypeToList(MazeTypes.Scatter.ToString());
            View.AddMazeTypeToList(MazeTypes.Traditional.ToString());
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
        private void UpdateViewDisplayMazeSolutionPath(List<INode> mazeSolution)
        {
            //test code for path
            //make async?? 
            if(mazeSolution == null) { throw new ArgumentNullException("Cannot display null maze solution"); }
            foreach (INode n in mazeSolution)
            {
                int x = n.XPosition;
                int y = n.YPosition;
                View.UpdateSolutionPath(x, y);
            }
            UpdateViewDrawGrid();
        }
        private void UpdateViewClearMazeSolutionPath(List<INode> mazeSolution)
        {
            if(mazeSolution == null) { throw new ArgumentNullException("Cannot clear a path that is null."); }
            foreach (INode n in mazeSolution)
            {
                int x = n.XPosition;
                int y = n.YPosition;
                View.UpdateCellType(x, y, (int)n.TypeValue);
            }
            UpdateViewDrawGrid();
        }
        private void UpdateViewDrawGrid()
        {
            View.DrawGridLines();
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
