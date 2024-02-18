using AutoMapper;
using FVMI_INSPECTION.DAL;
using FVMI_INSPECTION.Models;
using FVMI_INSPECTION.Models.ViewData;
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
    public partial class DashboardControl : UserControl
    {
        private string modelName;
        private DateTime startTime;
        private MasterModel model;
        private FVMITCPProcess dashboardProcess;
        private FileLib lib = new FileLib();
        private ModelRepository repo = new ModelRepository();
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
            dashboardProcess.cTokenSource.Cancel();
            dashboardProcess.Disconnect();
        }


        private async void DashboardControl_Load(object sender, EventArgs e)
        {
            var list = await repo.GetModel(modelName);
            if (list.Count < 1)
                return;
            model = list.First();
            campointLabel.Text = model.CameraPoint.ToString();
            dashboardProcess = new FVMITCPProcess(model, lib);
            textBox1.Invoke(delegate
            {
                textBox1.Enabled = true;

            });
            dashboardProcess.eventUpdate += updateEvent;
        }
        protected void updateEvent(string status)
        {
            Invoke(delegate
            {
                statusLabel.Text = status;
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
                await dashboardProcess.RunProcess();
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
        private async Task<ProcessRecordModel?> ReadCsv()
        {
            ProcessRecordModel? mdl = null;
            var files  = await lib.GetFiles(lib.CSVPath);
            if (files.Length < 1) return null;
            using (var stream = new FileStream(Path.Combine(lib.CSVPath, files[0]), FileMode.Open))
            {
                using (var reader = new StreamReader(stream))
                {
                    string? text= await reader.ReadLineAsync();
                    if (text is null) return null;
                    string[] data = text.Split(',');
                    mdl = new ProcessRecordModel(data);
                    while (await reader.ReadLineAsync() is not null)
                    {
                        data = text.Split(",");
                        if (data.Length < 4)
                            continue;
                        int[] details = new int[4];
                        for (int i = 0; i < details.Length; i++)
                            details[i] = int.Parse(data[i]);
                        mdl.Data.Add(details);
                    }
                }
            }
            return mdl;
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
