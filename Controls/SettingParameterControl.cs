using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design;
using FVMI_INSPECTION.Models;
using FVMI_INSPECTION.DAL;
using FVMI_INSPECTION.TCP;
using FVMI_INSPECTION.Utilities;

namespace FVMI_INSPECTION.Controls
{
    public partial class SettingParameterControl : UserControl
    {

        private MasterModel currentModel = new MasterModel();
        private bool isNew = false;
        private readonly ModelRepository repository = new ModelRepository();
        private FVMITCPProcess? process = null;
        private readonly FileLib lib = new FileLib();
        public SettingParameterControl(string ModelName)
        {
            InitializeComponent();
            currentModel.Model = ModelName;
            runningModel.Text = $"Model: {ModelName}";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DetailModel model = new DetailModel()
            {
                Area = string.Empty,
                CameraExecution = int.Parse(camExecBoxTop.Text.Trim()),
                Model = currentModel.Model,
                Type = "Top",
                Image = string.Empty
            };
            if (isNew)
                await CreateModelMaster();
            await setDetail(model, "Top");
            
        }
        public async Task CreateModelMaster()
        {

            currentModel.CameraPoint = int.Parse(camPoint.Value.ToString());
            await repository.InsertModel(currentModel);
            isNew = false;
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            DetailModel model = new DetailModel()
            {
                Area = string.Empty,
                CameraExecution = int.Parse(camExecBoxBottom.Text.Trim()),
                Model = currentModel.Model,
                Type = "Bottom",
                Image = string.Empty
            };
            if (isNew)
                await CreateModelMaster();
            await setDetail(model,"Bottom");
        }
        private async Task setDetail(DetailModel model,string type)
        {
            var find = currentModel.Details.Where(x => x.Type == model.Type).Any();
            if (find)
                await repository.UpdateModel(model, currentModel.Model,type);
            else
                await repository.InsertModel(model);
            await LoadCurrentModel();
            var result = await process!.GetNgImage(type);
            if (type == "Top")
                pictureBox1.Image = result;
            else if (type == "Bottom")
                pictureBox2.Image = result;
        }
        private async void SettingParameterControl_Load(object sender, EventArgs e)
        {
            isNew = true;
            await LoadCurrentModel();
        }
        private async Task LoadCurrentModel()
        {
            var list = await repository.GetModel(currentModel.Model);
            if (list.Count < 1)
                return;
            currentModel = list.First();
            process = new FVMITCPProcess(currentModel, lib);
            camPoint.Value = currentModel.CameraPoint;
            var top = currentModel.Details.Where(x => x.Type == "Top").FirstOrDefault();
            var bottom = currentModel.Details.Where(x => x.Type == "Bottom").FirstOrDefault();
            if (top is not null)
            {
                //areaBoxTop.Text = top.Area;
                camExecBoxTop.Text = top.CameraExecution.ToString();
            }
            if (bottom is not null)
            {
                //areaBoxBottom.Text = bottom.Area;
                camExecBoxBottom.Text = bottom.CameraExecution.ToString();
            }
            isNew = false;
        }
        private async void button14_Click(object sender, EventArgs e)
        {
            currentModel.CameraPoint = int.Parse(camPoint.Value.ToString());
            if (isNew)
                await repository.InsertModel(currentModel);
            else
                await repository.UpdateModel(currentModel,currentModel.Model);
            await LoadCurrentModel();
        }
    }
}
