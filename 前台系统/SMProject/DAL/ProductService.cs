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
    public class ProductService
    {
        public Product GetProductInfoById(string productId)
        {
            StringBuilder sqlBuilder = new StringBuilder(
                "select ProductId, ProductName, UnitPrice, Unit, Discount, ProductCategory.CategoryId,CategoryName from Products ");
            sqlBuilder.Append("inner join ProductCategory on ProductCategory.CategoryId=Products.CategoryId ");
            sqlBuilder.Append("where ProductId=@ProductId");
            SqlDataReader objReader = null;
            Product objProduct = null;
            try
            {
                objReader = SQLHelper.GetReader(sqlBuilder.ToString(), new SqlParameter[] { new SqlParameter("@ProductId", productId) });
                if (objReader.Read())
                {
                    objProduct = new Product()
                    {
                        ProductId = productId,
                        ProductName = objReader["ProductName"].ToString(),
                        UnitPrice = Convert.ToDecimal(objReader["UnitPrice"]),
                        Unit = objReader["Unit"].ToString(),
                        Discount = Convert.ToDecimal(objReader["Discount"]),
                        CategoryId = Convert.ToInt32(objReader["CategoryId"]),
                        CategoryName = objReader["CategoryName"].ToString()
                    };
                }
                return objProduct;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objReader != null)
                    objReader.Close();
            }
        }

        public bool UpdateSaleInfo(SaleInfo sale)
        {
            StringBuilder sqlBuilder = new StringBuilder("insert into SalesList(SerialNum, TotalMoney, RealReceive, ReturnMoney, SalePeronId, SalePeronName) values ('{0}',{1},{2},{3},{4},'{5}')");
            StringBuilder sqlBuilder1 = new StringBuilder("insert into SalesListDetail(SerialNum, ProductId, ProductName, UnitPrice, Discount, Quantity, SubTotalMoney) values ('{0}','{1}','{2}',{3},{4},{5},{6})");
            StringBuilder sqlBuilder2 = new StringBuilder("update ProductInventory set TotalCount={0} where ProductId = '{1}'");

            List<string> sqlList = new List<string>();
            //[SalesList]：SerialNum, TotalMoney, ReadlReceive, ReturnMoney, SalePeronId, SalePeronName, SaleDate
            string sql = string.Format(sqlBuilder.ToString(), sale.SerialNum, sale.TotalMoney, sale.RealMoney, sale.ReturnMoney, sale.SalePersonId, sale.SalePersonName);
            sqlList.Add(sql);
            try
            {
                foreach (var product in sale.objProduct)
                {                    
                    //销售详情表[SalesListDetail]：DetailId, SerialNum, ProductId, ProductName, UnitPrice, Discount, Quantity, SubTotalMoney
                    string sql1 = string.Format(sqlBuilder1.ToString(), sale.SerialNum, product.ProductId, product.ProductName, product.UnitPrice, product.Discount, product.Quantity, product.SubTotal);
                    sqlList.Add(sql1);
                    //商品库存表ProductInventory相应商品需要更新数量，ProductId, TotalCount, MinCount, MaxCount, StatusId
                    //这里还需要判断库存剩余
                    int total = Convert.ToInt32(SQLHelper.GetSingleResult("select TotalCount from ProductInventory where ProductId=@ProductId", new SqlParameter[] { new SqlParameter("@ProductId", product.ProductId) }));
                    string sql2 = string.Format(sqlBuilder2.ToString(), total - product.Quantity,product.ProductId);
                    sqlList.Add(sql2);                    
                }

                if (SQLHelper.UpdateByTran(sqlList))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateSaleInfoByParamers(SaleInfo sale)
        {
            StringBuilder sqlBuilder = new StringBuilder("insert into SalesList(SerialNum, TotalMoney, RealReceive, ReturnMoney, SalePeronId, SalePeronName) values (@SerialNum, @TotalMoney, @RealReceive, @ReturnMoney, @SalePeronId, @SalePeronName)");
            StringBuilder sqlBuilder1 = new StringBuilder("insert into SalesListDetail(SerialNum, ProductId, ProductName, UnitPrice, Discount, Quantity, SubTotalMoney) values (@SerialNum, @ProductId, @ProductName, @UnitPrice, @Discount, @Quantity, @SubTotalMoney)");
            StringBuilder sqlBuilder2 = new StringBuilder("update ProductInventory set TotalCount={0} where ProductId = '{1}'");

            List<string> sqlList = new List<string>();
            //[SalesList]：SerialNum, TotalMoney, ReadlReceive, ReturnMoney, SalePeronId, SalePeronName, SaleDate
            string sql = string.Format(sqlBuilder.ToString(), sale.SerialNum, sale.TotalMoney, sale.RealMoney, sale.ReturnMoney, sale.SalePersonId, sale.SalePersonName);
            sqlList.Add(sql);
            try
            {
                foreach (var product in sale.objProduct)
                {
                    //销售详情表[SalesListDetail]：DetailId, SerialNum, ProductId, ProductName, UnitPrice, Discount, Quantity, SubTotalMoney
                    string sql1 = string.Format(sqlBuilder1.ToString(), sale.SerialNum, product.ProductId, product.ProductName, product.UnitPrice, product.Discount, product.Quantity, product.SubTotal);
                    sqlList.Add(sql1);
                    //商品库存表ProductInventory相应商品需要更新数量，ProductId, TotalCount, MinCount, MaxCount, StatusId
                    //这里还需要判断库存剩余
                    int total = Convert.ToInt32(SQLHelper.GetSingleResult("selec TotalCount from ProductInventory where ProductId=@ProductId", new SqlParameter[] { new SqlParameter("@ProductId", product.ProductId) }));
                    string sql2 = string.Format(sqlBuilder2.ToString(), total - product.Quantity, product.ProductId);
                    sqlList.Add(sql2);
                }

                if (SQLHelper.UpdateByTran(sqlList))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
