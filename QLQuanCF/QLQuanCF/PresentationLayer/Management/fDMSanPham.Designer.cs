namespace QLQuanCF.PresentationLayer
{
    partial class fDMSanPham
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
            this.panel24 = new System.Windows.Forms.Panel();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.dataDMSP = new System.Windows.Forms.DataGridView();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.btnExitDMSP = new System.Windows.Forms.Button();
            this.btnAddDMSP = new System.Windows.Forms.Button();
            this.btnEditDMSP = new System.Windows.Forms.Button();
            this.btnDeleteDMSP = new System.Windows.Forms.Button();
            this.panel23 = new System.Windows.Forms.Panel();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.btnCancelDMSP = new System.Windows.Forms.Button();
            this.btnSaveDMSP = new System.Windows.Forms.Button();
            this.panel41 = new System.Windows.Forms.Panel();
            this.txtTenDMSP = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.panel42 = new System.Windows.Forms.Panel();
            this.txtMaDMSP = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.btnSearchDMSP = new System.Windows.Forms.Button();
            this.txtSearchDMSP = new System.Windows.Forms.TextBox();
            this.panel24.SuspendLayout();
            this.groupBox19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDMSP)).BeginInit();
            this.groupBox20.SuspendLayout();
            this.panel23.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.panel41.SuspendLayout();
            this.panel42.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.groupBox19);
            this.panel24.Controls.Add(this.groupBox20);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel24.Location = new System.Drawing.Point(0, 0);
            this.panel24.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(693, 505);
            this.panel24.TabIndex = 3;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.dataDMSP);
            this.groupBox19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox19.Location = new System.Drawing.Point(0, 78);
            this.groupBox19.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox19.Size = new System.Drawing.Size(693, 427);
            this.groupBox19.TabIndex = 3;
            this.groupBox19.TabStop = false;
            // 
            // dataDMSP
            // 
            this.dataDMSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDMSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataDMSP.Location = new System.Drawing.Point(3, 17);
            this.dataDMSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataDMSP.Name = "dataDMSP";
            this.dataDMSP.ReadOnly = true;
            this.dataDMSP.RowHeadersWidth = 51;
            this.dataDMSP.RowTemplate.Height = 24;
            this.dataDMSP.Size = new System.Drawing.Size(687, 408);
            this.dataDMSP.TabIndex = 0;
            this.dataDMSP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataDanhMuc_CellClick);
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.btnExitDMSP);
            this.groupBox20.Controls.Add(this.btnAddDMSP);
            this.groupBox20.Controls.Add(this.btnEditDMSP);
            this.groupBox20.Controls.Add(this.btnDeleteDMSP);
            this.groupBox20.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox20.Location = new System.Drawing.Point(0, 0);
            this.groupBox20.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox20.Size = new System.Drawing.Size(693, 78);
            this.groupBox20.TabIndex = 0;
            this.groupBox20.TabStop = false;
            // 
            // btnExitDMSP
            // 
            this.btnExitDMSP.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExitDMSP.Image = global::QLQuanCF.Properties.Resources.exit;
            this.btnExitDMSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExitDMSP.Location = new System.Drawing.Point(581, 19);
            this.btnExitDMSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExitDMSP.Name = "btnExitDMSP";
            this.btnExitDMSP.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnExitDMSP.Size = new System.Drawing.Size(109, 49);
            this.btnExitDMSP.TabIndex = 3;
            this.btnExitDMSP.Text = "Thoát";
            this.btnExitDMSP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExitDMSP.UseVisualStyleBackColor = false;
            this.btnExitDMSP.Click += new System.EventHandler(this.btnExitDM_Click);
            // 
            // btnAddDMSP
            // 
            this.btnAddDMSP.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddDMSP.Image = global::QLQuanCF.Properties.Resources.add;
            this.btnAddDMSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddDMSP.Location = new System.Drawing.Point(12, 19);
            this.btnAddDMSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddDMSP.Name = "btnAddDMSP";
            this.btnAddDMSP.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnAddDMSP.Size = new System.Drawing.Size(109, 49);
            this.btnAddDMSP.TabIndex = 0;
            this.btnAddDMSP.Text = "Thêm";
            this.btnAddDMSP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddDMSP.UseVisualStyleBackColor = false;
            this.btnAddDMSP.Click += new System.EventHandler(this.btnAddDM_Click);
            // 
            // btnEditDMSP
            // 
            this.btnEditDMSP.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditDMSP.Image = global::QLQuanCF.Properties.Resources.edit;
            this.btnEditDMSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditDMSP.Location = new System.Drawing.Point(378, 19);
            this.btnEditDMSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditDMSP.Name = "btnEditDMSP";
            this.btnEditDMSP.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnEditDMSP.Size = new System.Drawing.Size(109, 49);
            this.btnEditDMSP.TabIndex = 2;
            this.btnEditDMSP.Text = "Sửa";
            this.btnEditDMSP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditDMSP.UseVisualStyleBackColor = false;
            this.btnEditDMSP.Click += new System.EventHandler(this.btnEditDM_Click);
            // 
            // btnDeleteDMSP
            // 
            this.btnDeleteDMSP.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteDMSP.Image = global::QLQuanCF.Properties.Resources.delete;
            this.btnDeleteDMSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteDMSP.Location = new System.Drawing.Point(188, 19);
            this.btnDeleteDMSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteDMSP.Name = "btnDeleteDMSP";
            this.btnDeleteDMSP.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnDeleteDMSP.Size = new System.Drawing.Size(109, 49);
            this.btnDeleteDMSP.TabIndex = 1;
            this.btnDeleteDMSP.Text = "Xóa";
            this.btnDeleteDMSP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteDMSP.UseVisualStyleBackColor = false;
            this.btnDeleteDMSP.Click += new System.EventHandler(this.btnDeleteDM_Click);
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.groupBox17);
            this.panel23.Controls.Add(this.groupBox18);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel23.Location = new System.Drawing.Point(693, 0);
            this.panel23.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(449, 505);
            this.panel23.TabIndex = 2;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.btnCancelDMSP);
            this.groupBox17.Controls.Add(this.btnSaveDMSP);
            this.groupBox17.Controls.Add(this.panel41);
            this.groupBox17.Controls.Add(this.panel42);
            this.groupBox17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox17.Location = new System.Drawing.Point(0, 78);
            this.groupBox17.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox17.Size = new System.Drawing.Size(449, 427);
            this.groupBox17.TabIndex = 1;
            this.groupBox17.TabStop = false;
            // 
            // btnCancelDMSP
            // 
            this.btnCancelDMSP.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelDMSP.Image = global::QLQuanCF.Properties.Resources.cancel;
            this.btnCancelDMSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelDMSP.Location = new System.Drawing.Point(266, 235);
            this.btnCancelDMSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelDMSP.Name = "btnCancelDMSP";
            this.btnCancelDMSP.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnCancelDMSP.Size = new System.Drawing.Size(109, 49);
            this.btnCancelDMSP.TabIndex = 3;
            this.btnCancelDMSP.Text = "Hủy";
            this.btnCancelDMSP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelDMSP.UseVisualStyleBackColor = false;
            this.btnCancelDMSP.Click += new System.EventHandler(this.btnCancelDM_Click);
            // 
            // btnSaveDMSP
            // 
            this.btnSaveDMSP.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveDMSP.Image = global::QLQuanCF.Properties.Resources.save;
            this.btnSaveDMSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveDMSP.Location = new System.Drawing.Point(77, 235);
            this.btnSaveDMSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveDMSP.Name = "btnSaveDMSP";
            this.btnSaveDMSP.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnSaveDMSP.Size = new System.Drawing.Size(109, 49);
            this.btnSaveDMSP.TabIndex = 2;
            this.btnSaveDMSP.Text = "Lưu";
            this.btnSaveDMSP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveDMSP.UseVisualStyleBackColor = false;
            this.btnSaveDMSP.Click += new System.EventHandler(this.btnSaveDM_Click);
            // 
            // panel41
            // 
            this.panel41.Controls.Add(this.txtTenDMSP);
            this.panel41.Controls.Add(this.label24);
            this.panel41.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel41.Location = new System.Drawing.Point(3, 59);
            this.panel41.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel41.Name = "panel41";
            this.panel41.Size = new System.Drawing.Size(443, 42);
            this.panel41.TabIndex = 1;
            // 
            // txtTenDMSP
            // 
            this.txtTenDMSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenDMSP.Location = new System.Drawing.Point(119, 15);
            this.txtTenDMSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenDMSP.Name = "txtTenDMSP";
            this.txtTenDMSP.Size = new System.Drawing.Size(286, 22);
            this.txtTenDMSP.TabIndex = 2;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(11, 17);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(58, 16);
            this.label24.TabIndex = 1;
            this.label24.Text = "Tên DM:";
            // 
            // panel42
            // 
            this.panel42.Controls.Add(this.txtMaDMSP);
            this.panel42.Controls.Add(this.label25);
            this.panel42.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel42.Location = new System.Drawing.Point(3, 17);
            this.panel42.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel42.Name = "panel42";
            this.panel42.Size = new System.Drawing.Size(443, 42);
            this.panel42.TabIndex = 0;
            // 
            // txtMaDMSP
            // 
            this.txtMaDMSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaDMSP.Enabled = false;
            this.txtMaDMSP.Location = new System.Drawing.Point(119, 15);
            this.txtMaDMSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaDMSP.Name = "txtMaDMSP";
            this.txtMaDMSP.Size = new System.Drawing.Size(286, 22);
            this.txtMaDMSP.TabIndex = 1;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(11, 17);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 16);
            this.label25.TabIndex = 0;
            this.label25.Text = "Mã DM:";
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.btnSearchDMSP);
            this.groupBox18.Controls.Add(this.txtSearchDMSP);
            this.groupBox18.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox18.Location = new System.Drawing.Point(0, 0);
            this.groupBox18.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox18.Size = new System.Drawing.Size(449, 78);
            this.groupBox18.TabIndex = 2;
            this.groupBox18.TabStop = false;
            // 
            // btnSearchDMSP
            // 
            this.btnSearchDMSP.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearchDMSP.Image = global::QLQuanCF.Properties.Resources.search;
            this.btnSearchDMSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchDMSP.Location = new System.Drawing.Point(331, 19);
            this.btnSearchDMSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearchDMSP.Name = "btnSearchDMSP";
            this.btnSearchDMSP.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnSearchDMSP.Size = new System.Drawing.Size(109, 49);
            this.btnSearchDMSP.TabIndex = 1;
            this.btnSearchDMSP.Text = "Tìm kiếm";
            this.btnSearchDMSP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchDMSP.UseVisualStyleBackColor = false;
            this.btnSearchDMSP.Click += new System.EventHandler(this.btnSearchDM_Click);
            // 
            // txtSearchDMSP
            // 
            this.txtSearchDMSP.Location = new System.Drawing.Point(6, 32);
            this.txtSearchDMSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchDMSP.Multiline = true;
            this.txtSearchDMSP.Name = "txtSearchDMSP";
            this.txtSearchDMSP.Size = new System.Drawing.Size(315, 27);
            this.txtSearchDMSP.TabIndex = 0;
            // 
            // fDMSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 505);
            this.Controls.Add(this.panel24);
            this.Controls.Add(this.panel23);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fDMSanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Danh Mục Sản Phẩm";
            this.panel24.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataDMSP)).EndInit();
            this.groupBox20.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.panel41.ResumeLayout(false);
            this.panel41.PerformLayout();
            this.panel42.ResumeLayout(false);
            this.panel42.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.DataGridView dataDMSP;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Button btnExitDMSP;
        private System.Windows.Forms.Button btnAddDMSP;
        private System.Windows.Forms.Button btnEditDMSP;
        private System.Windows.Forms.Button btnDeleteDMSP;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Panel panel41;
        private System.Windows.Forms.TextBox txtTenDMSP;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel panel42;
        private System.Windows.Forms.TextBox txtMaDMSP;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.Button btnSearchDMSP;
        private System.Windows.Forms.TextBox txtSearchDMSP;
        private System.Windows.Forms.Button btnCancelDMSP;
        private System.Windows.Forms.Button btnSaveDMSP;
    }
}