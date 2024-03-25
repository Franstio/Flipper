using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVMI_INSPECTION.Models
{
    public class RecordModel
    {
        public string Model { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string ActualImage { get; set; } = string.Empty;
        public DateTime DateRecorded { get; set; } = DateTime.Now;
        public string Judgement { get; set; } = string.Empty;
        public string? Reason { get; set; } = null;
        public string Serial { get; set;} = string.Empty;
    }
}
