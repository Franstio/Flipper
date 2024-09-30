using FVMI_INSPECTION.Repositories;
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
using System.Diagnostics;

namespace FVMI_INSPECTION.TCP
{
    public class FVMITCPProcess : FVMITcpClient
    {
        private readonly FileLib lib;
        public MasterModel Model { get; set; }
        private readonly int CameraDelay = 100;
        public delegate void SimpleNotifyEvent(string status);
        public SimpleNotifyEvent eventUpdate { get; set; }

        public CancellationTokenSource cTokenSource { get; private set; } = new CancellationTokenSource();
        public enum DashboardProcessType
        {
            Top,
            Bottom
        }

        public FVMITCPProcess(MasterModel model, FileLib _lib) : base()
        {
            Model = model;
            CameraDelay = int.Parse(Properties.Settings.Default["NgCameraDelay"].ToString() ?? "0");
            lib = _lib;
        }

        public async Task SetupCamExecution()
        {
            var res = await PushCommand("MR400", 10, "1", "0");
        }
        public async Task SetupCamPoint()
        {
            _ = await WriteCommand("W0FC", Model.CameraPoint);
            await Task.Delay(5);
            _ = await PushCommand("MR401", 10, "1", "0");
//            var res2 = await PushCommand("B040", 10, "1", "0");
        }

        public async Task<bool> TriggerCam(string passCmd, string ngCmd, bool check = true)
        {
            var res = await PushCommand("MR300", 100, "0", "1", "0");
            string[]? data = null;
            if (check)
                data = await MonitorCommand("MR400", "1", cTokenSource.Token);
            bool result = await GetResult(passCmd, ngCmd);
            return result;
        }
        public async Task<Image?> GetNgImage(string type)
        {

            DetailModel? dtl = Model.Details.Where(x => x.Type == type).FirstOrDefault();
            if (dtl is null)
                return null;
            string res = string.Empty;
            //            string[] check= await PushCommand("MR400", 100,"0", "1");
            string path = await lib.GetNGImgPath(type.ToLower() == "top", CameraDelay);
            await Task.Delay(500);
            return lib.ReadImage(path, false);
        }

        public async Task<string?> GetNgImagePath(string type)
        {

            DetailModel? dtl = Model.Details.Where(x => x.Type == type).FirstOrDefault();
            if (dtl is null)
                return null;
            string res = string.Empty;
            //            string[] check= await PushCommand("MR400", 100,"0", "1");
            return await lib.GetNGImgPath(type.ToLower() == "top", CameraDelay);
        }
        public async Task<bool> GetResult(string positiveCmd, string negativeCmd)
        {
            string[] data;
            CancellationTokenSource src = new();
            Task<string[]>[] tasks = new Task<string[]>[] { MonitorCommand(positiveCmd, "1", src.Token), MonitorCommand(negativeCmd, "1", src.Token) };
            var result = await Task.WhenAny<string[]>(tasks);
            data = await result;
            src.Cancel();
            src.Dispose();
            if (data[0] == positiveCmd && data[1] == "1") return true;
            if (data[0] == negativeCmd && data[1] == "1") return false;

            throw new Exception("Get Result Error");
        }
    }
}
