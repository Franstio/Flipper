using FVMI_INSPECTION.Models.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVMI_INSPECTION.Interfaces
{
    public class DashboardMVP
    {
        public interface View
        {
            string SerialNumber { get; set; }
            string StatusRun { get; set; }
            int CampPoint { get; set; }
        }
        public interface Presenter
        {
            Task<ProcessResultModel?> RunProcess();
            Task<ProcessRecordModel?> ReadCsv();
        }
    }
}
