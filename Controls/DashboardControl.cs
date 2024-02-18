using AutoMapper;
using FVMI_INSPECTION.Repositories;
using FVMI_INSPECTION.Interfaces;
using FVMI_INSPECTION.Models;
using FVMI_INSPECTION.Models.ViewData;
using FVMI_INSPECTION.Presenter;
using FVMI_INSPECTION.TCP;
using FVMI_INSPECTION.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FVMI_INSPECTION.Controls
{
    public partial class DashboardControl : UserControl, DashboardMVP.View
    {
        private string modelName;
        private DateTime startTime;
        private DashboardPresenter presenter;
        private FileLib lib = new FileLib();
        private ModelRepository repo = new ModelRepository();
        public string SerialNumber { get => textBox1.Text; set => Invoke(delegate { textBox1.Text = value; }); }
        public string StatusRun { get => statusLabel.Text; set => Invoke(delegate { statusLabel.Text = value; }); }
        public int CampPoint { get => int.Parse(campointLabel.Text); set => Invoke(delegate { campointLabel.Text = value.ToString(); }); }

        public DashboardControl()
        {
            InitializeComponent();
            textBox1.Enabled = false;
        }
        public DashboardControl(string _model)
        {
            InitializeComponent();
            modelName = _model;
            runningModel.Text = modelName;
            textBox1.Enabled = false;
        }
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            presenter.Dispose();
        }


        private async void DashboardControl_Load(object sender, EventArgs e)
        {
            var p = await DashboardPresenter.Build(this, modelName, lib, repo);
            if (p is null)
                return;
            textBox1.Invoke(delegate
            {
                textBox1.Enabled = true;

            });
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            scanLabel.Text = textBox1.Text;
            textBox1.Enabled = false;
            finalJudgeLabel.Text = string.Empty;
            areaLabel.Text = string.Empty;
            decisionLabel.Text = string.Empty;
            processTimeLabel.Invoke(new Action(() => processTimeLabel.Text = "Process Time: 00:00:00"));
            actualPictureBox.Image = null;
            parameterPictureBox.Image = null;
            startTime = DateTime.Now;
            processTimer.Enabled = true;
            processTimer.Start();
            Task.Run(async delegate
            {
                //                await dashboardProcess.RunProcess(FVMITCPProcess.DashboardProcessType.Top);
                //await ReadCsv();
                //              await dashboardProcess.RunProcess(FVMITCPProcess.DashboardProcessType.Bottom);
                //await ReadCsv();
                await presenter.RunProcess();
                Invoke(delegate
                {
                    textBox1.Enabled = true;
                    textBox1.Text = string.Empty;
                    processTimer.Stop();
                    processTimer.Enabled = false;

                    scanLabel.Text = "-";
                });
            });
        }

        private void processTimer_Tick(object sender, EventArgs e)
        {

            var elapsed = DateTime.Now - startTime;
            processTimeLabel.Invoke(new Action(() =>
            {
                processTimeLabel.Text = $"Process Time: {elapsed.Hours.ToString("00")}:{elapsed.Minutes.ToString("00")}:{elapsed.Seconds.ToString("00")}";
            }));
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            Task.Run(new Action(() =>
            {
                try
                {
                    timeLabel.Invoke(new Action(() =>
                    {
                        timeLabel.Text = $"Date: {DateTime.Now.ToString("dd MMM yyyy")}\nTime: {DateTime.Now.ToString("HH:mm:ss")}";
                    }));
                }
                catch(Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                }

            }));
        }
    }
}
