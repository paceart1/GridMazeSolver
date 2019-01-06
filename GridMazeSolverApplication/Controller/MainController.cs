namespace GridMazeSolverApplication.Controller
{
    public class MainController
    {
        private int IdentifyCell(int pointLocation, int gridLength) //change to float?
        {
            return (gridLength / pointLocation);
        }

        public MainController(IMainView view)
        {

        }
    }
}
