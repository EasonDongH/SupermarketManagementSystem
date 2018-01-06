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
    public class LoginService
    {
        /// <summary>
        /// 验证账号与密码
        /// </summary>
        /// <param name="objLogin"></param>
        /// <returns></returns>
        public Loginer LoginConfirm(Loginer objLogin)
        {
            string sql = "select SalePersonName from SalesPerson where SalePersonId=@SalePersonId and LoginPwd=@LoginPwd";
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@SalePersonId",objLogin.LoginId),
                new SqlParameter("@LoginPwd",objLogin.LoginPwd)
            };

            try
            {
                object obj = SQLHelper.GetSingleResult(sql, param);
                if (obj != null)
                {
                    objLogin.LoginName = obj.ToString();
                    return objLogin;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }      
    }
}
