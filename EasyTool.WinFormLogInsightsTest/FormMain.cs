using EasyTool.WinFormLogInsights;

namespace EasyTool.WinFormLogInsightsTest
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            logger.InitConfig(new LoggerConfiguration()
            {
                Font = Font
            });
        }

        private void btnAddMsg_Click(object sender, EventArgs e)
        {
            logger.LogInfo("Test...");
        }

        private void logger_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = (CustomListItem)logger.SelectedItem;
            MessageBox.Show(item.Message);
        }
    }
}
