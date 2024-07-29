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
        public enum FVMI_ImageType
        {
            TopWhite,
            BottomWhite,
            TopUV,
            BottomUV
        }
        public static async Task<SettingParameterPresenter> Build(string model, SettingParameterMVP.IView _view)
        {
            ModelRepository _repo = new ModelRepository();
            var list = await _repo.GetModel(model);
            var mdl = new MasterModel();
            mdl.Model = model;
            var _lib = new FileLib();

            var process = new FVMITCPProcess(mdl, _lib);
            if ( list is  null || list.Count < 1)
                return new SettingParameterPresenter(mdl, _view, process, _lib, _repo);
            mdl = list.First();
            process = new FVMITCPProcess(mdl, _lib);
            if (mdl is not null && mdl.Details.Count > 0)
            {
                Func<FVMI_ImageType, string?> getImage = (t) => mdl.Details.Where(x => x.Type == t.ToString()).FirstOrDefault()?.Image;
                _view.TopUVImage = getImage(FVMI_ImageType.TopUV) is not null ? _lib.ReadImage(getImage(FVMI_ImageType.TopUV)!, true) ?? _view.TopUVImage : _view.TopUVImage;
                _view.BottomUVImage = getImage(FVMI_ImageType.BottomUV) is not null ? _lib.ReadImage(getImage(FVMI_ImageType.BottomUV)!, true) ?? _view.BottomUVImage : _view.BottomUVImage;
                _view.TopWhiteImage = getImage(FVMI_ImageType.TopWhite) is not null ? _lib.ReadImage(getImage(FVMI_ImageType.TopWhite)!, true) ?? _view.TopWhiteImage : _view.TopWhiteImage;
                _view.BottomWhiteImage = getImage(FVMI_ImageType.BottomWhite) is not null ? _lib.ReadImage(getImage(FVMI_ImageType.BottomWhite)!, true) ?? _view.BottomWhiteImage : _view.BottomWhiteImage;
                _view.CameraPoint = mdl.CameraPoint;
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
        public async Task CylinderToggle(bool state)
        {
            var res = await process.SendCommand($"WR MR302 {(state ? 1 : 0)}");
            await loadbutton();
        }
        public async Task UVToggle(bool state)
        {
            var res = await process.SendCommand($"WR MR303 {(state ? 1 : 0)}");
            await loadbutton();
        }
        public async Task TriggerFlip()
        {
            var res = await process.SendCommand("WR MR201 1");
            await Task.Delay(100);
            res = await process.SendCommand("WR MR201 0");
        }
        public async Task TriggerOrigin()
        {
            var res = await process.SendCommand("WR MR200 1");
            await Task.Delay(100);
            res = await process.SendCommand("WR MR200 0");
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
        private SettingParameterPresenter(MasterModel _model, SettingParameterMVP.IView _view, FVMITCPProcess proc, FileLib fileLib, ModelRepository _repo)
        {
            isNew = _model is null;
            model = _model ?? new MasterModel();
            repo = new ModelRepository();
            lib = fileLib;
            process = proc;
            view = _view;
            SetupView();
        }
        public async Task LoadCurrentModel()
        {
            string modelName = model.Model;
            var list = await repo.GetModel(model.Model);
            isNew = list is null || list.Count<1;
            if (list?.Count < 1)
            {
                model = new MasterModel();
                model.Model = modelName;
                process.Model = model;
                return;
            }
            model = list.First();
            process.Model = model;
            view.ModelName = modelName;
            await process.SetupCamPoint();
            await loadbutton();
        }
        private async Task loadbutton()
        {

            var cylinder = await process.ReadCommand("R505");
            var uv = await process.ReadCommand("R502");
            view.UVButton[0].Invoke(delegate
            {
                view.UVButton[0].BackColor= uv == "0" ? Color.White : Color.Gray;
                view.UVButton[0].Enabled = uv == "0";
            });
            view.UVButton[1].Invoke(delegate
            {
                view.UVButton[1].BackColor = uv == "1" ? Color.White : Color.Gray;
                view.UVButton[1].Enabled = uv == "1";
            });
            view.CylinderButton[0].Invoke(delegate
            {
                view.CylinderButton[0].BackColor = cylinder == "0" ? Color.White : Color.Gray;
                view.CylinderButton[0].Enabled = cylinder == "0";
            });
            view.CylinderButton[1].Invoke(delegate
            {

                view.CylinderButton[1].BackColor = cylinder== "1" ? Color.White : Color.Gray;
                view.CylinderButton[1].Enabled = cylinder == "1";
            });


        }
        private void SetupView()
        {
            var mdl = model;
            var _lib = lib;
            var _view = view;
            Func<FVMI_ImageType, string?> getImage = (t) => mdl.Details.Where(x => x.Type == t.ToString()).FirstOrDefault()?.Image;
            _view.TopUVImage = getImage(FVMI_ImageType.TopUV) is not null ? _lib.ReadImage(getImage(FVMI_ImageType.TopUV)!, true) ?? _view.TopUVImage : _view.TopUVImage;
            _view.BottomUVImage = getImage(FVMI_ImageType.BottomUV) is not null ? _lib.ReadImage(getImage(FVMI_ImageType.BottomUV)!, true) ?? _view.BottomUVImage : _view.BottomUVImage;
            _view.TopWhiteImage = getImage(FVMI_ImageType.TopWhite) is not null ? _lib.ReadImage(getImage(FVMI_ImageType.TopWhite)!, true) ?? _view.TopWhiteImage : _view.TopWhiteImage;
            _view.BottomWhiteImage = getImage(FVMI_ImageType.BottomWhite) is not null ? _lib.ReadImage(getImage(FVMI_ImageType.BottomWhite)!, true) ?? _view.BottomWhiteImage : _view.BottomWhiteImage;
        }
        private async Task setDetail(DetailModel detail, string type)
        {
            var find = model.Details.Where(x => x.Type == detail.Type).Any();
            if (find)
                await repo.UpdateModel(detail, model.Model, type);
            else
                await repo.InsertModel(detail);
            await LoadCurrentModel();
        }

        public async Task UploadImage(string Type)
        {
            if (isNew)
                await CreateModelMaster();
            string TAG = Type;
            var result = await repo.GetDetail(view.ModelName, TAG);
            bool isExist = result.Count() > 0;
            await lib.SaveImage(view.UploadFilePath, view.UploadFileName);
            DetailModel detail = new DetailModel()
            {
                Area = isExist ? result.First().Area : string.Empty,
                Model = isExist ? result.First().Model : view.ModelName,
                Type = TAG,
                Image = view.UploadFileName,
                CameraExecution = 0
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
            if (TAG ==nameof(FVMI_ImageType.TopUV) )
                view.TopUVImage = img ;
            else if (TAG == nameof(FVMI_ImageType.BottomUV))
                view.BottomUVImage = img;
            else if (TAG == nameof(FVMI_ImageType.TopWhite))
                view.TopWhiteImage = img;
            else if (TAG == nameof(FVMI_ImageType.BottomWhite))
                view.BottomWhiteImage = img;
        }
    }
}
