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

namespace FVMI_INSPECTION.Presenter
{
    internal class DashboardPresenter : DashboardMVP.Presenter, IDisposable
    {
        private readonly DashboardMVP.View view;
        public CancellationTokenSource cTokenSource { get; private set; }
        private FVMITCPProcess process;
        private ModelRepository repository;
        private FileLib lib;
        public static async Task<DashboardPresenter?> Build(DashboardMVP.View view,string model,FileLib fileLib,ModelRepository repo)
        {
            var list = await repo.GetModel(model);
            if (list.Count < 1)
                return null;
            var _model = list.First();
            var presenter = new DashboardPresenter(view, _model, fileLib, repo);
            presenter.view.CampPoint = int.Parse(_model.CameraPoint.ToString());
            return presenter;
        }
        private DashboardPresenter( DashboardMVP.View view,MasterModel model,FileLib fileLib,ModelRepository repo)
        {
            this.view = view;
            this.process = new FVMITCPProcess(model,fileLib);
            cTokenSource = new CancellationTokenSource();
            repository = repo;
            lib = fileLib;
        }
        public async Task<ProcessResultModel?> RunProcess()
        {
            view.StatusRun = view.SerialNumber;
            string res;
            ProcessResultModel? ret = null;
            res = await process.WriteCommand("MR004", 1);
            ret = await TopProcess();
            ret = await BottomProcess();
            string[] data = await process.MonitorCommand("MR8000", "0", cTokenSource.Token);
            res = await process.WriteCommand("MR004", 0);
            eventUpdate("Completed...");
            return ret;
        }
        private void eventUpdate(string status) => view.StatusRun = status;
        public async Task<ProcessResultModel> TopProcess()
        {

            string[] data;
            eventUpdate("Waiting for start Button (Top)");
            data = await process.MonitorCommand("MR8000", "1", cTokenSource.Token);
            eventUpdate("Running....");
            string res;
            string[] a = await process.PushCommand("MR300", 500, "0", "1", "0");
            bool result = true;// await TriggerCam("MR1000","MR1001");
            Image? img = null;//result ? GetLocalImage("Top") : await GetNgImage("Top");
            return new ProcessResultModel()
            {
                Image = img,
                ResultJudgement = result
            };
        }

        public async Task<ProcessResultModel> BottomProcess()
        {
            string[] data;
            eventUpdate("Waiting for start Button (Bottom)");
            data = await process.MonitorCommand("MR8001", "1", cTokenSource.Token);
            eventUpdate("Running....");
            string res;

            string[] a = await process.PushCommand("MR300", 500, "0", "1", "0");
            //res = await WriteCommand("W0F8", model.CameraPoint);
            bool result = true;//await TriggerCam("MR1000", "MR1001");
            Image? img = null; //result ? GetLocalImage("Bottom") : await GetNgImage("Bottom");
                               //            string[] check = await PushCommand("MR400", "0", "1");
            return new ProcessResultModel()
            {
                Image = img,
                ResultJudgement = result
            };
        }

        public async Task<ProcessRecordModel?> ReadCsv()
        {
            ProcessRecordModel? mdl = null;
            var files = await lib.GetFiles(lib.CSVPath);
            if (files.Length < 1) return null;
            using (var stream = new FileStream(Path.Combine(lib.CSVPath, files[0]), FileMode.Open))
            {
                using (var reader = new StreamReader(stream))
                {
                    string? text = await reader.ReadLineAsync();
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

        public void Dispose()
        {
            process.cTokenSource.Cancel();
            process.Disconnect();
        }
    }
}
