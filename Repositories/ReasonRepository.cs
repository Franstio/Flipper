using Dapper;
using FVMI_INSPECTION.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVMI_INSPECTION.Repositories
{
    public class ReasonRepository
    {
        private static readonly string ConnectionString = ConfigurationManager.AppSettings["ConnString"] ?? "";
        private SqlConnection conn;
        private string MasterModelName = "Tbl_Reason";
        public ReasonRepository()
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
        public async Task InsertReason(string reason)
        {
            string query = $"Insert Into {MasterModelName}(Reason) Values(@reason);";
            using (conn = await GetConn())
            {
               await conn.ExecuteAsync(query, new { reason = reason });
            }
        }
        public async Task DeleteReason(int id)
        {
            string query = $"Delete From {MasterModelName} where Id=@id;";
            using (conn = await GetConn())
            {
                await conn.ExecuteAsync(query, new { id=id });
            }
        }
        public async Task<IEnumerable<ReasonModel>> GetReason()
        {
            string query = $"Select Id,Reason From {MasterModelName};";
            using (conn = await GetConn())
            {
                IEnumerable<ReasonModel> reasons = await conn.QueryAsync<ReasonModel>(query);
                return reasons;
            }
        }
        public async Task<ReasonModel?> GetReason(int id)
        {
            string query = $"Select Id,Reason From {MasterModelName} where id=@id;";
            using (conn = await GetConn())
            {
                ReasonModel? reason = await conn.QueryFirstOrDefaultAsync<ReasonModel>(query,new {id=id});
                return reason;
            }
        }
    }
}
