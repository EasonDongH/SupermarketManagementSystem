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
using System.Net;

namespace SMManager
{
    public partial class FrmLogin : Form
    {
        private LoginManager objLoginManage = new LoginManager();
        
        public FrmLogin()
        {
            InitializeComponent();
        }

        //登录
        private void btnLogin_Click(object sender, EventArgs e)
        {
            SysAdmin objSysAdmin = new SysAdmin()
            {
                LoginId = Convert.ToInt32(this.txtLoginId.Text.Trim()),
                LoginPwd = this.txtLoginPwd.Text
            };

            try
            {
                if (objLoginManage.LoginVerify(objSysAdmin) != null)
                {
                    Program.objCurrentAdmin = objSysAdmin;
                    this.DialogResult = DialogResult.OK;

                    Program.objCurrentLog.LoginId = objSysAdmin.LoginId;
                    Program.objCurrentLog.LoginName = objSysAdmin.AdminName;
                    Program.objCurrentLog.ServerName = Dns.GetHostName();                    

                    new LoginManager().LoginLog(Program.objCurrentLog);
                }
                else
                {
                    MessageBox.Show( "账号或密码错误","登录提示");                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库发生错误，请重新操作或通知管理员！","错误提示",MessageBoxButtons.OK);
                
                new ErrorLogManager().ErrorLog(new ErrorLog
                {
                    LoginId=-1,
                    Operate=Operate.ErrorHappenedWhenLogining,
                    ErrorMessage=ex.Message
                });
            }            
        }
        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
