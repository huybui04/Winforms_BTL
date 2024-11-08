using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
<<<<<<< HEAD
using QLQuanCF.DataAccessLayer;
using QLQuanCF.Models;
=======
using QLQuanCF.Model;
using System.Data;
using QLQuanCF.BusinessLogicLayer;
>>>>>>> ad3e75cc11dd7f70a7eb0d2b1e3f3cca8d0abaa7

namespace QLQuanCF
{
    public partial class fLogin : Form
    {
<<<<<<< HEAD
        private UserDAL _userDAL = new UserDAL(Classes.DbConfig.connectString);

=======
		private NhanVienBLL _nhanVienBLL = new NhanVienBLL(Classes.DbConfig.connectString);
        public NhanVien LoggedInNhanVien { get; private set; }
>>>>>>> ad3e75cc11dd7f70a7eb0d2b1e3f3cca8d0abaa7
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
<<<<<<< HEAD
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.");
                return;
            }

            // Kiểm tra đăng nhập
            bool isValid = _userDAL.CheckLogin(username, password);
            if (isValid)
            {
                // Lấy thông tin người dùng và phân quyền
                User user = _userDAL.GetUserByUsername(username);

                // Mở form chính và phân quyền
                fMain f = new fMain(user);
=======
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
>>>>>>> ad3e75cc11dd7f70a7eb0d2b1e3f3cca8d0abaa7
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
<<<<<<< HEAD
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
=======
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
>>>>>>> ad3e75cc11dd7f70a7eb0d2b1e3f3cca8d0abaa7
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
