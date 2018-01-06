using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Models;

namespace SMManager
{
    public partial class FrmProductStorage : Form
    {
        private ProductManager objProductManager = new ProductManager();        
        private Product objCurrentProduct = null;
        public FrmProductStorage()
        {
            InitializeComponent();

            this.txtProductId.Focus();
        }

        public FrmProductStorage(Product objProduct ):this()
        {
            this.txtProductId.Text = objProduct.ProductId;
            this.txtProductName.Text = objProduct.ProductName;

            this.objCurrentProduct = objProduct;

            this.txtProductId.ReadOnly = true;
            this.txtQuantity.Focus();
        }


        //查询商品信息
        private void txtProductId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                objCurrentProduct = objProductManager.GetPreciseProductByProductId(this.txtProductId.Text.Trim());   
                if (objCurrentProduct==null)
                {
                    MessageBox.Show("查无该商品！", "查询提示");
                    return;
                }

                this.txtProductName.Text = objCurrentProduct.ProductName;
            }
        }
        private void txtProductId_Leave(object sender, EventArgs e)
        {
        }
        //执行商品入库（点击“入库确认”按钮）
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.txtProductId.Text.Trim() == string.Empty || this.txtProductName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("入库信息不完善！", "入库提示");
                return;
            }
            if (this.txtQuantity.Text.Length == 0)
            {
                MessageBox.Show("请输入需要入库的数量！","入科提示");
                return;
            }

            objCurrentProduct.Quantity = Convert.ToInt32(this.txtQuantity.Text);
            if (objCurrentProduct.Quantity < 0 && Math.Abs(objCurrentProduct.Quantity) > objCurrentProduct.TotalCount)
            {
                MessageBox.Show("数量错误！","入库提示");
                return;
            }

            objCurrentProduct.TotalCount += objCurrentProduct.Quantity;
            if (MessageBox.Show($"确定对该商品 [商品名称] {objCurrentProduct.ProductName} [入库数量] {objCurrentProduct.Quantity} 吗？", "入库提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (objProductManager.ModifyProductStorage(objCurrentProduct, Program.objCurrentAdmin.LoginId))
                {
                    MessageBox.Show("入库成功！", "入库提示");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("入库失败！", "入库提示");
                }
            }
        }
        //执行商品入库（在“入库数量”文本框中点击回车键）
        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnConfirm_Click(null,null);
            }
        }

        //限制只能输入数字与删除键--backspace+delete
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char)8 || e.KeyChar == (char)48||e.KeyChar=='-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmProductStorage_FormClosing(object sender, FormClosingEventArgs e)
        {            
            FrmMain.objStorage = null;           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtProductId.ReadOnly = false;
            this.txtProductId.Clear();
            this.txtQuantity.Clear();
            this.txtProductId.Focus();
            this.txtProductName.Clear();
        }

        
    }
}
