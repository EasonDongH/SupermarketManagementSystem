using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }//货币类型
        public string Unit { get; set; }//单位
        public decimal Discount { get; set; }
        public int CategoryId { get; set; }
        
        //扩展属性
        public string CategoryName { get; set; }//种类
    }
}
