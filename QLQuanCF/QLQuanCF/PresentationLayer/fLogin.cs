using System;
using System.Windows.Forms;

namespace QLQuanCF
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
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

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
