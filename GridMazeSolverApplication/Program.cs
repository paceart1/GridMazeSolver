using GridMazeSolverApplication.Controller;
using GridMazeSolverApplication.View;
namespace GridMazeSolverApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            MainForm view = new MainForm();

            MainController controller = new MainController(view);

            view.ShowDialog();
        }
    }
}
