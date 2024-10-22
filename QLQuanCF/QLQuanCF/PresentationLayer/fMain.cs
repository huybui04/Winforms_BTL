using QLQuanCF.PresentationLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanCF
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void fMain_Load(object sender, EventArgs e)
        {

        }

        private void QLNVStripMenuItem_Click(object sender, EventArgs e)
        {
            fNhanVien f = new fNhanVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void QLKHStripMenuItem_Click(object sender, EventArgs e)
        {
            fKhachHang f = new fKhachHang();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void QLNLStripMenuItem_Click(object sender, EventArgs e)
        {
            fNguyenLieu f = new fNguyenLieu();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnChonMon_Click(object sender, EventArgs e)
        {
            fMenuSelection fMenuSelection = new fMenuSelection();
            fMenuSelection.Show();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}