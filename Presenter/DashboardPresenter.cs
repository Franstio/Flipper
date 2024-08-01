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
using static FVMI_INSPECTION.Presenter.SettingParameterPresenter;
using System.Collections.Frozen;

namespace FVMI_INSPECTION.Presenter
{
    internal class DashboardPresenter : DashboardMVP.IPresenter, IDisposable
    {
        private readonly DashboardMVP.IView view;
        public CancellationTokenSource cTokenSource { get; private set; }
        public CancellationTokenSource cMonitorTokenSource { get;private set; }
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
                var mdl = _model;
                var _lib = fileLib;
                var _view = view;
                _view.TopUVDecision = "";
                _view.TopWhiteDecision = "";
                _view.BottomUVDecision = "";
                _view.BottomWhiteDecision = "";
            }
            presenter.view.CampPoint = _model.CameraPoint;
            await presenter.LoadCampoint();
            return presenter;
        }
        public async Task ResetProcess()
        {
            await process.WriteCommand("MR305", "1");
            var rst = await process.ReadCommand("R006");
            if (rst == "0")
                await process.PushCommand("MR200", 100, "1", "0");
            int loading = 0;
            do
            {
                rst = await process.ReadCommand("R006");
                eventUpdate("Reset in progress" + new string('.', loading));
                loading = (loading + 1) % 6;
            }
            while (!rst.Contains("1"));
            await Task.Delay(1000);
            await process.WriteCommand("MR305", "0");
            await process.WriteCommand("MR302", "0");
            await process.WriteCommand("MR303", "0");
            cTokenSource.Cancel();
            await process.WriteCommand("MR004", 0);
            await process.WriteCommand("DM0", 0);
            await process.WriteCommand("MR010", 0);
            view.StatusRun = "Cancelled...";
            view.SerialNumber = string.Empty;
            view.FinalJudge = string.Empty;
            view.TopUVRecord = new List<ProcessRecordModel>();
            view.BottomUVRecord = new List<ProcessRecordModel>();
            view.TopWhiteRecord = new List<ProcessRecordModel>();
            view.BottomWhiteRecord = new List<ProcessRecordModel>();
            view.topUVImage = null;
            view.topWhiteImage = null;
            view.bottomUVImage = null;
            view.bottomWhiteImage = null;
            view.TopUVDecision = "";
            view.BottomUVDecision = "";
            view.TopWhiteDecision = "";
            view.BottomWhiteDecision = "";

        }
        private DashboardPresenter( DashboardMVP.IView view,MasterModel model,FileLib fileLib,ModelRepository repo)
        {
            this.view = view;
            Model = model;
            this.process = new FVMITCPProcess(model,fileLib);
            cTokenSource = new CancellationTokenSource();
            cMonitorTokenSource = new CancellationTokenSource();
            repository = repo;
            lib = fileLib;
        }
        public async Task LoadCampoint()
        {
            await process.SetupCamPoint();
        }
        public async Task<ProcessResultModel[]> RunProcess()
        {
            view.topUVImage = null;
            view.topWhiteImage = null;
            view.bottomUVImage = null;
            view.bottomWhiteImage = null;
            view.FinalJudge = string.Empty;
            view.TopWhiteRecord = new List<ProcessRecordModel>();
            view.BottomWhiteRecord = new List<ProcessRecordModel>();
            view.TopUVRecord = new List<ProcessRecordModel>();
            view.BottomUVRecord = new List<ProcessRecordModel>();
//            view.StatusRun = view.SerialNumber;
            string res,res2;
            res = await process.WriteCommand("MR004", 1);
            await Task.Delay(100);
            do
            {
                res = await process.ReadCommand("R000");
                res2 = await process.ReadCommand("MR004");
            }
            while (!res.Contains("1") || !res.Contains("1"));
            view.StartTimer();
            await MonitorImageOutput();
            /*ret[0] = await TopProcess();
            view.topUVImage = ret[0].Image;
            ret[1] = await BottomProcess();
            view.topWhiteImage = ret[1].Image;
            string[] data = await process.MonitorCommand("MR8000", "0", cTokenSource.Token);
            res = await process.WriteCommand("MR004", 0);*/
            if (cTokenSource.IsCancellationRequested)
            {
                eventUpdate("Process Cancelled");
                cTokenSource.Dispose();
                cMonitorTokenSource.Dispose();
                cTokenSource = new CancellationTokenSource();
                cMonitorTokenSource = new CancellationTokenSource();
                cMonitorTokenSource.Cancel();
                return [];
            }

            await Task.Delay(500);
            eventUpdate("Writing Record");
            List<ProcessRecordModel>[]?  record = new List<ProcessRecordModel>[4];
            int Count = 0;
            do
            {
                record = await ReadCsv();
                Count = Count + 1;
                await Task.Delay(100);
            }
            while (Count < 100 && record is null);
            if (record is null)
            {
                MessageBox.Show("CSV File Invalid, please check CSV File", "Logging Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                view.StatusRun = "Error: Invalid CSV...";
                return new ProcessResultModel[0];
            }
            if (cTokenSource.IsCancellationRequested)
            {
                eventUpdate("Process Cancelled");
                cTokenSource.Dispose();
                cMonitorTokenSource.Dispose();
                cTokenSource = new CancellationTokenSource();
                cMonitorTokenSource = new CancellationTokenSource();
                cMonitorTokenSource.Cancel();
                return [];
            }
            view.TopUVRecord = record[0].Where(x=>x.Judgement=="NG").ToList() ?? new List<ProcessRecordModel>();
            view.BottomUVRecord = record[1].Where(x=>x.Judgement=="NG").ToList() ?? new List<ProcessRecordModel>();
            view.TopWhiteRecord = record[2].Where(x => x.Judgement == "NG").ToList() ?? new List<ProcessRecordModel>();
            view.BottomWhiteRecord = record[3].Where(x => x.Judgement == "NG").ToList() ?? new List<ProcessRecordModel>();
            bool isFail = record.SelectMany(x => x).Any(x => x.Judgement != "PASS");
            var cvm = new CountViewModel()
            {
                Count = view.countViewModel.Count + 1,
                Fail = isFail ? view.countViewModel.Fail+1 : view.countViewModel.Fail ,
                Pass = isFail ? view.countViewModel.Pass  : view.countViewModel.Pass+1,
            };
            view.countViewModel = cvm;
            eventUpdate($"Completed... {(isFail ? "(Please Click Generate Log)" : "")}" );
            if (record.SelectMany(x => x).Any(x => x.Judgement == "NG" || x.Judgement == "FAIL"))
                view.FinalJudge = "FAIL";
            else
                view.FinalJudge = "PASS";
            var topUvImgSet = await GetImageFVMI(FileLib.FVMI_ProcessType.Top, FileLib.FVMI_Type.UV);
            var bottomUvImgSet = await GetImageFVMI(FileLib.FVMI_ProcessType.Bottom, FileLib.FVMI_Type.UV);
            var topWhiteImgSet = await GetImageFVMI(FileLib.FVMI_ProcessType.Top, FileLib.FVMI_Type.White);
            var bottomWhiteImgSet = await GetImageFVMI(FileLib.FVMI_ProcessType.Bottom, FileLib.FVMI_Type.White);
            ProcessResultModel[] ret =  [
                new ProcessResultModel()
                {
                    Type = FileLib.FVMI_ProcessType.Top.ToString()+ FileLib.FVMI_Type.UV.ToString(),
                    FVMI_Type =  FileLib.FVMI_Type.UV,
                    ProcessType = FileLib.FVMI_ProcessType.Top,
                    ResultJudgement = !view.TopUVRecord.Any(x=>x.Judgement=="NG"),
                    Image = topUvImgSet?.Item2,
                    ImagePath = topUvImgSet?.Item1
                },
                new ProcessResultModel()
                {
                    Type = FileLib.FVMI_ProcessType.Bottom.ToString() + FileLib.FVMI_Type.UV.ToString(),
                    FVMI_Type = FileLib.FVMI_Type.UV,
                    ProcessType = FileLib.FVMI_ProcessType.Bottom,
                    ResultJudgement = !view.BottomUVRecord.Any(x=>x.Judgement=="NG"),
                    Image = bottomUvImgSet?.Item2,
                    ImagePath = bottomUvImgSet?.Item1
                },
                new ProcessResultModel()
                {

                    Type = FileLib.FVMI_ProcessType.Top.ToString() + FileLib.FVMI_Type.White.ToString(),
                    FVMI_Type = FileLib.FVMI_Type.White,
                    ProcessType = FileLib.FVMI_ProcessType.Top,
                    ResultJudgement = !view.TopWhiteRecord.Any(x => x.Judgement == "NG"),
                    Image = topWhiteImgSet?.Item2,
                    ImagePath = topWhiteImgSet?.Item1
                },
                new ProcessResultModel()
                {
                    Type = FileLib.FVMI_ProcessType.Bottom.ToString() + FileLib.FVMI_Type.White.ToString(),
                    FVMI_Type = FileLib.FVMI_Type.White,
                    ProcessType = FileLib.FVMI_ProcessType.Bottom,
                    ResultJudgement = !view.BottomWhiteRecord.Any(x => x.Judgement == "NG"),
                    Image = bottomWhiteImgSet?.Item2,
                    ImagePath = bottomWhiteImgSet?.Item1
                }
            ];
            view.StopTimer();
            return ret;
        }
        private async Task MonitorImageOutput()
        {
            string ret = string.Empty, ret1 = string.Empty ;
            int loading = 0;
            do
            {
                ret = await process.ReadCommand("MR200");
                ret1 = await process.ReadCommand("MR004");
                await Task.Delay(100);
                eventUpdate("Waiting for process complete" + new string('.', loading));
                loading = (loading + 1) % 6;
            }
            while ( (ret.Last() !='1' || ret1.Last() != '1')  && !cMonitorTokenSource.IsCancellationRequested && !cTokenSource.IsCancellationRequested);
            if (cMonitorTokenSource.IsCancellationRequested || cTokenSource.IsCancellationRequested)
            {
                cMonitorTokenSource = new CancellationTokenSource();
                return;
            }
            await Task.Delay(100);
            var topUvImgSet = await GetImageFVMI(FileLib.FVMI_ProcessType.Top, FileLib.FVMI_Type.UV);
            var bottomUvImgSet = await GetImageFVMI(FileLib.FVMI_ProcessType.Bottom, FileLib.FVMI_Type.UV);
            var topWhiteImgSet = await GetImageFVMI(FileLib.FVMI_ProcessType.Top, FileLib.FVMI_Type.White);
            var bottomWhiteImgSet = await GetImageFVMI(FileLib.FVMI_ProcessType.Bottom, FileLib.FVMI_Type.White);
            string bottomWhiteResult = (await process.ReadCommand("DM1000"));
            string bottomUVResult = (await process.ReadCommand("DM1100"));
            string topUVResult = (await process.ReadCommand("DM1200"));
            string topWhiteResult = (await process.ReadCommand("DM1300")) ;
            Func<FVMI_ImageType, string?> getImage = (t) => Model.Details.Where(x => x.Type == t.ToString()).FirstOrDefault()?.Image;
            if (cMonitorTokenSource.IsCancellationRequested || cTokenSource.IsCancellationRequested)
            {
                cMonitorTokenSource = new CancellationTokenSource();
                return;
            }
            view.topUVImage = !topUVResult.Contains("1") ? (getImage(FVMI_ImageType.TopUV) is not null ? lib.ReadImage(getImage(FVMI_ImageType.TopUV)!, true) ?? view.bottomWhiteImage : view.bottomWhiteImage) : topUvImgSet?.Item2;
            view.bottomUVImage = !bottomUVResult.Contains("1")? (getImage(FVMI_ImageType.BottomUV) is not null ? lib.ReadImage(getImage(FVMI_ImageType.BottomUV)!, true) ?? view.bottomUVImage : view.bottomUVImage) : bottomUvImgSet?.Item2;
            view.topWhiteImage = !topWhiteResult.Contains("1")? (getImage(FVMI_ImageType.TopWhite) is not null ? lib.ReadImage(getImage(FVMI_ImageType.TopWhite)!, true) ?? view.topWhiteImage : view.topWhiteImage) : topWhiteImgSet?.Item2;
            view.bottomWhiteImage = !bottomWhiteResult.Contains("1") ? (getImage(FVMI_ImageType.BottomWhite) is not null ? lib.ReadImage(getImage(FVMI_ImageType.BottomWhite)!, true) ?? view.bottomWhiteImage : view.bottomWhiteImage) :bottomWhiteImgSet?.Item2;

            view.TopUVDecision = !topUVResult.Contains("1")? "PASS" : "FAIL";
            view.BottomUVDecision = !bottomUVResult.Contains("1")? "PASS" : "FAIL";
            view.TopWhiteDecision = !topWhiteResult.Contains("1")? "PASS" : "FAIL";
            view.BottomWhiteDecision = !bottomWhiteResult.Contains("1")? "PASS" : "FAIL";
        }
        private async Task<Tuple<string,Image>?> GetImageFVMI(FileLib.FVMI_ProcessType procType,FileLib.FVMI_Type fType)
        {
            var config = Properties.Settings.Default;
            string path = string.Empty;
            if (fType == FileLib.FVMI_Type.UV)
            {
                path = config.UVImgPath;
                if (procType == FileLib.FVMI_ProcessType.Top)
                    path = Path.Combine(path, config.UVTopPrefix);
                else if (procType == FileLib.FVMI_ProcessType.Bottom)
                    path = Path.Combine(path, config.UVBottomPrefix);
            }
            else if (fType == FileLib.FVMI_Type.White)
            {
                path = config.WhiteImgPath;

                if (procType == FileLib.FVMI_ProcessType.Top)
                    path = Path.Combine(path, config.WhiteTopPrefix);
                else if (procType == FileLib.FVMI_ProcessType.Bottom)
                    path = Path.Combine(path, config.WhiteBottomPrefix);
            }
            string[] dir = Directory.GetDirectories(path).OrderByDescending(x=>x).ToArray();
            if (dir is null || dir.Length < 1)
                return null;
            string[] f = await lib.GetFiles(dir[0]);
            if (f is null || f.Length < 1)
                return null;
            await Task.Delay(100);
            return new Tuple<string, Image>(f[0].Split("/")[(f[0].Split("/").Length-1)], Image.FromFile(f[0]));
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
                    ProcessType = resultModel.ProcessType,
                    FVMI_Type = resultModel.FVMI_Type,
                    DateRecorded = DateTime.Now,
                    Serial = serial,
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
            mdl = new List<ProcessRecordModel>[4];
            int count = 0;
            var getConfig = Properties.Settings.Default;
            string[] paths = new string[]
            {
                Path.Combine(getConfig.UVCSVPath,getConfig.UVTopPrefix),
                Path.Combine(getConfig.UVCSVPath,getConfig.UVBottomPrefix),
                Path.Combine(getConfig.WhiteCSVPath,getConfig.WhiteTopPrefix),
                Path.Combine(getConfig.WhiteCSVPath,getConfig.WhiteBottomPrefix)
            };
            for (int i = 0; i < paths.Length; i++)
            {
                await Task.Delay(2000);
                var files = await lib.GetFiles(paths[i]);
                if (files is null || files.Length < 1)
                    throw new Exception(paths[i] + " Empty");
                List<ProcessRecordModel> list = new List<ProcessRecordModel>();
                using (var stream = new FileStream(files[0], FileMode.Open))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string? text = await reader.ReadLineAsync();
                        if (text is null) throw new Exception(files[0] + " Is empty");
                        string? row= await reader.ReadLineAsync();
                        if (row is null) throw new Exception(files[0] + " 2nd Row Is empty");
                        list.AddRange(ReadRecord(text, row));
                        mdl[i] = list;
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
            if (records is null || records.Count < 1)
                return;
            var dt = records.Where(x => x.Judgement == "NG" || x.Judgement == "FAIL").ToArray();
            var grouped = dt.GroupBy(x => x.Type);
            var keys = grouped.Select(x => new KeyValuePair<string,string[]>( x.Key, x.Select(x => x.Area).ToArray()) );
            Dictionary<string, string[]> data = new Dictionary<string, string[]>(keys);
            var failures = dt.Where(x=>x.Reason != null && x.Reason != "").Select(x => $"{x.Area}:{x.Reason}").ToArray();
            LogModel model = new LogModel()
            {
                Model = view.modelName,
                SN = records.First()!.Serial,
                Status = view.FinalJudge,
                Failure = failures.Length < 1 ? "" : string.Join(";", failures),
                TopFailTool = data.ContainsKey("TopWhite") && data["TopWhite"].Length > 0 ? string.Join(";", data["TopWhite"]) : "NONE",
                TopUvFailTool = data.ContainsKey("TopUV") && data["TopUV"].Length >0 ? string.Join(";", data["TopUV"]) : "NONE",
                BotFailTool = data.ContainsKey("BottomWhite")  && data["BottomWhite"].Length >  0? string.Join(";",data["BottomWhite"]) : "NONE",
                BotUVFailTool = data.ContainsKey("BottomUV") && data["BottomUV"].Length > 0 ? string.Join(";", data["BottomUV"]) : "NONE",
            };
            var log = lib.GenerateLog(model);
            view.LogLabel = await lib.WriteLog(records.FirstOrDefault()?.Serial ?? "", log, view.FinalJudge);
            try
            {
                await repository.WriteLog(records);
            }
            catch
            {

            }
        }

        public async Task CheckReset()
        {
            var rst = await process.ReadCommand("MR010");
            view.AllowReset = rst == "1";
        }
    }
}
