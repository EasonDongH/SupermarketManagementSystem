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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            this.lblClose.Parent = this.pictureBox;//使其完全透明
            this.lblMin.Parent = this.pictureBox;//使其完全透明
        }

        #region 界面设计
        private void lblMax_MouseMove(object sender, MouseEventArgs e)
        {
            lblClose.BackColor = Color.OrangeRed;
        }

        private void lblMax_MouseLeave(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.Transparent;
        }

        private void lblMin_MouseLeave(object sender, EventArgs e)
        {
            lblMin.BackColor = Color.Transparent;
        }

        private void lblMin_MouseMove(object sender, MouseEventArgs e)
        {
            lblMin.BackColor = Color.OrangeRed;
        }

        #region  窗体拖动、关闭
        private Point mouseOff;//鼠标移动位置变量
        private bool leftFlag;//标签是否为左键
        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }
        private void FrmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }
        private void FrmLogin_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }
        #endregion

        private void btnLogin_MouseMove(object sender, MouseEventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(109, 187, 250);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(48, 157, 248);
        }
        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLoginId.Text.Trim().Length == 0)
            {
                txtLoginId.Focus();
                return;
            }
            if (txtPwd.Text.Length == 0)
            {
                txtPwd.Focus();
                return;
            }
            Loginer objLoginer = new Loginer()
            {
                LoginId = Convert.ToInt32(txtLoginId.Text),
                LoginPwd = txtPwd.Text
            };
            try
            {
                objLoginer = new LoginService().LoginConfirm(objLoginer);
                if (objLoginer != null)
                {
                    this.DialogResult = DialogResult.OK;
                    Program.objCurrentLoginer = objLoginer;
                }
                else
                    MessageBox.Show("账号或密码不正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                try
                {
                    new ErrorInfoService().WriteErrorInfoToDB(new Error
                    {                        
                        LoginId = -1,//-1未能成功登录
                        Opearte = new GetInfo().GetEnumDescription(OperateInfo.ErrorHappenedWhenLogining),
                        ErrorDesc = ex.Message
                    });
                }
                catch (Exception logEx)
                {
                    //记录到本地
                    throw;
                }
                
                MessageBox.Show("登录异常，请再次尝试或者联系管理员！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lblMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
