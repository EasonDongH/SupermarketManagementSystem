using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    public class ProductManager
    {
        private ProductService objProductService = new ProductService();
        public List<ProductUnit> GetProductUnit()
        {
            return objProductService.GetProductUnit();
        }

        public List<ProductCategory> GetProductCategory()
        {
            return objProductService.GetProductCategory();
        }

        public bool AddProduct(Product objProduct)
        {
            return objProductService.AddProduct(objProduct);
        }

        public bool ProductIdIsExist(string productId)
        {
            return objProductService.ProductIdIsExist(productId);
        }

        public bool ProductIdIsExistExceptProductName(string productId,string productName)
        {
            return objProductService.ProductIdIsExistExceptProductName(productId, productName);
        }

        public bool ProductNameIsExist(string productName)
        {
            return objProductService.ProductNameIsExist(productName);
        }

        public List<Product> GetProductInfo(string productId, string productName, int categoryId)
        {
            return objProductService.GetProductInfo(productId, productName, categoryId);
        }

        public Product GetPreciseProductByProductId(string productId)
        {
            return objProductService.GetPreciseProductByProductId(productId);
        }

        public bool ModifyProductStorage(Product objProduct, int loginId)
        {
            return objProductService.ModifyProductStorage(objProduct, loginId);
        }

        public bool DeleteProductBuProductId(string productId)
        {
            return objProductService.DeleteProductByProductId(productId);
        }

        public bool ModfiyProductInfo(Product objProduct,Product newProduct)
        {
            return objProductService.ModfiyAllProductInfo(objProduct,newProduct);
        }

        public bool ModifyProductDiscount(int discount,string productId)
        {
            return objProductService.ModifyProductDiscount(discount,productId);
        }

        public bool ModifyProductWarningInfo(Product objProduct)
        {
            return objProductService.ModifyProductStorageWariningInfo(objProduct);
        }
    }
}
