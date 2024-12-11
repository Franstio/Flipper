using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< Updated upstream
=======
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Security.Policy;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Security.Cryptography;
using static FVMI_INSPECTION.Presenter.SettingParameterPresenter;
using System.Collections.Frozen;
using System.Diagnostics;
using System.Reflection.Metadata;
using ClosedXML.Excel;
>>>>>>> Stashed changes

namespace FVMI_INSPECTION.Presenter
{
    internal class DashboardPresenter
    {
<<<<<<< Updated upstream
=======
        private readonly DashboardMVP.IView view;
        public CancellationTokenSource cTokenSource { get; private set; }
        public CancellationTokenSource cMonitorTokenSource { get;private set; }
        private FVMITCPProcess process;
        private FVMITCPProcess pocesssReset;
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
            await presenter.ToggleUV(_model.isUV);
            await presenter.LoadCampoint();
            return presenter;
        }
        public async Task ResetProcess()
        {
            await process.WriteCommand("MR101", 1);
            await process.WriteCommand("DM0", 0);
            await process.WriteCommand("MR004", 0);
            await process.WriteCommand("MR201", 0);
            string retWait = string.Empty;
            do
            {
                retWait = await process.ReadCommand("R003");
            }
            while (retWait != "1");
            await process.WriteCommand("MR200", 0);
            await process.WriteCommand("MR5000", 0);
            await process.WriteCommand("MR5001", 0);
            await process.WriteCommand("MR5002", 0);
            await process.WriteCommand("MR5003", 0);
            await process.WriteCommand("MR400", 0);
//            await process.WriteCommand("MR010", 0);
            cTokenSource.Cancel();
            view.StatusRun = "Please scan code";
            view.EnableControls();
            view.ResetControls();
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
            view.EmergencyActive = false;
            view.AllowReset = false;

        }
        private DashboardPresenter( DashboardMVP.IView view,MasterModel model,FileLib fileLib,ModelRepository repo)
        {
            this.view = view;
            Model = model;
            this.process = new FVMITCPProcess(model,fileLib);
            this.pocesssReset = new FVMITCPProcess(model, fileLib);
            process.setLog(false);
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
            eventUpdate("Press Start Button..");
            cTokenSource = new CancellationTokenSource();
            cMonitorTokenSource = new CancellationTokenSource();
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
//            view.tReset =  Task.Run(view.CheckResetTask);
            do
            {
                res = await process.ReadCommand("R000");
                res2 = await process.ReadCommand("MR004");
            }
            while (!res.Contains("1") || !res.Contains("1"));
            view.StartTimer();
            var imageMonitor = await MonitorImageOutput();
            /*ret[0] = await TopProcess();
            view.topUVImage = ret[0].Image;
            ret[1] = await BottomProcess();
            view.topWhiteImage = ret[1].Image;
            string[] data = await process.MonitorCommand("MR8000", "0", cTokenSource.Token);
            res = await process.WriteCommand("MR004", 0);*/
            if (cTokenSource.IsCancellationRequested)
            {
                eventUpdate("Process Cancelled, Please Click Reset");
                cTokenSource.Dispose();
                cMonitorTokenSource.Dispose();
                cTokenSource = new CancellationTokenSource();
                cMonitorTokenSource = new CancellationTokenSource();
                cMonitorTokenSource.Cancel();
                return [];
            }
            Func<Task<string>> checkOrigin = async () => await process.ReadCommand("R003");
            var t1 = Task.Run(async delegate
            {
                int loading = 0;
                while ((await checkOrigin()).Last() != '1' && !cTokenSource.IsCancellationRequested)
                {
                    Debug.WriteLine("Check origin....");
                    eventUpdate("Waiting Origin" + new string('.', loading));
                    await Task.Delay(50);
                    loading = (loading + 1) % 3;
                }
                view.StopTimer();
                if (cTokenSource.IsCancellationRequested)
                    return;
            });
//            await Task.Delay(500);
  //          eventUpdate("Writing Record");
            List<ProcessRecordModel>[]?  record = new List<ProcessRecordModel>[4];
            int Count = 0;
            do
            {
                record = await ReadCsv();
                if (cTokenSource.IsCancellationRequested)
                    continue;
                Count = Count + 1;
                await Task.Delay(100);
            }
            while (Count < 100 && record is null && !cTokenSource.IsCancellationRequested) ; 
            if (cTokenSource.IsCancellationRequested)
            {
                eventUpdate("Process Cancelled, Please Click Reset");
                cTokenSource.Dispose();
                cMonitorTokenSource.Dispose();
                cTokenSource = new CancellationTokenSource();
                cMonitorTokenSource = new CancellationTokenSource();
                cMonitorTokenSource.Cancel();
                return [];
            }
            if (record is null)
            {
                MessageBox.Show("CSV File Invalid, please check CSV File", "Logging Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                view.StatusRun = "Error: Invalid CSV...";
                return new ProcessResultModel[0];
            }
            try
            {
                cTokenSource.Token.ThrowIfCancellationRequested();

                view.TopUVRecord = Model.isUV ? record[0].Where(x => x.Judgement == "NG").ToList() ?? new List<ProcessRecordModel>() : [];
                view.BottomUVRecord = Model.isUV ? record[1].Where(x => x.Judgement == "NG").ToList() ?? new List<ProcessRecordModel>() : [];
                view.TopWhiteRecord = record[2].Where(x => x.Judgement == "NG").ToList() ?? new List<ProcessRecordModel>();
                view.BottomWhiteRecord = record[3].Where(x => x.Judgement == "NG").ToList() ?? new List<ProcessRecordModel>();
                bool isFail = record.SelectMany(x => x).Any(x => x.Judgement != "PASS");
                var cvm = new CountViewModel()
                {
                    Count = view.countViewModel.Count + 1,
                    Fail = isFail ? view.countViewModel.Fail + 1 : view.countViewModel.Fail,
                    Pass = isFail ? view.countViewModel.Pass : view.countViewModel.Pass + 1,
                };
                view.countViewModel = cvm;
                if (record.SelectMany(x => x).Any(x => x.Judgement == "NG" || x.Judgement == "FAIL"))
                    view.FinalJudge = "FAIL";
                else
                    view.FinalJudge = "PASS";
                if (imageMonitor is null || imageMonitor.Length < 1)
                    throw new Exception("Image Not Available");
                var topUvImgSet = imageMonitor[0]; //await GetImageFVMI(FileLib.FVMI_ProcessType.Top, FileLib.FVMI_Type.UV);
                var bottomUvImgSet = imageMonitor[1];//await GetImageFVMI(FileLib.FVMI_ProcessType.Bottom, FileLib.FVMI_Type.UV);
                var topWhiteImgSet = imageMonitor[2];//await GetImageFVMI(FileLib.FVMI_ProcessType.Top, FileLib.FVMI_Type.White);
                var bottomWhiteImgSet = imageMonitor[3];// await GetImageFVMI(FileLib.FVMI_ProcessType.Bottom, FileLib.FVMI_Type.White);
                ProcessResultModel[] ret = [
                    new ProcessResultModel()
                    {
                        Type = FileLib.FVMI_ProcessType.Top.ToString() + FileLib.FVMI_Type.UV.ToString(),
                        FVMI_Type = FileLib.FVMI_Type.UV,
                        ProcessType = FileLib.FVMI_ProcessType.Top,
                        ResultJudgement = !view.TopUVRecord.Any(x => x.Judgement == "NG"),
                        Image = topUvImgSet?.Item2,
                        ImagePath = topUvImgSet?.Item1
                    },
                    new ProcessResultModel()
                    {
                        Type = FileLib.FVMI_ProcessType.Bottom.ToString() + FileLib.FVMI_Type.UV.ToString(),
                        FVMI_Type = FileLib.FVMI_Type.UV,
                        ProcessType = FileLib.FVMI_ProcessType.Bottom,
                        ResultJudgement = !view.BottomUVRecord.Any(x => x.Judgement == "NG"),
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
                view.EmergencyActive = false;

                eventUpdate($"Completed... {(isFail ? "(Confirm Result and Click Generate Log)" : "")}");
                return ret;
            }
            catch(OperationCanceledException e ) when (e.CancellationToken == cTokenSource.Token)
            {
                return [];
            }
        }
        private async Task<Tuple<string, Image>?[]?> MonitorImageOutput()
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
                return null;
            }
            try
            {
                cTokenSource.Token.ThrowIfCancellationRequested();
                await Task.Delay(100);
                Task<Tuple<string, Image>?>[] getImagesTask =
                [
                    GetImageFVMI(FileLib.FVMI_ProcessType.Top, FileLib.FVMI_Type.UV),
                    GetImageFVMI(FileLib.FVMI_ProcessType.Bottom, FileLib.FVMI_Type.UV),
                    GetImageFVMI(FileLib.FVMI_ProcessType.Top, FileLib.FVMI_Type.White),
                    GetImageFVMI(FileLib.FVMI_ProcessType.Bottom, FileLib.FVMI_Type.White)
                ];
                var data = await Task.WhenAll(getImagesTask);
                var topUvImgSet = data[0];//await GetImageFVMI(FileLib.FVMI_ProcessType.Top, FileLib.FVMI_Type.UV);
                var bottomUvImgSet = data[1]; //GetImageFVMI(FileLib.FVMI_ProcessType.Bottom, FileLib.FVMI_Type.UV);
                var topWhiteImgSet = data[2];//GetImageFVMI(FileLib.FVMI_ProcessType.Top, FileLib.FVMI_Type.White);
                var bottomWhiteImgSet = data[3];//GetImageFVMI(FileLib.FVMI_ProcessType.Bottom, FileLib.FVMI_Type.White);
                string bottomWhiteResult = (await process.ReadCommand("DM1000"));
                string bottomUVResult = (await process.ReadCommand("DM1100"));
                string topUVResult = (await process.ReadCommand("DM1200"));
                string topWhiteResult = (await process.ReadCommand("DM1300"));
                Func<FVMI_ImageType, string?> getImage = (t) => Model.Details.Where(x => x.Type == t.ToString()).FirstOrDefault()?.Image;
                if (cMonitorTokenSource.IsCancellationRequested || cTokenSource.IsCancellationRequested)
                {
                    cMonitorTokenSource = new CancellationTokenSource();
                    return null;
                }
                view.topUVImage = !topUVResult.Contains("1") ? (getImage(FVMI_ImageType.TopUV) is not null ? lib.ReadImage(getImage(FVMI_ImageType.TopUV)!, true) ?? view.bottomWhiteImage : view.bottomWhiteImage) : topUvImgSet?.Item2;
                view.bottomUVImage = !bottomUVResult.Contains("1") ? (getImage(FVMI_ImageType.BottomUV) is not null ? lib.ReadImage(getImage(FVMI_ImageType.BottomUV)!, true) ?? view.bottomUVImage : view.bottomUVImage) : bottomUvImgSet?.Item2;
                view.topWhiteImage = !topWhiteResult.Contains("1") ? (getImage(FVMI_ImageType.TopWhite) is not null ? lib.ReadImage(getImage(FVMI_ImageType.TopWhite)!, true) ?? view.topWhiteImage : view.topWhiteImage) : topWhiteImgSet?.Item2;
                view.bottomWhiteImage = !bottomWhiteResult.Contains("1") ? (getImage(FVMI_ImageType.BottomWhite) is not null ? lib.ReadImage(getImage(FVMI_ImageType.BottomWhite)!, true) ?? view.bottomWhiteImage : view.bottomWhiteImage) : bottomWhiteImgSet?.Item2;

                view.TopUVDecision = !Model.isUV ? "N\\A"  : !topUVResult.Contains("1") ? "PASS" : "FAIL";
                view.BottomUVDecision = !Model.isUV ? "N\\A" : !bottomUVResult.Contains("1") ? "PASS" : "FAIL";
                view.TopWhiteDecision = !topWhiteResult.Contains("1") ? "PASS" : "FAIL";
                view.BottomWhiteDecision = !bottomWhiteResult.Contains("1") ? "PASS" : "FAIL";
                return data;
            }
            catch(OperationCanceledException e) when (e.CancellationToken == cTokenSource.Token)
            {
                return null;
            }
        }
        private async Task<Tuple<string,Image>?> GetImageFVMI(FileLib.FVMI_ProcessType procType,FileLib.FVMI_Type fType,int delay=9000)
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
            await Task.Delay(delay);
//            string[] dir = Directory.GetDirectories(path).OrderByDescending(x=>x).ToArray();
            DirectoryInfo info = new DirectoryInfo(path);
            DirectoryInfo[] infos = info.GetDirectories();
            string[] dir = infos.OrderByDescending(x => x.CreationTime).Select(x => x.FullName).ToArray();
            if (dir is null || dir.Length < 1)
                return null;
            string[] f = await lib.GetFiles(dir[0]);
            if (f is null || f.Length < 1)
                return null;
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
            bool[] checkResult = [view.TopUVDecision == "PASS" || !Model.isUV, view.BottomUVDecision == "PASS" || !Model.isUV, view.TopWhiteDecision == "PASS", view.BottomWhiteDecision == "PASS"];
            for (int i = 0; i < paths.Length; i++)
            {
                if (checkResult[i])
                {
                    mdl[i] = new List<ProcessRecordModel>();
                    continue;
                }
                await Task.Delay(100);
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
                    Area = cols[j].Contains("time_") ? "" : cols[j],
                    Judgement = rows[j] == "1" ? "NG" : (rows[j] != "0" && rows[j] != "1" ? "PASS" : null),
                    timeprocess = rows[j] != "0" && rows[j] != "1" ? rows[j] : null
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

        public async Task WriteLogAndGenerateExcelAsync(List<RecordModel> records,string sn)
        {
            if (records is null )
                return;
            var dt = records.ToArray();
            var grouped = dt.GroupBy(x => x.Type);
            var keys = grouped.Select(x => new KeyValuePair<string,string[]>( x.Key, x.Select(x => x.Area).ToArray()) );
            Dictionary<string, string[]> data = new Dictionary<string, string[]>(keys);
            var failures = dt.Where(x=>x.Reason != null && x.Reason != "").Select(x => $"{x.Area}:{x.Reason}").ToArray();
            LogModel model = new LogModel()
            {
                Model = view.modelName,
                SN = sn,
                Status = view.FinalJudge,
                Failure = failures.Length < 1 ? "" : string.Join(";", failures),
                TopFailTool = data.ContainsKey("TopWhite") && data["TopWhite"].Length > 0 ? string.Join(";", data["TopWhite"]) : "NONE",
                TopUvFailTool = !Model.isUV ? "N\\A" : data.ContainsKey("TopUV") && data["TopUV"].Length >0 ? string.Join(";", data["TopUV"]) : "NONE",
                BotFailTool = data.ContainsKey("BottomWhite")  && data["BottomWhite"].Length >  0? string.Join(";",data["BottomWhite"]) : "NONE",
                BotUVFailTool = !Model.isUV ? "N\\A" : data.ContainsKey("BottomUV") && data["BottomUV"].Length > 0 ? string.Join(";", data["BottomUV"]) : "NONE",
            };
            var log = lib.GenerateLog(model);
            view.LogLabel = await lib.WriteLog(sn, log, view.FinalJudge);
            try
            {
                await repository.WriteLog(records);
            }
            catch
            {

            }
        }

        public async Task WriteLog(List<RecordModel> x, string sn)
        {
            var csvData = await ReadCsv();

            var records = csvData.SelectMany(x => x ?? new List<ProcessRecordModel>()).ToList();

            if (!records.Any())
                return;

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Records Data");

                worksheet.Cell(1, 1).Value = "Area";
                worksheet.Cell(1, 2).Value = "Judgemnet";
                worksheet.Cell(1, 3).Value = "Time Process";
                worksheet.Cell(1, 1).Style.Font.Bold = true;
                worksheet.Cell(1, 2).Style.Font.Bold = true;
                worksheet.Cell(1, 3).Style.Font.Bold = true;
                worksheet.Cell(1, 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(1, 2).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(1, 3).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                var uniqueAreas = records.Select(r => r.Area).Distinct().ToList();
                for (int i = 1; i < (uniqueAreas.Count + 1); i++)
                {
                    worksheet.Cell(i+1, 1).Value = uniqueAreas[i-1];
                    worksheet.Cell(i+1, 1).Style.Font.Bold = true;
                    worksheet.Cell(i+1, 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }

                int p = 0; int q = 0;

                for (int i = 1; i < (records.Count + 1); i++)
                {
                    for (int j = 0; j < uniqueAreas.Count; j++)
                    {
                        if (records[i-1].Area == uniqueAreas[j])
                        {
                            if (records[i-1].Area == x[q].Area && x[q].Area != null && records[i-1].Area != null) {
                                worksheet.Cell(i + 2, j + 1).Value = records[i-1].Judgement == x[q].Judgement ? records[i-1].Judgement : x[q].Judgement;
                                q++;
                            } else {
                                worksheet.Cell(i + 2, j + 1).Value = records[i-1].Judgement;
                            }
                            worksheet.Cell(i + 2, j+1).Style.Font.Bold = true;
                            worksheet.Cell(i + 2, j+1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        }
                        else if (records[i-1].timeprocess != null)
                        {
                            worksheet.Cell(p + 1, 3).Value = records[i-1].timeprocess;
                            worksheet.Cell(p + 1, 3).Style.Font.Bold = true;
                            worksheet.Cell(p + 1, 3).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        }
                    }
                }

                var filePath = Path.Combine("C:\\Logs", $"log_{sn}.xlsx");
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                workbook.SaveAs(filePath);
            }

            try
            {
                WriteLogAndGenerateExcelAsync(x, sn);
            }
            catch
            {

            }
        }

        public async Task ToggleUV(bool value)
        {
            view.UVStatus = value;
            await process.WriteCommand("MR2100", value ? 0 : 1);
        }
        public async Task CheckReset()
        {
            var rst = await this.pocesssReset.ReadCommand("MR2000");
            bool valreset = rst == "1";
            
            Debug.WriteLine($"Reset Detected : {valreset} {view.ProcessTimeRun}");
            if (!view.AllowReset && valreset)
            {
                view.CancelResetTask();
                view.AllowReset = valreset;
                view.EmergencyActive = true;
                view.StopTimer();
                cTokenSource.Cancel();
                
                cMonitorTokenSource.Cancel();
                //                eventUpdate("Emergency Active");
                eventUpdate("Process Cancelled, Please Click Reset");
            }
        }
>>>>>>> Stashed changes
    }
}
