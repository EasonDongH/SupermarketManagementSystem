using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using BLL;

namespace SMManager
{
    public partial class FrmInventoryManage : Form
    {
        private ProductManager objProductManager = new ProductManager();
        private List<Product> objCurrentProductList = null;
        private Product objCurrentProduct = null;
        private List<Product> objBeyondProductInventory = null;//超出库存
        private List<Product> objBelowProductInventory = null;//低于库存
        public FrmInventoryManage()
        {
            InitializeComponent();

            List<ProductCategory> objCategoryList = new List<ProductCategory>();
            objCategoryList.Add(new ProductCategory { CategoryId = -1, CategoryName = "全部商品" });
            objCategoryList.AddRange(objProductManager.GetProductCategory());

            this.cboCategory.DataSource = objCategoryList;
            this.cboCategory.DisplayMember = "CategoryName";
            this.cboCategory.ValueMember = "CategoryId";
            this.cboCategory.SelectedIndex = -1;

            GetWarningInfo();

            this.dgvProduct.AutoGenerateColumns = false;
        }

        //显示行号
        private void dgvProduct_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(this.dgvProduct, e);
        }

        //获取预警信息
        private void GetWarningInfo()
        {
            //获取所有商品信息
            objCurrentProductList = objProductManager.GetProductInfo(null, null, -1);
            objBeyondProductInventory = objCurrentProductList.Where(s => s.StatusId == 2).ToList();//超出库存statusId=2
            objBelowProductInventory = objCurrentProductList.Where(s => s.StatusId == -1).ToList();//超出库存statusId=-1

            this.lblCount.Text = (this.objBelowProductInventory.Count + this.objBeyondProductInventory.Count).ToString();
            this.lblBeyondCount.Text = this.objBeyondProductInventory.Count.ToString();
            this.lblBelowCount.Text = this.objBelowProductInventory.Count.ToString();
        }

        //刷新库存预警信息
        private void linklbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetWarningInfo();
        }
        //查看超出商品库存上限的商品信息
        private void btnShowMax_Click(object sender, EventArgs e)
        {
            this.dgvProduct.DataSource = null;
            this.dgvProduct.DataSource = this.objBeyondProductInventory;
        }
        //查看低于商品库存下限的商品信息
        private void btnShowMin_Click(object sender, EventArgs e)
        {
            this.dgvProduct.DataSource = null;
            this.dgvProduct.DataSource = this.objBelowProductInventory;
        }

        //根据多条件查询商品信息且显示在dgv
        private void QueryProduct(string productId, string productName, int categoryId)
        {
            if (objCurrentProductList != null)
                objCurrentProductList.Clear();

            objCurrentProductList = objProductManager.GetProductInfo(productId, productName, categoryId);
            this.dgvProduct.DataSource = null;
            this.dgvProduct.DataSource = objCurrentProductList;
        }

        //提交查询
        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryProduct(this.txtProductId.Text.Trim(), this.txtProductName.Text.Trim(), Convert.ToInt32(this.cboCategory.SelectedValue));
        }
        //同步显示库存数据
        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = this.dgvProduct.CurrentRow.Index;

            objCurrentProduct = new Product
            {
                ProductId = this.dgvProduct.Rows[index].Cells["ProductId"].Value.ToString(),
                ProductName= this.dgvProduct.Rows[index].Cells["ProductName"].Value.ToString(),
                MaxCount =Convert.ToInt32(this.dgvProduct.Rows[index].Cells["MaxCount"].Value),
                MinCount=Convert.ToInt32(this.dgvProduct.Rows[index].Cells["MinCount"].Value),
                TotalCount=Convert.ToInt32(this.dgvProduct.Rows[index].Cells["TotalCount"].Value)
            };
            this.txtMaxCount.Text = objCurrentProduct.MaxCount.ToString();
            this.txtMinCount.Text = objCurrentProduct.MinCount.ToString();
            this.txtTotalCount.Text = objCurrentProduct.TotalCount.ToString();
        }
        //调整库存预警设置
        private void btnUpdateSet_Click(object sender, EventArgs e)
        {
            if (this.dgvProduct == null || !ConfirmData(this.txtMaxCount)||!ConfirmData(this.txtMinCount))
            {
                return;
            }

            //应有权限限制
            int minCount = Convert.ToInt32(this.txtMinCount.Text);
            int maxCount = Convert.ToInt32(this.txtMaxCount.Text);
            
            if (MessageBox.Show($"确定对该商品 商品名称 [{objCurrentProduct.ProductName}] 更新 最大库存 [{maxCount}],最小库存[{minCount}] 吗？", "更新提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                objCurrentProduct.MinCount = minCount;
                objCurrentProduct.MaxCount = maxCount;
                int statusId= this.objCurrentProduct.TotalCount > objCurrentProduct.MaxCount ? 2 : (this.objCurrentProduct.TotalCount < this.objCurrentProduct.MinCount&&this.objCurrentProduct.TotalCount>0 ? -1 : (this.objCurrentProduct.TotalCount==0?-2:1));
                this.objCurrentProduct.StatusId = statusId;
                if (objProductManager.ModifyProductWarningInfo(objCurrentProduct))
                {
                    MessageBox.Show("更新成功！", "更新提示");
                    //更新商品表
                    GetWarningInfo();
                    //如何实时更新界面数据？   
                    this.dgvProduct.Rows[this.dgvProduct.CurrentRow.Index].Cells["MinCount"].Value = minCount;
                    this.dgvProduct.Rows[this.dgvProduct.CurrentRow.Index].Cells["MaxCount"].Value = maxCount;
                    this.dgvProduct.Rows[this.dgvProduct.CurrentRow.Index].Cells["InventoryStatus"].Value = statusId==2 ? "高于库存" : (statusId==-1 ? "低于库存" :(statusId==-2?"清仓":"正常"));
                }
                else
                {
                    MessageBox.Show("更新失败！", "更新提示");
                }
            }
        }

        //检查数据，可以设为业务逻辑
        private bool ConfirmData(TextBox objText)
        {
            //默认已经通过keypress控制只能输入数字与删除键
            if (objText.Text == string.Empty)
            {
                MessageBox.Show("数据格式错误！", "更新提示");
                return false;
            }
            else
            {
                return true;
            }
        }

        //更新当前库存数据
        private void btnUpdateInventory_Click(object sender, EventArgs e)
        {
            if(this.dgvProduct==null||!ConfirmData(this.txtTotalCount))
            {
                return;
            }

            //应有权限限制
            int inventory= Convert.ToInt32(this.txtTotalCount.Text);
            
            if (MessageBox.Show($"确定对该商品 商品名称 [{objCurrentProduct.ProductName}] 更新 库存数量 [{inventory}] 吗？", "更新提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                objCurrentProduct.Quantity = inventory;
                objCurrentProduct.TotalCount = inventory;
                int statusId = this.objCurrentProduct.TotalCount > objCurrentProduct.MaxCount ? 2 : (this.objCurrentProduct.TotalCount < this.objCurrentProduct.MinCount && this.objCurrentProduct.TotalCount > 0 ? -1 : (this.objCurrentProduct.TotalCount == 0 ? -2 : 1));
                this.objCurrentProduct.StatusId = statusId;
                if (objProductManager.ModifyProductStorage(objCurrentProduct, Program.objCurrentAdmin.LoginId))
                {
                    MessageBox.Show("更新成功！", "更新提示");
                    //更新商品表
                    GetWarningInfo();
                    //如何实时更新界面数据？   
                    this.dgvProduct.Rows[this.dgvProduct.CurrentRow.Index].Cells["TotalCount"].Value = inventory;
                    this.dgvProduct.Rows[this.dgvProduct.CurrentRow.Index].Cells["InventoryStatus"].Value = statusId == 2 ? "高于库存" : (statusId == -1 ? "低于库存" : (statusId == -2 ? "清仓" : "正常"));
                }
                else
                {
                    MessageBox.Show("更新失败！", "更新提示");
                }
            }
        }
        //关闭窗口
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmInventoryManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMain.objInventoryManage = null;
        }
    }
}
