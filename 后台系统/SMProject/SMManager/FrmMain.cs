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
    public partial class FrmMain : Form
    {
        #region 系统初始化与退出

        public FrmMain()
        {
            InitializeComponent();

            this.lblLoginName.Text = Program.objCurrentAdmin.AdminName;
        }
        //退出系统
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确认关闭系统吗？", "退出提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    Program.objCurrentLog.ExitTime = DateTime.Now;
                    new LoginManager().ExitLog(Program.objCurrentLog);
                }
                catch (Exception ex)
                {
                    new ErrorLogManager().ErrorLog(new ErrorLog
                    {
                        LoginId = Program.objCurrentAdmin.LoginId,
                        Operate = Operate.ErrorHappenedWhenExiting,
                        ErrorMessage = ex.Message
                    });
                }
            }
        }

        #endregion

        //让窗体在容器panle2的中间位置
        private void FormStartPosition(Form objForm)
        {
            objForm.Location = new Point(
                    this.Location.X + this.spContainer.Panel1.Width + (this.spContainer.Panel2.Width - objForm.Width) / 2 + 12,
                    this.Location.Y + (this.spContainer.Panel2.Height - objForm.Height) / 2 + 50);
        }
        //添加商品
        public static FrmAddProduct objAddProduct = null;
        private void tsmiAddProduct_Click(object sender, EventArgs e)
        {
            if (objAddProduct == null)
            {
                objAddProduct = new FrmAddProduct();
                objAddProduct.Show();

            }
            else
            {
                objAddProduct.Activate();//激活最小化的窗体
                objAddProduct.WindowState = FormWindowState.Normal;//让最小化的窗体正常显示
            }
            FormStartPosition(objAddProduct);
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            tsmiAddProduct_Click(null, null);
        }
        //商品入库
        public static FrmProductStorage objStorage = null;
        private void tsmiProductStorage_Click(object sender, EventArgs e)
        {
            if (objStorage == null)
            {
                objStorage = new FrmProductStorage();
                objStorage.Show();
            }
            else
            {
                objStorage.Activate();
                objStorage.WindowState = FormWindowState.Normal;
            }
            FormStartPosition(objStorage);
        }
        private void btnProductInventor_Click(object sender, EventArgs e)
        {
            tsmiProductStorage_Click(null, null);
        }
        //商品维护
        public static FrmProductManage objProductManage = null;
        private void tsmiProductManage_Click(object sender, EventArgs e)
        {
            if (objProductManage == null)
            {
                objProductManage = new FrmProductManage();
                objProductManage.Show();
            }
            else
            {
                objProductManage.Activate();
                objProductManage.WindowState = FormWindowState.Normal;
            }
            FormStartPosition(objProductManage);
        }
        private void btnProductManage_Click(object sender, EventArgs e)
        {
            tsmiProductManage_Click(null, null);
        }
        //库存管理
        public static FrmInventoryManage objInventoryManage = null;
        private void tsmiInventoryManage_Click(object sender, EventArgs e)
        {
            if (objInventoryManage == null)
            {
                objInventoryManage = new FrmInventoryManage();
                objInventoryManage.Show();
            }
            else
            {
                objInventoryManage.Activate();
                objInventoryManage.WindowState = FormWindowState.Normal;
            }
            FormStartPosition(objInventoryManage);
        }
        private void btnInventoryManage_Click(object sender, EventArgs e)
        {
            tsmiInventoryManage_Click(null, null);
        }
        //销售统计
        public static FrmSaleStat objSaleStat = null;
        private void tsmiSaleStat_Click(object sender, EventArgs e)
        {
            if (objSaleStat == null)
            {
                objSaleStat = new FrmSaleStat();
                objSaleStat.Show();
            }
            else
            {
                objSaleStat.Activate();
                objSaleStat.WindowState = FormWindowState.Normal;
            }
            FormStartPosition(objSaleStat);
        }
        private void btnSalAnalasys_Click(object sender, EventArgs e)
        {
            tsmiSaleStat_Click(null, null);
        }
        //用户管理
        public static FrmAdminManage objAdminanage = null;
        private void tsmiUserManage_Click(object sender, EventArgs e)
        {
            if (objAdminanage == null)
            {
                objAdminanage = new FrmAdminManage();
                objAdminanage.Show();
            }
            else
            {
                objAdminanage.Activate();
                objAdminanage.WindowState = FormWindowState.Normal;
            }
            FormStartPosition(objAdminanage);
        }
        //修改密码
        private void tsmiModifyPwd_Click(object sender, EventArgs e)
        {
            FrmModifyPwd objModifyPwd = new FrmModifyPwd();
            objModifyPwd.ShowDialog();
        }
        private void btnModifyPwd_Click(object sender, EventArgs e)
        {
            tsmiModifyPwd_Click(null, null);
        }
        //日志查询
        private void tsmiLogs_Click(object sender, EventArgs e)
        {
            FrmLogQuery objFrmLog = new FrmLogQuery();
            objFrmLog.Show();
            FormStartPosition(objFrmLog);
        }
        private void btnLogQuery_Click(object sender, EventArgs e)
        {
            tsmiLogs_Click(null, null);
        }


    }
}
