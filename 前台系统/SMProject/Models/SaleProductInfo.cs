using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SaleProductInfo
    {
        public Product SaleProduct { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }//货币类型
        public string Unit { get; set; }//单位
        public decimal Discount { get; set; }
        public int Num { get; set; }//序号
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
    }
}
