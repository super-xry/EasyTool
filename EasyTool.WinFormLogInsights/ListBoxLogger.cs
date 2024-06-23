using System.Drawing;
using System.Windows.Forms;

namespace EasyTool.WinFormLogInsights
{
    public class ListBoxLogger : ListBox
    {
        private const int DefaultItemHigh = 25;
        private LoggerConfiguration _loggerConfiguration = new();
        private int? _maxLine;

        public ListBoxLogger()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            ContextMenuStrip = new ContextMenuStrip()
            {
                Items =
                {
                    new ToolStripMenuItem("Clear", null, (_,_)=>Items.Clear()),
                    new ToolStripMenuItem("Copy", null, (_, _) =>
                    {
                        if (SelectedItem is not CustomListItem item) return;
                        if (string.IsNullOrEmpty(item.Message)) return;
                        Clipboard.SetText(item.Message);
                    },"Copy"),
                    new ToolStripMenuItem("Detail",null, (_, _) =>
                    {
                        if (SelectedItem is not CustomListItem item) return;
                        if (string.IsNullOrEmpty(item.Message)) return;
                        MessageBox.Show(item.Message);
                    },"Detail"),
                }
            };
            MouseDown += ShowActions;
            ItemHeight = DefaultItemHigh;
            BackColor = SystemColors.InactiveCaptionText;
        }

        public void InitConfig(LoggerConfiguration configuration)
        {
            _loggerConfiguration = configuration;
        }

        private void ShowActions(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var index = IndexFromPoint(e.Location);
            if (index != NoMatches) return;
            ContextMenuStrip.Items["Copy"].Visible = false;
            ContextMenuStrip.Items["Detail"].Visible = false;
        }

        public void LogInfo(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => LogInfo(message)));
                return;
            }

            var currentIndex = Items.Add(new CustomListItem(message, _loggerConfiguration.InfoBrush));
            if (!_loggerConfiguration.AutoScroll) return;
            AutoScrollDown(currentIndex);
        }

        public void LogError(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => LogError(message)));
                return;
            }

            var currentIndex = Items.Add(new CustomListItem(message, _loggerConfiguration.ErrorBrush));

            if (!_loggerConfiguration.AutoScroll) return;
            AutoScrollDown(currentIndex);
        }

        public void AutoScrollDown(int currentIndex)
        {
            _maxLine ??= Height / ItemHeight;
            if (currentIndex <= _maxLine) return;
            TopIndex = Items.Count - _maxLine.Value;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0 || Items.Count == 0) return;
            var item = Items[e.Index] as CustomListItem;
            using var borderPen = new Pen(Color.Gray);
            e.Graphics.DrawLine(borderPen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
            e.Graphics.DrawString(item.Message, _loggerConfiguration.Font, item.Brush, e.Bounds);
            e.DrawFocusRectangle();
        }
    }
}
