using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SMManager
{
    public partial class FrmEditAdmin : Form
    {
        public FrmEditAdmin(string loginId, string adminName, string roleName)
        {
            InitializeComponent();

        }
        //保存用户
        private void btnSubmit_Click(object sender, EventArgs e)
        {
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
