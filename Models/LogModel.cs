using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVMI_INSPECTION.Models
{
    public class LogModel
    {
        public string Model { get; set; }
        public string SN { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string Status { get; set; }

        public string TopFailTool { get; set; } = "NONE";
        public string TopUvFailTool { get; set; } = "NONE";
        public string BotFailTool { get; set; } = "NONE";
        public string BotUVFailTool { get; set; } = "NONE";

        public string Failure { get; set; } = string.Empty;
    }
}
