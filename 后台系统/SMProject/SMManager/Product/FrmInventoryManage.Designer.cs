namespace SMManager
{
    partial class FrmInventoryManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventoryManage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowMax = new System.Windows.Forms.Button();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaxCount = new System.Windows.Forms.TextBox();
            this.btnUpdateSet = new System.Windows.Forms.Button();
            this.txtMinCount = new System.Windows.Forms.TextBox();
            this.btnUpdateInventory = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalCount = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.linklbl = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnShowMin = new System.Windows.Forms.Button();
            this.lblBelowCount = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblBeyondCount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboCategory);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.txtProductId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(789, 68);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[商品库存查询]";
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(458, 29);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(109, 20);
            this.cboCategory.TabIndex = 3;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(272, 29);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(122, 21);
            this.txtProductName.TabIndex = 1;
            // 
            // btnQuery
            // 
            this.btnQuery.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(692, 20);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(91, 38);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "提交查询";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtProductId
            // 
            this.txtProductId.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtProductId.Location = new System.Drawing.Point(84, 29);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(119, 21);
            this.txtProductId.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "商品分类：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "商品名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品编码：";
            // 
            // btnShowMax
            // 
            this.btnShowMax.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnShowMax.Image = ((System.Drawing.Image)(resources.GetObject("btnShowMax.Image")));
            this.btnShowMax.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowMax.Location = new System.Drawing.Point(391, 24);
            this.btnShowMax.Name = "btnShowMax";
            this.btnShowMax.Size = new System.Drawing.Size(93, 38);
            this.btnShowMax.TabIndex = 2;
            this.btnShowMax.Text = "显示超库存";
            this.btnShowMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowMax.UseVisualStyleBackColor = true;
            this.btnShowMax.Click += new System.EventHandler(this.btnShowMax_Click);
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.AllowUserToDeleteRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvProduct.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvProduct.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvProduct.ColumnHeadersHeight = 25;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.ProductName,
            this.Unit,
            this.MaxCount,
            this.TotalCount,
            this.MinCount,
            this.InventoryStatus});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProduct.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvProduct.EnableHeadersVisualStyles = false;
            this.dgvProduct.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvProduct.Location = new System.Drawing.Point(18, 182);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvProduct.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvProduct.RowTemplate.Height = 23;
            this.dgvProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvProduct.Size = new System.Drawing.Size(789, 318);
            this.dgvProduct.TabIndex = 18;
            this.dgvProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellClick);
            this.dgvProduct.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvProduct_RowPostPaint);
            // 
            // ProductId
            // 
            this.ProductId.DataPropertyName = "ProductId";
            this.ProductId.HeaderText = "商品编号";
            this.ProductId.Name = "ProductId";
            this.ProductId.ReadOnly = true;
            this.ProductId.Width = 120;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "商品名称";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 180;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "计量单位";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.Width = 80;
            // 
            // MaxCount
            // 
            this.MaxCount.DataPropertyName = "MaxCount";
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaxCount.DefaultCellStyle = dataGridViewCellStyle9;
            this.MaxCount.HeaderText = "最大库存";
            this.MaxCount.Name = "MaxCount";
            this.MaxCount.ReadOnly = true;
            this.MaxCount.Width = 80;
            // 
            // TotalCount
            // 
            this.TotalCount.DataPropertyName = "TotalCount";
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Blue;
            this.TotalCount.DefaultCellStyle = dataGridViewCellStyle10;
            this.TotalCount.HeaderText = "当前库存";
            this.TotalCount.Name = "TotalCount";
            this.TotalCount.ReadOnly = true;
            this.TotalCount.Width = 80;
            // 
            // MinCount
            // 
            this.MinCount.DataPropertyName = "MinCount";
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MinCount.DefaultCellStyle = dataGridViewCellStyle11;
            this.MinCount.HeaderText = "最小库存";
            this.MinCount.Name = "MinCount";
            this.MinCount.ReadOnly = true;
            // 
            // InventoryStatus
            // 
            this.InventoryStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InventoryStatus.DataPropertyName = "InventoryStatus";
            this.InventoryStatus.HeaderText = "库存状态";
            this.InventoryStatus.Name = "InventoryStatus";
            this.InventoryStatus.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "最大库存：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(149, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "最小库存：";
            // 
            // txtMaxCount
            // 
            this.txtMaxCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMaxCount.Location = new System.Drawing.Point(73, 29);
            this.txtMaxCount.Name = "txtMaxCount";
            this.txtMaxCount.Size = new System.Drawing.Size(69, 21);
            this.txtMaxCount.TabIndex = 0;
            // 
            // btnUpdateSet
            // 
            this.btnUpdateSet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnUpdateSet.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateSet.Image")));
            this.btnUpdateSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateSet.Location = new System.Drawing.Point(293, 19);
            this.btnUpdateSet.Name = "btnUpdateSet";
            this.btnUpdateSet.Size = new System.Drawing.Size(83, 38);
            this.btnUpdateSet.TabIndex = 26;
            this.btnUpdateSet.Text = "更新设置";
            this.btnUpdateSet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateSet.UseVisualStyleBackColor = true;
            this.btnUpdateSet.Click += new System.EventHandler(this.btnUpdateSet_Click);
            // 
            // txtMinCount
            // 
            this.txtMinCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMinCount.Location = new System.Drawing.Point(209, 29);
            this.txtMinCount.Name = "txtMinCount";
            this.txtMinCount.Size = new System.Drawing.Size(69, 21);
            this.txtMinCount.TabIndex = 0;
            // 
            // btnUpdateInventory
            // 
            this.btnUpdateInventory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnUpdateInventory.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateInventory.Image")));
            this.btnUpdateInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateInventory.Location = new System.Drawing.Point(170, 19);
            this.btnUpdateInventory.Name = "btnUpdateInventory";
            this.btnUpdateInventory.Size = new System.Drawing.Size(82, 38);
            this.btnUpdateInventory.TabIndex = 26;
            this.btnUpdateInventory.Text = "修改库存";
            this.btnUpdateInventory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateInventory.UseVisualStyleBackColor = true;
            this.btnUpdateInventory.Click += new System.EventHandler(this.btnUpdateInventory_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMinCount);
            this.groupBox2.Controls.Add(this.btnUpdateSet);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtMaxCount);
            this.groupBox2.Location = new System.Drawing.Point(17, 519);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 70);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "[库存预警设置]";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnUpdateInventory);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtTotalCount);
            this.groupBox3.Location = new System.Drawing.Point(438, 519);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 70);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "[调整商品库存]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "当前库存：";
            // 
            // txtTotalCount
            // 
            this.txtTotalCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTotalCount.Location = new System.Drawing.Point(75, 29);
            this.txtTotalCount.Name = "txtTotalCount";
            this.txtTotalCount.Size = new System.Drawing.Size(69, 21);
            this.txtTotalCount.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(727, 539);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 38);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.linklbl);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.btnShowMin);
            this.groupBox4.Controls.Add(this.btnShowMax);
            this.groupBox4.Controls.Add(this.lblBelowCount);
            this.groupBox4.Controls.Add(this.lblCount);
            this.groupBox4.Controls.Add(this.lblBeyondCount);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(17, 98);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(789, 73);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "[库存预警信息]";
            // 
            // linklbl
            // 
            this.linklbl.AutoSize = true;
            this.linklbl.Location = new System.Drawing.Point(107, 0);
            this.linklbl.Name = "linklbl";
            this.linklbl.Size = new System.Drawing.Size(113, 12);
            this.linklbl.TabIndex = 3;
            this.linklbl.TabStop = true;
            this.linklbl.Text = "[刷新库存预警信息]";
            this.linklbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklbl_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(509, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "低于库存下限：";
            // 
            // btnShowMin
            // 
            this.btnShowMin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnShowMin.Image = ((System.Drawing.Image)(resources.GetObject("btnShowMin.Image")));
            this.btnShowMin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowMin.Location = new System.Drawing.Point(692, 26);
            this.btnShowMin.Name = "btnShowMin";
            this.btnShowMin.Size = new System.Drawing.Size(91, 38);
            this.btnShowMin.TabIndex = 2;
            this.btnShowMin.Text = "显示低库存";
            this.btnShowMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowMin.UseVisualStyleBackColor = true;
            this.btnShowMin.Click += new System.EventHandler(this.btnShowMin_Click);
            // 
            // lblBelowCount
            // 
            this.lblBelowCount.BackColor = System.Drawing.Color.White;
            this.lblBelowCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBelowCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBelowCount.ForeColor = System.Drawing.Color.Red;
            this.lblBelowCount.Location = new System.Drawing.Point(598, 32);
            this.lblBelowCount.Name = "lblBelowCount";
            this.lblBelowCount.Size = new System.Drawing.Size(76, 22);
            this.lblBelowCount.TabIndex = 0;
            this.lblBelowCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCount
            // 
            this.lblCount.BackColor = System.Drawing.Color.White;
            this.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCount.Location = new System.Drawing.Point(84, 32);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(76, 22);
            this.lblCount.TabIndex = 0;
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBeyondCount
            // 
            this.lblBeyondCount.BackColor = System.Drawing.Color.White;
            this.lblBeyondCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBeyondCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBeyondCount.ForeColor = System.Drawing.Color.Blue;
            this.lblBeyondCount.Location = new System.Drawing.Point(294, 32);
            this.lblBeyondCount.Name = "lblBeyondCount";
            this.lblBeyondCount.Size = new System.Drawing.Size(76, 22);
            this.lblBeyondCount.TabIndex = 0;
            this.lblBeyondCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "预警总数：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(203, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "超出库存上限：";
            // 
            // FrmInventoryManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 608);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmInventoryManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[商品库存管理]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInventoryManage_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Button btnShowMax;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaxCount;
        private System.Windows.Forms.Button btnUpdateSet;
        private System.Windows.Forms.TextBox txtMinCount;
        private System.Windows.Forms.Button btnUpdateInventory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotalCount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.LinkLabel linklbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnShowMin;
        private System.Windows.Forms.Label lblBelowCount;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblBeyondCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryStatus;
    }
}