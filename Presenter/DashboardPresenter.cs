using FVMI_INSPECTION.Repositories;
using FVMI_INSPECTION.Interfaces;
using FVMI_INSPECTION.Models;
using FVMI_INSPECTION.Models.ViewData;
using FVMI_INSPECTION.TCP;
using FVMI_INSPECTION.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Security.Policy;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Security.Cryptography;

namespace FVMI_INSPECTION.Presenter
{
    internal class DashboardPresenter : DashboardMVP.IPresenter, IDisposable
    {
        private readonly DashboardMVP.IView view;
        public CancellationTokenSource cTokenSource { get; private set; }
        private FVMITCPProcess process;
        private ModelRepository repository;
        private MasterModel Model;
        private FileLib lib;
        public static async Task<DashboardPresenter?> Build(DashboardMVP.IView view,string model,FileLib fileLib,ModelRepository repo)
        {
            var list = await repo.GetModel(model);
            if (list.Count < 1)
                return null;
            var _model = list.First();
            var presenter = new DashboardPresenter(view, _model, fileLib, repo);
            if (_model.Details.Count() > 0)
            {

                var top = _model.Details.Where(x => x.Type == "Top").FirstOrDefault();
                if (top is not null)
                    view.TopParameterImage = fileLib.ReadImage(top.Image, true) ?? view.TopParameterImage;
                var bottom = _model.Details.Where(x => x.Type == "Bottom").FirstOrDefault();
                if (bottom is not null)
                    view.BottomParameterImage = fileLib.ReadImage(bottom.Image, true) ?? view.BottomParameterImage;
            }
            presenter.view.CampPoint = _model.CameraPoint;
            await presenter.LoadCampoint();
            return presenter;
        }
        public async Task ResetProcess()
        {
            await process.PushCommand("MR2000", 300, "1", "0");
            cTokenSource.Cancel();
            cTokenSource.Dispose();
            cTokenSource = new CancellationTokenSource();
            view.StatusRun = "Cancelled...";
            view.SerialNumber = string.Empty;
            view.FinalJudge = string.Empty;
            view.TopRecord = new List<ProcessRecordModel>();
            view.BottomRecord = new List<ProcessRecordModel>();
            view.TopDecision = "-";
            view.BottomDecision = "-";
        }
        private DashboardPresenter( DashboardMVP.IView view,MasterModel model,FileLib fileLib,ModelRepository repo)
        {
            this.view = view;
            Model = model;
            this.process = new FVMITCPProcess(model,fileLib);
            cTokenSource = new CancellationTokenSource();
            repository = repo;
            lib = fileLib;
        }
        public async Task LoadCampoint()
        {
            await process.SetupCamPoint();
        }
        public async Task<ProcessResultModel[]> RunProcess()
        {
            view.FinalJudge = string.Empty;
            view.TopRecord = new List<ProcessRecordModel>();
            view.BottomRecord = new List<ProcessRecordModel>();
            view.TopDecision = "-";
            view.BottomDecision = "-";
            view.StatusRun = view.SerialNumber;
            string res;
            ProcessResultModel[] ret = new ProcessResultModel[2];
            res = await process.WriteCommand("MR004", 1);
            ret[0] = await TopProcess();
            view.TopActualImage = ret[0].Image;
            ret[1] = await BottomProcess();
            view.BottomActualImage = ret[1].Image;
            string[] data = await process.MonitorCommand("MR8000", "0", cTokenSource.Token);
            res = await process.WriteCommand("MR004", 0);
            eventUpdate("Writing Record");
            await Task.Delay(1200);
            var record = await ReadCsv();
            if (record is null)
            {
                MessageBox.Show("CSV File Invalid, please check CSV File","Logging Error",MessageBoxButtons.OK, MessageBoxIcon.Error);

                view.StatusRun = "Error: Invalid CSV...";
                return new ProcessResultModel[0];
            }
            view.TopDecision = record[1].Any(x => x.Judgement == "NG") ? "FAIL" : "PASS";
            view.BottomDecision = record[0].Any(x => x.Judgement == "NG") ? "FAIL" : "PASS";
            view.TopRecord = record[1].Where(x=>x.Judgement=="NG").ToList() ?? new List<ProcessRecordModel>();
            view.BottomRecord = record[0].Where(x=>x.Judgement=="NG").ToList() ?? new List<ProcessRecordModel>();
            var cvm = new CountViewModel()
            {
                Count = view.countViewModel.Count + 1,
                Fail = (view.TopDecision == "PASS" && view.BottomDecision == "PASS") ? view.countViewModel.Fail : view.countViewModel.Fail + 1,
                Pass = (view.TopDecision == "PASS" && view.BottomDecision == "PASS") ? view.countViewModel.Pass + 1 : view.countViewModel.Pass,
            };
            view.countViewModel = cvm;
            eventUpdate("Completed...");
            if (record.SelectMany(x => x).Any(x => x.Judgement == "NG" || x.Judgement == "FAIL"))
                view.FinalJudge = "FAIL";
            else
                view.FinalJudge = "PASS";
            return ret;
        }
        public List<RecordModel> GenerateRecordModel(ProcessResultModel resultModel, ProcessRecordModel[] pRecordModel,string modelName,string serial)
        {
            List<RecordModel> recordModels = new List<RecordModel>();
            for (int j = 0; j < pRecordModel.Length; j++)
            {
                recordModels.Add(new RecordModel()
                {
                    ActualImage = resultModel.ImagePath!,
                    Area = pRecordModel[j].Area,
                    Judgement = pRecordModel[j].Judgement,
                    Model = modelName,
                    Type = resultModel.Type,
                    DateRecorded = DateTime.Now,
                    Serial = serial
                });
            }
            return recordModels;
        }
        private void eventUpdate(string status) => view.StatusRun = status;
        public async Task<ProcessResultModel> TopProcess()
        {

            string[] data;
            eventUpdate("Waiting for start Button (Top)");
            data = await process.MonitorCommand("MR8000", "1", cTokenSource.Token);
            eventUpdate("Running....");
//            string[] a = await process.PushCommand("MR300", 500, "0", "1", "0");
            bool result = await process.TriggerCam("MR1000","MR1001");
            await Task.Delay(1000);
            Image? img = result ? GetLocalImage("Top") : await process.GetNgImage("Top");

            string? imgPath = result ? GetLocalImagePath("Top") : await process.GetNgImagePath("Top");
            return new ProcessResultModel()
            {
                Image = img,
                ResultJudgement = result,
                ImagePath = imgPath,
                Type="Top"
            };
        }
        public Image? GetLocalImage(string type)
        {
            DetailModel? dtl = Model.Details.Where(x => x.Type == type).FirstOrDefault();
            if (dtl is null)
                return null;
            return lib.ReadImage(dtl.Image, local: true);
        }
        public string? GetLocalImagePath(string type)
        {
            DetailModel? dtl = Model.Details.Where(x => x.Type == type).FirstOrDefault();
            if (dtl is null)
                return null;
            return Path.Combine(lib._savePath, dtl.Image);// lib.ReadImage(dtl.Image, local: true);
        }
        public async Task<ProcessResultModel> BottomProcess()
        {
            string[] data;
            eventUpdate("Waiting for start Button (Bottom)");
            data = await process.MonitorCommand("MR8001", "1", cTokenSource.Token);
            eventUpdate("Running....");
            string res;

            //string[] a = await process.PushCommand("MR300", 500, "0", "1", "0");
            //res = await WriteCommand("W0F8", model.CameraPoint);
            bool result = await process.TriggerCam("MR1000", "MR1001",false);

            data = await process.MonitorCommand("MR8000", "0", cTokenSource.Token);
            await Task.Delay(500);

            Image? img = result ? GetLocalImage("Bottom") : await process.GetNgImage("Bottom");
            //            string[] check = await PushCommand("MR400", "0", "1");

            string? imgPath = result ? GetLocalImagePath("Bottom") : await process.GetNgImagePath("Bottom");
            return new ProcessResultModel()
            {
                Image = img,
                ResultJudgement = result,
                ImagePath = imgPath,
                Type="Bottom"
            };
        }

        public async Task<List<ProcessRecordModel>[]?> ReadCsv()
        {
            List<ProcessRecordModel>[]? mdl = null;
            var files = await lib.GetFiles(lib.CSVPath);
            if (files.Length < 2) return null;
            mdl = new List<ProcessRecordModel>[2];
            int count = 0;
            for (int i = 0; i < 2; i++)
            {
                await Task.Delay(1000);
                List<ProcessRecordModel> list = new List<ProcessRecordModel>();
                using (var stream = new FileStream(Path.Combine(lib.CSVPath, files[i]), FileMode.Open))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string? text = await reader.ReadLineAsync();
                        if (text is null) return null;
                        string? row= await reader.ReadLineAsync();
                        if (files[i].Contains("U0051"))
                            row = await reader.ReadLineAsync();
                        if (row is null)
                            return null;
                        list.AddRange(ReadRecord(text, row));
                        mdl[count] = list;
                        count++;
                    }
                }
            }
            return mdl;
        }
        private List<ProcessRecordModel> ReadRecord(string col, string row)
        {
            List<ProcessRecordModel> l = new List<ProcessRecordModel>() ;
            string[] cols = col.Split(",");
            string[] rows = row.Split(',');
            if (cols.Length != rows.Length)
                throw new Exception("Area & Result Count invalid");
            for (int j = 0; j < cols.Length; j++)
            {
                var _mdl = new ProcessRecordModel()
                {
                    Area = cols[j],
                    Judgement = rows[j] == "1" ? "NG" : "PASS"
                };
                l.Add(_mdl);
            }
            return l;
        }
        public void Dispose()
        {
            process.cTokenSource.Cancel();
            process.Disconnect();
        }

        public async Task WriteLog(List<RecordModel> records)
        {
            await repository.WriteLog(records);
        }
    }
}
