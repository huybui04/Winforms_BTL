using Microsoft.VisualBasic;
using QLQuanCF.BusinessLogicLayer;
using QLQuanCF.DataAccessLayer;
using QLQuanCF.Models;
using QLQuanCF.PresentationLayer;
using QLQuanCF.PresentationLayer.Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLQuanCF
{
	public partial class fMain : Form
	{
		private BanBLL _banBLL = new BanBLL(Classes.DbConfig.connectString);
		private KhuVucBLL _khuVucBLL = new KhuVucBLL(Classes.DbConfig.connectString);
		private NhanVienBLL _nhanVienBLL = new NhanVienBLL(Classes.DbConfig.connectString);
		private HoaDonBanBLL _hoaDonBanBLL = new HoaDonBanBLL(Classes.DbConfig.connectString);
		private KhachHangBLL _khachHangBLL = new KhachHangBLL(Classes.DbConfig.connectString);
		private SanPhamBLL _sanPhamBLL = new SanPhamBLL(Classes.DbConfig.connectString);
		private OrderDetailsBLL _orderDetailsBLL = new OrderDetailsBLL(Classes.DbConfig.connectString);
		private User _currentUser;
		private NhanVien _nhanVien;
		private Ban currentSelectedBan;

		public List<SanPham> selectedSanPhamList = new List<SanPham>();

		public fMain(User user, NhanVien nhanVien)
		{
			_currentUser = user;
			_nhanVien = nhanVien;
			InitializeComponent();
			LoadKhuVuc();
			LoadAllTables();
			SetUserPermissions();
			SetupListViewCTHD();
		}

		private void fMain_Load(object sender, EventArgs e)
		{
			txtNV.Text = _nhanVien.TenNV;
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
				btn.Click += btn_Click;

				flpTable.Controls.Add(btn);
			}
		}

		private void btn_Click(object sender, EventArgs e)
		{
			currentSelectedBan = (sender as Button).Tag as Ban;
			lblTenBan.Text = currentSelectedBan.TenBan;

			lsvCTHD.Items.Clear();

			if(currentSelectedBan.TrangThai == "Đang sử dụng")
			{
				List<OrderDetails> orderDetails = _orderDetailsBLL.GetOrderDetailsByTable(currentSelectedBan.MaBan);
				foreach (OrderDetails orderDetail in orderDetails)
				{
					ListViewItem item = new ListViewItem(orderDetail.ItemName);
					item.SubItems.Add(orderDetail.SoLuong.ToString());
					item.SubItems.Add(orderDetail.DonGia.ToString());
					item.SubItems.Add((orderDetail.SoLuong * orderDetail.DonGia).ToString());
					lsvCTHD.Items.Add(item);
				}
			}
		}

		private void SetupListViewCTHD()
		{
			lsvCTHD.Columns.Clear();

			lsvCTHD.Columns.Add("TenSP", "Tên Món");
			lsvCTHD.Columns.Add("SoLuong", "Số Lượng");
			lsvCTHD.Columns.Add("Gia", "Giá");
			lsvCTHD.Columns.Add("ThanhTien", "Thành Tiền");

			lsvCTHD.Columns["TenSP"].Width = 120;
			lsvCTHD.Columns["SoLuong"].Width = 70;
			lsvCTHD.Columns["Gia"].Width = 80;
			lsvCTHD.Columns["ThanhTien"].Width = 100;
		}

		private void btnChonMon_Click(object sender, EventArgs e)
		{
			if (currentSelectedBan == null)
			{
				MessageBox.Show("Vui lòng chọn bàn trước khi chọn món.");
				return;
			}

			// Kiểm tra trạng thái bàn. Nếu đang sử dụng, tải món từ cơ sở dữ liệu
			if (currentSelectedBan.TrangThai == "Đang sử dụng")
			{
				LoadSelectedProductsFromDatabase(currentSelectedBan.MaBan);
			}
			else
			{
				selectedSanPhamList.Clear();
			}

			fMenuSelection fMenuSelection = new fMenuSelection();
			if (fMenuSelection.ShowDialog() == DialogResult.OK)
			{
				// Tạo danh sách tạm thời cho các món mới
				var sanPhamMoiList = new List<SanPham>();

				foreach (SanPham sanPham in selectedSanPhamList)
				{
					// Kiểm tra nếu món đã tồn tại trong cơ sở dữ liệu (hoặc `selectedSanPhamList`)
					var existingOrder = _orderDetailsBLL.GetOrderDetailsByTable(currentSelectedBan.MaBan)
										 .FirstOrDefault(od => od.ItemName == sanPham.TenSP);

					if (existingOrder == null)
					{
						// Nếu món chưa tồn tại, thêm vào danh sách tạm
						sanPhamMoiList.Add(sanPham);

						OrderDetails orderDetail = new OrderDetails
						{
							MaBan = currentSelectedBan.MaBan,
							ItemName = sanPham.TenSP,
							SoLuong = 1,
							DonGia = sanPham.Gia ?? 0
						};

						_orderDetailsBLL.AddOrderItem(orderDetail);
					}
				}

				// Thêm tất cả món mới từ danh sách tạm vào selectedSanPhamList
				selectedSanPhamList.AddRange(sanPhamMoiList);

				DisplaySelectedProducts(selectedSanPhamList);
				CapNhatTrangThaiBanThanhDSD();
				UpdateTongTien();
			}
		}

		private void LoadSelectedProductsFromDatabase(string maBan)
		{
			List<OrderDetails> orderDetailsList = _orderDetailsBLL.GetOrderDetailsByTable(maBan);

			// Cập nhật danh sách selectedSanPhamList từ dữ liệu đã lấy
			selectedSanPhamList.Clear();
			foreach (var orderDetail in orderDetailsList)
			{
				SanPham sanPham = new SanPham
				{
					TenSP = orderDetail.ItemName,
					Gia = orderDetail.DonGia
				};

				selectedSanPhamList.Add(sanPham);
			}
		}

		public void DisplaySelectedProducts(List<SanPham> selectedSanPhamList)
		{
			lsvCTHD.Items.Clear();

			foreach (SanPham sanPham in selectedSanPhamList)
			{
				bool exists = false;
				foreach (ListViewItem item in lsvCTHD.Items)
				{
					if (item.Text == sanPham.TenSP)
					{
						exists = true;
						break;
					}
				}

				if (!exists && sanPham != null && sanPham.Gia != null)
				{
					ListViewItem item = new ListViewItem(sanPham.TenSP);
					int soLuong = 1;
					item.SubItems.Add(soLuong.ToString());
					decimal thanhTien = (decimal)(sanPham.Gia * soLuong);
					item.SubItems.Add(sanPham.Gia.ToString());
					item.SubItems.Add(thanhTien.ToString());
					lsvCTHD.Items.Add(item);
				}
			}
		}

		private void CapNhatTrangThaiBanThanhDSD()
		{
			if (currentSelectedBan != null && currentSelectedBan.TrangThai == "Trống")
			{
				string newStatus = "Đang sử dụng";
				_banBLL.UpdateTrangThaiBan(currentSelectedBan.MaBan, newStatus);

				currentSelectedBan.TrangThai = newStatus;

				foreach (Button btn in flpTable.Controls)
				{
					Ban btnBan = (Ban)btn.Tag;
					if (btnBan.MaBan == currentSelectedBan.MaBan)
					{
						btn.Text = btnBan.TenBan + Environment.NewLine + newStatus;
						btn.BackColor = Color.LightCoral;
						break;
					}
				}
			}
		}

		public void CapNhatTrangThaiBanThanhTrong()
		{
			if (currentSelectedBan != null && currentSelectedBan.TrangThai == "Đang sử dụng")
			{
				string newStatus = "Trống";
				_banBLL.UpdateTrangThaiBan(currentSelectedBan.MaBan, newStatus);

				currentSelectedBan.TrangThai = newStatus;

				foreach (Button btn in flpTable.Controls)
				{
					Ban btnBan = (Ban)btn.Tag;
					if (btnBan.MaBan == currentSelectedBan.MaBan)
					{
						btn.Text = btnBan.TenBan + Environment.NewLine + newStatus;
						btn.BackColor = Color.LightGreen; 
						break;
					}
				}
			}
		}

		private void UpdateTongTien()
		{
			decimal totalAmount = 0;

			foreach (ListViewItem item in lsvCTHD.Items)
			{
				if (decimal.TryParse(item.SubItems[3].Text, out decimal itemTotal))
				{
					totalAmount += itemTotal;
				}
			}

			decimal discountPercentage = 0;
			if (decimal.TryParse(txtGiamGia.Text, out discountPercentage) && discountPercentage > 0)
			{
				decimal discountAmount = (totalAmount * discountPercentage) / 100;
				totalAmount -= discountAmount;
			}

			if (totalAmount < 0)
			{
				totalAmount = 0;
			}

			txtTongTien.Text = totalAmount.ToString("N2");
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

		private void QLCLVtripMenuItem_Click(object sender, EventArgs e)
		{
			fCaLamViec f = new fCaLamViec();
			this.Hide();
			f.ShowDialog();
			this.Show();
		}

		private void QLHDBtripMenuItem_Click(object sender, EventArgs e)
		{
			if (_currentUser != null)
			{
				NhanVien loggedInNhanVien = _nhanVienBLL.GetNhanVienByMaNV(_currentUser.MaNV);

				if (loggedInNhanVien != null)
				{
					fHoaDonBan f = new fHoaDonBan(loggedInNhanVien);
					this.Hide();
					f.ShowDialog();
					this.Show();
				}
				else
				{
					MessageBox.Show("Không tìm thấy thông tin nhân viên.");
				}
			}
			else
			{
				MessageBox.Show("Thông tin người dùng không hợp lệ.");
			}
		}

		private void đăngKýLịchLàmViệcToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (_currentUser != null)
			{
				NhanVien loggedInNhanVien = _nhanVienBLL.GetNhanVienByMaNV(_currentUser.MaNV);

				if (loggedInNhanVien != null)
				{
					ShiftRegister f = new ShiftRegister(loggedInNhanVien);
					this.Hide();
					f.ShowDialog();
					this.Show();
				}
				else
				{
					MessageBox.Show("Không tìm thấy thông tin nhân viên.");
				}
			}
			else
			{
				MessageBox.Show("Thông tin người dùng không hợp lệ.");
			}
		}

		private void quảnLýChiLịchLàmViệcCủaNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//if (_currentUser != null)
			//{
			//    NhanVien loggedInNhanVien = _nhanVienBLL.GetNhanVienByMaNV(_currentUser.MaNV);

			//    if (loggedInNhanVien != null)
			//    {
			fLichLamViec f = new fLichLamViec();
			this.Hide();
			f.ShowDialog();
			this.Show();
			//    }
			//    else
			//    {
			//        MessageBox.Show("Không tìm thấy thông tin nhân viên.");
			//    }
			//}
			//else
			//{
			//    MessageBox.Show("Thông tin người dùng không hợp lệ.");
			//}
		}

		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void BaoCaoDTToolStripMenuItem_Click(object sender, EventArgs e)
		{
			fBaoCaoDT f = new fBaoCaoDT();
			this.Hide();
			f.ShowDialog();
			this.Show();
		}

		private void btnChinhSua_Click(object sender, EventArgs e)
		{
			if (lsvCTHD.SelectedItems.Count > 0)
			{
				ListViewItem selectedItem = lsvCTHD.SelectedItems[0];

				int currentQuantity = Convert.ToInt32(selectedItem.SubItems[1].Text);

				string newQuantityStr = Interaction.InputBox("Nhập số lượng mới:", "Chỉnh sửa số lượng", currentQuantity.ToString());

				if (int.TryParse(newQuantityStr, out int newQuantity) && newQuantity > 0)
				{
					selectedItem.SubItems[1].Text = newQuantity.ToString();

					decimal price = Convert.ToDecimal(selectedItem.SubItems[2].Text);
					decimal total = newQuantity * price;
					selectedItem.SubItems[3].Text = total.ToString();

					UpdateTongTien();

					string itemName = selectedItem.Text;
					string maBan = currentSelectedBan.MaBan; 

					_orderDetailsBLL.UpdateOrderItem(maBan, itemName, newQuantity);
				}
				else
				{
					MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập một số nguyên dương.");
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn một món để chỉnh sửa.");
			}
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			if (lsvCTHD.SelectedItems.Count > 0)
			{
				if (MessageBox.Show("Bạn có chắc chắn muốn xóa món này?", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{

					ListViewItem selectedItem = lsvCTHD.SelectedItems[0];

					string itemName = selectedItem.Text;  
					string maBan = currentSelectedBan.MaBan;  

					_orderDetailsBLL.DeleteOrderItem(maBan, itemName);

					lsvCTHD.Items.Remove(selectedItem);

					UpdateTongTien();
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn một món để xóa.");
			}
		}

		private void txtGiamGia_TextChanged(object sender, EventArgs e)
		{
			UpdateTongTien();
		}

		private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != 8)
			{
				e.Handled = true;
			}

			if (e.KeyChar == '.' && txtGiamGia.Text.Contains("."))
			{
				e.Handled = true;
			}
		}

		private void btnHHD_Click(object sender, EventArgs e)
		{
			if (currentSelectedBan != null)
			{
				_orderDetailsBLL.DeleteOrderDetailsByTable(currentSelectedBan.MaBan);

				CapNhatTrangThaiBanThanhTrong();

				ResetForm();
			}
			else
			{
				MessageBox.Show("Vui lòng chọn bàn trước khi hủy hóa đơn.");
			}
		}

		public void ResetForm()
		{
			txtSDT.Clear();
			txtGiamGia.Text = "0";
			txtTongTien.Text = "0";
			txtKH.Clear();
			dtpNgayVao.Value = DateTime.Now;
			lsvCTHD.Items.Clear();
			selectedSanPhamList.Clear();
		}

		private void txtSDT_TextChanged(object sender, EventArgs e)
		{
			string sdt = txtSDT.Text;

			if (sdt.Length == 10 && sdt.All(char.IsDigit))
			{
				KhachHang khachHangList = _khachHangBLL.GetKhachHangBySDT(sdt);

				if (khachHangList != null && !string.IsNullOrEmpty(khachHangList.TenKH))
				{
					txtKH.Text = khachHangList.TenKH;
				}
				else
				{
					txtKH.Clear();

					if (DialogResult.Yes == MessageBox.Show("Số điện thoại chưa tồn tại. Bạn có muốn nhập khách hàng mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
					{
						string soDienThoai = txtSDT.Text;
						fNhapKH fNhapKH = new fNhapKH(soDienThoai);
						fNhapKH.ShowDialog();

						if (!string.IsNullOrEmpty(fNhapKH.TenKhachHang))
						{
							txtKH.Text = fNhapKH.TenKhachHang;
						}
					}
				}
			}
			else
			{
				txtKH.Clear();
			}
		}

		private void btnYCTT_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtKH.Text) ||
				string.IsNullOrWhiteSpace(txtSDT.Text) ||
				string.IsNullOrWhiteSpace(txtGiamGia.Text) ||
				string.IsNullOrWhiteSpace(txtTongTien.Text))
			{
				MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi tạo hóa đơn.");
				return;
			}

			decimal giamGia;
			decimal tongTien;

			if (!decimal.TryParse(txtGiamGia.Text, out giamGia) ||
				!decimal.TryParse(txtTongTien.Text, out tongTien))
			{
				MessageBox.Show("Vui lòng nhập số hợp lệ cho giảm giá và tổng tiền.");
				return; 
			}

			string tenBan = currentSelectedBan.TenBan;
			DateTime ngayBan = DateTime.Now;
			string tenNhanVien = _nhanVien.TenNV;
			string tenKhachHang = txtKH.Text;
			string soDienThoai = txtSDT.Text;

			HoaDonBan hoaDon = new HoaDonBan
			{
				MaBan = currentSelectedBan.MaBan,
				MaNV = _nhanVien.MaNV,
				NgayBan = ngayBan,
				TriGia = tongTien,
				MaKH = _khachHangBLL.GetKhachHangBySDT(soDienThoai).MaKH,
				ChiTietHoaDonBans = new List<ChiTietHoaDonBan>()
			};

			foreach (ListViewItem item in lsvCTHD.Items)
			{
				SanPham sanPham = selectedSanPhamList.FirstOrDefault(sp => sp.TenSP == item.Text);

				if (sanPham != null)
				{
					var chiTiet = new ChiTietHoaDonBan
					{
						MaSP = sanPham.MaSP,
						SLBan = Convert.ToInt32(item.SubItems[1].Text),
						ThanhTien = Convert.ToDecimal(item.SubItems[3].Text),
						KhuyenMai = giamGia.ToString()
					};

					hoaDon.ChiTietHoaDonBans.Add(chiTiet);
				}
			}

			_hoaDonBanBLL.AddHDB(hoaDon);

			var listViewItemsClone = new List<ListViewItem>();
			foreach (ListViewItem it in lsvCTHD.Items)
			{
				listViewItemsClone.Add((ListViewItem)it.Clone());
			}

			fChiTietHDB fChiTietHDB = new fChiTietHDB(tenBan, ngayBan, tenNhanVien, tenKhachHang, soDienThoai, giamGia, tongTien, listViewItemsClone);
			fChiTietHDB.ShowDialog();
		}
	}
}