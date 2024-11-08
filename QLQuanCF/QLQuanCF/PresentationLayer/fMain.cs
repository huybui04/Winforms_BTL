using QLQuanCF.BusinessLogicLayer;
using QLQuanCF.Models;
using QLQuanCF.PresentationLayer;
using QLQuanCF.PresentationLayer.Management;
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
        private NhanVienBLL _nhanVienBLL = new NhanVienBLL(Classes.DbConfig.connectString);
        private User _currentUser;

        public fMain(User user)
        {
            _currentUser = user;
            InitializeComponent();
			LoadKhuVuc();
			LoadAllTables();
            SetUserPermissions();
        }
        private void SetUserPermissions()
        {
            if (_currentUser.Role == "Admin")
            {
                // Hiển thị tất cả các menu cho Admin
                //QLNVStripMenuItem.Visible = true;
                //QLKHStripMenuItem.Visible = true;
                //QLNLStripMenuItem.Visible = true;
                QLDMSPStripMenuItem.Visible = true;
                QLNCCStripMenuItem.Visible = true;
                QLKVStripMenuItem.Visible = true;
                QLBStripMenuItem.Visible = true;
            }
            else if (_currentUser.Role == "Manager")
            {
                // Người quản lý chỉ có quyền truy cập một số menu
                //QLNVStripMenuItem.Visible = true;
                //QLKHStripMenuItem.Visible = true;
                //QLNLStripMenuItem.Visible = true;
                QLDMSPStripMenuItem.Visible = true;
                QLKVStripMenuItem.Visible = true;
                QLBStripMenuItem.Visible = true;
            }
            else if (_currentUser.Role == "Staff")
            {
                // Nhân viên chỉ có quyền truy cập một số menu hạn chế
                //QLNVStripMenuItem.Visible = false;
                //QLKHStripMenuItem.Visible = true;
                //QLNLStripMenuItem.Visible = false;
                QLDMSPStripMenuItem.Visible = false;
                QLNCCStripMenuItem.Visible = false;
                QLKVStripMenuItem.Visible = false;
                QLBStripMenuItem.Visible = true;
            }
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

        private void QLSPtripMenuItem_Click(object sender, EventArgs e)
        {
            fSanPham f = new fSanPham();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void QLLCLVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCaLamViec f = new fCaLamViec();
			this.Hide();
			f.ShowDialog();
			this.Show();
        }

        private void QLHDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fHoaDonBan f = new fHoaDonBan(((fLogin)this.Owner).LoggedInNhanVien);
            this.Hide();
			f.ShowDialog();
            this.Show();
        }

        private void QLCTHDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
			fChiTietHoaDonBan f = new fChiTietHoaDonBan();
			this.Hide();
			f.ShowDialog();
			this.Show();
        }
    }
}