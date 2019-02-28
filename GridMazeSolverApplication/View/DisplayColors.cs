using System.Drawing;

namespace GridMazeSolverApplication.View
{
    static class DisplayColors
    {
        public static Color WallColor { get; set; } = Color.Gray;
        public static Color OpenColor { get; set; } = System.Windows.Forms.Control.DefaultBackColor;
        public static Color StartColor { get; set; } = Color.Green;
        public static Color EndColor { get; set; } = Color.Blue;
        public static Color PathColor { get; set; } = Color.Aquamarine;
        public static Color CurrentAnalyzed { get; set; } = Color.DarkRed;
        public static Color UnknownTypeColor { get; set; } = Color.Empty;
    }
}
