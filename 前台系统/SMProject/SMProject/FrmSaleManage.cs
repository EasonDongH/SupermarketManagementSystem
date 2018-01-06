using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using DAL;

namespace SMProject
{
    public partial class FrmSaleManage : Form
    {
        private List<SaleProductInfo> saleProductList = new List<SaleProductInfo>();
        private BindingSource bs = new BindingSource();

        #region  窗体拖动、关闭【实际项目中不用】

        private Point mouseOff;//鼠标移动位置变量
        private bool leftFlag;//标签是否为左键
        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }
        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }
        private void FrmMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }

        #endregion


        public FrmSaleManage()
        {
            InitializeComponent();

            this.lblSalePerson.Text = Program.objCurrentLoginer.LoginName;
            this.dgvProdutList.AutoGenerateColumns = false;
        }

        //库存商品，禁止更改价格与折扣
        private void ForbidChanage()
        {
            this.txtUnitPrice.Enabled = false;
            this.txtDiscount.Enabled = false;
        }
        //未知商品，允许修改信息
        private void AllowForbidChanage()
        {
            this.txtUnitPrice.Enabled = true;
            this.txtDiscount.Enabled = false;
        }

        private void txtProductId_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                //enter键
                case 13:
                    if (this.dgvProdutList.RowCount == 0) PrepareForSettleAccounts();
                    AddProductToSaleList(); break;
                //up键
                case 38:
                    if (this.dgvProdutList.RowCount < 2) return;
                    this.bs.MovePrevious(); break;
                //down键
                case 40:
                    if (this.dgvProdutList.RowCount < 2) return;
                    this.bs.MoveNext(); break;
                //del键
                case 46:
                    DeleteCurrentProduct(); break;
                //F1
                case 112:
                    Balance(); break;
                //F10
                case 121:
                    if (MessageBox.Show("确定退出系统？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    { Application.Exit(); }
                    break;
                //F4清除所有商品与信息
                case 115:
                    if (MessageBox.Show("确定全部清除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    { return; }
                    this.lblTotalMoney.Text = "0.00";
                    ResetInfo(); break;
            }
        }

        //当键入第一个商品的时候，需要：生成新的流水号，清除上次结算的商品信息与结算信息
        private void PrepareForSettleAccounts()
        {
            this.lblTotalMoney.Text = this.lblReceivedMoney.Text = this.lblReturnMoney.Text = "0.00";
            CreateSerialNum();
        }
        //生成流水账号
        private void CreateSerialNum()
        {
            Random random = new Random();
            int ranNum = random.Next(10, 99);
            string time = DateTime.Now.ToString("yyyyMMddHHmmssms");
            this.lblSerialNum.Text = time + ranNum;
        }
        //将商品加入到购物列表
        private void AddProductToSaleList()
        {
            if (this.txtProductId.Text.Trim() == string.Empty || this.txtQuantity.Text.Trim() == string.Empty)
                return;

            var pro = from p in this.saleProductList
                      where p.ProductId.Equals(this.txtProductId.Text.Trim())
                      select p;
            if (pro.Count() > 0)
            {
                SaleProductInfo obj = pro.FirstOrDefault<SaleProductInfo>();
                obj.Quantity += Convert.ToInt32(this.txtQuantity.Text.Trim());
                obj.SubTotal = Math.Round(obj.Quantity * obj.UnitPrice * (obj.Discount == 0 ? 1 : obj.Discount) / 10, 2);
                //return;
            }
            else
            {
                //购物列表没有该商品
                if (!AddNewProductToSaleList()) return;
            }

            this.bs.DataSource = this.saleProductList;
            this.dgvProdutList.DataSource = null;
            this.dgvProdutList.DataSource = this.bs;
            //修改总金额
            this.lblTotalMoney.Text = (from p in this.saleProductList select p.SubTotal).Sum().ToString();

            ClearProductInfo();
        }
        //清除商品信息，如商品ID、单价、数量、折扣
        private void ClearProductInfo()
        {
            this.txtProductId.Clear();
            this.txtQuantity.Text = "1";
            this.txtUnitPrice.Text = "0.00";
            this.txtDiscount.Text = "0";
        }
        //将新商品加入到购物列表
        private bool AddNewProductToSaleList()
        {
            SaleProductInfo objSaleProduct = null;
            Product objProduct = new ProductService().GetProductInfoById(this.txtProductId.Text.Trim());
            if (objProduct == null)//商品不存在
            {
                if (Convert.ToDecimal(this.txtUnitPrice.Text.Trim()) == 0 && MessageBox.Show("请问该商品不要钱吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                { return false; }

                objProduct = new Product()
                {
                    ProductId = this.txtProductId.Text.Trim().ToString(),
                    ProductName = "暂未登记商品",
                    UnitPrice = Convert.ToDecimal(this.txtUnitPrice.Text.Trim()),
                    Discount = this.txtDiscount.Text.Trim() == string.Empty ? 0 : Convert.ToDecimal(this.txtDiscount.Text.Trim())//若折扣框为空
                };

            }

            objSaleProduct = new SaleProductInfo()
            {
                //SaleProduct = objProduct,
                ProductId = objProduct.ProductId,
                ProductName = objProduct.ProductName,
                UnitPrice = objProduct.UnitPrice,
                Discount = Math.Round(objProduct.Discount, 1),
                Num = saleProductList.Count + 1,
                Quantity = Convert.ToInt32(this.txtQuantity.Text.Trim()),
                SubTotal = Math.Round(Convert.ToDecimal(Convert.ToInt32(this.txtQuantity.Text.Trim()) * objProduct.UnitPrice * (objProduct.Discount == 0 ? 1 : objProduct.Discount / 10)), 2)
            };

            saleProductList.Add(objSaleProduct);
            this.bs.MoveLast();

            return true;
        }
        //删除选中商品
        private void DeleteCurrentProduct()
        {
            if (this.dgvProdutList.RowCount <= 0) return;

            //int index = this.dgvProdutList.CurrentRow.Index;
            //this.saleProductList.RemoveAt(index);

            //for (int i = index; i < this.saleProductList.Count; i++)
            //{
            //    this.saleProductList[i].Num -= 1;
            //}
            this.bs.RemoveCurrent();//从bs里面删除会自动从绑定源删除
            this.dgvProdutList.DataSource = null;
            this.dgvProdutList.DataSource = this.bs;

            //可以写到dgv RowRemoved事件
            this.lblTotalMoney.Text = (from p in this.saleProductList select p.SubTotal).Sum().ToString();
            for (int i = 0; i < this.saleProductList.Count; i++)
            {
                this.saleProductList[i].Num = i + 1;
            }
        }
        //进入结算界面
        private void Balance()
        {
            FrmBalance frm = new FrmBalance(this.lblTotalMoney.Text);
            frm.ShowDialog();
            string[] temp = frm.Tag.ToString().Split('|');
            if (temp[0].Equals("F3"))//正常结账
            {
                this.lblReceivedMoney.Text = temp[1];
                this.lblReturnMoney.Text = (Convert.ToDecimal(this.lblReceivedMoney.Text) - Convert.ToDecimal(this.lblTotalMoney.Text)).ToString();
                SaleInfo objSale = new SaleInfo()
                {
                    SerialNum = this.lblSerialNum.Text,
                    SalePersonId = Program.objCurrentLoginer.LoginId,
                    SalePersonName = Program.objCurrentLoginer.LoginName,
                    TotalMoney=Convert.ToDecimal(this.lblTotalMoney.Text),
                    RealMoney =Convert.ToDecimal(this.lblReceivedMoney.Text),//这里需要检查
                    ReturnMoney=Convert.ToDecimal(this.lblReturnMoney.Text),
                    objProduct = this.saleProductList
                };

                try
                {
                    if (new ProductService().UpdateSaleInfo(objSale))
                    {
                        //不作为或记录到本地
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        new ErrorInfoService().WriteErrorInfoToDB(new Error
                        {
                            LoginId = Program.objCurrentLoginer.LoginId,
                            Opearte = new GetInfo().GetEnumDescription(OperateInfo.ErrorHappenedWhenLoginSaleInfo),
                            ErrorDesc = ex.Message
                        });
                    }
                    catch (Exception)
                    {
                       //数据库记录失败，记录到本地
                    }                                   
                }

                ResetInfo();
            }
        }
        //清除所有信息
        private void ResetInfo()
        {
            this.saleProductList.Clear();
            this.dgvProdutList.DataSource = null;
            this.dgvProdutList.DataSource = this.bs;

            ClearProductInfo();
        }
    }
}
