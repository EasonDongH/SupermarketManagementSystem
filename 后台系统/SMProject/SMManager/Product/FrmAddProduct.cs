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
    public partial class FrmAddProduct : Form
    {
        private ProductManager objProductManager = new ProductManager();
        public FrmAddProduct()
        {
            InitializeComponent();

            try
            {
                this.cboUnit.DataSource = objProductManager.GetProductUnit();
                this.cboUnit.DisplayMember = "Unit";
                this.cboUnit.ValueMember = "UnitId";
                this.cboUnit.SelectedIndex = 0;

                this.cboCategory.DataSource = objProductManager.GetProductCategory();
                this.cboCategory.DisplayMember = "CategoryName";
                this.cboCategory.ValueMember = "CategoryId";
                this.cboCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库发生错误，请检查连接后再次尝试或联系管理员！", "错误提示");

                new ErrorLogManager().ErrorLog(new ErrorLog
                {
                    LoginId = Program.objCurrentAdmin.LoginId,
                    Operate = Operate.ErrorHappenedWhenDataBaseQuery,
                    ErrorMessage = ex.Message
                });
            }

        }
        //添加锁定分类按钮，避免输入同类商品时频繁选择问题
        private void btnLock_Click(object sender, EventArgs e)
        {
            if (this.btnLock.Text == "锁定")
            {
                this.btnLock.Text = "解锁";
                this.cboUnit.Enabled = false;
                this.cboCategory.Enabled = false;
            }
            else
            {
                this.btnLock.Text = "锁定";
                this.cboUnit.Enabled = true;
                this.cboCategory.Enabled = true;
            }
        }
        //关闭窗口
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmEditProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMain.objAddProduct = null;
        }
        //添加商品
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

            if (this.txtMaxCount.Text == string.Empty)
            {
                MessageBox.Show("最大库存不能为空", "错误提示");
                txtMaxCount.Focus();
                return;
            }

            if (this.txtMinCount.Text == string.Empty)
            {
                MessageBox.Show("最小库存不能为空", "错误提示");
                txtMinCount.Focus();
                return;
            }

            //检查商品编号与商品名称是否已存在
            if (objProductManager.ProductIdIsExist(this.txtProductId.Text.Trim()))
            {
                MessageBox.Show("该商品编号已存在！","添加提示");
                this.txtProductId.Focus();
                return;
            }

            if (objProductManager.ProductNameIsExist(this.txtProductName.Text.Trim()))
            {
                MessageBox.Show("该商品名称已存在！", "添加提示");
                this.txtProductName.Focus();
                return;
            }
            //检查最大库存要大于最小库存
            int maxCount = Convert.ToInt32(this.txtMaxCount.Text);
            int minCount = Convert.ToInt32(this.txtMinCount.Text);
            if (minCount > maxCount)
            {
                MessageBox.Show("最小库存不能比最大库存大！","添加提示");
                this.txtMinCount.Focus();
                return;
            }
            #endregion

            #region 数据封装

            Product objProduct = new Product()
            {
                ProductId=this.txtProductId.Text.Trim(),
                ProductName=this.txtProductName.Text.Trim(),
                Unit=this.cboUnit.Text,
                UnitPrice=Convert.ToDecimal(this.txtUnitPrice.Text),
                CategoryId=Convert.ToInt32(this.cboCategory.SelectedValue),
                MaxCount=maxCount,
                MinCount=minCount
            };
            #endregion

            #region 数据添加
            try
            {
                if (objProductManager.AddProduct(objProduct))
                {
                    if (MessageBox.Show("添加成功！是否继续添加商品？", "添加提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        foreach (var item in gbInfo.Controls)
                        {
                            if (item is TextBox)
                            {
                                TextBox tx = item as TextBox;
                                tx.Clear();
                            }
                        }

                        foreach (var item in gbStorage.Controls)
                        {
                            if (item is TextBox)
                            {
                                TextBox tx = item as TextBox;
                                tx.Clear();
                            }
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("添加失败！具体原因请联系管理员。","添加提示");
                }
            }
            catch (Exception)
            {
                //写入数据库或本地
                throw;
            }
            #endregion
        }

        //库存输入检查：只能输入数字、删除
        private void txtStorageConfim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //验证价格
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
    }
}
