namespace QLQuanCF.PresentationLayer.Management
{
	partial class fBaoCaoDT
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
			this.button1 = new System.Windows.Forms.Button();
			this.txtTongCong = new System.Windows.Forms.TextBox();
			this.dtpDen = new System.Windows.Forms.DateTimePicker();
			this.dtpTu = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvBaoCao = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(981, 20);
			this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(137, 33);
			this.button1.TabIndex = 12;
			this.button1.Text = "Xem báo cáo";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.btnLoadReport_Click);
			// 
			// txtTongCong
			// 
			this.txtTongCong.Location = new System.Drawing.Point(141, 588);
			this.txtTongCong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtTongCong.Name = "txtTongCong";
			this.txtTongCong.Size = new System.Drawing.Size(89, 22);
			this.txtTongCong.TabIndex = 11;
			// 
			// dtpDen
			// 
			this.dtpDen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDen.Location = new System.Drawing.Point(486, 32);
			this.dtpDen.Margin = new System.Windows.Forms.Padding(4);
			this.dtpDen.Name = "dtpDen";
			this.dtpDen.Size = new System.Drawing.Size(143, 22);
			this.dtpDen.TabIndex = 9;
			// 
			// dtpTu
			// 
			this.dtpTu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpTu.Location = new System.Drawing.Point(125, 32);
			this.dtpTu.Margin = new System.Windows.Forms.Padding(4);
			this.dtpTu.Name = "dtpTu";
			this.dtpTu.Size = new System.Drawing.Size(143, 22);
			this.dtpTu.TabIndex = 10;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(428, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(31, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "Đến";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(80, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(23, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "Từ";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(29, 591);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 8;
			this.label1.Text = "Tổng cộng";
			// 
			// dgvBaoCao
			// 
			this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvBaoCao.Location = new System.Drawing.Point(33, 109);
			this.dgvBaoCao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dgvBaoCao.Name = "dgvBaoCao";
			this.dgvBaoCao.RowHeadersWidth = 62;
			this.dgvBaoCao.RowTemplate.Height = 28;
			this.dgvBaoCao.Size = new System.Drawing.Size(1031, 452);
			this.dgvBaoCao.TabIndex = 5;
			// 
			// fBaoCaoDT
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1146, 631);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtTongCong);
			this.Controls.Add(this.dtpDen);
			this.Controls.Add(this.dtpTu);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dgvBaoCao);
			this.Name = "fBaoCaoDT";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "fBaoCao";
			((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtTongCong;
		private System.Windows.Forms.DateTimePicker dtpDen;
		private System.Windows.Forms.DateTimePicker dtpTu;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgvBaoCao;
	}
}