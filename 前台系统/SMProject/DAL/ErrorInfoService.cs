using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ErrorInfoService
    {
        public void WriteErrorInfoToDB(Error objError)
        {
            string sql = "insert into ErrorLogs (ServerName, LoginId, ErrorDesc,Operate) values (@ServerName, @LoginId, @ErrorDesc,@Operate)";
            SqlParameter[] parames = new SqlParameter[]
                {
                    new SqlParameter("@ServerName",objError.ServerName),
                    new SqlParameter("@LoginId",objError.LoginId),
                    new SqlParameter("@Operate",objError.Opearte),
                    new SqlParameter("@ErrorDesc",objError.ErrorDesc)
                };
            try
            {
                SQLHelper.Update(sql, parames);
            }
            catch (Exception ex)
            {
                //若是出错，将错误统一记录到本地
                throw ex;
            }
        }
    }
}
