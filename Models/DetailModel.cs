using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVMI_INSPECTION.Models
{
    public class DetailModel
    {

        [ExplicitKey]
        public string Model { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int CameraExecution { get; set; } = -1;
        public string Area { get; set; } = string.Empty;
        public DetailModel()
        {

        }
        public DetailModel(DetailModel detail)
        {
            Model = detail.Model;
            Image = detail.Image;
            Type = detail.Type;
            CameraExecution = detail.CameraExecution;
            Area = detail.Area;
        }
    }
}
