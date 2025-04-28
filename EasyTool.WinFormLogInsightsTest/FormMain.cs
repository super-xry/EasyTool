using EasyTool.WinFormLogInsights;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            logger.LogInfo("This is an info style...");
            logger.LogError("This is an error style...");
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRawJson.Text)) return;
            jsonViewer.JsonData = JsonConvert.DeserializeObject<JObject>(txtRawJson.Text);
        }
    }
}