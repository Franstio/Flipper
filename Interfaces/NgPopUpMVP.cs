using FVMI_INSPECTION.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVMI_INSPECTION.Interfaces
{
    public static class NgPopUpMVP
    {
        public interface IView
        {
            Image ActualImage { get; set; }
            Image ParameterImage { get; set; }
            string Area { get; set; }
        }
        public interface IPresenter
        {
            Task<RecordModel> UpdateResult(bool isPassed,string reason);
        }
    }
}
