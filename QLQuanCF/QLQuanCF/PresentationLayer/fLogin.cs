using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using QLQuanCF.DataAccessLayer;
using QLQuanCF.Models;

namespace QLQuanCF
{
    public partial class fLogin : Form
    {
        private UserDAL _userDAL = new UserDAL(Classes.DbConfig.connectString);

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
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
            }
        }

		private void txtUsername_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtUsername.Text))
			{
				txtUsername.Text = "User Name";
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
			if (txtUsername.Text == "User Name") 
				txtUsername.Text = "";
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
