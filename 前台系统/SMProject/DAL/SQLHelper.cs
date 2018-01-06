using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class SQLHelper
    {
        private static readonly string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

        /// <summary>
        /// 带参数的增删改，适合单条SQL语句
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
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (SqlException ex)
            {
                throw new Exception("数据库错误：" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 获得单条查询结果
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql, SqlParameter[] parameters)
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
                throw new Exception("数据库错误：" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public static SqlDataReader GetReader(string sql, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql,conn);
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
                throw new Exception("数据库错误：" + ex.Message);
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                throw ex;
            }          
        }

        //基于事务，执行多条SQL语句
        public static bool UpdateByTran(List<string> sqlList)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.Transaction = conn.BeginTransaction();//开启事务
                foreach (var sql in sqlList)
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();//此时与数据库连接未关闭，直到循环结束
                }
                cmd.Transaction.Commit();//提交事务
                return true;
            }
            catch (SqlException ex)
            {
                if (cmd.Transaction != null)
                    cmd.Transaction.Rollback();//事务回滚，保证数据的一致性
                throw new Exception("数据库发送错误：" + ex.Message);
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                    cmd.Transaction.Rollback();//事务回滚，保证数据的一致性        
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cmd.Transaction != null)
                    cmd.Transaction = null;
                conn.Close();
            }
        }


        //基于事务，执行多条SQL语句，带参数
        //public static bool UpdateByTranAndParamers(List<string> sqlList,SqlParameter[] paramers)
        //{
        //    SqlConnection conn = new SqlConnection(connString);
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = conn;
        //    try
        //    {
        //        conn.Open();
        //        cmd.Transaction = conn.BeginTransaction();//开启事务
        //        foreach (var sql in sqlList)
        //        {
        //            cmd.CommandText = sql;
        //            cmd.Parameters.AddRange(paramers);
        //            cmd.ExecuteNonQuery();//此时与数据库连接未关闭，直到循环结束
        //        }
        //        cmd.Transaction.Commit();//提交事务
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        if (cmd.Transaction != null)
        //            cmd.Transaction.Rollback();//事务回滚，保证数据的一致性
        //        throw new Exception("数据库发送错误：" + ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (cmd.Transaction != null)
        //            cmd.Transaction.Rollback();//事务回滚，保证数据的一致性        
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (cmd.Transaction != null)
        //            cmd.Transaction = null;
        //        conn.Close();
        //    }
        //}
    }
}
