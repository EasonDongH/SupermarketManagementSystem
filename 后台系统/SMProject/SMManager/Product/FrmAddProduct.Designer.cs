namespace SMManager
{
    partial class FrmAddProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddProduct));
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.btnLock = new System.Windows.Forms.Button();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMinCount = new System.Windows.Forms.TextBox();
            this.txtMaxCount = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbStorage = new System.Windows.Forms.GroupBox();
            this.gbInfo.SuspendLayout();
            this.gbStorage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSubmit.Image = ((System.Drawing.Image)(resources.GetObject("btnSubmit.Image")));
            this.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubmit.Location = new System.Drawing.Point(476, 326);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(107, 41);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "添加商品";
            this.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(119, 35);
            this.cboCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(153, 23);
            this.cboCategory.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 41);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "商品分类：";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(472, 128);
            this.txtUnitPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(112, 25);
            this.txtUnitPrice.TabIndex = 4;
            this.txtUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnitPrice_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "销售单价：";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(119, 128);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(235, 25);
            this.txtProductName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 131);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "商品名称：";
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(119, 82);
            this.txtProductId.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(235, 25);
            this.txtProductId.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "商品编码：";
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.btnLock);
            this.gbInfo.Controls.Add(this.label1);
            this.gbInfo.Controls.Add(this.txtProductId);
            this.gbInfo.Controls.Add(this.label2);
            this.gbInfo.Controls.Add(this.txtProductName);
            this.gbInfo.Controls.Add(this.cboUnit);
            this.gbInfo.Controls.Add(this.cboCategory);
            this.gbInfo.Controls.Add(this.label8);
            this.gbInfo.Controls.Add(this.label3);
            this.gbInfo.Controls.Add(this.label4);
            this.gbInfo.Controls.Add(this.txtUnitPrice);
            this.gbInfo.Location = new System.Drawing.Point(24, 29);
            this.gbInfo.Margin = new System.Windows.Forms.Padding(4);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Padding = new System.Windows.Forms.Padding(4);
            this.gbInfo.Size = new System.Drawing.Size(695, 180);
            this.gbInfo.TabIndex = 0;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "[商品信息]";
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(283, 32);
            this.btnLock.Margin = new System.Windows.Forms.Padding(4);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(72, 29);
            this.btnLock.TabIndex = 13;
            this.btnLock.Text = "锁定";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(472, 35);
            this.cboUnit.Margin = new System.Windows.Forms.Padding(4);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(115, 23);
            this.cboUnit.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(377, 41);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "计量单位：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(375, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "最小库存：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 38);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "最大库存：";
            // 
            // txtMinCount
            // 
            this.txtMinCount.Location = new System.Drawing.Point(469, 34);
            this.txtMinCount.Margin = new System.Windows.Forms.Padding(4);
            this.txtMinCount.Name = "txtMinCount";
            this.txtMinCount.Size = new System.Drawing.Size(207, 25);
            this.txtMinCount.TabIndex = 1;
            this.txtMinCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStorageConfim_KeyPress);
            // 
            // txtMaxCount
            // 
            this.txtMaxCount.Location = new System.Drawing.Point(116, 34);
            this.txtMaxCount.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaxCount.Name = "txtMaxCount";
            this.txtMaxCount.Size = new System.Drawing.Size(235, 25);
            this.txtMaxCount.TabIndex = 0;
            this.txtMaxCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStorageConfim_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(612, 326);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 41);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbStorage
            // 
            this.gbStorage.Controls.Add(this.txtMinCount);
            this.gbStorage.Controls.Add(this.txtMaxCount);
            this.gbStorage.Controls.Add(this.label6);
            this.gbStorage.Controls.Add(this.label5);
            this.gbStorage.Location = new System.Drawing.Point(27, 228);
            this.gbStorage.Margin = new System.Windows.Forms.Padding(4);
            this.gbStorage.Name = "gbStorage";
            this.gbStorage.Padding = new System.Windows.Forms.Padding(4);
            this.gbStorage.Size = new System.Drawing.Size(692, 79);
            this.gbStorage.TabIndex = 1;
            this.gbStorage.TabStop = false;
            this.gbStorage.Text = "[库存预设]";
            // 
            // FrmAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 404);
            this.Controls.Add(this.gbStorage);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.btnSubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmAddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[添加新商品]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEditProduct_FormClosing);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.gbStorage.ResumeLayout(false);
            this.gbStorage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMinCount;
        private System.Windows.Forms.TextBox txtMaxCount;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbStorage;
    }
}