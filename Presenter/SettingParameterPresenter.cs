using FVMI_INSPECTION.Interfaces;
using FVMI_INSPECTION.Models;
using FVMI_INSPECTION.Repositories;
using FVMI_INSPECTION.TCP;
using FVMI_INSPECTION.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FVMI_INSPECTION.Presenter
{
    public class SettingParameterPresenter : SettingParameterMVP.IPresenter
    {
        private readonly FileLib lib;
        private MasterModel model;
        private readonly ModelRepository repo;
        private readonly FVMITCPProcess process;
        private readonly SettingParameterMVP.IView view;
        private bool isNew = true;
        public static async Task<SettingParameterPresenter> Build(string model, SettingParameterMVP.IView _view)
        {
            ModelRepository _repo = new ModelRepository();
            var list = await _repo.GetModel(model);
            var mdl = new MasterModel();
            mdl.Model = model;
            var _lib = new FileLib();
            var process = new FVMITCPProcess(mdl, _lib);
            if (list.Count < 1)
                return new SettingParameterPresenter(mdl,_view,process,_lib,_repo);
            mdl = list.First();
            process = new FVMITCPProcess(mdl, _lib);
            if (mdl.Details.Count > 0)
            {
                var top = mdl.Details.Where(x => x.Type == "Top").FirstOrDefault();
                if (top is not null && !string.IsNullOrEmpty(top.Image))
                    _view.TopImage = _lib.ReadImage(top.Image, true) ?? _view.TopImage;
                var bottom = mdl.Details.Where(x => x.Type == "Bottom").FirstOrDefault();
                if (bottom is not null && !string.IsNullOrEmpty(bottom.Image))
                    _view.BottomImage= _lib.ReadImage(bottom.Image, true) ?? _view.BottomImage;
            }
            return new SettingParameterPresenter(mdl, _view, process, _lib, _repo);
        }

        public async Task SetCamPoint()
        {

            model.CameraPoint = view.CameraPoint;
            if (isNew)
                await repo.InsertModel(model);
            else
                await repo.UpdateModel(model, model.Model);
            await LoadCurrentModel();
            await process.SetupCamPoint();
        }

        public async Task SetTopCamExec()
        {
            DetailModel detail = new DetailModel()
            {
                Area = string.Empty,
                CameraExecution = view.TopCamExecution,
                Model = model.Model,
                Type = "Top",
                Image = string.Empty
            };
            if (isNew)
                await CreateModelMaster();
            await setDetail(detail, "Top");

        }
        
        public async Task SetBottomCamExec()
        {

            
            DetailModel detail = new DetailModel()
            {
                Area = string.Empty,
                CameraExecution = view.BottomExecution,
                Model = model.Model,
                Type = "Bottom",
                Image = string.Empty
            };
            if (isNew)
                await CreateModelMaster();
            await setDetail(detail, "Bottom");
        }
        public async Task CreateModelMaster()
        {

            model.CameraPoint = view.CameraPoint;
            await repo.InsertModel(model);
            isNew = false;
        }
        private SettingParameterPresenter(MasterModel _model,SettingParameterMVP.IView _view,FVMITCPProcess proc,FileLib fileLib,ModelRepository _repo)
        {
            isNew = _model is null;
            model = _model ?? new MasterModel();
            repo = _repo;
            lib = fileLib;
            process = proc;
            view = _view;
            SetupView();
        }
        public async Task LoadCurrentModel()
        {
            string modelName = model.Model;
            var list = await repo.GetModel(model.Model);
            isNew = false;
            if (list.Count < 1)
            {
                isNew = true;
                model = new MasterModel();
                model.Model = modelName;
                process.Model = model;
                return;
            }
            model = list.First();
            process.Model = model;
        }
        private void SetupView()
        {
            view.CameraPoint = model.CameraPoint;
            var top = model.Details.Where(x => x.Type == "Top").FirstOrDefault();
            var bottom = model.Details.Where(x => x.Type == "Bottom").FirstOrDefault();
            if (top is not null)
            {
                //areaBoxTop.Text = top.Area;
                view.TopCamExecution = top.CameraExecution;
            }
            if (bottom is not null)
            {
                //areaBoxBottom.Text = bottom.Area;
                view.BottomExecution = bottom.CameraExecution;
            }
        }
        private async Task setDetail(DetailModel detail, string type)
        {
            var find = model.Details.Where(x => x.Type == detail.Type).Any();
            if (find)
                await repo.UpdateModel(detail, model.Model, type);
            else
                await repo.InsertModel(detail);
            await LoadCurrentModel();
/*            await process.SetupCamExecution();
            var result = await process!.GetNgImage(type);
            if (type == "Top" && result is not null)
                view.TopImage = result;
            else if (type == "Bottom" && result is not null)
                view.BottomImage= result;*/
        }

        public async Task UploadImage(string Type)
        {
            string TAG = Type;
            if (TAG != "Top" && TAG != "Bottom")
                return;

            var result = await repo.GetDetail(view.ModelName, TAG);
            bool isExist = result.Count() > 0;
            lib.SaveImage(view.UploadFilePath, view.UploadFileName);
            DetailModel detail = new DetailModel()
            {
                Area = isExist ? result.First().Area : string.Empty,
                Model = isExist ? result.First().Model : view.ModelName,
                Type = TAG,
                Image = view.UploadFileName,
                CameraExecution = isExist ? result.First().CameraExecution : TAG == "TOP" ? view.TopCamExecution : view.BottomExecution,
            };
            if (isExist)
                await repo.UpdateModel(detail, view.ModelName, TAG);
            else
                await repo.InsertModel(detail);
            Image? img = lib.ReadImage(detail.Image,true);
            if (img is null)
            {
                MessageBox.Show("Upload Fail");
                return;
            }
            if (TAG == "Top" )
                view.TopImage = img ;
            else
                view.BottomImage = img;
        }
    }
}
