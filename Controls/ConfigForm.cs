using FVMI_INSPECTION.TCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVMI_INSPECTION.Utilities;
using System.Windows.Forms;
using FVMI_INSPECTION.Forms;

namespace FVMI_INSPECTION.Controls
{
    public partial class ConfigForm : UserControl
    {
        private FVMITcpClient tcp = new FVMITcpClient();
        public ConfigForm()
        {
            InputModalForm frm = new InputModalForm("Confirm Password","Password", '*');
            var resDialog = frm.ShowDialog();
            if (resDialog == DialogResult.OK)
            {
                if (frm.textBox1.Text.Hmac512Hash() != Properties.Settings.Default.Password)
                {
                    MessageBox.Show("Incorrect Password");
                    return;
                }
            }
            else
                return;
            InitializeComponent();
            button15.Text = tcp.isRunning ? "Disconnect" : "Connect";
            ipBox.Enabled = !tcp.isRunning;
            portBox.Enabled = !tcp.isRunning;
            statusLabel.Text = "Status: " + (tcp.isRunning ? "Connected" : "Disconnected");
            currentPasswordBox.PasswordChar = '*';
            newPasswordBox.PasswordChar = '*';
            LoadDirBox();
        }

        private async void button15_Click(object sender, EventArgs e)
        {
            if (tcp.isRunning)
            {
                await tcp.Reconnect();
                ipBox.Enabled = true;
                portBox.Enabled = true;
                button15.Invoke(new Action(() => { button15.Text = "Connect"; }));
            }
            else
            {
                Properties.Settings.Default["ServerIpAddress"] = ipBox.Text;
                Properties.Settings.Default["ServerPort"] = int.Parse(portBox.Text);
                Properties.Settings.Default.Save();
                tcp.SetIpAddress(ipBox.Text);
                tcp.SetPort(int.Parse(portBox.Text));
                await tcp.Connect();
                this.Invoke(new Action(() =>
                {
                    button15.Text = "Disconnect";
                    ipBox.Enabled = false;
                    portBox.Enabled = false;
                }));
                MessageBox.Show("Save Complete");
            }
            statusLabel.Invoke(new Action(() =>
            {
                statusLabel.Text = "Status: " + (tcp.isRunning ? "Connected" : "Disconnected");
            }));
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {

            ipBox.Text = Properties.Settings.Default["ServerIpAddress"].ToString();
            portBox.Text = Properties.Settings.Default["ServerPort"].ToString();
            dashboardDelay.Value = Convert.ToDecimal(Properties.Settings.Default["DelayDashboardProcess"].ToString() ?? "0");
            settingParamDelay.Value = Convert.ToDecimal(Properties.Settings.Default["DelaySettingParameter"].ToString() ?? "0");
            cameraTriggerDelay.Value = Convert.ToDecimal(Properties.Settings.Default["CameraDelay"].ToString() ?? "0");
            ngCameraDelay.Value = Convert.ToDecimal(Properties.Settings.Default["NgCameraDelay"].ToString() ?? "0");
        }
        private string GetConfig(string name)
        {
            return Properties.Settings.Default[name].ToString() ?? string.Empty;
        }
        private void LoadDirBox()
        {
            triggerImgSaveDir.Text = GetConfig("SaveImageDirName");
            ngImgSaveDir.Text = GetConfig("NgImageDirName");
            markedImgSaveDir.Text = GetConfig("MarkSaveDir");
            ftpCameraDir.Text = GetConfig("ImageDirName");
            reportLogPath.Text = GetConfig("LogPath");
            debugLogPath.Text = GetConfig("DebugLogPath");
            csvPathBox.Text = GetConfig("CSVPath");
            whiteCSVBox.Text = GetConfig("WhiteCSVPath");
            whiteImgBox.Text = GetConfig("WhiteImgPath");
            uvCSVBox.Text = GetConfig("UVCSVPath");
            uvImgBox.Text = GetConfig("UVImgPath");
            UVPrefixBox.Text = $"{GetConfig("UVTopPrefix")};{GetConfig("UVBottomPrefix")}";
            WhitePrefixBox.Text = $"{GetConfig("WhiteTopPrefix")};{GetConfig("WhiteBottomPrefix")}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["DelayDashboardProcess"] = int.Parse(dashboardDelay.Value.ToString());
            Properties.Settings.Default["DelaySettingParameter"] = int.Parse(settingParamDelay.Value.ToString());
            Properties.Settings.Default["CameraDelay"] = int.Parse(cameraTriggerDelay.Value.ToString());
            Properties.Settings.Default["NgCameraDelay"] = int.Parse(ngCameraDelay.Value.ToString());
            Properties.Settings.Default.Save();
        }

        private void openDialogFolder(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var res = folderBrowserDialog1.ShowDialog();
            if (res != DialogResult.OK)
                return;
            Properties.Settings.Default[btn!.Tag.ToString()] = folderBrowserDialog1.SelectedPath;
            Properties.Settings.Default.Save();
            LoadDirBox();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string currentPassword = Properties.Settings.Default["Password"].ToString() ?? string.Empty;
            if (currentPassword != currentPasswordBox.Text.Hmac512Hash() || newPasswordBox.Text == string.Empty)
            {
                MessageBox.Show(newPasswordBox.Text == string.Empty ? "New Passwrod Can't be Empty" : "Incorrect Password");
                return;
            }
            Properties.Settings.Default["Password"] = newPasswordBox.Text.Hmac512Hash();
            Properties.Settings.Default.Save();
            MessageBox.Show("Password Successfully Updated");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (UVPrefixBox.Text.Split(";").Length != 2)
            {
                MessageBox.Show("Invalid UV prefix format");
                return;
            }
            Properties.Settings.Default["UVTopPrefix"] = UVPrefixBox.Text.Split(";")[0];
            Properties.Settings.Default["UVBottomPrefix"] = UVPrefixBox.Text.Split(";")[1];
            Properties.Settings.Default.Save();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (WhitePrefixBox.Text.Split(";").Length != 2)
            {
                MessageBox.Show("Invalid White prefix format");
                return;
            }
            Properties.Settings.Default["WhiteTopPrefix"] = WhitePrefixBox.Text.Split(";")[0];
            Properties.Settings.Default["WhiteBottomPrefix"] = WhitePrefixBox.Text.Split(";")[1];
            Properties.Settings.Default.Save();
        }
    }
}
