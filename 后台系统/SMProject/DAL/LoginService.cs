using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace DAL
{
    public class LoginService
    {
        /// <summary>
        /// 登录验证
        /// 缺点：返回时进行时强制转换影响了性能
        /// </summary>
        /// <param name="objSysAdmin"></param>
        /// <returns></returns>
        public SysAdmin LoginVerify(SysAdmin objSysAdmin)
        {
            string sql = "select LoginId, LoginPwd, AdminName, AdminStatus, RoleId from SysAdmins where LoginId=@LoginId and LoginPwd=@LoginPwd";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter ( "@LoginId",objSysAdmin.LoginId ),
                new SqlParameter ("@LoginPwd",objSysAdmin.LoginPwd)
            };
            SqlDataReader objReader = null;
            try
            {
                objReader = SQLHelper.GetReader(sql, parameters);
                if (objReader.Read())
                {
                    objSysAdmin.AdminName = objReader["AdminName"].ToString();
                    objSysAdmin.AdminStatus = Convert.ToInt32(objReader["AdminStatus"]);
                    objSysAdmin.RoleId = Convert.ToInt32(objReader["RoleId"]);

                    return objSysAdmin;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objReader != null)
                {
                    objReader.Close();
                }               
            }
        }
        
        /// <summary>
        /// 登录日志
        /// </summary>
        /// <param name="objLog"></param>
        public void LoginLog(LoginLogs objLog)
        {
            //loginTime通过数据库中getdate方法获取数据库默认时间
            string sql = "insert into LoginLogs ( LoginId, LoginName, ServerName) values(@LoginId, @LoginName, @ServerName);select @@identity";
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@LoginId",objLog.LoginId),
                    new SqlParameter("@LoginName",objLog.LoginName),
                    new SqlParameter("@ServerName",objLog.ServerName)
                    //new SqlParameter("@LoginTime",objLog.LoginTime)
                };
            try
            {               
                objLog.LogId = Convert.ToInt32(SQLHelper.GetSingleResult(sql,parameters));//获取当前登录时插入的LogId                            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 退出日志
        /// </summary>
        public void ExitLog(LoginLogs objLog)
        {
            string sql = "update LoginLogs set ExitTime=@ExitTime where LogId=@LogId";
            SqlParameter[] parameters = new SqlParameter[]
                {                   
                    new SqlParameter("@ExitTime",SQLHelper.GetDBTime()),
                    new SqlParameter("@LogId",objLog.LogId)
                };
            try
            {
                SQLHelper.Update(sql,parameters);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
