using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design;
using FVMI_INSPECTION.Models;
using FVMI_INSPECTION.Repositories;
using FVMI_INSPECTION.TCP;
using FVMI_INSPECTION.Utilities;
using FVMI_INSPECTION.Interfaces;
using FVMI_INSPECTION.Presenter;
using FVMI_INSPECTION.Forms;
using Microsoft.VisualBasic.FileIO;

namespace FVMI_INSPECTION.Controls
{
    public partial class SettingParameterControl : UserControl, SettingParameterMVP.IView
    {
        private string _ModelName = string.Empty;
        private readonly ModelRepository repository = new ModelRepository();
        private FVMITCPProcess? process = null;
        private readonly FileLib lib = new FileLib();

        public string ModelName
        {
            get => _ModelName; set
            {
                _ModelName = value;
                if (runningModel.IsHandleCreated && modelBox.IsHandleCreated)
                    Invoke(delegate { runningModel.Text = $"Model: {value}"; modelBox.Enabled = true; modelBox.Text = value; modelBox.Enabled = false; });
            }
        }
        public int CameraPoint { get => int.Parse(camPoint.Value.ToString()); set => Invoke(delegate { camPoint.Value = value; }); }
        public int TopCamExecution { get; set; } = 0;
        public int BottomExecution { get; set; } = 0;
        public Image TopUVImage { get => pictureBox3.Image; set => Invoke(delegate { pictureBox3.Image = value; }); }
        public Image BottomUVImage { get => pictureBox2.Image; set => Invoke(delegate { pictureBox2.Image = value; }); }
        public Image TopWhiteImage { get => pictureBox4.Image; set => Invoke(delegate { pictureBox4.Image = value; }); }
        public Image BottomWhiteImage { get => pictureBox1.Image; set => Invoke(delegate { pictureBox1.Image = value; }); }

        public string UploadFilePath { get => uploadFileDialog.FileName; }
        public string UploadFileName { get => uploadFileDialog.SafeFileName; }
        public Button[] UVButton { get; set; } = new Button[2];
        public Button[] CylinderButton { get; set; } = new Button[2];
        public SettingParameterMVP.IPresenter presenter;
        public SettingParameterControl(string ModelName)
        {

            InitializeComponent();
            UVButton = [button3,button6];
            CylinderButton = [button8,button7];
            this._ModelName = ModelName;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await presenter.SetTopCamExec();
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            await presenter.SetBottomCamExec();
        }
        private async void SettingParameterControl_Load(object sender, EventArgs e)
        {
            this.ModelName = _ModelName;
            presenter = await SettingParameterPresenter.Build(_ModelName, this);
            await presenter.LoadCurrentModel();
        }

        private async void button14_Click(object sender, EventArgs e)
        {
            await presenter.SetCamPoint();
            MessageBox.Show("Set Complete");
        }

        private async void uploadEvent(object sender, EventArgs e)
        {
            Control btn = (Control)sender;
            btn.Invoke(delegate { btn.Enabled = false; });
            var dialog = uploadFileDialog.ShowDialog();
            if (dialog == DialogResult.OK)
                await presenter.UploadImage(btn.Tag!.ToString()!);
            btn.Invoke(delegate { btn.Enabled = true; });
        }
        private void flipControl(object s, bool state)
        {
            if (s is null)
                return;
            Control c = (Control)s;
            c.Invoke(delegate { c.Enabled = state; });

        }
        private async void triggerOrigin(object sender, EventArgs e)
        {
            flipControl(sender, false);
            await presenter.TriggerOrigin();
            flipControl(sender, true);
        }
        private async void triggerFlip(object sender, EventArgs e)
        {
            flipControl(sender, false);
            await presenter.TriggerFlip();
            flipControl(sender, true);
        }
        private async void toggleUV(object sender, EventArgs e)
        {

            flipControl(sender, false);
            string? val = ((Button)sender)?.Tag?.ToString();
            if (val is null)
            {
                MessageBox.Show("Control issue, fail to detect value");
                return;
            }
            await presenter.UVToggle(val == "1");
            flipControl(sender!, true);
        }
        private async void toggleCylinder(object sender, EventArgs e)
        {

            flipControl(sender, false);
            string? val = ((Button)sender)?.Tag?.ToString();
            if (val is null)
            {
                MessageBox.Show("Control issue, fail to detect value");
                return;
            }
            await presenter.CylinderToggle(val == "1");
            flipControl(sender!, true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Task.Run(new Action(() =>
            {
                try
                {
                    if (timeLabel.IsHandleCreated)
                    {
                        timeLabel.Invoke(new Action(() =>
                        {
                            timeLabel.Text = $"Date: {DateTime.Now.ToString("dd MMM yyyy")}\nTime: {DateTime.Now.ToString("HH:mm:ss")}";
                        }));
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                }

            }));
        }
    }
}
