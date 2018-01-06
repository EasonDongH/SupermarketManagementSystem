using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace DAL
{
    public class SaleService
    {
        /// <summary>
        /// 获取商品销售统计信息
        /// </summary>
        /// <returns></returns>
        public List<Product> GetSaleStats(string beginDate,string endDate)
        {
            //StringBuilder sqlBuilder =new StringBuilder( "select ProductId,ProductName,Unit,CategoryName,SaleCount=sum(Quantity) from view_ProductSaleStats");
            //sqlBuilder.Append(" group by SaleDate,ProductId,ProductName,Unit,CategoryName");
            //sqlBuilder.Append(" having SaleDate between @BeginDate and @EndDate");
            //sqlBuilder.Append(" order by SaleCount Desc");
            SqlDataReader objReader = null;
            List<Product> objProduct = new List<Product>();
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@BeginDate",beginDate),
                    new SqlParameter("EndDate",endDate)
                };
            try
            {
                objReader = SQLHelper.GetReaderByStoredProcedure("usp_ProdoctSaleStat".ToString(),parameters);
                while (objReader.Read())
                {
                    objProduct.Add(new Product
                    {
                        ProductId = objReader["ProductId"].ToString(),
                        ProductName = objReader["ProductName"].ToString(),
                        Unit = objReader["Unit"].ToString(),
                        CategoryName = objReader["CategoryName"].ToString(),
                        SaleCount = Convert.ToInt32(objReader["SaleCount"])
                    });
                }
                return objProduct;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (objReader != null)
                    objReader.Close();
            }
        }
    }
}
