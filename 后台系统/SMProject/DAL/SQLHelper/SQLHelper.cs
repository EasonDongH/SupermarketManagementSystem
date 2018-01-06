using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class SQLHelper
    {
        private static readonly string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

        #region 普通SQL语句

        /// <summary>
        /// 执行增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Update(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql,conn);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("SQLHelper-Update方法发生错误：" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("SQLHelper-Update方法发生错误：" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 获取单一结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql,conn);
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw new Exception("SQLHelper-GetSingleResult方法发生错误：" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("SQLHelper-GetSingleResult方法发生错误：" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 获取多个结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException ex)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                throw new Exception("SQLHelper-GetReader方法发生错误：" + ex.Message);
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                throw new Exception("SQLHelper-GetReader方法发生错误：" + ex.Message);
            }            
        }

        /// <summary>
        /// 获取结果集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                da.Fill(ds);
                return ds;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQLHelper-GetDataSet方法发生错误：" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("SQLHelper-GetDataSet方法发生错误：" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region 带参数SQL语句

        /// <summary>
        /// 带参数更新语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int Update(string sql,SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql,conn);          
            try
            {
                conn.Open();                
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("SQLHelper-Update(带参数)方法发生错误：" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("SQLHelper-Update(带参数)方法发生错误：" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 获取单一结果(带参数)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql,SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw new Exception("SQLHelper-GetSingleResult(带参数)方法发生错误：" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("SQLHelper-GetSingleResult(带参数)方法发生错误：" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 获取多个结果(带参数)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string sql, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException ex)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                throw new Exception("SQLHelper-GetReader(带参数)方法发生错误：" + ex.Message);
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                throw new Exception("SQLHelper-GetReader(带参数)方法发生错误：" + ex.Message);
            }
        }

        public static DataSet GetDataSet(string sql,SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql,conn);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(parameters);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL-GetDataSet带参数方法发生错误："+ex.Message);
            }
        }
        #endregion

        #region 使用事务执行多条更新语句（增删改）语句
        /// <summary>
        /// 事务处理多条SQL语句更新
        /// </summary>
        /// <param name="sqlList"></param>
        /// <returns></returns>
        public static int UpdateByTran(List<string> sqlList)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                int result = 0;
                cmd.Transaction = conn.BeginTransaction();
                foreach (var sql in sqlList)
                {
                    cmd.CommandText = sql;
                    result+= cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();
                return result;
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                    cmd.Transaction.Rollback();               
                throw new Exception("SQLHelper-UpdateByTran方法发生错误：" + ex.Message);                
            }
            finally
            {
                if (cmd.Transaction != null)
                    cmd.Transaction = null;
                conn.Close();
            }
        }
        #endregion

        #region 使用存储过程

        /// <summary>
        /// 带参数更新语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int UpdateByStoredProcdure(string storedProcdureName, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(storedProcdureName, conn);
            //cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = storedProcdureName;
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("SQLHelper-UpdateByStoredProcdure方法发生错误：" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("SQLHelper-UpdateByStoredProcdure方法发生错误：" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 获取单一结果(带参数)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResultByStoredProcdure(string storedProcdureName, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(storedProcdureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw new Exception("SQLHelper-GetSingleResultByStoredProcedure方法发生错误：" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("SQLHelper-GetSingleResultByStoredProcedure方法发生错误：" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 获取多个结果(带参数)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetReaderByStoredProcedure(string storedProcdureName, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(storedProcdureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException ex)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                throw new Exception("SQLHelper-GetReaderByStoredProcedure方法发生错误：" + ex.Message);
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                throw new Exception("SQLHelper-GetReaderByStoredProcedure方法发生错误：" + ex.Message);
            }
        }

        public static DataSet GetDataSetByProcedure(string storedProcdureName, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(storedProcdureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();          
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(parameters);
                
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL-GetDataSet带参数方法发生错误：" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region 获取数据库时间

        public static DateTime GetDBTime()
        {
            return Convert.ToDateTime(GetSingleResult("select getdate()"));
        }
        #endregion
    }
}
