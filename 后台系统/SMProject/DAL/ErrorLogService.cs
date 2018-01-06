using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace DAL
{
    public class ErrorLogService
    {
        public void ErrorLog(ErrorLog objError)
        {
            string sql = "insert into ErrorLogs (OccurTime, ServerName, LoginId, ErrorDesc, OperateInfo) values (@OccurTime, @ServerName, @LoginId, @ErrorDesc, @OperateInfo)";
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@OccurTime",objError.OccurTime),
                    new SqlParameter("@ServerName",objError.ServerName),
                    new SqlParameter("@LoginId",objError.LoginId),
                    new SqlParameter("@ErrorDesc",objError.ErrorMessage),
                    new SqlParameter("@OperateInfo",objError.OperateInfo)
                };

            try
            {
                SQLHelper.Update(sql,parameters);
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message );
            }            
        }
    }
}
