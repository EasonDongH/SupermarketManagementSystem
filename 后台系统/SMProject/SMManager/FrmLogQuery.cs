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
    public partial class FrmLogQuery : Form
    {
        private DataSet objDS = new DataSet();
        private LoginLogPageQueryManager objPageQuery = new LoginLogPageQueryManager();
        private LoginLogPageQuery objLog = null;
        public FrmLogQuery()
        {
            InitializeComponent();

            this.cboPageSize.SelectedIndex = 2;
            this.dgvLogs.AutoGenerateColumns = false;
        }
        //提交查询
        private void btnQuery_Click(object sender, EventArgs e)
        {
            objLog = new LoginLogPageQuery()
            {
                PageSize = Convert.ToInt32(this.cboPageSize.Text),
                BeginTime = Convert.ToDateTime(this.dtpStart.Text),
                EndTime = Convert.ToDateTime(this.dtpEnd.Text).AddDays(1.0)
            };
            try
            {
                //获取数据总量
                objLog.RecordCount = objPageQuery.GetRecordCount(objLog);
                this.lblRecordCount.Text = objLog.RecordCount.ToString();
                //获取分页DataSet
                objDS = objPageQuery.GetLoginLogPageQueryDS(objLog);
                this.dgvLogs.DataSource = objDS.Tables[objLog.CurrentPage];
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库发生错误，请检查连接或联系管理员！","错误提示");
                new ErrorLogManager().ErrorLog(new ErrorLog()
                {
                    LoginId = Program.objCurrentAdmin.LoginId,
                    Operate=Operate.ErrorHappenedWhenLoginLogPageQuery,
                    ErrorMessage=ex.Message
                });
                return;
            }
            
            //计算当前页
            this.lblCurrentPage.Text = (objLog.CurrentPage + 1).ToString();
            //计算总页数
            int pageCount = objLog.RecordCount / objLog.PageSize;
            objLog.PageCount = objLog.RecordCount % objLog.PageSize == 0 ? pageCount : pageCount + 1;
            this.lblPageCount.Text = objLog.PageCount.ToString();

            if (objLog.PageCount == 0)
            {
                MessageBox.Show("该查询下无数据！", "查询提示");
                return;
            }
            //所有按钮开启
            this.btnFirst.Enabled = true;
            this.btnNext.Enabled = true;
            this.btnPrevious.Enabled = true;
            this.btnLast.Enabled = true;
            this.btnGoTo.Enabled = true;
            //关闭不需要的按钮
            if (objLog.PageCount == 1)
            {
                this.btnFirst.Enabled = false;
                this.btnNext.Enabled = false;
                this.btnPrevious.Enabled = false;
                this.btnLast.Enabled = false;
                this.btnGoTo.Enabled = false;
            }
        }
        //显示行号
        private void dgvLogs_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
           DataGridViewStyle.DgvRowPostPaint(this.dgvLogs, e);
        }
        //关闭窗口
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 分页显示

        //跳转到
        private void btnGoTo_Click(object sender, EventArgs e)
        {
            if (objLog == null)//未查询
            {
                return;
            }
            int current = Convert.ToInt32(this.txtGoTo.Text.Trim());
            if (current < 1 || current > objLog.PageCount)
            {
                MessageBox.Show("无该页数据！", "查询提示");
                return;
            }
            this.lblCurrentPage.Text = current.ToString();
            objLog.CurrentPage = current - 1;
            this.dgvLogs.DataSource = objDS.Tables[objLog.CurrentPage];
            //所有按钮开启
            this.btnFirst.Enabled = true;
            this.btnNext.Enabled = true;
            this.btnPrevious.Enabled = true;
            this.btnLast.Enabled = true;           
            //当到达第一页
            if (objLog.CurrentPage == 0)
            {
                this.btnPrevious.Enabled = false;
                this.btnFirst.Enabled = false;
            }
            //当到达最后一页
            if (objLog.CurrentPage == objLog.PageCount - 1)//当前页从0开始，页总数从1开始
            {
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
            }
        }
        //第一页
        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (objLog == null)//未查询
            {
                return;
            }
            this.dgvLogs.DataSource = null;
            objLog.CurrentPage = 0;
            this.dgvLogs.DataSource = objDS.Tables[objLog.CurrentPage];
            //计算当前页
            this.lblCurrentPage.Text = (objLog.CurrentPage + 1).ToString();
            //开启按钮
            this.btnLast.Enabled = true;
            this.btnNext.Enabled = true;
            //关闭按钮
            this.btnPrevious.Enabled = false;
            this.btnFirst.Enabled = false;
        }
        //下一页
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (objLog == null)//未查询
            {
                return;
            }
            this.dgvLogs.DataSource = null;
            objLog.CurrentPage++;
            this.dgvLogs.DataSource = objDS.Tables[objLog.CurrentPage];
            this.btnFirst.Enabled = true;
            this.btnPrevious.Enabled = true;
            //计算当前页
            this.lblCurrentPage.Text = (objLog.CurrentPage + 1).ToString();
            //当到达最后一页
            if (objLog.CurrentPage == objLog.PageCount - 1)//当前页从0开始，页总数从1开始
            {
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
            }
        }
        //上一页
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (objLog == null)//未查询
            {
                return;
            }
            this.dgvLogs.DataSource = null;
            objLog.CurrentPage--;
            this.dgvLogs.DataSource = objDS.Tables[objLog.CurrentPage];
            this.btnNext.Enabled = true;
            this.btnLast.Enabled = true;
            //计算当前页
            this.lblCurrentPage.Text = (objLog.CurrentPage + 1).ToString();
            //当到达第一页
            if (objLog.CurrentPage == 0)
            {
                this.btnPrevious.Enabled = false;
                this.btnFirst.Enabled = false;
            }
        }
        //最后页
        private void btnLast_Click(object sender, EventArgs e)
        {
            if (objLog == null)//未查询
            {
                return;
            }
            this.dgvLogs.DataSource = null;
            //当前页从0开始，页总数从1开始
            objLog.CurrentPage = objLog.PageCount - 1;
            this.dgvLogs.DataSource = objDS.Tables[objLog.CurrentPage];
            //计算当前页
            this.lblCurrentPage.Text = (objLog.CurrentPage + 1).ToString();
            //开启按钮
            this.btnPrevious.Enabled = true;
            this.btnFirst.Enabled = true;
            //关闭按钮
            this.btnNext.Enabled = false;
            this.btnLast.Enabled = false;
        }

        #endregion
    }
}
