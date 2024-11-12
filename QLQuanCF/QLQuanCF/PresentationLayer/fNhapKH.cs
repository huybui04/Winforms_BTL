using QLQuanCF.BusinessLogicLayer;
using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanCF.PresentationLayer
{
	public partial class fNhapKH : Form
	{
		private ErrorProvider errorProvider = new ErrorProvider();
		private KhachHangBLL _khachHangBLL = new KhachHangBLL(Classes.DbConfig.connectString);

		public string TenKhachHang { get; private set; }
		public fNhapKH(string soDienThoai)
		{
			InitializeComponent();
			txtSDT.Text = soDienThoai;
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			if(!ValidateInput()) return;
			var khachHang = new KhachHang
			{
				TenKH = txtTenKH.Text,
				DiaChi = txtDiaChi.Text,
				DienThoai = txtSDT.Text
			};

			_khachHangBLL.AddKhachHang(khachHang);
			TenKhachHang = khachHang.TenKH;
			MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			this.Close();
		}

		private bool ValidateInput()
		{
			bool isValid = true;
			errorProvider.Clear();

			if (string.IsNullOrWhiteSpace(txtTenKH.Text))
			{
				errorProvider.SetError(txtTenKH, "Tên khách hàng không được để trống!");
				isValid = false;
			}

			if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
			{
				errorProvider.SetError(txtDiaChi, "Địa chỉ không được để trống!");
				isValid = false;
			}

			return isValid;
		}
	}
}
