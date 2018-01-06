using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    [Serializable]
    public class ProductCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
