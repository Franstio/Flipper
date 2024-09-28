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
using System.Diagnostics.Eventing.Reader;

namespace FVMI_INSPECTION.Repositories
{
    public class ModelRepository
    {
        private static readonly string ConnectionString = ConfigurationManager.AppSettings["ConnString"] ?? "";
        private SqlConnection conn;
        private string MasterModelName = "Tbl_Model";
        private string DetailModelName = "Tbl_ModelDetail";
        public ModelRepository() 
        {
            if (ConnectionString is null || ConnectionString == "")
                throw new Exception("Appsettings fail to read");
            conn = new SqlConnection(ConnectionString);
        }
        private async Task<SqlConnection> GetConn()
        {
            conn = new SqlConnection(ConnectionString);
            await Task.Delay(100);
            await conn.OpenAsync();
            return conn;
        }
        public async Task<List<MasterModel>?> GetModel(string ModelName)
        {
            List<MasterModel>? result = null;
            using (var _con = await GetConn())
            {
                string Query = $"Select t1.Model,t1.isUV,t1.CameraPoint,t2.Model,t2.Image,t2.Type,t2.CameraExecution,t2.Area From {MasterModelName} t1 left join {DetailModelName} t2 on t1.Model=t2.Model Where t1.Model=@ModelName";
                result = (await _con.QueryAsync<MasterModel, DetailModel, MasterModel>(Query, (masterModel, detailModel) =>
                {
                    if (detailModel is not null)
                        masterModel.Details.Add(detailModel);
                    return masterModel;
                },splitOn:"Model",param: new {ModelName=ModelName}
                )).ToList();
            }
            if (result is not null)
            {
                result = result.GroupBy(x => x.Model).Select(g => new MasterModel()
                {
                    Model = g.First().Model,
                    isUV = g.First().isUV,
                    CameraPoint = g.First().CameraPoint,
                    Details = g.Select(x => x.Details).SelectMany(z => z).ToList()
                }).ToList();
            }
            return result;
        }
        public async Task WriteLog(List<RecordModel> Log)
        {
            using (var _con = await GetConn())
            {   
                string Query = $"Insert Into Tbl_ModelRecord(Model,Area,Type,ActualImage,DateRecord,Judgement,Reason,Serial) Values(@Model,@Area,@Type,@ActualImage,@DateRecorded,@Judgement,@Reason,@Serial);";
                await _con.ExecuteAsync(Query, Log);
            }
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
        public async Task<bool> ValidateLog(string serial, string model)
        {
            using (var _con = await GetConn())
            {
                string query = "Select Count(*) as c From Tbl_ModelRecord Where model=@Model and Serial=@Serial;";
                var res = await _con.ExecuteReaderAsync(query, new {Model=model,Serial=serial});
                if (await res.ReadAsync())
                {
                    int c = int.Parse(res[0]?.ToString() ??"0");
                    return c == 0;
                }
                else
                    return false;
            }
        }
        public async Task<List<MasterModel>> GetModel()
        {
            List<MasterModel> result = new List<MasterModel>();
            using (var _con = await GetConn())
            {
                string Query = $"Select t1.Model,t1.CameraPoint,t1.isUV From {MasterModelName} t1  ";
                result = (await _con.QueryAsync<MasterModel>(Query
                )).ToList();
            }
            return result;
        }

        public async Task InsertModel(MasterModel model)
        {
            using (var _con = await GetConn())
            {
                string Query = $"Insert Into {MasterModelName}(Model,CameraPoint,isUV) Values(@Model,@CameraPoint,@isUV);";
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
                string Query = $"Update {MasterModelName} Set Model=@Model,CameraPoint=@CameraPoint,isUV=@isUV where Model=@oldModelName";
                await _con.ExecuteAsync(Query,new {Model=model.Model,CameraPoint=model.CameraPoint,isUV=model.isUV,oldModelName=oldModelName});
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
        public async Task DeletePosition(string model)
        {
            using (var conn = await GetConn())
            {
                string query = "Delete Tbl_Model where model=@model";
                await conn.ExecuteAsync(query, new { model = model });
            }
        }
        public async Task FullCopyPosition(string oldModelName, string newModelName)
        {
            string[] queries = new string[]
                {

                    "Insert Into tbl_Model(Model,CameraPoint,isUV) Select @newModelName,CameraPoint,isUV From TBl_Model where model=@oldModelName;",
                    "Insert Into Tbl_ModelDetail(Model,Image,Type,CameraExecution,Area) Select @newModelName,Image,Type,CameraExecution,Area From TBl_ModelDetail where model=@oldModelName",
                };
            using (var conn = await GetConn())
            {
                using (var transact = await conn.BeginTransactionAsync())
                {

                    int res = await conn.ExecuteAsync(queries[0], new { oldModelName = oldModelName, newModelName = newModelName }, transaction: transact);
                    if (res < 1)
                    {
                        await transact.RollbackAsync();
                        return;
                    }
                    for (int i = 1; i < queries.Length; i++)
                        await conn.ExecuteAsync(queries[i], new { oldModelName = oldModelName, newModelName = newModelName }, transaction: transact);
                    await transact.CommitAsync();
                }
            }
        }
    }
}
