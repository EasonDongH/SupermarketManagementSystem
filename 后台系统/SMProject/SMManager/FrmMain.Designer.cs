namespace SMManager
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系统SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUserManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiModifyPwd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.商品管理PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProductStorage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProductManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInventoryManage = new System.Windows.Forms.ToolStripMenuItem();
            this.销售管理XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaleStat = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblAdminName = new System.Windows.Forms.ToolStripStatusLabel();
            this.spContainer = new System.Windows.Forms.SplitContainer();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnModifyPwd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnInventoryManage = new System.Windows.Forms.Button();
            this.btnLogQuery = new System.Windows.Forms.Button();
            this.btnProductInventor = new System.Windows.Forms.Button();
            this.btnSalAnalasys = new System.Windows.Forms.Button();
            this.btnProductManage = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.lblLoginName = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spContainer)).BeginInit();
            this.spContainer.Panel1.SuspendLayout();
            this.spContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统SToolStripMenuItem,
            this.商品管理PToolStripMenuItem,
            this.销售管理XToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1685, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统SToolStripMenuItem
            // 
            this.系统SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUserManage,
            this.tsmiModifyPwd,
            this.toolStripSeparator3,
            this.tsmiLogs,
            this.toolStripSeparator2,
            this.tsmiExit});
            this.系统SToolStripMenuItem.Name = "系统SToolStripMenuItem";
            this.系统SToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.系统SToolStripMenuItem.Text = "系统(&S)";
            // 
            // tsmiUserManage
            // 
            this.tsmiUserManage.Image = ((System.Drawing.Image)(resources.GetObject("tsmiUserManage.Image")));
            this.tsmiUserManage.Name = "tsmiUserManage";
            this.tsmiUserManage.Size = new System.Drawing.Size(165, 26);
            this.tsmiUserManage.Text = "用户管理(&U)";
            this.tsmiUserManage.Click += new System.EventHandler(this.tsmiUserManage_Click);
            // 
            // tsmiModifyPwd
            // 
            this.tsmiModifyPwd.Image = ((System.Drawing.Image)(resources.GetObject("tsmiModifyPwd.Image")));
            this.tsmiModifyPwd.Name = "tsmiModifyPwd";
            this.tsmiModifyPwd.Size = new System.Drawing.Size(165, 26);
            this.tsmiModifyPwd.Text = "修改密码(&P)";
            this.tsmiModifyPwd.Click += new System.EventHandler(this.tsmiModifyPwd_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(162, 6);
            // 
            // tsmiLogs
            // 
            this.tsmiLogs.Image = ((System.Drawing.Image)(resources.GetObject("tsmiLogs.Image")));
            this.tsmiLogs.Name = "tsmiLogs";
            this.tsmiLogs.Size = new System.Drawing.Size(165, 26);
            this.tsmiLogs.Text = "日志查询(&L)";
            this.tsmiLogs.Click += new System.EventHandler(this.tsmiLogs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Image = ((System.Drawing.Image)(resources.GetObject("tsmiExit.Image")));
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(165, 26);
            this.tsmiExit.Text = "退出系统(&E)";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // 商品管理PToolStripMenuItem
            // 
            this.商品管理PToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddProduct,
            this.tsmiProductStorage,
            this.toolStripSeparator1,
            this.tsmiProductManage,
            this.tsmiInventoryManage});
            this.商品管理PToolStripMenuItem.Name = "商品管理PToolStripMenuItem";
            this.商品管理PToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.商品管理PToolStripMenuItem.Text = "商品管理(&P)";
            // 
            // tsmiAddProduct
            // 
            this.tsmiAddProduct.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAddProduct.Image")));
            this.tsmiAddProduct.Name = "tsmiAddProduct";
            this.tsmiAddProduct.Size = new System.Drawing.Size(169, 26);
            this.tsmiAddProduct.Text = "添加商品(&A)";
            this.tsmiAddProduct.Click += new System.EventHandler(this.tsmiAddProduct_Click);
            // 
            // tsmiProductStorage
            // 
            this.tsmiProductStorage.Image = ((System.Drawing.Image)(resources.GetObject("tsmiProductStorage.Image")));
            this.tsmiProductStorage.Name = "tsmiProductStorage";
            this.tsmiProductStorage.Size = new System.Drawing.Size(169, 26);
            this.tsmiProductStorage.Text = "商品入库(&I)";
            this.tsmiProductStorage.Click += new System.EventHandler(this.tsmiProductStorage_Click);
            // 
            // tsmiProductManage
            // 
            this.tsmiProductManage.Image = ((System.Drawing.Image)(resources.GetObject("tsmiProductManage.Image")));
            this.tsmiProductManage.Name = "tsmiProductManage";
            this.tsmiProductManage.Size = new System.Drawing.Size(169, 26);
            this.tsmiProductManage.Text = "商品维护(&M)";
            this.tsmiProductManage.Click += new System.EventHandler(this.tsmiProductManage_Click);
            // 
            // tsmiInventoryManage
            // 
            this.tsmiInventoryManage.Image = ((System.Drawing.Image)(resources.GetObject("tsmiInventoryManage.Image")));
            this.tsmiInventoryManage.Name = "tsmiInventoryManage";
            this.tsmiInventoryManage.Size = new System.Drawing.Size(169, 26);
            this.tsmiInventoryManage.Text = "库存管理(&K)";
            this.tsmiInventoryManage.Click += new System.EventHandler(this.tsmiInventoryManage_Click);
            // 
            // 销售管理XToolStripMenuItem
            // 
            this.销售管理XToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSaleStat});
            this.销售管理XToolStripMenuItem.Name = "销售管理XToolStripMenuItem";
            this.销售管理XToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.销售管理XToolStripMenuItem.Text = "销售管理(&X)";
            // 
            // tsmiSaleStat
            // 
            this.tsmiSaleStat.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSaleStat.Image")));
            this.tsmiSaleStat.Name = "tsmiSaleStat";
            this.tsmiSaleStat.Size = new System.Drawing.Size(163, 26);
            this.tsmiSaleStat.Text = "销售统计(&S)";
            this.tsmiSaleStat.Click += new System.EventHandler(this.tsmiSaleStat_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblAdminName,
            this.lblLoginName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 886);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1685, 25);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(153, 20);
            this.toolStripStatusLabel1.Text = "[超市管理系统]  V2.0 ";
            // 
            // lblAdminName
            // 
            this.lblAdminName.Name = "lblAdminName";
            this.lblAdminName.Size = new System.Drawing.Size(99, 20);
            this.lblAdminName.Text = "【管理员】：";
            // 
            // spContainer
            // 
            this.spContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spContainer.Location = new System.Drawing.Point(0, 28);
            this.spContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.spContainer.Name = "spContainer";
            // 
            // spContainer.Panel1
            // 
            this.spContainer.Panel1.Controls.Add(this.monthCalendar1);
            this.spContainer.Panel1.Controls.Add(this.btnModifyPwd);
            this.spContainer.Panel1.Controls.Add(this.btnExit);
            this.spContainer.Panel1.Controls.Add(this.btnInventoryManage);
            this.spContainer.Panel1.Controls.Add(this.btnLogQuery);
            this.spContainer.Panel1.Controls.Add(this.btnProductInventor);
            this.spContainer.Panel1.Controls.Add(this.btnSalAnalasys);
            this.spContainer.Panel1.Controls.Add(this.btnProductManage);
            this.spContainer.Panel1.Controls.Add(this.btnAddProduct);
            // 
            // spContainer.Panel2
            // 
            this.spContainer.Panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("spContainer.Panel2.BackgroundImage")));
            this.spContainer.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.spContainer.Size = new System.Drawing.Size(1685, 858);
            this.spContainer.SplitterDistance = 243;
            this.spContainer.SplitterWidth = 5;
            this.spContainer.TabIndex = 10;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(17, 30);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            // 
            // btnModifyPwd
            // 
            this.btnModifyPwd.Image = ((System.Drawing.Image)(resources.GetObject("btnModifyPwd.Image")));
            this.btnModifyPwd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModifyPwd.Location = new System.Drawing.Point(35, 734);
            this.btnModifyPwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModifyPwd.Name = "btnModifyPwd";
            this.btnModifyPwd.Size = new System.Drawing.Size(109, 51);
            this.btnModifyPwd.TabIndex = 1;
            this.btnModifyPwd.Text = "密码修改";
            this.btnModifyPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModifyPwd.UseVisualStyleBackColor = true;
            this.btnModifyPwd.Click += new System.EventHandler(this.btnModifyPwd_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(168, 734);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(109, 51);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "退出系统";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnInventoryManage
            // 
            this.btnInventoryManage.Image = ((System.Drawing.Image)(resources.GetObject("btnInventoryManage.Image")));
            this.btnInventoryManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventoryManage.Location = new System.Drawing.Point(41, 366);
            this.btnInventoryManage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInventoryManage.Name = "btnInventoryManage";
            this.btnInventoryManage.Size = new System.Drawing.Size(109, 51);
            this.btnInventoryManage.TabIndex = 1;
            this.btnInventoryManage.Text = "库存管理";
            this.btnInventoryManage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInventoryManage.UseVisualStyleBackColor = true;
            this.btnInventoryManage.Click += new System.EventHandler(this.btnInventoryManage_Click);
            // 
            // btnLogQuery
            // 
            this.btnLogQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnLogQuery.Image")));
            this.btnLogQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogQuery.Location = new System.Drawing.Point(175, 454);
            this.btnLogQuery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogQuery.Name = "btnLogQuery";
            this.btnLogQuery.Size = new System.Drawing.Size(109, 51);
            this.btnLogQuery.TabIndex = 1;
            this.btnLogQuery.Text = "日志查询";
            this.btnLogQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogQuery.UseVisualStyleBackColor = true;
            this.btnLogQuery.Click += new System.EventHandler(this.btnLogQuery_Click);
            // 
            // btnProductInventor
            // 
            this.btnProductInventor.Image = ((System.Drawing.Image)(resources.GetObject("btnProductInventor.Image")));
            this.btnProductInventor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductInventor.Location = new System.Drawing.Point(175, 289);
            this.btnProductInventor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnProductInventor.Name = "btnProductInventor";
            this.btnProductInventor.Size = new System.Drawing.Size(109, 51);
            this.btnProductInventor.TabIndex = 1;
            this.btnProductInventor.Text = "商品入库";
            this.btnProductInventor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductInventor.UseVisualStyleBackColor = true;
            this.btnProductInventor.Click += new System.EventHandler(this.btnProductInventor_Click);
            // 
            // btnSalAnalasys
            // 
            this.btnSalAnalasys.Image = ((System.Drawing.Image)(resources.GetObject("btnSalAnalasys.Image")));
            this.btnSalAnalasys.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalAnalasys.Location = new System.Drawing.Point(41, 454);
            this.btnSalAnalasys.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalAnalasys.Name = "btnSalAnalasys";
            this.btnSalAnalasys.Size = new System.Drawing.Size(109, 51);
            this.btnSalAnalasys.TabIndex = 1;
            this.btnSalAnalasys.Text = "销售统计";
            this.btnSalAnalasys.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalAnalasys.UseVisualStyleBackColor = true;
            this.btnSalAnalasys.Click += new System.EventHandler(this.btnSalAnalasys_Click);
            // 
            // btnProductManage
            // 
            this.btnProductManage.Image = ((System.Drawing.Image)(resources.GetObject("btnProductManage.Image")));
            this.btnProductManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductManage.Location = new System.Drawing.Point(175, 366);
            this.btnProductManage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnProductManage.Name = "btnProductManage";
            this.btnProductManage.Size = new System.Drawing.Size(109, 51);
            this.btnProductManage.TabIndex = 1;
            this.btnProductManage.Text = "商品维护";
            this.btnProductManage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductManage.UseVisualStyleBackColor = true;
            this.btnProductManage.Click += new System.EventHandler(this.btnProductManage_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnAddProduct.Image")));
            this.btnAddProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddProduct.Location = new System.Drawing.Point(41, 288);
            this.btnAddProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(109, 51);
            this.btnAddProduct.TabIndex = 1;
            this.btnAddProduct.Text = "新增商品";
            this.btnAddProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // lblLoginName
            // 
            this.lblLoginName.Name = "lblLoginName";
            this.lblLoginName.Size = new System.Drawing.Size(39, 20);
            this.lblLoginName.Text = "姓名";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1685, 911);
            this.Controls.Add(this.spContainer);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "超市后台数据管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.spContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spContainer)).EndInit();
            this.spContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiUserManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiModifyPwd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem 商品管理PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmiProductStorage;
        private System.Windows.Forms.ToolStripMenuItem tsmiProductManage;
        private System.Windows.Forms.ToolStripMenuItem 销售管理XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaleStat;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblAdminName;
        private System.Windows.Forms.ToolStripMenuItem tsmiInventoryManage;
        private System.Windows.Forms.SplitContainer spContainer;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnModifyPwd;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnInventoryManage;
        private System.Windows.Forms.Button btnLogQuery;
        private System.Windows.Forms.Button btnProductInventor;
        private System.Windows.Forms.Button btnSalAnalasys;
        private System.Windows.Forms.Button btnProductManage;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.ToolStripStatusLabel lblLoginName;
    }
}