using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVMI_INSPECTION.Interfaces
{
    public static class SettingParameterMVP
    {
        public interface IView
        {
            public string ModelName { get; set; } 
            public int CameraPoint { get; set; }
            public int TopCamExecution { get; set; }
            public int BottomExecution { get; set; }
            public Image TopImage { get; set; }
            public Image BottomImage { get; set; }
            public string UploadFilePath { get;  }
            string UploadFileName { get ; }
        }
        public interface IPresenter
        {
            public  Task SetCamPoint();
            public Task SetTopCamExec();
            public Task SetBottomCamExec();
            public Task UploadImage(string Type);
        }
    }
}
