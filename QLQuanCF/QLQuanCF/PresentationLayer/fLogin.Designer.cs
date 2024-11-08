namespace QLQuanCF
{
    partial class fLogin
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
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.gradientPanel = new System.Windows.Forms.Panel();
            this.labelInvisible = new System.Windows.Forms.Label();
            this.pbLogin = new System.Windows.Forms.PictureBox();
            this.lbRGT = new System.Windows.Forms.Label();
            this.lbFTP = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.gradientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaNV
            // 
            this.txtMaNV.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtMaNV.ForeColor = System.Drawing.Color.DimGray;
            this.txtMaNV.Location = new System.Drawing.Point(109, 154);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(0);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(260, 26);
            this.txtMaNV.TabIndex = 1;
            this.txtMaNV.Text = "Mã NV";
            this.txtMaNV.Click += new System.EventHandler(this.txtUsername_Click);
            this.txtMaNV.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtPassword.ForeColor = System.Drawing.Color.DimGray;
            this.txtPassword.Location = new System.Drawing.Point(109, 206);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(260, 26);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "Password";
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Click += new System.EventHandler(this.txtPassword_Click);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.LimeGreen;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogin.Location = new System.Drawing.Point(63, 294);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(112, 35);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExit.Location = new System.Drawing.Point(243, 294);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 35);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gradientPanel
            // 
            this.gradientPanel.BackColor = System.Drawing.Color.Snow;
            this.gradientPanel.Controls.Add(this.labelInvisible);
            this.gradientPanel.Controls.Add(this.pbLogin);
            this.gradientPanel.Controls.Add(this.lbRGT);
            this.gradientPanel.Controls.Add(this.lbFTP);
            this.gradientPanel.Controls.Add(this.pictureBox3);
            this.gradientPanel.Controls.Add(this.pictureBox2);
            this.gradientPanel.Controls.Add(this.txtPassword);
            this.gradientPanel.Controls.Add(this.txtMaNV);
            this.gradientPanel.Controls.Add(this.btnExit);
            this.gradientPanel.Controls.Add(this.btnLogin);
            this.gradientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientPanel.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel.Margin = new System.Windows.Forms.Padding(2);
            this.gradientPanel.Name = "gradientPanel";
            this.gradientPanel.Size = new System.Drawing.Size(421, 346);
            this.gradientPanel.TabIndex = 0;
            this.gradientPanel.Click += new System.EventHandler(this.gradientPanel_Click);
            this.gradientPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gradientPanel_Paint);
            // 
            // labelInvisible
            // 
            this.labelInvisible.AutoSize = true;
            this.labelInvisible.Location = new System.Drawing.Point(374, 96);
            this.labelInvisible.Name = "labelInvisible";
            this.labelInvisible.Size = new System.Drawing.Size(0, 19);
            this.labelInvisible.TabIndex = 7;
            // 
            // pbLogin
            // 
            this.pbLogin.BackColor = System.Drawing.Color.Transparent;
            this.pbLogin.Image = global::QLQuanCF.Properties.Resources.login;
            this.pbLogin.Location = new System.Drawing.Point(143, 12);
            this.pbLogin.Name = "pbLogin";
            this.pbLogin.Size = new System.Drawing.Size(123, 118);
            this.pbLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogin.TabIndex = 0;
            this.pbLogin.TabStop = false;
            // 
            // lbRGT
            // 
            this.lbRGT.AutoSize = true;
            this.lbRGT.BackColor = System.Drawing.Color.Transparent;
            this.lbRGT.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRGT.ForeColor = System.Drawing.Color.Orange;
            this.lbRGT.Location = new System.Drawing.Point(283, 255);
            this.lbRGT.Name = "lbRGT";
            this.lbRGT.Size = new System.Drawing.Size(56, 14);
            this.lbRGT.TabIndex = 6;
            this.lbRGT.Text = "REGISTER";
            // 
            // lbFTP
            // 
            this.lbFTP.AutoSize = true;
            this.lbFTP.BackColor = System.Drawing.Color.Transparent;
            this.lbFTP.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFTP.ForeColor = System.Drawing.Color.Orange;
            this.lbFTP.Location = new System.Drawing.Point(60, 255);
            this.lbFTP.Name = "lbFTP";
            this.lbFTP.Size = new System.Drawing.Size(131, 14);
            this.lbFTP.TabIndex = 5;
            this.lbFTP.Text = "FORGET THE PASWORD?";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::QLQuanCF.Properties.Resources.password;
            this.pictureBox3.Location = new System.Drawing.Point(44, 206);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(43, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::QLQuanCF.Properties.Resources.user1;
            this.pictureBox2.Location = new System.Drawing.Point(44, 154);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // fLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(421, 346);
            this.Controls.Add(this.gradientPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.fLogin_Load);
            this.gradientPanel.ResumeLayout(false);
            this.gradientPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel gradientPanel;
		private System.Windows.Forms.PictureBox pbLogin;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label lbRGT;
		private System.Windows.Forms.Label lbFTP;
		private System.Windows.Forms.Label labelInvisible;
	}
}

