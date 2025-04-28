using Newtonsoft.Json.Linq;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EasyTool.JsonViewer
{
    public class JsonViewerControl : SKControl
    {
        private JObject _jsonData;
        private readonly List<TreeNode> _nodes;

        [Browsable(true)]
        [Category("Appearance")]
        [Description("The item hight (flaot)")]
        [DefaultValue(20F)]
        public float NodeHeight { get; set; } = 20f;

        [Browsable(true)]
        [Category("Appearance")]
        [Description("The indent size (flaot)")]
        [DefaultValue(20F)]
        public float IndentSize { get; set; } = 20f;

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Item text size (float)")]
        [DefaultValue(14F)]
        public float TextSize { get; set; } = 14f;

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Padding of left (right)")]
        [DefaultValue(10F)]
        public float PaddingLeft { get; set; } = 10f;

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Padding of left (float)")]
        [DefaultValue(15F)]
        public float PaddingTop { get; set; } = 15f;

        private const int ButtonSize = 20;
        private const int ButtonPadding = 5;
        private bool expanded = false;
        private float scrollOffsetY;
        private const float ScrollSpeed = 20f;

        public JObject? JsonData
        {
            get => _jsonData;
            set
            {
                _jsonData = value;
                LoadJsonData();
                Invalidate();
            }
        }

        public JsonViewerControl()
        {
            DoubleBuffered = true;
            _nodes = new List<TreeNode>();
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);

            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(SKColors.White);

            if (_nodes.Count <= 0) return;

            using var textPaint = new SKPaint();
            textPaint.IsAntialias = true;
            textPaint.TextSize = TextSize;
            textPaint.Color = SKColors.Black;

            float y = PaddingTop + 10;
            foreach (var node in _nodes)
            {
                DrawTreeNode(canvas, node, textPaint, ref y, 0);
            }
        }

        private void DrawTreeNode(SKCanvas canvas, TreeNode node, SKPaint paint, ref float y, int indentLevel)
        {
            float x = PaddingLeft + indentLevel * IndentSize;

            // Draw the expand/collapse icon
            string icon = node.IsExpanded ? "[-]" : "[+]";
            canvas.DrawText(icon, x, y, paint);
            x += paint.MeasureText(icon) + 5;

            // Draw the node text
            canvas.DrawText(node.Text ?? "null", x, y, paint);

            y += NodeHeight;

            if (!node.IsExpanded) return;

            foreach (var childNode in node.Nodes)
            {
                DrawTreeNode(canvas, childNode, paint, ref y, indentLevel + 1);
            }
        }

        private void LoadJsonData()
        {
            _nodes.Clear();
            TreeNode rootNode = new("Root", true);
            if (_jsonData == null) return;
            PopulateTreeNode(_jsonData, rootNode);
            _nodes.Add(rootNode);
        }

        private void PopulateTreeNode(JToken token, TreeNode parentNode)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    foreach (var prop in token.Children<JProperty>())
                    {
                        TreeNode node = new(prop.Name);
                        parentNode.Nodes.Add(node);
                        PopulateTreeNode(prop.Value, node);
                    }
                    break;

                case JTokenType.Array:
                    int index = 0;
                    foreach (var item in token)
                    {
                        TreeNode node = new($"[{index++}]");
                        parentNode.Nodes.Add(node);
                        PopulateTreeNode(item, node);
                    }
                    break;

                case JTokenType.None:
                case JTokenType.Constructor:
                case JTokenType.Property:
                case JTokenType.Comment:
                case JTokenType.Integer:
                case JTokenType.Float:
                case JTokenType.String:
                case JTokenType.Boolean:
                case JTokenType.Null:
                case JTokenType.Undefined:
                case JTokenType.Date:
                case JTokenType.Raw:
                case JTokenType.Bytes:
                case JTokenType.Guid:
                case JTokenType.Uri:
                case JTokenType.TimeSpan:
                default:
                    parentNode.Nodes.Add(new TreeNode(token.ToString()));
                    break;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (_nodes.Count <= 0) return;
            float y = PaddingTop;
            HandleMouseDown(e.Location, _nodes, ref y, 0);
            Invalidate();
        }

        private bool HandleMouseDown(Point location, List<TreeNode> nodes, ref float y, int indentLevel)
        {
            var x = PaddingLeft + indentLevel * IndentSize;

            using var paint = new SKPaint()
            {
                TextSize = TextSize
            };

            foreach (var node in nodes)
            {
                var iconWidth = paint.MeasureText("[-]") + 5;

                if (location.Y >= y && location.Y <= y + NodeHeight)
                {
                    if (location.X >= x && location.X <= x + iconWidth)
                    {
                        node.Toggle();
                        return true;
                    }
                }

                y += NodeHeight;

                if (!node.IsExpanded) continue;
                if (HandleMouseDown(location, node.Nodes, ref y, indentLevel + 1))
                    return true;
            }

            return false;
        }

        private class TreeNode(string text, bool isExpanded = false)
        {
            public string? Text { get; } = text;
            public bool IsExpanded { get; private set; } = isExpanded;
            public List<TreeNode> Nodes { get; } = [];

            public void Toggle()
            {
                IsExpanded = !IsExpanded;
            }
        }
    }
}