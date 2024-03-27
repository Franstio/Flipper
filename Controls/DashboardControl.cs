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

namespace FVMI_INSPECTION.Controls
{
    public partial class DashboardControl : UserControl, DashboardMVP.IView
    {
        private string modelName;
        private DateTime startTime;
        private DashboardPresenter presenter;
        private FileLib lib = new FileLib();
        private ModelRepository repo = new ModelRepository();
        private ProcessResultModel[] data = new ProcessResultModel[0];
        private CountViewModel _cvm = new CountViewModel();
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
        public string SerialNumber { get => textBox1.Text; set
            {
                if (IsHandleCreated)
                    Invoke(delegate { textBox1.Text = value; });
            }
        }
        public string StatusRun
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
                        clr = Color.LimeGreen;
                    else if (value == "NG" || value == "FAIL")
                        clr = Color.DarkRed;
                    finalJudgeLabel.ForeColor = clr;
                    finalJudgeLabel.Text = value;
                });
            }
        }
        public string TopDecision
        {
            get => topDecisionLabel.Text;
            set
            {
                if (IsHandleCreated)
                Invoke(delegate
                {
                    topDecisionLabel.Text = value;
                    Color clr = Color.Black;
                    if (value == "PASS")
                        clr = Color.LimeGreen;
                    else if (value == "FAIL")
                        clr = Color.DarkRed;
                    topDecisionLabel.ForeColor = clr;
                });
            }
        }
        public string BottomDecision
        {
            get => bottomDecisionLabel.Text;
            set
            {
                if (IsHandleCreated)
                    Invoke(delegate
                    {
                        bottomDecisionLabel.Text = value;
                        Color clr = Color.Black;
                        if (value == "PASS")
                            clr = Color.LimeGreen;
                        else if (value == "FAIL")
                            clr = Color.DarkRed;
                        bottomDecisionLabel.ForeColor = clr;
                    });
            }
        }
        public int CampPoint { get => int.Parse(campointLabel.Text); set {if (IsHandleCreated) Invoke(delegate { campointLabel.Text = value.ToString(); }); } }
        public Image? TopParameterImage { get => parameterTop.Image; set { if (IsHandleCreated) Invoke(delegate { parameterTop.Image = value; }); } }
        public Image? BottomParameterImage { get => parameterBottom.Image; set { if (IsHandleCreated) Invoke(delegate { parameterBottom.Image = value; }); } }
        public Image? TopActualImage { get => actualTop.Image; set { if (IsHandleCreated) Invoke(delegate { actualTop.Image = value; }); } }
        public Image? BottomActualImage { get => actualBottom.Image; set { if (actualBottom.IsHandleCreated) Invoke(delegate { actualBottom.Image = value; }); } }
        private List<RecordModel> records = new List<RecordModel>();
        private List<ProcessRecordModel> _topRecord = new List<ProcessRecordModel>(), _bottomRecord = new List<ProcessRecordModel>();
        public List<ProcessRecordModel> TopRecord
        {
            get => _topRecord; set
            {
                _topRecord = value;
                inspectionListGridView.Invoke(delegate
                {
                    inspectionListGridView.Rows.Clear();
                    for (int i = 0; i < value.Count; i++)
                        inspectionListGridView.Rows.Add(new object[] { value[i].Area, value[i].Judgement });
                    inspectionListGridView.Refresh();
                    for (int i = 0; i < inspectionListGridView.RowCount; i++)
                        inspectionListGridView[1, i].Style.ForeColor = value[i].Judgement == "PASS" ? Color.LimeGreen : Color.DarkRed;
                    inspectionListGridView.Refresh();
                });
            }
        }
        public List<ProcessRecordModel> BottomRecord
        {
            get => _bottomRecord; set
            {
                _bottomRecord= value;
                bottomInspectionGridView.Invoke(delegate
                {
                    bottomInspectionGridView.Rows.Clear();
                    for (int i = 0; i < value.Count; i++)
                        bottomInspectionGridView.Rows.Add(new object[] { value[i].Area, value[i].Judgement });
                    bottomInspectionGridView.Refresh();
                    for (int i = 0; i < bottomInspectionGridView.RowCount; i++)
                        bottomInspectionGridView[1, i].Style.ForeColor = value[i].Judgement == "PASS" ? Color.LimeGreen : Color.DarkRed;
                    bottomInspectionGridView.Refresh();
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
            if (records.Count > 0)
                await presenter.WriteLog(records);
            scanLabel.Text = textBox1.Text;
            textBox1.Enabled = false;
            topDecisionLabel.Text = string.Empty;
            bottomDecisionLabel.Text = string.Empty;
            processTimeLabel.Invoke(new Action(() => processTimeLabel.Text = "Process Time: 00:00:00"));
            actualBottom.Image = null;
            actualTop.Image = null;
            startTime = DateTime.Now;
            processTimer.Enabled = true;
            processTimer.Start();
            await Task.Run(async delegate
            {
                //                await dashboardProcess.RunProcess(FVMITCPProcess.DashboardProcessType.Top);
                //await ReadCsv();
                //              await dashboardProcess.RunProcess(FVMITCPProcess.DashboardProcessType.Bottom);
                //await ReadCsv();
                data = await presenter.RunProcess();
                
                records = presenter.GenerateRecordModel(data[0], TopRecord.ToArray(), modelName,SerialNumber);
                records.AddRange(presenter.GenerateRecordModel(data[1], BottomRecord.ToArray(), modelName, SerialNumber));
                Invoke(delegate
                {
                    textBox1.Enabled = true;
                    textBox1.Text = string.Empty;
                    processTimer.Stop();
                    processTimer.Enabled = false;

                    scanLabel.Text = "-";
                });
            }).ConfigureAwait(false);
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

        private void ShowNgPopup(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || data.Length < 1)
                return;
            DataGridView v = (DataGridView)sender;
            string type = v.Tag!.ToString()!;
            var selected = type == "TOP" ? TopRecord : BottomRecord;
            bool isPrevPass = !records.Any(x => x.Judgement == "NG" || x.Judgement == "FAIL");
            if (selected is null)
                return;
            var record = records.Where(x => x.Type.ToLower() == type.ToLower() && x.Area == selected[e.RowIndex].Area).FirstOrDefault();
            if (record is null) return;
            int index = records.IndexOf(record);
            NgPopupShowForm frm = new NgPopupShowForm(record);
            var res = frm.ShowDialog();
            if (res != DialogResult.OK)
                return;
            records[index] = frm.Model;

            selected[e.RowIndex].Judgement = records[index].Judgement;
            if (type == "TOP")
                TopRecord = selected.ToList();
            else
                BottomRecord = selected.ToList();
            if (isPrevPass && (records[index].Judgement == "NG" || records[index].Judgement == "FAIL"))
            {
                if (type == "TOP")
                    TopDecision = "FAIL";
                else
                    BottomDecision = "FAIL";
                
            }
            else if (!isPrevPass && records[index].Judgement == "PASS")
            {
                var _data = records.Where(x => x.Type.ToLower() == type.ToLower());
                var isPassNow = !_data.Any(x => x.Judgement == "NG" || x.Judgement == "FAIL");
                if (isPassNow)
                {
                    if (type == "TOP")
                        TopDecision = "PASS";
                    else
                        BottomDecision = "PASS";
                    
                }
            }
            if (records.Any(x => x.Judgement == "NG" || x.Judgement == "FAIL"))
            {
                if (isPrevPass)
                {
                    countViewModel = new CountViewModel()
                    {
                        Count = countViewModel.Count,
                        Fail = countViewModel.Fail + 1,
                        Pass = countViewModel.Pass - 1,
                    };
                }
                FinalJudge = "FAIL";
            }
            else
            {
                if (!isPrevPass)
                {
                    countViewModel = new CountViewModel()
                    {
                        Count = countViewModel.Count,
                        Fail = countViewModel.Fail - 1,
                        Pass = countViewModel.Pass + 1,
                    };
                }
                FinalJudge = "PASS";
            }
        }

        private async void DashboardControl_Leave(object sender, EventArgs e)
        {
            if (records.Count > 0)
                await presenter.WriteLog(records);
        }
    }
}
