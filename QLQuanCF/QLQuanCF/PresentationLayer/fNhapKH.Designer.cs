namespace QLQuanCF.PresentationLayer
{
	partial class fNhapKH
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtTenKH = new System.Windows.Forms.TextBox();
			this.txtDiaChi = new System.Windows.Forms.TextBox();
			this.txtSDT = new System.Windows.Forms.TextBox();
			this.btnThem = new System.Windows.Forms.Button();
			this.btnThoat = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(107, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(185, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Thêm khách hàng";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Họ tên:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(26, 143);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Địa chỉ:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(26, 206);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Số điện thoại:";
			// 
			// txtTenKH
			// 
			this.txtTenKH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTenKH.Location = new System.Drawing.Point(129, 85);
			this.txtTenKH.Name = "txtTenKH";
			this.txtTenKH.Size = new System.Drawing.Size(236, 22);
			this.txtTenKH.TabIndex = 4;
			// 
			// txtDiaChi
			// 
			this.txtDiaChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDiaChi.Location = new System.Drawing.Point(129, 140);
			this.txtDiaChi.Name = "txtDiaChi";
			this.txtDiaChi.Size = new System.Drawing.Size(236, 22);
			this.txtDiaChi.TabIndex = 5;
			// 
			// txtSDT
			// 
			this.txtSDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSDT.Enabled = false;
			this.txtSDT.Location = new System.Drawing.Point(129, 204);
			this.txtSDT.Name = "txtSDT";
			this.txtSDT.Size = new System.Drawing.Size(236, 22);
			this.txtSDT.TabIndex = 6;
			// 
			// btnThem
			// 
			this.btnThem.Location = new System.Drawing.Point(60, 265);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(78, 33);
			this.btnThem.TabIndex = 7;
			this.btnThem.Text = "Thêm";
			this.btnThem.UseVisualStyleBackColor = true;
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
			// 
			// btnThoat
			// 
			this.btnThoat.Location = new System.Drawing.Point(241, 265);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new System.Drawing.Size(78, 33);
			this.btnThoat.TabIndex = 8;
			this.btnThoat.Text = "Thoát";
			this.btnThoat.UseVisualStyleBackColor = true;
			this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
			// 
			// fNhapKH
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(404, 328);
			this.Controls.Add(this.btnThoat);
			this.Controls.Add(this.btnThem);
			this.Controls.Add(this.txtSDT);
			this.Controls.Add(this.txtDiaChi);
			this.Controls.Add(this.txtTenKH);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "fNhapKH";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Thêm khách hàng";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtTenKH;
		private System.Windows.Forms.TextBox txtDiaChi;
		private System.Windows.Forms.TextBox txtSDT;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.Button btnThoat;
	}
}