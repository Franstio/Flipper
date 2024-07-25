using FVMI_INSPECTION.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVMI_INSPECTION.Models.ViewData
{
    public class ProcessResultModel
    {
        public bool ResultJudgement { get; set; } = false;
        public Image? Image { get; set; }
        public string Type { get; set; } = string.Empty;
        public string? ImagePath { get; set; }
        public FileLib.FVMI_ProcessType ProcessType { get; set; }
        public FileLib.FVMI_Type FVMI_Type { get; set; }
    }
}
