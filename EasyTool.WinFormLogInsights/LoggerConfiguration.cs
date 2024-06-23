using System.Drawing;

namespace EasyTool.WinFormLogInsights
{
    public class LoggerConfiguration
    {
        public bool AutoScroll { get; set; } = true;

        public Brush InfoBrush { get; set; } = Brushes.LimeGreen;

        public Brush ErrorBrush { get; set; } = Brushes.OrangeRed;

        public Font Font { get; set; } = new("Microsoft YaHei UI", 9);
    }
}
