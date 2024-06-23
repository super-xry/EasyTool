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
            logger = new WinFormLogInsights.ListBoxLogger();
            SuspendLayout();
            // 
            // btnAddMsg
            // 
            btnAddMsg.Location = new Point(387, 23);
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
            logger.Location = new Point(58, 146);
            logger.Name = "logger";
            logger.Size = new Size(419, 254);
            logger.TabIndex = 1;
            logger.MouseDoubleClick += logger_MouseDoubleClick;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(549, 457);
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
    }
}
