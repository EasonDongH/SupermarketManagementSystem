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
    public partial class FrmEditProduct : Form
    {
        private ProductManager objProductManager = new ProductManager();
        private Product objProduct = null;
        public FrmEditProduct()
        {
            InitializeComponent();

            this.cboUnit.DataSource = objProductManager.GetProductUnit();
            this.cboUnit.DisplayMember = "Unit";
            this.cboUnit.ValueMember = "UnitId";
            
            this.cboCategory.DataSource = objProductManager.GetProductCategory();
            this.cboCategory.DisplayMember = "CategoryName";
            this.cboCategory.ValueMember = "CategoryId";            
        }

        public FrmEditProduct(Product objProduct):this()
        {
            this.txtProductId.Text = objProduct.ProductId;
            this.txtProductName.Text = objProduct.ProductName;
            this.txtUnitPrice.Text = objProduct.UnitPrice.ToString();

            this.objProduct = objProduct;

            this.cboCategory.Text = objProduct.CategoryName;
            this.cboUnit.Text = objProduct.Unit;
        }
        //提交修改
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            #region 数据验证
            if (this.txtProductId.Text.Trim() == string.Empty)
            {
                MessageBox.Show("商品编号不能为空", "错误提示");
                txtProductId.Focus();
                return;
            }

            if (this.txtProductName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("商品名称不能为空", "错误提示");
                txtProductName.Focus();
                return;
            }
            //已在keypress事件做了限制，不会出现空格
            if (this.txtUnitPrice.Text == string.Empty)
            {
                MessageBox.Show("商品价格不能为空", "错误提示");
                txtUnitPrice.Focus();
                return;
            }

            //检查商品编号与商品名称是否已存在
            if (objProductManager.ProductIdIsExistExceptProductName(this.txtProductId.Text.Trim(),this.objProduct.ProductName))
            {
                MessageBox.Show("该商品编号已存在！", "添加提示");
                this.txtProductId.Focus();
                return;
            }

            if (this.txtProductName.Text.Trim() != this.objProduct.ProductName && objProductManager.ProductNameIsExist(this.txtProductName.Text.Trim()))
            {
                MessageBox.Show("该商品名称已存在！", "添加提示");
                this.txtProductName.Focus();
                return;
            }
            #endregion

            #region 数据封装

            Product objCurrentProduct = new Product
            {
                ProductId = this.txtProductId.Text.Trim(),
                ProductName = this.txtProductName.Text.Trim(),
                Unit = this.cboUnit.Text,
                UnitPrice = Convert.ToDecimal(this.txtUnitPrice.Text),
                CategoryId = Convert.ToInt32(this.cboCategory.SelectedValue)
            };
            #endregion

            #region 数据修改
            try
            {
                if (objProductManager.ModfiyProductInfo(this.objProduct, objCurrentProduct))
                {
                    MessageBox.Show("修改成功！", "修改提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    this.Close();
                    //this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("修改失败！具体原因请联系管理员。", "修改提示");
                }
            }
            catch (Exception)
            {
                //写入数据库或本地
                throw;
            }
            #endregion
        }
        //关闭窗口
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char)8 || (e.KeyChar == '.' && !this.txtUnitPrice.Text.Contains('.')))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void FrmEditProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmProductManage.objEditProduct = null;
        }
    }
}
