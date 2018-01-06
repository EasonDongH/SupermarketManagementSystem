using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Models;

namespace SMProject
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmLogin frm = new FrmLogin();           
            if (frm.ShowDialog() == DialogResult.OK)
                Application.Run(new FrmSaleManage());
            else
                Application.Exit();
        }
        public static Loginer objCurrentLoginer = null;
    }
}
