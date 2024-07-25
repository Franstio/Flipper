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
            public Image TopUVImage { get; set; }
            public Image BottomUVImage { get; set; }
            public Image TopWhiteImage { get; set; }
            public Image BottomWhiteImage { get; set; }
            public string UploadFilePath { get;  }
            string UploadFileName { get ; }
            Button[] UVButton { get; set; }
            Button[] CylinderButton { get; set; } 
        }
        public interface IPresenter
        {
            public  Task SetCamPoint();
            public Task SetTopCamExec();
            public Task SetBottomCamExec();
            public Task UploadImage(string Type);
            Task LoadCurrentModel();
            Task CylinderToggle(bool state);
            Task UVToggle(bool state);
            Task TriggerFlip();
            Task TriggerOrigin();
        }
    }
}
