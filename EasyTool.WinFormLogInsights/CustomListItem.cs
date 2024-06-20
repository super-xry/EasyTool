using System.Drawing;

namespace EasyTool.WinFormLogInsights
{
    public class CustomListItem(string message, Brush brush)
    {
        public CustomListItem(string message) : this(message, Brushes.LimeGreen)
        {
        }

        public string Message { get; set; } = message;

        public Brush Brush { get; set; } = brush;
    }
}