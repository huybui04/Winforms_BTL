namespace QLQuanCF
{
    partial class fMenuSelection
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnSearchMon = new System.Windows.Forms.Button();
			this.btnThoat = new System.Windows.Forms.Button();
			this.btnChonMon = new System.Windows.Forms.Button();
			this.txtSearchMon = new System.Windows.Forms.TextBox();
			this.cbDM = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvSP = new System.Windows.Forms.DataGridView();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSP)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnSearchMon);
			this.groupBox1.Controls.Add(this.btnThoat);
			this.groupBox1.Controls.Add(this.btnChonMon);
			this.groupBox1.Controls.Add(this.txtSearchMon);
			this.groupBox1.Controls.Add(this.cbDM);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.dgvSP);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(786, 556);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Chọn thực đơn";
			// 
			// btnSearchMon
			// 
			this.btnSearchMon.Image = global::QLQuanCF.Properties.Resources.search;
			this.btnSearchMon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSearchMon.Location = new System.Drawing.Point(663, 25);
			this.btnSearchMon.Name = "btnSearchMon";
			this.btnSearchMon.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.btnSearchMon.Size = new System.Drawing.Size(109, 49);
			this.btnSearchMon.TabIndex = 7;
			this.btnSearchMon.Text = "Tìm kiếm";
			this.btnSearchMon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSearchMon.UseVisualStyleBackColor = true;
			this.btnSearchMon.Click += new System.EventHandler(this.btnSearchMon_Click);
			// 
			// btnThoat
			// 
			this.btnThoat.BackColor = System.Drawing.Color.OrangeRed;
			this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThoat.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnThoat.Location = new System.Drawing.Point(520, 509);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new System.Drawing.Size(137, 35);
			this.btnThoat.TabIndex = 6;
			this.btnThoat.Text = "Thoát";
			this.btnThoat.UseVisualStyleBackColor = false;
			this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
			// 
			// btnChonMon
			// 
			this.btnChonMon.BackColor = System.Drawing.Color.DeepSkyBlue;
			this.btnChonMon.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnChonMon.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnChonMon.Location = new System.Drawing.Point(105, 509);
			this.btnChonMon.Name = "btnChonMon";
			this.btnChonMon.Size = new System.Drawing.Size(137, 35);
			this.btnChonMon.TabIndex = 5;
			this.btnChonMon.Text = "Chọn";
			this.btnChonMon.UseVisualStyleBackColor = false;
			this.btnChonMon.Click += new System.EventHandler(this.btnChonMon_Click);
			// 
			// txtSearchMon
			// 
			this.txtSearchMon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSearchMon.Location = new System.Drawing.Point(446, 38);
			this.txtSearchMon.Name = "txtSearchMon";
			this.txtSearchMon.Size = new System.Drawing.Size(211, 25);
			this.txtSearchMon.TabIndex = 4;
			// 
			// cbDM
			// 
			this.cbDM.FormattingEnabled = true;
			this.cbDM.Location = new System.Drawing.Point(147, 38);
			this.cbDM.Name = "cbDM";
			this.cbDM.Size = new System.Drawing.Size(211, 25);
			this.cbDM.TabIndex = 2;
			this.cbDM.SelectedIndexChanged += new System.EventHandler(this.cbDM_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Chọn danh mục ";
			// 
			// dgvSP
			// 
			this.dgvSP.AllowUserToAddRows = false;
			dataGridViewCellStyle13.BackColor = System.Drawing.Color.LightGray;
			this.dgvSP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
			this.dgvSP.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.dgvSP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle14.BackColor = System.Drawing.Color.LightSlateGray;
			dataGridViewCellStyle14.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
			this.dgvSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle15.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.LightBlue;
			dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvSP.DefaultCellStyle = dataGridViewCellStyle15;
			this.dgvSP.EnableHeadersVisualStyles = false;
			this.dgvSP.GridColor = System.Drawing.Color.LightGray;
			this.dgvSP.Location = new System.Drawing.Point(12, 90);
			this.dgvSP.MultiSelect = false;
			this.dgvSP.Name = "dgvSP";
			this.dgvSP.RowHeadersWidth = 51;
			this.dgvSP.RowTemplate.Height = 24;
			this.dgvSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvSP.Size = new System.Drawing.Size(768, 404);
			this.dgvSP.TabIndex = 0;
			this.dgvSP.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSP_CellContentClick);
			this.dgvSP.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSP_CellValueChanged);
			// 
			// fMenuSelection
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Snow;
			this.ClientSize = new System.Drawing.Size(786, 556);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "fMenuSelection";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "fMenuSelection";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSP)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvSP;
        private System.Windows.Forms.ComboBox cbDM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnChonMon;
        private System.Windows.Forms.TextBox txtSearchMon;
        private System.Windows.Forms.Button btnSearchMon;
    }
}