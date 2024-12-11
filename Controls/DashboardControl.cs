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
<<<<<<< Updated upstream
=======

        private void ShowNgPopup(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            DataGridView v = (DataGridView)sender;
            bool isAnyFail = records.Any(x => x.Judgement != "PASS");
            var record = records.Where(x => x.Area == v[0, e.RowIndex].Value.ToString() && v.Tag!.ToString() == x.Type).FirstOrDefault();
            if (record is null)
            {
                MessageBox.Show("Data Not Found");
                return;
            }
            var ngForm = new NgPopupShowForm(record);
            var dialog = ngForm.ShowDialog();
            if (dialog != DialogResult.OK)
                return;
            var index = records.IndexOf(record);
            records[index] = ngForm.Model;
            v[1, e.RowIndex].Value = ngForm.Model.Judgement;
            v[1, e.RowIndex].Style.ForeColor = ngForm.Model.Judgement == "PASS" ? ColorTranslator.FromHtml("#37fd12") : ColorTranslator.FromHtml("#FF0707");
            string tag = v.Tag!.ToString()!;
            if (tag.Contains("TopUV"))
            {
                var r = TopUVRecord.Where(x => x.Area == record.Area).First();
                r.Judgement = ngForm.Model.Judgement;
                index = TopUVRecord.IndexOf(r);
                TopUVRecord[index].Judgement = r.Judgement;
                TopUVDecision = TopUVRecord.Any(x => x.Judgement == "NG" || x.Judgement == "FAIL") ? "FAIL" : "PASS";
            }
            if (tag.Contains("BottomUV"))
            {

                var r = BottomUVRecord.Where(x => x.Area == record.Area).First();
                r.Judgement = ngForm.Model.Judgement;
                index = BottomUVRecord.IndexOf(r);
                BottomUVRecord[index].Judgement = r.Judgement;
                BottomUVDecision = BottomUVRecord.Any(x => x.Judgement == "NG" || x.Judgement == "FAIL") ? "FAIL" : "PASS";
            }
            if (tag.Contains("TopWhite"))
            {
                var r = TopWhiteRecord.Where(x => x.Area == record.Area).First();
                r.Judgement = ngForm.Model.Judgement;
                index = TopWhiteRecord.IndexOf(r);
                TopWhiteRecord[index].Judgement = r.Judgement;
                TopWhiteDecision = TopWhiteRecord.Any(x => x.Judgement == "NG" || x.Judgement == "FAIL") ? "FAIL" : "PASS";
            }
            if (tag.Contains("BottomWhite"))
            {
                var r = BottomWhiteRecord.Where(x => x.Area == record.Area).First();
                r.Judgement = ngForm.Model.Judgement;
                index = BottomWhiteRecord.IndexOf(r);
                BottomWhiteRecord[index].Judgement = r.Judgement;
                BottomWhiteDecision = BottomWhiteRecord.Any(x => x.Judgement == "NG" || x.Judgement == "FAIL") ? "FAIL" : "PASS";
            }

            if (records.Any(x => x.Judgement == "NG" || x.Judgement == "FAIL"))
                FinalJudge = "FAIL";
            else
                FinalJudge = "PASS";
            if (!isAnyFail)
            {
                if (records.Any(x => x.Judgement != "PASS"))
                {

                    countViewModel = new CountViewModel()
                    {
                        Count = countViewModel.Count,
                        Fail = countViewModel.Fail + 1,
                        Pass = countViewModel.Pass - 1,
                    };
                }
            }
            else
            {
                if (!records.Any(x => x.Judgement != "PASS"))
                {
                    countViewModel = new CountViewModel()
                    {
                        Count = countViewModel.Count,
                        Fail = countViewModel.Fail - 1,
                        Pass = countViewModel.Pass + 1,
                    };
                }
            }
        }

        private void DashboardControl_Leave(object sender, EventArgs e)
        {
            //            if (records.Count > 0)
            //                await presenter.WriteLog(records);
            try
            {
                resetCheckToken.Cancel();
            }
            catch
            {

            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (tReset is not null)
                await tReset;
            resetCheckToken = new CancellationTokenSource();
            await presenter.ResetProcess();
            tReset = Task.Run(CheckResetTask);

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var rst = MessageBox.Show("Confirm for Generate Log?", "Generate Log Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rst != DialogResult.Yes) return;
            try
            {
                await presenter.WriteLog(records, textBox1.Text);
                Invoke(delegate
                {

                    textBox1.Enabled = true;
                    textBox1.Text = string.Empty;
                    button2.Enabled = false;
                    button2.BackColor = Color.Gray;
                });
                StatusRun = "Please Scan Code";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to write log", "Log Write");
            }
        }
        public async Task CheckResetTask()
        {
            resetCheckToken = new CancellationTokenSource();
            try
            {
                resetCheckToken.Token.ThrowIfCancellationRequested();
                while (!resetCheckToken.IsCancellationRequested)
                {
                    if (presenter is not null)
                    {
                        await presenter.CheckReset();
                        await Task.Delay(1);

                    }
                }
                resetCheckToken.Dispose();
            }
            catch (OperationCanceledException e) when (e.CancellationToken == resetCheckToken.Token)
            {
                return;
            }
        }
        private void resetCheckTimer_Tick(object sender, EventArgs e)
        {
        }

        public void StartTimer()
        {
            Invoke(delegate
            {
                startTime = DateTime.Now;

                processTimer.Enabled = true;
                processTimer.Start();
            });
        }

        public void StopTimer()
        {
            Invoke(delegate
            {
                processTimer.Stop();
                processTimer.Enabled = false;
            });
        }

        public void CancelResetTask()
        {
            resetCheckToken.Cancel();
        }

    
>>>>>>> Stashed changes
    }
}
