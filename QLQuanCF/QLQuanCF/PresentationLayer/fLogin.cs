using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using QLQuanCF.Model;
using System.Data;
using QLQuanCF.BusinessLogicLayer;

namespace QLQuanCF
{
    public partial class fLogin : Form
    {
		private NhanVienBLL _nhanVienBLL = new NhanVienBLL(Classes.DbConfig.connectString);
        public NhanVien LoggedInNhanVien { get; private set; }
        public fLogin()
		{
			InitializeComponent();
		}

		private void fLogin_Load(object sender, EventArgs e)
		{
			this.ActiveControl = labelInvisible;
			labelInvisible.Visible = false;
		}

		private void gradientPanel_Click(object sender, EventArgs e)
		{
			this.ActiveControl = null;
		}

		private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
			do
			{
				if (string.IsNullOrEmpty(txtMaNV.Text) || string.IsNullOrEmpty(txtPassword.Text))
				{
					MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			} while (string.IsNullOrEmpty(txtMaNV.Text) || string.IsNullOrEmpty(txtPassword.Text));
            
			NhanVien emp = _nhanVienBLL.GetNhanVienByMaNV(txtMaNV.Text);


            if (emp != null ) // TODO: thêm check password
            {
                LoggedInNhanVien = emp; 
                fMain f = new fMain();
                f.Owner = this; // Set the owner
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void txtUsername_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtMaNV.Text))
			{
				txtMaNV.Text = "Mã NV";
			}
		}

		private void txtPassword_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtPassword.Text))
			{
				txtPassword.Text = "Password";
			}
		}

		private void txtUsername_Click(object sender, EventArgs e)
		{
			if (txtMaNV.Text == "Mã NV") 
				txtMaNV.Text = "";
		}

		private void txtPassword_Click(object sender, EventArgs e)
		{
			if (txtPassword.Text == "Password") 
				txtPassword.Text = "";
		}

		private void gradientPanel_Paint(object sender, PaintEventArgs e)
		{
			using (LinearGradientBrush brush = new LinearGradientBrush(this.gradientPanel.ClientRectangle, Color.Pink, Color.Blue, 45F))
			{
				e.Graphics.FillRectangle(brush, this.gradientPanel.ClientRectangle);
			}
		}
	}
}
