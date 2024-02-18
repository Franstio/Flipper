using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FVMI_INSPECTION.Models;
using System.Reflection;

namespace FVMI_INSPECTION.DAL
{
    public class ModelRepository
    {
        private readonly string ConnectionString = string.Empty;
        private SqlConnection conn;
        private string MasterModelName = "Tbl_Model";
        private string DetailModelName = "Tbl_ModelDetail";
        public ModelRepository() 
        {
            ConnectionString = ConfigurationManager.AppSettings["ConnString"] ?? "";
            conn = new SqlConnection(ConnectionString);
        }
        private async Task<SqlConnection> GetConn()
        {
            conn = new SqlConnection(ConnectionString);
            await conn.OpenAsync();
            return conn;
        }
        public async Task<List<MasterModel>> GetModel(string ModelName)
        {
            List<MasterModel> result = new List<MasterModel>();
            using (var _con = await GetConn())
            {
                string Query = $"Select t1.Model,t1.CameraPoint,t2.Model,t2.Image,t2.Type,t2.CameraExecution,t2.Area From {MasterModelName} t1 inner join {DetailModelName} t2 on t1.Model=t2.Model Where t1.Model=@ModelName";
                result= (await _con.QueryAsync<MasterModel, DetailModel, MasterModel>(Query, (masterModel, detailModel) =>
                {
                    masterModel.Details.Add(detailModel);
                    return masterModel;
                },splitOn:"Model",param: new {ModelName=ModelName}
                )).ToList();
            }
            result = result.GroupBy(x => x.Model).Select(g => new MasterModel()
            {
                Model = g.First().Model,
                CameraPoint = g.First().CameraPoint,
                Details = g.Select(x=>x.Details).SelectMany(z=>z).ToList()
            }).ToList() ;
            return result;
        }
        public async Task<IEnumerable<DetailModel>> GetDetail(string model, string type)
        {
            IEnumerable<DetailModel> details = new List<DetailModel>();
            using (var _con = await GetConn())
            {
                string Query = $"Select Model,Image,Type,CameraExecution,Area From {DetailModelName} where Model=@Model and Type=@Type ";
                details = await _con.QueryAsync<DetailModel>(Query,new {Model=model, Type=type});
            }
            return details;
        }
        public async Task<List<MasterModel>> GetModel()
        {
            List<MasterModel> result = new List<MasterModel>();
            using (var _con = await GetConn())
            {
                string Query = $"Select t1.Model,t1.CameraPoint From {MasterModelName} t1  ";
                result = (await _con.QueryAsync<MasterModel>(Query
                )).ToList();
            }
            return result;
        }
        public async Task InsertModel(MasterModel model)
        {
            using (var _con = await GetConn())
            {
                string Query = $"Insert Into {MasterModelName}(Model,CameraPoint) Values(@Model,@CameraPoint);";
                await _con.ExecuteAsync(Query, model);
                foreach (var detail in model.Details)
                    await InsertModel(detail);
            }
        }
        public async Task InsertModel(DetailModel detail)
        {

            using (var _con = await GetConn())
            {
                string Query = $"Insert Into {DetailModelName}(Model,Image,Type,CameraExecution,Area) Values(@Model,@Image,@Type,@CameraExecution,@Area);";
                await _con.ExecuteAsync(Query, detail);
            }
        }
        public async Task UpdateModel(MasterModel model,string oldModelName)
        {
            using (var _con = await GetConn())
            {
                string Query = $"Update {MasterModelName} Set Model=@Model,CameraPoint=@CameraPoint where Model=@oldModelName";
                await _con.ExecuteAsync(Query,new {Model=model.Model,CameraPoint=model.CameraPoint,oldModelName=oldModelName});
            }
        }

        public async Task UpdateModel(DetailModel model, string oldModelName,string oldType)
        {
            using (var _con = await GetConn())
            {
                string Query = $"Update {DetailModelName} Set Model=@Model,Image=@Image,Type=@Type,CameraExecution=@CameraExecution,Area=@Area where Model=@oldModelName and Type=@oldType";
                await _con.ExecuteAsync(Query, new { Model = model.Model, Image= model.Image,Type=model.Type,CameraExecution=model.CameraExecution,Area=model.Area, oldModelName = oldModelName ,oldType=oldType});
            }
        }
    }
}
