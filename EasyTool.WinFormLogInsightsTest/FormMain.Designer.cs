namespace EasyTool.WinFormLogInsightsTest
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnAddMsg = new Button();
            logger = new EasyTool.WinFormLogInsights.ListBoxLogger();
            panel1 = new Panel();
            btnFormat = new Button();
            txtRawJson = new RichTextBox();
            jsonViewer = new EasyTool.JsonViewer.JsonViewerControl();
            SuspendLayout();
            // 
            // btnAddMsg
            // 
            btnAddMsg.Location = new Point(287, 55);
            btnAddMsg.Name = "btnAddMsg";
            btnAddMsg.Size = new Size(90, 32);
            btnAddMsg.TabIndex = 0;
            btnAddMsg.Text = "Add";
            btnAddMsg.UseVisualStyleBackColor = true;
            btnAddMsg.Click += btnAddMsg_Click;
            // 
            // logger
            // 
            logger.BackColor = SystemColors.InactiveCaptionText;
            logger.DrawMode = DrawMode.OwnerDrawFixed;
            logger.FormattingEnabled = true;
            logger.ItemHeight = 25;
            logger.Location = new Point(-1, 105);
            logger.Name = "logger";
            logger.Size = new Size(424, 504);
            logger.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 100);
            panel1.TabIndex = 5;
            // 
            // btnFormat
            // 
            btnFormat.Location = new Point(781, 3);
            btnFormat.Name = "btnFormat";
            btnFormat.Size = new Size(89, 112);
            btnFormat.TabIndex = 3;
            btnFormat.Text = "Format";
            btnFormat.UseVisualStyleBackColor = true;
            btnFormat.Click += btnFormat_Click;
            // 
            // txtRawJson
            // 
            txtRawJson.Location = new Point(429, 3);
            txtRawJson.Name = "txtRawJson";
            txtRawJson.Size = new Size(332, 112);
            txtRawJson.TabIndex = 4;
            txtRawJson.Text = "";
            // 
            // jsonViewer
            // 
            jsonViewer.JsonData = null;
            jsonViewer.Location = new Point(431, 135);
            jsonViewer.Name = "jsonViewer";
            jsonViewer.Size = new Size(439, 309);
            jsonViewer.TabIndex = 6;
            jsonViewer.Text = "jsonViewerControl1";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 625);
            Controls.Add(jsonViewer);
            Controls.Add(txtRawJson);
            Controls.Add(btnFormat);
            Controls.Add(panel1);
            Controls.Add(logger);
            Controls.Add(btnAddMsg);
            Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Name = "FormMain";
            Text = "FormMain";
            ResumeLayout(false);
        }

        #endregion

        private Button btnAddMsg;
        private WinFormLogInsights.ListBoxLogger logger;
        private Panel panel1;
        private Button btnFormat;
        private RichTextBox txtRawJson;
        private JsonViewer.JsonViewerControl jsonViewer;
    }
}
