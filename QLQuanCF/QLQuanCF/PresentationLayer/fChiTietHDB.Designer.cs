namespace QLQuanCF.PresentationLayer
{
	partial class fChiTietHDB
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
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lsvCTHD = new System.Windows.Forms.ListView();
			this.btnThanhToan = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lblMaHDB = new System.Windows.Forms.Label();
			this.lblTenBan = new System.Windows.Forms.Label();
			this.lblNgayBan = new System.Windows.Forms.Label();
			this.lblTenNV = new System.Windows.Forms.Label();
			this.lblTenKH = new System.Windows.Forms.Label();
			this.lblSDTKH = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtGiamGia = new System.Windows.Forms.TextBox();
			this.txtTongTien = new System.Windows.Forms.TextBox();
			this.btnHuy = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(162, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(135, 36);
			this.label1.TabIndex = 0;
			this.label1.Text = "Hóa đơn";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblSDTKH);
			this.groupBox1.Controls.Add(this.lblTenKH);
			this.groupBox1.Controls.Add(this.lblTenNV);
			this.groupBox1.Controls.Add(this.lblNgayBan);
			this.groupBox1.Controls.Add(this.lblTenBan);
			this.groupBox1.Controls.Add(this.lblMaHDB);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(12, 48);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(423, 227);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông tin chung";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lsvCTHD);
			this.groupBox2.Location = new System.Drawing.Point(12, 281);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(423, 300);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Chi tiết hóa đơn";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(22, 30);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Mã hóa đơn:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(22, 129);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 16);
			this.label3.TabIndex = 1;
			this.label3.Text = "Tên nhân viên:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(22, 94);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 16);
			this.label4.TabIndex = 2;
			this.label4.Text = "Ngày bán:";
			// 
			// lsvCTHD
			// 
			this.lsvCTHD.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lsvCTHD.GridLines = true;
			this.lsvCTHD.HideSelection = false;
			this.lsvCTHD.Location = new System.Drawing.Point(6, 21);
			this.lsvCTHD.Name = "lsvCTHD";
			this.lsvCTHD.Size = new System.Drawing.Size(411, 270);
			this.lsvCTHD.TabIndex = 0;
			this.lsvCTHD.UseCompatibleStateImageBehavior = false;
			this.lsvCTHD.View = System.Windows.Forms.View.Details;
			// 
			// btnThanhToan
			// 
			this.btnThanhToan.Location = new System.Drawing.Point(68, 660);
			this.btnThanhToan.Name = "btnThanhToan";
			this.btnThanhToan.Size = new System.Drawing.Size(112, 43);
			this.btnThanhToan.TabIndex = 3;
			this.btnThanhToan.Text = "Thanh toán";
			this.btnThanhToan.UseVisualStyleBackColor = true;
			this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(23, 162);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(106, 16);
			this.label5.TabIndex = 3;
			this.label5.Text = "Tên khách hàng:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(22, 197);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 16);
			this.label6.TabIndex = 4;
			this.label6.Text = "Số điện thoại:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(22, 60);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(34, 16);
			this.label7.TabIndex = 5;
			this.label7.Text = "Bàn:";
			// 
			// lblMaHDB
			// 
			this.lblMaHDB.AutoSize = true;
			this.lblMaHDB.Location = new System.Drawing.Point(212, 30);
			this.lblMaHDB.Name = "lblMaHDB";
			this.lblMaHDB.Size = new System.Drawing.Size(44, 16);
			this.lblMaHDB.TabIndex = 6;
			this.lblMaHDB.Text = "label8";
			// 
			// lblTenBan
			// 
			this.lblTenBan.AutoSize = true;
			this.lblTenBan.Location = new System.Drawing.Point(212, 60);
			this.lblTenBan.Name = "lblTenBan";
			this.lblTenBan.Size = new System.Drawing.Size(44, 16);
			this.lblTenBan.TabIndex = 7;
			this.lblTenBan.Text = "label9";
			// 
			// lblNgayBan
			// 
			this.lblNgayBan.AutoSize = true;
			this.lblNgayBan.Location = new System.Drawing.Point(212, 94);
			this.lblNgayBan.Name = "lblNgayBan";
			this.lblNgayBan.Size = new System.Drawing.Size(51, 16);
			this.lblNgayBan.TabIndex = 8;
			this.lblNgayBan.Text = "label10";
			// 
			// lblTenNV
			// 
			this.lblTenNV.AutoSize = true;
			this.lblTenNV.Location = new System.Drawing.Point(212, 129);
			this.lblTenNV.Name = "lblTenNV";
			this.lblTenNV.Size = new System.Drawing.Size(51, 16);
			this.lblTenNV.TabIndex = 9;
			this.lblTenNV.Text = "label11";
			// 
			// lblTenKH
			// 
			this.lblTenKH.AutoSize = true;
			this.lblTenKH.Location = new System.Drawing.Point(212, 162);
			this.lblTenKH.Name = "lblTenKH";
			this.lblTenKH.Size = new System.Drawing.Size(51, 16);
			this.lblTenKH.TabIndex = 10;
			this.lblTenKH.Text = "label12";
			// 
			// lblSDTKH
			// 
			this.lblSDTKH.AutoSize = true;
			this.lblSDTKH.Location = new System.Drawing.Point(212, 197);
			this.lblSDTKH.Name = "lblSDTKH";
			this.lblSDTKH.Size = new System.Drawing.Size(51, 16);
			this.lblSDTKH.TabIndex = 11;
			this.lblSDTKH.Text = "label13";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(36, 594);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 16);
			this.label8.TabIndex = 5;
			this.label8.Text = "Giảm giá:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(34, 621);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(66, 16);
			this.label9.TabIndex = 6;
			this.label9.Text = "Tổng tiền:";
			// 
			// txtGiamGia
			// 
			this.txtGiamGia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtGiamGia.Enabled = false;
			this.txtGiamGia.Location = new System.Drawing.Point(179, 592);
			this.txtGiamGia.Name = "txtGiamGia";
			this.txtGiamGia.Size = new System.Drawing.Size(150, 22);
			this.txtGiamGia.TabIndex = 7;
			// 
			// txtTongTien
			// 
			this.txtTongTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTongTien.Enabled = false;
			this.txtTongTien.Location = new System.Drawing.Point(179, 620);
			this.txtTongTien.Name = "txtTongTien";
			this.txtTongTien.Size = new System.Drawing.Size(150, 22);
			this.txtTongTien.TabIndex = 8;
			// 
			// btnHuy
			// 
			this.btnHuy.Location = new System.Drawing.Point(249, 660);
			this.btnHuy.Name = "btnHuy";
			this.btnHuy.Size = new System.Drawing.Size(112, 43);
			this.btnHuy.TabIndex = 9;
			this.btnHuy.Text = "Hủy";
			this.btnHuy.UseVisualStyleBackColor = true;
			this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(331, 592);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(27, 22);
			this.label10.TabIndex = 44;
			this.label10.Text = "%";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(332, 621);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(42, 18);
			this.label11.TabIndex = 45;
			this.label11.Text = "VNĐ";
			// 
			// fChiTietHDB
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(441, 715);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.btnHuy);
			this.Controls.Add(this.txtTongTien);
			this.Controls.Add(this.txtGiamGia);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.btnThanhToan);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "fChiTietHDB";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Hóa Đơn";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListView lsvCTHD;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnThanhToan;
		private System.Windows.Forms.Label lblSDTKH;
		private System.Windows.Forms.Label lblTenKH;
		private System.Windows.Forms.Label lblTenNV;
		private System.Windows.Forms.Label lblNgayBan;
		private System.Windows.Forms.Label lblTenBan;
		private System.Windows.Forms.Label lblMaHDB;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtGiamGia;
		private System.Windows.Forms.TextBox txtTongTien;
		private System.Windows.Forms.Button btnHuy;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
	}
}