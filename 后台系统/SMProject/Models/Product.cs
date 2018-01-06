using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 商品实体类
    /// </summary>
    [Serializable]
    public class Product
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public int Discount { get; set; }

        //扩展属性：供扫描商品并显示商品信息时使用
        public int Num { get; set; }//商品序号
        public int Quantity { get; set; }//购买数量
        public double SubTotal { get; set; }//小计金额

        /// <summary>
        /// 分类编号
        /// </summary>
        public int CategoryId { get; set; }
        //直接扩展：商品分类名称
        public string CategoryName { get; set; }

        //扩展两个库存的属性
        public int MaxCount { get; set; }//最大库存
        public int MinCount { get; set; }//最小库存
        //扩展库存状态
        public string InventoryStatus { get; set; }
        public int StatusId { get; set; }
        //扩展当前商品库存总数
        public int TotalCount { get; set; }
        //销售总量
        public int SaleCount { get; set; }
    }
}
