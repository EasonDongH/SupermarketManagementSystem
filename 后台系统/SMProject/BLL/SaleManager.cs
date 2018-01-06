using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    public class SaleManager
    {
        private SaleService objSaleService = new SaleService();
        public List<Product> GetProductSaleStats(string beginDate, string endDate)
        {
            return objSaleService.GetSaleStats(beginDate, endDate);
        }
    }
}
