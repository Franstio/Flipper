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
    }
}
