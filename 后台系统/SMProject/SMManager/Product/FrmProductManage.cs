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
    public partial class FrmProductManage : Form
    {
        private ProductManager objProductManager = new ProductManager();
        private Product objCurrentProduct = null;
        private List<Product> objCurrentProductList = null;
        public FrmProductManage()
        {
            InitializeComponent();

            List<ProductCategory> objCategoryList = new List<ProductCategory>();
            objCategoryList.Add(new ProductCategory { CategoryId = -1, CategoryName = "全部商品" });
            objCategoryList.AddRange(objProductManager.GetProductCategory());
            
            this.cboCategory.DataSource = objCategoryList;
            this.cboCategory.DisplayMember = "CategoryName";
            this.cboCategory.ValueMember = "CategoryId";
            this.cboCategory.SelectedIndex = -1;

            this.dgvProduct.AutoGenerateColumns = false;
        }
        //提交查询
        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryProduct(this.txtProductId.Text.Trim(), this.txtProductName.Text.Trim(), Convert.ToInt32(this.cboCategory.SelectedValue));
        }
        //显示行号
        private void dgvProduct_RowPostPaint(object sender,
            DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(this.dgvProduct, e);
        }
        //显示商品折扣
        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //更新折扣
        private void btnUpdateDiscount_Click(object sender, EventArgs e)
        {
            if (this.txtDiscount.Text.Trim() == string.Empty)
            {
                MessageBox.Show("折扣不能为空!","折扣更新提示");
                this.txtDiscount.Focus();
                return;
            }
            //keypress限制只能输入数字与backspace
            int disCount = Convert.ToInt32(this.txtDiscount.Text.Trim());
            if (disCount>9)
            {
                MessageBox.Show("折扣范围错误!", "折扣更新提示");
                this.txtDiscount.Focus();
                return;
            }

            //数据库折扣更新
            if (objProductManager.ModifyProductDiscount(disCount, objCurrentProduct.ProductId))
            {
                MessageBox.Show("更新成功！", "更新折扣提示");
            }
            else
            {
                MessageBox.Show("更新失败！", "更新折扣提示");
                return;
            }

            int index = this.dgvProduct.CurrentRow.Index;
            this.dgvProduct.Rows[index].Cells["DisCount"].Value = this.txtDiscount.Text.Trim();
            this.objCurrentProduct.Discount = disCount;
        }

        public static FrmEditProduct objEditProduct = null;
        //显示修改窗体，并将当前的商品编号传递给修改窗体
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (this.dgvProduct.CurrentRow == null) return;
            if (objEditProduct == null)
            {
                objEditProduct = new FrmEditProduct(objCurrentProduct);
                //FormStartPosition(FrmMain.objAddProduct);
                objEditProduct.ShowDialog();

                QueryProduct(this.txtProductId.Text.Trim(), this.txtProductName.Text.Trim(), Convert.ToInt32(this.cboCategory.SelectedValue));
            }
            else
            {
                objEditProduct.Activate();//激活最小化的窗体
                objEditProduct.WindowState = FormWindowState.Normal;//让最小化的窗体正常显示
            }
        }

        //删除商品
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (objCurrentProduct == null) return;

            if (MessageBox.Show($"确定要删除 商品编号：[{objCurrentProduct.ProductId}] 商品名称：[{objCurrentProduct.ProductName}] 吗？一旦删除不可撤回！", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //执行删除，同时删除Products、ProuctInventory
                if (objProductManager.DeleteProductBuProductId(objCurrentProduct.ProductId))
                {
                    MessageBox.Show("删除成功！", "删除提示");

                    objCurrentProductList = objCurrentProductList.Where(s => s.ProductId != objCurrentProduct.ProductId).ToList();
                    this.dgvProduct.DataSource = null;
                    this.dgvProduct.DataSource = objCurrentProductList;
                    objCurrentProduct = null;

                }
                else
                {
                    MessageBox.Show("删除失败！", "删除提示");
                }
            }
        }
        //显示添加商品窗口
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if (this.dgvProduct.CurrentRow == null) return;
            if (FrmMain.objAddProduct == null)
            {
                FrmMain.objAddProduct = new FrmAddProduct();
                //FormStartPosition(FrmMain.objAddProduct);
                FrmMain.objAddProduct.ShowDialog();

                QueryProduct(this.txtProductId.Text.Trim(), this.txtProductName.Text.Trim(), Convert.ToInt32(this.cboCategory.SelectedValue));
            }
            else
            {
                FrmMain.objAddProduct.Activate();//激活最小化的窗体
                FrmMain.objAddProduct.WindowState = FormWindowState.Normal;//让最小化的窗体正常显示
            }
        }

        private void QueryProduct(string productId, string productName, int categoryId)
        {
            if (objCurrentProductList != null)
                objCurrentProductList.Clear();

            objCurrentProductList = objProductManager.GetProductInfo(productId, productName, categoryId);
            this.dgvProduct.DataSource = null;
            this.dgvProduct.DataSource = objCurrentProductList;
        }
        //显示商品入库窗口
        private void btnStorage_Click(object sender, EventArgs e)
        {
            if (this.dgvProduct.CurrentRow == null) return;
            //int index = this.dgvProduct.CurrentRow.Index;
            //Product objProduct = new Product()
            //{
            //    ProductId = this.dgvProduct.Rows[index].Cells["ProductId"].Value.ToString(),
            //    ProductName = this.dgvProduct.Rows[index].Cells["ProductName"].Value.ToString(),
            //    TotalCount=Convert.ToInt32(this.dgvProduct.Rows[index].Cells["TotalCount"].Value)
            //};
            if (FrmMain.objStorage == null)
            {
                //使用窗口方式打开，不需要提前保存查询条件                
                FrmMain.objStorage = new FrmProductStorage(objCurrentProduct);
                //FormStartPosition(FrmMain.objStorage);
                FrmMain.objStorage.ShowDialog();
                QueryProduct(this.txtProductId.Text.Trim(), this.txtProductName.Text.Trim(), Convert.ToInt32(this.cboCategory.SelectedValue));
            }
            else
            {
                FrmMain.objStorage.Activate();
                FrmMain.objStorage.WindowState = FormWindowState.Normal;
            }
        }
        //关闭窗体
        private void FrmProductManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMain.objProductManage = null;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormStartPosition(Form objForm)
        {
            objForm.Location = new Point(
                    this.Location.X + this.dgvProduct.Width + (this.dgvProduct.Width - objForm.Width) / 2 + 12,
                    this.Location.Y + (this.dgvProduct.Height - objForm.Height) / 2 + 50);
        }

        private void dgvProduct_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //if (this.dgvProduct.CurrentRow != null)
            //{
            //    int index = this.dgvProduct.CurrentRow.Index;
            //    if (this.dgvProduct.Rows[index].Cells["Discount"].Value != null)
            //        this.txtDiscount.Text = this.dgvProduct.Rows[index].Cells["Discount"].Value.ToString();
            //}
        }

        //当dgv某一行获取焦点时，自动保存该行数据
        private void dgvProduct_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvProduct.CurrentRow != null)
            {
                int index = this.dgvProduct.CurrentRow.Index;
                if (this.dgvProduct.Rows[index].Cells["Discount"].Value != null)
                {
                    this.txtDiscount.Text = this.dgvProduct.Rows[index].Cells["Discount"].Value.ToString();

                    objCurrentProduct = new Product()
                    {
                        ProductId = this.dgvProduct.Rows[index].Cells["ProductId"].Value.ToString(),
                        ProductName = this.dgvProduct.Rows[index].Cells["ProductName"].Value.ToString(),
                        Unit= this.dgvProduct.Rows[index].Cells["Unit"].Value.ToString(),
                        UnitPrice=Convert.ToDecimal(this.dgvProduct.Rows[index].Cells["UnitPrice"].Value),
                        CategoryName= this.dgvProduct.Rows[index].Cells["CategoryName"].Value.ToString(),
                        TotalCount = Convert.ToInt32(this.dgvProduct.Rows[index].Cells["TotalCount"].Value)
                    };
                }
            }
            else
            {
                this.txtDiscount.Clear();
            }
        }
    }
}
