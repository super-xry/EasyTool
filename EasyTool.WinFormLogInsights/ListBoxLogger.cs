using System.Drawing;
using System.Windows.Forms;

namespace EasyTool.WinFormLogInsights
{
    public class ListBoxLogger
    {
        private const int DefaultMaxPageItemCount = 100;
        private readonly ListBox _logContainer;
        private readonly Font _font;
        private readonly int _maxInsightItemCount;
        private readonly bool _autoScroll;
        private readonly ContextMenuStrip _contextMenuStrip;

        public ListBoxLogger(ListBox logContainer, Font font) : this(logContainer, font, DefaultMaxPageItemCount)
        {
        }

        public ListBoxLogger(ListBox logContainer, Font font, int maxInsightItemCount) : this(logContainer, font, maxInsightItemCount, true)
        {

        }

        public ListBoxLogger(ListBox logContainer, Font font, int maxInsightItemCount, bool autoScroll)
        {
            _logContainer = logContainer;
            _font = font;
            _maxInsightItemCount = maxInsightItemCount;
            _autoScroll = autoScroll;

            _logContainer.BackColor = SystemColors.InactiveCaptionText;
            _logContainer.ItemHeight = 25;
            _logContainer.DrawMode = DrawMode.OwnerDrawFixed;
            _logContainer.DrawItem += LogContainerDrawItem;
            _logContainer.MouseDoubleClick += PopupMessage;
            _logContainer.MouseDown += ShowActions;
            _contextMenuStrip = new ContextMenuStrip();

            var copyMenuItem = new ToolStripMenuItem("Copy", null, (_, _) =>
            {
                var item = (CustomListItem)_logContainer.SelectedItem;
                if (item == null) return;
                Clipboard.SetText(item.Message);
            });
            _contextMenuStrip.Items.Add(copyMenuItem);
        }

        private void ShowActions(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            var index = _logContainer.IndexFromPoint(e.Location);
            if (index == ListBox.NoMatches)
            {
                _logContainer.ContextMenuStrip = null;
                return;
            }

            _logContainer.ContextMenuStrip = _contextMenuStrip;
        }

        private void PopupMessage(object? sender, MouseEventArgs e)
        {
            var index = _logContainer.IndexFromPoint(e.Location);
            if (index == ListBox.NoMatches) return;
            var item = (CustomListItem)_logContainer.Items[index];
            MessageBox.Show(item.Message);
        }

        public void LogInfo(string message)
        {
            if (_logContainer.InvokeRequired)
            {
                _logContainer.BeginInvoke(new MethodInvoker(() => LogInfo(message)));
                return;
            }

            var currentIndex = _logContainer.Items.Add(new CustomListItem(message));
            if (!_autoScroll) return;
            AutoScrollDown(currentIndex);
        }

        public void LogError(string message)
        {
            if (_logContainer.InvokeRequired)
            {
                _logContainer.BeginInvoke(new MethodInvoker(() => LogError(message)));
                return;
            }

            var currentIndex = _logContainer.Items.Add(new CustomListItem(message, Brushes.OrangeRed));

            if (!_autoScroll) return;
            AutoScrollDown(currentIndex);
        }

        public void AutoScrollDown(int currentIndex)
        {
            if (currentIndex <= _maxInsightItemCount) return;
            _logContainer.TopIndex = _logContainer.Items.Count - _logContainer.Height / _logContainer.ItemHeight;
        }

        private void LogContainerDrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;
            var listBox = (ListBox)sender;
            var item = (CustomListItem)listBox.Items[e.Index];
            using var borderPen = new Pen(Color.Gray);
            e.Graphics.DrawLine(borderPen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
            e.DrawFocusRectangle();
            e.Graphics.DrawString(item.Message, _font, item.Brush, e.Bounds);
        }
    }
}
