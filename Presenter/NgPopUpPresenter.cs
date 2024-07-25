using FVMI_INSPECTION.Interfaces;
using FVMI_INSPECTION.Models;
using FVMI_INSPECTION.Models.ViewData;
using FVMI_INSPECTION.Repositories;
using FVMI_INSPECTION.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVMI_INSPECTION.Presenter
{
    public class NgPopUpPresenter : NgPopUpMVP.IPresenter
    {
        public static async Task<NgPopUpPresenter> Build(NgPopUpMVP.IView view, RecordModel detail)
        {
            var _repo = new ModelRepository();
            var res = await _repo.GetDetail(detail.Model, detail.ProcessType.ToString()+detail.FVMI_Type.ToString());
            return new NgPopUpPresenter(view,detail,res.First());
        }
        private RecordModel model;
        private NgPopUpMVP.IView view;
        private FileLib lib = new FileLib();
        private ModelRepository repo = new ModelRepository();
        public NgPopUpPresenter(NgPopUpMVP.IView view, RecordModel rModel,DetailModel dModel)
        {
            model = rModel;
            this.view = view;
            FileLib.FVMI_Type fType = rModel.Type.Contains("UV") ? FileLib.FVMI_Type.UV : FileLib.FVMI_Type.White;
            FileLib.FVMI_ProcessType pType = rModel.Type.Contains("Top") ? FileLib.FVMI_ProcessType.Top : FileLib.FVMI_ProcessType.Bottom;
            view.ActualImage = lib.ReadImage(rModel.ActualImage,fType,pType)!;
            view.ParameterImage = lib.ReadImage(dModel.Image, true)!;
            view.Area = rModel.Area;
        }
        public Task<RecordModel> UpdateResult(bool isPassed, string reason)
        {
            model.Judgement = isPassed ? "PASS" : "NG";
            model.Reason = reason;
            return Task.FromResult(model);
        }
    }
}
