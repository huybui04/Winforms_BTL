using QLQuanCF.BusinessLogicLayer;
using QLQuanCF.Models;
using QLQuanCF.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QLQuanCF
{
    public partial class fMain : Form
    {
        private BanBLL _banBLL = new BanBLL(Classes.DbConfig.connectString);
		private KhuVucBLL _khuVucBLL = new KhuVucBLL(Classes.DbConfig.connectString);

		public fMain()
        {
            InitializeComponent();
			LoadKhuVuc();
			LoadAllTables();
		}

		void LoadKhuVuc()
		{
			List<KhuVuc> khuVucList = _khuVucBLL.GetAllKhuVuc();

			foreach (KhuVuc khuVuc in khuVucList)
			{
				Button btnKhuVuc = new Button()
				{
					Width = 140,
					Height = 60,
					Text = khuVuc.MaKV,
					Tag = khuVuc,
					BackColor = Color.LightBlue
				};

				btnKhuVuc.Click += (sender, e) =>
				{
					KhuVuc selectedKV = (KhuVuc)(sender as Button).Tag;
					LoadTableByKhuVuc(selectedKV.MaKV);
					gbBan.Text = selectedKV.TenKV;
				};

				flpKV.Controls.Add(btnKhuVuc);
			}
		}

		void LoadAllTables()
		{
			flpTable.Controls.Clear(); 

			List<Ban> tableList = _banBLL.GetAllBan(); 
			AddButtonsToTable(tableList);
		}

		void LoadTableByKhuVuc(string maKV)
		{
			flpTable.Controls.Clear(); 

			List<Ban> tableList = _banBLL.GetBanByKhuVuc(maKV);
			AddButtonsToTable(tableList);

			if (tableList.Count == 0)
			{
				MessageBox.Show("Không có bàn nào trong khu vực này.");
			}
		}

		private void AddButtonsToTable(List<Ban> tableList)
		{
			foreach (Ban ban in tableList)
			{
				Button btn = new Button()
				{
					Width = 120,
					Height = 120,
					Text = ban.TenBan + Environment.NewLine + ban.TrangThai,
					Tag = ban,
					BackColor = ban.TrangThai == "Trống" ? Color.LightGreen : Color.LightCoral
				};

				flpTable.Controls.Add(btn);
			}
		}

		private void btnChonMon_Click(object sender, EventArgs e)
		{
			fMenuSelection fMenuSelection = new fMenuSelection();
			fMenuSelection.Show();
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

        private void QLDMSPStripMenuItem_Click(object sender, EventArgs e)
        {
            fDMSanPham f = new fDMSanPham();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void QLNCCStripMenuItem_Click(object sender, EventArgs e)
        {
            fNhaCungCap f = new fNhaCungCap();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

		private void QLKVStripMenuItem_Click(object sender, EventArgs e)
		{
			fKhuVuc f = new fKhuVuc();
			this.Hide();
			f.ShowDialog();
			this.Show();
		}

		private void QLBStripMenuItem_Click(object sender, EventArgs e)
		{
            fBan f = new fBan();
			this.Hide();
			f.ShowDialog();
			this.Show();
		}

		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}