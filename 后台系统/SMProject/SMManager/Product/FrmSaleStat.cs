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
    public partial class FrmSaleStat : Form
    {
        private SaleManager objSaleManager = new SaleManager();
        public FrmSaleStat()
        {
            InitializeComponent();

            this.dgvProductStat.AutoGenerateColumns = false;
        }
        //开始统计
        private void btnStat_Click(object sender, EventArgs e)
        {
            List<Product> objProductList = objSaleManager.GetProductSaleStats(string.Format(this.dtpStart.Text,"yyyy-MM-dd"), string.Format(this.dtpEnd.Text, "yyyy-MM-dd"));
            this.dgvProductStat.DataSource = null;
            this.dgvProductStat.DataSource = objProductList;
        }
        //显示行号
        private void dgvProductStat_RowPostPaint(object sender,
            DataGridViewRowPostPaintEventArgs e)
        {

        }
        //关闭窗口
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmSaleStat_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMain.objSaleStat = null;
        }
    }
}
