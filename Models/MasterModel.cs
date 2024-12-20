﻿using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVMI_INSPECTION.Models
{
    public class MasterModel
    {
        [ExplicitKey]
        public string Model { get; set; } = string.Empty;
        public int CameraPoint { get; set; } = -1;
        public ICollection<DetailModel> Details { get; set; }  =new List<DetailModel>();
        public MasterModel()
        {

        }
        public MasterModel(MasterModel model)
        {
            Model = model.Model;
            CameraPoint = model.CameraPoint;
        }
    }
}
