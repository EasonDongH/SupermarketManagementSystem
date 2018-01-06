using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DataPageQueryService
    {
        /// <summary>
        /// 使用存储过程分页查询LoginLogs
        /// </summary>
        /// <param name="objLog"></param>
        /// <returns></returns>
        public DataSet GetLoginLogPageQuery(LoginLogPageQuery objLog)
        {          
            SqlParameter[] parameters = new SqlParameter[]
                {                   
                    new SqlParameter("@PageSize",objLog.PageSize),
                    new SqlParameter("@RecordCount",objLog.RecordCount),
                    new SqlParameter("@BeginTime",objLog.BeginTime),
                    new SqlParameter("@EndTime",objLog.EndTime)
                };
            
            try
            {                
                return SQLHelper.GetDataSetByProcedure("usp_LoginLogsPagingQuery",parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }          
        }

        /// <summary>
        /// 查询总数据量
        /// </summary>
        /// <param name="objLog"></param>
        /// <returns></returns>
        public int GetRecordCount(LoginLogPageQuery objLog)
        {
            string sql = "select count(*) from Loginlogs where LoginTime between @BeginTime and @EndTime";
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@BeginTime",objLog.BeginTime),
                    new SqlParameter("@EndTime",objLog.EndTime)
                };
            try
            {
                return Convert.ToInt32(SQLHelper.GetSingleResult(sql,parameters));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
