using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace QLQuanCF
{
    public partial class fLogin : Form
    {
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
            fMain f = new fMain();
            this.Hide();
            f.ShowDialog();
            this.Show();
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
