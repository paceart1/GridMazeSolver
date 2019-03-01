using System.Drawing;

namespace GridMazeSolverApplication.View
{
    static class DisplayColors
    {
        public static Color GridColor { get; set; } = Color.FromArgb(100, 100, 100);
        public static Color WallColor { get; set; } = Color.FromArgb(100, 100, 100);
        public static Color OpenColor { get; set; } = System.Windows.Forms.Control.DefaultBackColor;
        public static Color StartColor { get; set; } = Color.Green;
        public static Color EndColor { get; set; } = Color.Blue;
        public static Color PathColor { get; set; } = Color.Aquamarine;
        public static Color CurrentNodeAnalyzed { get; set; } = Color.DarkRed;
        public static Color CurrentNeighborAnalyzed { get; set; } = Color.LightPink;
        public static Color UnknownTypeColor { get; set; } = Color.Empty;
    }
}
