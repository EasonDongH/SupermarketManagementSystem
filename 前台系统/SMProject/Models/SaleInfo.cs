using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SaleInfo
    {
        public SaleInfo()
        {
            objProduct = new List<SaleProductInfo>();
        }

        public string SerialNum { get; set; }
        public int SalePersonId { get; set; }
        public string SalePersonName { get; set; }
        public decimal TotalMoney { get; set; }
        public decimal RealMoney { get; set; }
        public decimal ReturnMoney { get; set; }
        public List<SaleProductInfo> objProduct { get; set; }
    }
}
