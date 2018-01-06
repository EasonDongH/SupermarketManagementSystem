using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMProject
{
    public partial class FrmBalance : Form
    {
        //构造方法
        public FrmBalance()
        {
            InitializeComponent();
        }

        public FrmBalance(string SumTotal):this()
        {
            this.lblTotalMoney.Text = SumTotal;
            this.txtRealReceive.Text = SumTotal;
            this.txtRealReceive.Focus();
        }

        private void txtMemberId_KeyDown(object sender, KeyEventArgs e)
        {
            //F3或Enter:正常结账
            if (e.KeyValue == 114||e.KeyValue==13)
            {
                this.Tag = $"F3|{this.txtRealReceive.Text.Trim()}|{this.txtMemberId.Text.Trim()}";
                this.Close();
            }
            else if (e.KeyValue == 116)//F5取消结算
            {
                this.Tag = $"F5|{this.txtRealReceive.Text.Trim()}|{this.txtMemberId.Text.Trim()}";
                this.Close();
            }
        }
    }
}
