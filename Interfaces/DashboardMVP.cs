using FVMI_INSPECTION.Models;
using FVMI_INSPECTION.Models.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVMI_INSPECTION.Interfaces
{
    public static class DashboardMVP
    {
        public interface IView
        {
            public string modelName { get; set; }
            string SerialNumber { get; set; }
            string StatusRun { get; set; }
            int CampPoint { get; set; }
            string LogLabel { get; set; }
            string TopUVDecision { get; set; }
            string BottomUVDecision { get; set; }
            string TopWhiteDecision { get; set; }
            string BottomWhiteDecision { get; set; }
            public Image? bottomUVImage { get; set; }
            public Image? bottomWhiteImage { get; set; }
            
            public Image? topUVImage { get; set; }
            public Image? topWhiteImage { get; set; }
            public List<ProcessRecordModel> TopUVRecord { get; set; }
            public List<ProcessRecordModel> BottomUVRecord { get; set; }
            public List<ProcessRecordModel> BottomWhiteRecord { get; set; }
            public List<ProcessRecordModel> TopWhiteRecord { get; set; }
            CountViewModel countViewModel { get; set; }
            string FinalJudge { get; set; }
            bool AllowReset { get; set; }
            void StartTimer();
            void StopTimer();
        }
        public interface IPresenter
        {
            Task<ProcessResultModel[]> RunProcess();
            Task<List<ProcessRecordModel>[]?> ReadCsv();
            Task WriteLog(List<RecordModel> records);
            List<RecordModel> GenerateRecordModel(ProcessResultModel resultModel, ProcessRecordModel[] pRecordModel, string modelName,string serial);
            Task ResetProcess();
            Task CheckReset();
        }
    }
}
