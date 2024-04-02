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
            string SerialNumber { get; set; }
            string StatusRun { get; set; }
            int CampPoint { get; set; }
            string TopDecision { get; set; }
            string BottomDecision { get; set; }
            public Image? TopParameterImage { get; set; }
            public Image? BottomParameterImage { get; set; }
            
            public Image? TopActualImage { get; set; }
            public Image? BottomActualImage { get; set; }
            public List<ProcessRecordModel> TopRecord { get; set; }
            public List<ProcessRecordModel> BottomRecord { get; set; }
            CountViewModel countViewModel { get; set; }
            string FinalJudge { get; set; }
        }
        public interface IPresenter
        {
            Task<ProcessResultModel[]> RunProcess();
            Task<List<ProcessRecordModel>[]?> ReadCsv();
            Task WriteLog(List<RecordModel> records);
            List<RecordModel> GenerateRecordModel(ProcessResultModel resultModel, ProcessRecordModel[] pRecordModel, string modelName,string serial);
            Task ResetProcess();
        }
    }
}
