using FVMI_INSPECTION.DAL;
using FVMI_INSPECTION.Models;
using FVMI_INSPECTION.Models.ViewData;
using FVMI_INSPECTION.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FVMI_INSPECTION.TCP
{
    public class FVMITCPProcess : FVMITcpClient
    {
        private readonly FileLib lib;
        public readonly MasterModel model;
        private readonly int CameraDelay = 100;
        public delegate void SimpleNotifyEvent(string status);
        public SimpleNotifyEvent eventUpdate { get; set; }

        public CancellationTokenSource cTokenSource { get; private set; } = new CancellationTokenSource();
        public enum DashboardProcessType
        {
            Top,
            Bottom
        }

        public FVMITCPProcess(MasterModel model,FileLib _lib) : base()
        {
            this.model = model;
            CameraDelay = int.Parse(Properties.Settings.Default["NgCameraDelay"].ToString() ?? "0");
            lib = _lib;
        }
        public async Task<ProcessResultModel?> RunProcess(DashboardProcessType type)
        {
            string res;
            ProcessResultModel? ret=null;
            res = await WriteCommand("MR004", 1);
            switch(type)
            {
                case DashboardProcessType.Top:
                    ret = await TopProcess();
                    break;
                case DashboardProcessType.Bottom:
                    ret = await BottomProcess();
                    break;
            }

            res = await WriteCommand("MR004", 0);
            eventUpdate("Completed...");
            return ret;

        }

        public async Task<ProcessResultModel?> RunProcess()
        {
            string res;
            ProcessResultModel? ret = null;
            res = await WriteCommand("MR004", 1);
            ret = await TopProcess();
            ret = await BottomProcess();
            string[] data = await MonitorCommand("MR8000", "0", cTokenSource.Token);
            res = await WriteCommand("MR004", 0);
            eventUpdate("Completed...");
            return ret;

        }
        public async Task<ProcessResultModel> TopProcess()
        {
            string[] data;
            eventUpdate("Waiting for start Button (Top)");
            data = await MonitorCommand("MR8000", "1", cTokenSource.Token);
            eventUpdate("Running....");
            string res;
            string[] a = await PushCommand("MR300", 500, "0", "1", "0");
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
            data = await MonitorCommand("MR8001", "1", cTokenSource.Token);
            eventUpdate("Running....");
            string res;
            
            string[] a = await PushCommand("MR300",500, "0","1","0");
            //res = await WriteCommand("W0F8", model.CameraPoint);
            bool result = true ;//await TriggerCam("MR1000", "MR1001");
            Image? img = null; //result ? GetLocalImage("Bottom") : await GetNgImage("Bottom");
//            string[] check = await PushCommand("MR400", "0", "1");
            return new ProcessResultModel()
            {
                Image = img,
                ResultJudgement = result
            };
        }
        private Image? GetLocalImage(string type)
        {
            DetailModel? dtl = model.Details.Where(x=>x.Type==type).FirstOrDefault();
            if (dtl is null)
                return null;
            return lib.ReadImage(dtl.Image,local:true);
        }
        public async Task<bool> TriggerCam(string passCmd,string ngCmd)
        {
            string res = string.Empty;
            res = await WriteCommand("MR300", 0);
            res = await WriteCommand("W0F8", model.CameraPoint);
            res = await WriteCommand("MR300", 1);
            string[] data = await MonitorCommand("MR400", "1", cTokenSource.Token);
            bool result = await GetResult(passCmd, ngCmd);
            return result;
        }
        public async Task<Image?> GetNgImage(string type)
        {

            DetailModel? dtl = model.Details.Where(x => x.Type == type).FirstOrDefault();
            if (dtl is null)
                return null;
            string res = string.Empty;
            res = await WriteCommand("W0F2", dtl.CameraExecution);
            string[] check= await PushCommand("MR400", 100,"0", "1");
            string path = await lib.GetTriggerImgPath(CameraDelay);
            return lib.ReadImage(path,false);
        }
        
        public async Task<bool> GetResult(string positiveCmd,string negativeCmd)
        {
            string[] data;
            Task<string[]>[] tasks = new Task<string[]>[] { MonitorCommand(positiveCmd, "1", cTokenSource.Token), MonitorCommand(negativeCmd, "1", cTokenSource.Token) };
            var result = await Task.WhenAny<string[]>(tasks);
            data = await result;
            if (data[0] == positiveCmd && data[1] == "1") return true;
            if (data[0] == negativeCmd && data[1] =="1") return false;

            throw new Exception("Get Result Error");
        }
    }
}
