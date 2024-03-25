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

namespace FVMI_INSPECTION.Controls
{
    public partial class SettingParameterControl : UserControl, SettingParameterMVP.IView
    {
        private string _ModelName = string.Empty;
        private bool isNew = false;
        private readonly ModelRepository repository = new ModelRepository();
        private FVMITCPProcess? process = null;
        private readonly FileLib lib = new FileLib();

        public string ModelName
        {
            get => _ModelName; set
            {
                _ModelName = value;
                runningModel.Invoke(delegate { runningModel.Text = $"Model: {value}"; });
            }
        }
        public int CameraPoint { get => int.Parse(camPoint.Value.ToString()); set => Invoke(delegate { camPoint.Value = value; }); }
        public int TopCamExecution { get => int.Parse(camExecBoxTop.Text); set => Invoke(delegate { camExecBoxTop.Text = value.ToString(); }); }
        public int BottomExecution { get => int.Parse(camExecBoxBottom.Text); set => Invoke(delegate { camExecBoxBottom.Text = value.ToString(); }); }
        public Image TopImage { get => pictureBox1.Image; set => Invoke(delegate { pictureBox1.Image = value; }); }
        public Image BottomImage { get => pictureBox2.Image; set => Invoke(delegate { pictureBox2.Image = value; }); }
        public string UploadFilePath { get => uploadFileDialog.FileName;  }
        public string UploadFileName { get => uploadFileDialog.SafeFileName; }
        public SettingParameterMVP.IPresenter presenter;
        public SettingParameterControl(string ModelName)
        {
            InitializeComponent();
            this._ModelName = ModelName;
            runningModel.Text = $"Model: {ModelName}";
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
            isNew = true;
            presenter = await SettingParameterPresenter.Build(_ModelName, this);
        }

        private async void button14_Click(object sender, EventArgs e)
        {
            await presenter.SetCamPoint();
        }

        private async void uploadEvent(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Invoke(delegate { btn.Enabled = false; });
            var dialog = uploadFileDialog.ShowDialog();
            if (dialog == DialogResult.OK)
                await presenter.UploadImage(btn.Tag!.ToString()!);
            btn.Invoke(delegate { btn.Enabled = true; });
        }
    }
}
