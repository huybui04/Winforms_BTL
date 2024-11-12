using OfficeOpenXml;
using QLQuanCF.BusinessLogicLayer;
using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace QLQuanCF.PresentationLayer
{
	public partial class fChiTietHDB : Form
	{
		private HoaDonBanBLL _hoaDonBanBLL = new HoaDonBanBLL(Classes.DbConfig.connectString);
		private BanBLL _BanBLL = new BanBLL(Classes.DbConfig.connectString);
		private OrderDetailsBLL _orderDetailsBLL = new OrderDetailsBLL(Classes.DbConfig.connectString);
		public fChiTietHDB(string ban, DateTime ngayBan, string tenNhanVien,
		string tenKhachHang, string soDienThoai, decimal giamGia, decimal tongTien, List<ListViewItem> items)
		{
			InitializeComponent();

			lblMaHDB.Text = _hoaDonBanBLL.GetLastMaHDB();
			lblTenBan.Text = ban;
			lblNgayBan.Text = ngayBan.ToString("dd/MM/yyyy");
			lblTenNV.Text = tenNhanVien;
			lblTenKH.Text = tenKhachHang;
			lblSDTKH.Text = soDienThoai;
			txtGiamGia.Text = giamGia.ToString();
			txtTongTien.Text = tongTien.ToString();

			if (lsvCTHD.Columns.Count == 0)
			{
				lsvCTHD.Columns.Add("Tên Sản Phẩm", 120);
				lsvCTHD.Columns.Add("Số Lượng", 70);
				lsvCTHD.Columns.Add("Đơn Giá", 80); 
				lsvCTHD.Columns.Add("Thành Tiền", 100); 
			}

			foreach (var item in items)
			{
				lsvCTHD.Items.Add((ListViewItem)item.Clone());
			}
		}

		private void btnThanhToan_Click(object sender, EventArgs e)
		{
			List<Ban> _banList = _BanBLL.GetBanByName(lblTenBan.Text);

			if (_banList.Count > 0)
			{
				string maBan = _banList[0].MaBan;
				_orderDetailsBLL.DeleteOrderDetailsByTable(maBan);

				SaveInvoiceToDatabase();
				ExportInvoiceToExcel();
			}

			this.Close();
		}

		private void SaveInvoiceToDatabase()
		{
			var mainForm = (fMain)Application.OpenForms["fMain"];
			if (mainForm != null)
			{
				mainForm.ResetForm();
				mainForm.CapNhatTrangThaiBanThanhTrong();
			}
		}

		private void ExportInvoiceToExcel()
		{
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			using (ExcelPackage package = new ExcelPackage())
			{
				// Tạo sheet mới
				ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Hóa Đơn");

				// Ghi thông tin vào các ô (Thông tin cơ bản về hóa đơn)
				worksheet.Cells[1, 2].Value = "HÓA ĐƠN BÁN HÀNG";
				worksheet.Cells[3, 1].Value = "Mã Hóa Đơn";
				worksheet.Cells[3, 3].Value = lblMaHDB.Text;
				worksheet.Cells[4, 1].Value = "Bàn";
				worksheet.Cells[4, 3].Value = lblTenBan.Text;
				worksheet.Cells[5, 1].Value = "Ngày Bán";
				worksheet.Cells[5, 3].Value = lblNgayBan.Text;
				worksheet.Cells[6, 1].Value = "Tên Nhân Viên";
				worksheet.Cells[6, 3].Value = lblTenNV.Text;
				worksheet.Cells[7, 1].Value = "Tên Khách Hàng";
				worksheet.Cells[7, 3].Value = lblTenKH.Text;
				worksheet.Cells[8, 1].Value = "Số Điện Thoại";
				worksheet.Cells[8, 3].Value = lblSDTKH.Text;

				// Thêm danh sách món vào Excel
				worksheet.Cells[10, 1].Value = "Tên Món";
				worksheet.Cells[10, 2].Value = "Số Lượng";
				worksheet.Cells[10, 3].Value = "Đơn Giá";
				worksheet.Cells[10, 4].Value = "Thành Tiền";

				decimal totalBeforeDiscount = 0; // Tổng tiền trước giảm giá
				int row = 11; 
				foreach (ListViewItem item in lsvCTHD.Items)
				{
					decimal donGia;
					int soLuong;
					decimal thanhTien;

					if (decimal.TryParse(item.SubItems[2].Text, out donGia) && int.TryParse(item.SubItems[1].Text, out soLuong))
					{
						thanhTien = donGia * soLuong;
						totalBeforeDiscount += thanhTien;

						worksheet.Cells[row, 1].Value = item.SubItems[0].Text;
						worksheet.Cells[row, 2].Value = soLuong;
						worksheet.Cells[row, 3].Value = donGia;
						worksheet.Cells[row, 4].Value = thanhTien;
						row++;
					}
					else
					{
						MessageBox.Show("Dữ liệu không hợp lệ trong danh sách chi tiết hóa đơn.");
						return;
					}
				}

				decimal giamGia;
				if (!decimal.TryParse(txtGiamGia.Text, out giamGia))
				{
					MessageBox.Show("Giảm giá không hợp lệ.");
					return;
				}

				decimal totalAfterDiscount = totalBeforeDiscount - (totalBeforeDiscount * giamGia / 100);

				worksheet.Cells[row, 3].Value = "Giảm Giá";
				worksheet.Cells[row, 4].Value = giamGia + "%";

				worksheet.Cells[row + 1, 3].Value = "Tổng Tiền Sau Giảm Giá";
				worksheet.Cells[row + 1, 4].Value = totalAfterDiscount;

				var fileInfo = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Invoice_" + lblMaHDB.Text + ".xlsx"));
				package.SaveAs(fileInfo);
			}

			MessageBox.Show("Hóa đơn đã được xuất ra Excel!");
		}

		private void btnHuy_Click(object sender, EventArgs e)
		{
			var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn hủy hóa đơn này không?",
													"Xác nhận hủy hóa đơn",
													MessageBoxButtons.YesNo);
			if (confirmResult == DialogResult.Yes)
			{
				_hoaDonBanBLL.DeleteHDB(lblMaHDB.Text);
			}
			this.Close();
		}
	}
}
