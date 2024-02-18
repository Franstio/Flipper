using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVMI_INSPECTION.Models.ViewData
{
    public class ProcessRecordModel
    {
        public string Area { get; set; } = string.Empty;
        public string Defect { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public string Point { get; set; } = string.Empty;
        public List<int[]> Data { get; set; } = new List<int[]>();
        public ProcessRecordModel() { }
        public ProcessRecordModel(string[] data)
        {
            if (data.Length < 4)
                return;
            Area  = data[0];
            Defect = data[1];
            Result = data[2];
            Point = data[3];
        }
    }
}
