using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace DAL
{
    public class ProductService
    {
        /// <summary>
        /// 获取产品单位
        /// </summary>
        /// <returns></returns>
        public List<ProductUnit> GetProductUnit()
        {
            string sql = "select UnitId,Unit from ProductUnit";
            SqlDataReader objReader = null;
            try
            {
                objReader = SQLHelper.GetReader(sql);
                List<ProductUnit> objUnit = new List<ProductUnit>();
                while (objReader.Read())
                {
                    objUnit.Add(new ProductUnit
                    {
                        UnitId = Convert.ToInt32(objReader["UnitId"]),
                        Unit = objReader["Unit"].ToString()
                    });
                }
                return objUnit;
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
        /// 获取产品分类
        /// </summary>
        /// <returns></returns>
        public List<ProductCategory> GetProductCategory()
        {
            string sql = "select CategoryId,CategoryName from ProductCategory";
            SqlDataReader objReader = null;
            try
            {
                objReader = SQLHelper.GetReader(sql);
                List<ProductCategory> objCategory = new List<ProductCategory>();
                while (objReader.Read())
                {
                    objCategory.Add(new ProductCategory
                    {
                        CategoryId = Convert.ToInt32(objReader["CategoryId"]),
                        CategoryName = objReader["CategoryName"].ToString()
                    });
                }
                return objCategory;
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
        /// 使用存储过程添加新产品
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns></returns>
        public bool AddProduct(Product objProduct)
        {
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ProductId",objProduct.ProductId),
                    new SqlParameter("@ProductName",objProduct.ProductName),
                    new SqlParameter("@Unit",objProduct.Unit),
                    new SqlParameter("@UnitPrice",objProduct.UnitPrice),
                    new SqlParameter("@MaxCount",objProduct.MaxCount),
                    new SqlParameter("@MinCount",objProduct.MinCount),
                    new SqlParameter("@CategoryId",objProduct.CategoryId)
                };
            try
            {
                int result = SQLHelper.UpdateByStoredProcdure("usp_AddNewProduct", parameters);
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //检查ProductId是否已存在
        public bool ProductIdIsExist(string productId)
        {
            string sql = "select count(*) from Products where ProductId=@ProductId";
            try
            {
                int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql, new SqlParameter[] { new SqlParameter("@ProductId", productId) }));
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ProductIdIsExistExceptProductName(string productId,string productName)
        {
            string sql = "select count(*) from Products where ProductId=@ProductId and ProductName <> @ProductName";
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ProductId", productId),
                    new SqlParameter("@ProductName", productName)
                };
            try
            {
                int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql, parameters));
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 检查ProductName是否已存在
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public bool ProductNameIsExist(string productName)
        {
            string sql = "select count(*) from Products where ProductName=@ProductName";
            try
            {
                int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql, new SqlParameter[] { new SqlParameter("@ProductName", productName) }));
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 多条件组合查询商品信息
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productName"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<Product> GetProductInfo(string productId, string productName, int categoryId)
        {
            //sql语句过长，应考虑分开查询，避免“万能方法”
            StringBuilder sqlBuilder = new StringBuilder("select Products.ProductId, ProductName, UnitPrice, Unit, Discount,TotalCount,MaxCount,MinCount,CategoryName,StatusDesc,ProductInventory.StatusId from Products");
            sqlBuilder.Append(" inner join ProductInventory on ProductInventory.ProductId =Products.ProductId");
            sqlBuilder.Append(" inner join InventoryStatus on InventoryStatus.StatusId =ProductInventory.StatusId");
            sqlBuilder.Append(" inner join ProductCategory on ProductCategory.CategoryId =Products.CategoryId where 1=1");

            //SqlParameter[] parameters = new SqlParameter[] { };
            List<SqlParameter> parameterList = new List<SqlParameter>();
            if (productId != null && productId != string.Empty)
            {
                sqlBuilder.Append(" and Products.ProductId like @ProductId");
                parameterList.Add(new SqlParameter("@ProductId", "%" + productId + "%"));
            }
            if (productName != null && productName != string.Empty)
            {
                sqlBuilder.Append(" and ProductName like @ProductName");
                parameterList.Add(new SqlParameter("@ProductName", "%" + productName + "%"));
            }
            if (categoryId >= 0)
            {
                sqlBuilder.Append(" and Products.CategoryId = @CategoryId");
                parameterList.Add(new SqlParameter("@CategoryId", categoryId));
            }

            List<Product> objProduct = new List<Product>();
            SqlDataReader objReader = null;
            try
            {
                objReader = SQLHelper.GetReader(sqlBuilder.ToString(), parameterList.ToArray());
                while (objReader.Read())
                {
                    objProduct.Add(new Product()
                    {
                        ProductId = objReader["ProductId"].ToString(),
                        ProductName = objReader["ProductName"].ToString(),
                        Unit = objReader["Unit"].ToString(),
                        UnitPrice = Convert.ToDecimal(objReader["UnitPrice"]),
                        TotalCount = Convert.ToInt32(objReader["TotalCount"]),
                        Discount = Convert.ToInt32(objReader["Discount"]),
                        CategoryName = objReader["CategoryName"].ToString(),
                        MaxCount = Convert.ToInt32(objReader["MaxCount"]),
                        MinCount = Convert.ToInt32(objReader["MinCount"]),
                        InventoryStatus=objReader["StatusDesc"].ToString(),
                        StatusId=Convert.ToInt32(objReader["StatusId"])                       
                    });
                }

                return objProduct;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 根据productId获取准确商品信息---对比模糊查询
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product GetPreciseProductByProductId(string productId)
        {
            StringBuilder sqlbuilder = new StringBuilder("select ProductName,TotalCount from Products");
            sqlbuilder.Append(" inner join ProductInventory on ProductInventory.ProductId=Products.ProductId");
            sqlbuilder.Append(" where Products.ProductId=@ProductId");
            Product objProduct = null;
            SqlDataReader objReader = null;
            try
            {
                objReader = SQLHelper.GetReader(sqlbuilder.ToString(), new SqlParameter[] { new SqlParameter("@ProductId", productId) });
                if (objReader.Read())
                {
                    objProduct = new Product()
                    {
                        ProductId = productId,
                        ProductName = objReader["ProductName"].ToString(),
                        TotalCount = Convert.ToInt32(objReader["TotalCount"]),
                    };
                }
                return objProduct;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 修改商品当前库存信息
        /// </summary>
        /// <param name="objProduct"></param>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public bool ModifyProductStorage(Product objProduct, int loginId)
        {
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@AddCount",objProduct.Quantity),
                    new SqlParameter("@TotalCount",objProduct.TotalCount),
                    //new SqlParameter("@MaxCount",objProduct.MaxCount),
                    //new SqlParameter("@MinCount",objProduct.MinCount),
                    new SqlParameter("@ProductId",objProduct.ProductId),
                    new SqlParameter("@LoginId",loginId)
                };
            try
            {
                int result = SQLHelper.UpdateByStoredProcdure("usp_ModifyProductInventory", parameters);
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改商品预警信息
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns></returns>
        public bool ModifyProductStorageWariningInfo(Product objProduct)
        {
            
            string sql = "update ProductInventory set MaxCount=@MaxCount,MinCount=@MinCount,StatusId=@StatusId where ProductId=@ProductId";
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaxCount",objProduct.MaxCount),
                    new SqlParameter("@MinCount",objProduct.MinCount),
                    new SqlParameter("@ProductId",objProduct.ProductId),
                    new SqlParameter("@StatusId",objProduct.StatusId)
                };
            try
            {
                int result = SQLHelper.Update(sql,parameters);
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool DeleteProductByProductId(string productId)
        {
            List<string> sqlList = new List<string>();
            //存在表间约束，顺序不可逆
            sqlList.Add($"delete from ProductInventory where ProductId='{productId}'");
            sqlList.Add($"delete from Products where ProductId='{productId}'");
            
            try
            {
                int result= SQLHelper.UpdateByTran(sqlList);
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 更新商品信息
        /// </summary>
        /// <param name="currentProduct"></param>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        public bool ModfiyAllProductInfo(Product currentProduct,Product newProduct)
        {
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ProductId",currentProduct.ProductId),
                    new SqlParameter("@NewProductId",newProduct.ProductId),
                    new SqlParameter("@ProductName",newProduct.ProductName),
                    new SqlParameter("@Unit",newProduct.Unit),
                    new SqlParameter("@UnitPrice",newProduct.UnitPrice),
                    new SqlParameter("@CategoryId",newProduct.CategoryId)
                };
            try
            {
                int result = SQLHelper.UpdateByStoredProcdure("usp_ModifyProductInfo", parameters);
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 修改商品折扣
        /// </summary>
        /// <param name="discount"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool ModifyProductDiscount(int discount,string productId)
        {
            string sql = "update Products set Discount=@Discount where ProductId=@ProductId";
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Discount",discount),
                    new SqlParameter("@ProductId",productId)
                };
            try
            {
                int result = SQLHelper.Update(sql,parameters);
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }



        
    }
}
