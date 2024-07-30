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
using FVMI_INSPECTION.Forms;
using Microsoft.VisualBasic;
using System.DirectoryServices.ActiveDirectory;

namespace FVMI_INSPECTION.Controls
{
    public partial class DashboardControl : UserControl, DashboardMVP.IView
    {
        public string modelName { get; set; }
        private DateTime startTime;
        private DashboardPresenter presenter;
        private FileLib lib = new FileLib();
        private ModelRepository repo = new ModelRepository();
        private ProcessResultModel[] data = new ProcessResultModel[0];
        private CountViewModel _cvm = new CountViewModel();
        private bool autoSave = true;
        public bool AllowReset
        {
            get => button1.Enabled; set
            {
                if (button1.IsHandleCreated)
                    button1.Invoke(delegate { button1.Enabled = value; button1.BackColor = value ? Color.Red : Color.Gray; button1.ForeColor = value ? Color.Black : Color.White; });
            }
        }
        public CountViewModel countViewModel
        {
            get => _cvm;

            set
            {
                if (IsHandleCreated)
                    groupBox8.Invoke(delegate
                    {
                        quantityLabel.Text = $"Count: {value.Count}";
                        failCountLabel.Text = $"Fail: {value.Fail}";
                        yieldLabel.Text = $"Yield: {(((decimal)value.Pass / (decimal)value.Count) * 100)}%";
                    });
                _cvm = value;
            }
        }
        public string SerialNumber
        {
            get => textBox1.Text; set
            {
                if (IsHandleCreated)
                    Invoke(delegate { textBox1.Text = value; });
            }
        }
        public string StatusRun
        {
            get => label6.Text; set
            {
                if (IsHandleCreated)
                    Invoke(delegate { label6.Text = value; });
            }
        }
        public string LogLabel
        {
            get => statusLabel.Text; set
            {
                if (IsHandleCreated)
                    Invoke(delegate { statusLabel.Text = value; });
            }
        }
        public string FinalJudge
        {
            get => finalJudgeLabel.Text; set
            {
                if (IsHandleCreated)
                    Invoke(delegate
                    {
                        Color clr = Color.Black;
                        if (value == "PASS")
                            clr = ColorTranslator.FromHtml("#37fd12");
                        else if (value == "NG" || value == "FAIL")
                            clr = ColorTranslator.FromHtml("#FF0707");
                        finalJudgeLabel.ForeColor = Color.Black;
                        finalJudgeLabel.BackColor = clr;
                        finalJudgeLabel.Text = value;
                    });
            }
        }
        public string TopUVDecision
        {
            get => topUVDecision.Text; set
            {
                if (!topUVDecision.IsHandleCreated) return;
                Invoke(delegate { topUVDecision.Text = value; topUVDecision.BackColor = value == "" ? Color.Transparent : value == "PASS" ? ColorTranslator.FromHtml("#37fd12") : ColorTranslator.FromHtml("#FF0707"); });
            }
        }
        public string BottomUVDecision
        {
            get => bottomUVDecision.Text; set
            {
                if (!bottomUVDecision.IsHandleCreated) return;
                Invoke(delegate { bottomUVDecision.Text = value; bottomUVDecision.BackColor = value == "" ? Color.Transparent : value == "PASS" ? ColorTranslator.FromHtml("#37fd12") : ColorTranslator.FromHtml("#FF0707"); });
            }
        }
        public string TopWhiteDecision
        {
            get => topWhiteDecision.Text; set
            {
                if (!topWhiteDecision.IsHandleCreated) return;
                Invoke(delegate { topWhiteDecision.Text = value; topWhiteDecision.BackColor = value == "" ? Color.Transparent : value == "PASS" ? ColorTranslator.FromHtml("#37fd12") : ColorTranslator.FromHtml("#FF0707"); });
            }
        }
        public string BottomWhiteDecision
        {
            get => bottomWhiteDecision.Text;
            set
            {
                if (!bottomWhiteDecision.IsHandleCreated) return;
                Invoke(delegate { bottomWhiteDecision.Text = value; bottomWhiteDecision.BackColor = value == "" ? Color.Transparent : value == "PASS" ? ColorTranslator.FromHtml("#37fd12") : ColorTranslator.FromHtml("#FF0707"); });
            }
        }

        public int CampPoint { get => int.Parse(campointLabel.Text); set { if (IsHandleCreated) Invoke(delegate { campointLabel.Text = value.ToString(); }); } }
        public Image? bottomUVImage { get => bottomUV.Image; set { if (IsHandleCreated) Invoke(delegate { bottomUV.Image = value; }); } }
        public Image? bottomWhiteImage { get => bottomWhite.Image; set { if (IsHandleCreated) Invoke(delegate { bottomWhite.Image = value; }); } }
        public Image? topUVImage { get => topUV.Image; set { if (IsHandleCreated) Invoke(delegate { topUV.Image = value; }); } }
        public Image? topWhiteImage { get => topWhite.Image; set { if (topWhite.IsHandleCreated) Invoke(delegate { topWhite.Image = value; }); } }
        private List<RecordModel> records = new List<RecordModel>();
        private List<ProcessRecordModel> _topRecord = new List<ProcessRecordModel>(), _bottomRecord = new List<ProcessRecordModel>(), _topWhiteRecord = new List<ProcessRecordModel>(), _bottomWhiteRecord = new List<ProcessRecordModel>();
        public List<ProcessRecordModel> TopUVRecord
        {
            get => _topRecord; set
            {
                _topRecord = value;
                if (!inspectionListGridTopUVView.IsHandleCreated)
                    return;
                inspectionListGridTopUVView.Invoke(delegate
                {
                    inspectionListGridTopUVView.Rows.Clear();
                    for (int i = 0; i < value.Count; i++)
                        inspectionListGridTopUVView.Rows.Add(new object[] { value[i].Area, value[i].Judgement });
                    inspectionListGridTopUVView.Refresh();
                    for (int i = 0; i < inspectionListGridTopUVView.RowCount; i++)
                        inspectionListGridTopUVView[1, i].Style.ForeColor = value[i].Judgement == "PASS" ? ColorTranslator.FromHtml("#37fd12") : ColorTranslator.FromHtml("#FF0707");
                    inspectionListGridTopUVView.Refresh();
                });
            }
        }
        public List<ProcessRecordModel> BottomUVRecord
        {
            get => _bottomRecord; set
            {
                _bottomRecord = value;
                if (!inspectionListGridBottomUVView.IsHandleCreated)
                    return;
                inspectionListGridBottomUVView.Invoke(delegate
                {
                    inspectionListGridBottomUVView.Rows.Clear();
                    for (int i = 0; i < value.Count; i++)
                        inspectionListGridBottomUVView.Rows.Add(new object[] { value[i].Area, value[i].Judgement });
                    inspectionListGridBottomUVView.Refresh();
                    for (int i = 0; i < inspectionListGridBottomUVView.RowCount; i++)
                        inspectionListGridBottomUVView[1, i].Style.ForeColor = value[i].Judgement == "PASS" ? ColorTranslator.FromHtml("#37fd12") : ColorTranslator.FromHtml("#FF0707");
                    inspectionListGridBottomUVView.Refresh();
                });
            }
        }
        public List<ProcessRecordModel> TopWhiteRecord
        {
            get => _topWhiteRecord;
            set
            {

                _topWhiteRecord = value;
                if (!inspectionListGridTopWhiteView.IsHandleCreated)
                    return;
                inspectionListGridTopWhiteView.Invoke(
                delegate
                {
                    inspectionListGridTopWhiteView.Rows.Clear();
                    for (int i = 0; i < value.Count; i++)
                        inspectionListGridTopWhiteView.Rows.Add(new object[] { value[i].Area, value[i].Judgement });
                    inspectionListGridTopWhiteView.Refresh();
                    for (int i = 0; i < inspectionListGridTopWhiteView.RowCount; i++)
                        inspectionListGridTopWhiteView[1, i].Style.ForeColor = value[i].Judgement == "PASS" ? ColorTranslator.FromHtml("#37fd12") : ColorTranslator.FromHtml("#FF0707");
                    inspectionListGridTopWhiteView.Refresh();
                });
            }
        }
        public List<ProcessRecordModel> BottomWhiteRecord
        {
            get => _bottomWhiteRecord;
            set
            {
                _bottomWhiteRecord = value;
                if (!inspectionListGridBottomWhiteView.IsHandleCreated)
                    return;
                inspectionListGridBottomWhiteView.Invoke(
                delegate
                {
                    inspectionListGridBottomWhiteView.Rows.Clear();
                    for (int i = 0; i < value.Count; i++)
                        inspectionListGridBottomWhiteView.Rows.Add(new object[] { value[i].Area, value[i].Judgement });
                    inspectionListGridBottomWhiteView.Refresh();
                    for (int i = 0; i < inspectionListGridBottomWhiteView.RowCount; i++)
                        inspectionListGridBottomWhiteView[1, i].Style.ForeColor = value[i].Judgement == "PASS" ? ColorTranslator.FromHtml("#37fd12") : ColorTranslator.FromHtml("#FF0707");
                    inspectionListGridBottomWhiteView.Refresh();
                });
            }
        }


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
            presenter = p;
            textBox1.Invoke(delegate
            {
                textBox1.Enabled = true;

            });
        }
        private async void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            /*bool isValid = await repo.ValidateLog(SerialNumber, modelName);
            if (!isValid)
            {
                MessageBox.Show($"Serial Number {SerialNumber} already used for {modelName}");
                return;
            }*/
            if (records.Count > 0 && autoSave)
                await presenter.WriteLog(records);
            scanLabel.Text = textBox1.Text;
            textBox1.Enabled = false;
            button2.Enabled = false;
            TopUVDecision = "";
            TopWhiteDecision = "";
            BottomUVDecision = "";
            BottomWhiteDecision = "";

            processTimeLabel.Invoke(new Action(() => processTimeLabel.Text = "00:00:00"));
            await Task.Run(async delegate
            {
                //                await dashboardProcess.RunProcess(FVMITCPProcess.DashboardProcessType.Top);
                //await ReadCsv();
                //              await dashboardProcess.RunProcess(FVMITCPProcess.DashboardProcessType.Bottom);
                //await ReadCsv();
                data = await presenter.RunProcess();
                if (data.Length < 1)
                {
                    autoSave = true;
                    Invoke(delegate
                    {
                        textBox1.Enabled = true;
                        textBox1.Text = string.Empty;

                        scanLabel.Text = "-";
                    });
                    records = new List<RecordModel>();
                    return;
                }
                records = presenter.GenerateRecordModel(data[0], TopUVRecord.ToArray(), modelName, SerialNumber);
                records.AddRange(presenter.GenerateRecordModel(data[1], BottomUVRecord.ToArray(), modelName, SerialNumber));
                records.AddRange(presenter.GenerateRecordModel(data[2], TopWhiteRecord.ToArray(), modelName, SerialNumber));
                records.AddRange(presenter.GenerateRecordModel(data[3], BottomWhiteRecord.ToArray(), modelName, SerialNumber));
                autoSave = !records.Any(x => x.Judgement == "NG" || x.Judgement == "FAIL");

                Invoke(delegate
                {
                    textBox1.Enabled = !records.Any(x => x.Judgement == "NG" || x.Judgement == "FAIL");
                    textBox1.Text = !records.Any(x => x.Judgement == "NG" || x.Judgement == "FAIL") ? textBox1.Text : string.Empty;
                    processTimer.Stop();
                    processTimer.Enabled = false;
                    button2.Enabled = !autoSave;
                    button2.BackColor = autoSave ? Color.Gray : Color.Yellow;
                    scanLabel.Text = "-";
                });
            }).ConfigureAwait(false);
        }

        private void processTimer_Tick(object sender, EventArgs e)
        {

            var elapsed = DateTime.Now - startTime;
            processTimeLabel.Invoke(new Action(() =>
            {
                processTimeLabel.Text = $"{elapsed.Hours.ToString("00")}:{elapsed.Minutes.ToString("00")}:{elapsed.Seconds.ToString("00")}";
            }));
            scanLabel.Invoke(delegate
            {
                scanLabel.BackColor = scanLabel.BackColor == Color.Yellow ? processTimeLabel.BackColor : Color.Yellow;
            });
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
                            timeLabel.Text = $"Date: {DateTime.Now.ToString("dd MMM yyyy")} Time: {DateTime.Now.ToString("HH:mm:ss")}";
                        }));
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                }

            }));
        }

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
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Invoke(delegate { button1.Enabled = false; });

            await presenter.ResetProcess();

            button1.Invoke(delegate { button1.Enabled = true; });
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var rst = MessageBox.Show("Confirm for Generate Log?", "Generate Log Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rst != DialogResult.Yes) return;
            try
            {
                await presenter.WriteLog(records);
                Invoke(delegate
                {

                    textBox1.Enabled = true;
                    textBox1.Text = string.Empty;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to write log", "Log Write");
            }
        }

        private async void resetCheckTimer_Tick(object sender, EventArgs e)
        {
            if (presenter is null)
                return;
            await presenter.CheckReset();
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
    }
}
