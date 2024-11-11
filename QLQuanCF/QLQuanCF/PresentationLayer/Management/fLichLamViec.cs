using QLQuanCF.BusinessLogicLayer;
using QLQuanCF.DataAccessLayer;
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

namespace QLQuanCF.PresentationLayer.Management
{
	public partial class fLichLamViec : Form
	{
		private ChiTietLuongBLL chiTietLuongBLL;
		private CaLamViecBLL caLamViecBLL;
		private NhanVienBLL nhanVienBLL;

		private ErrorProvider errorProvider = new ErrorProvider();
		private bool isAdding, isEditing;
		private ChiTietLuong tmpChiTietLuong;

		public fLichLamViec()
		{
			InitializeComponent();


			caLamViecBLL = new CaLamViecBLL(Classes.DbConfig.connectString);
			nhanVienBLL = new NhanVienBLL(Classes.DbConfig.connectString);
			chiTietLuongBLL = new ChiTietLuongBLL(Classes.DbConfig.connectString);

			ShowDetail(false);
			SetButtonState(true, false, false, false, false);
		}

		private void fLichLamViec_Load(object sender, EventArgs e)
		{
			txtTenCa.Enabled = false;
			txtTenNV.Enabled = false;

			ClearInputFields();
			LoadCaLamViec();
			LoadNhanVien();
		}

		private void LoadCaLamViec()
		{
			cbMaCa.DataSource = caLamViecBLL.GetAllCaLamViec();
			cbMaCa.DisplayMember = "MaCa";
			cbMaCa.ValueMember = "MaCa";
			cbMaCa.SelectedIndex = -1;
		}

		private void LoadNhanVien()
		{
			cbMaNV.DataSource = nhanVienBLL.GetAllNhanVien();
			cbMaNV.DisplayMember = "MaNV";
			cbMaNV.ValueMember = "MaNV";
			cbMaNV.SelectedIndex = -1;

			//load search
			cbSearch.DataSource = nhanVienBLL.GetAllNhanVien();
			cbSearch.DisplayMember = "MaNV";
			cbSearch.ValueMember = "MaNV";
			cbSearch.SelectedIndex = -1;
		}

		private void LoadData()
		{
			dataLichLamViec.DataSource = chiTietLuongBLL.GetAllChiTietLuong();
		}

		private void LoadDataByDate(DateTime date)
		{
			dataLichLamViec.DataSource = chiTietLuongBLL.GetChiTietLuongByDate(date);
		}

		private void ShowDetail(bool detail)
		{
			cbMaNV.Enabled = detail;
			cbMaCa.Enabled = detail;
		}

		private void ResetFlags()
		{
			isAdding = isEditing = false;
		}

		private void SetButtonState(bool add, bool edit, bool delete, bool save, bool cancel)
		{
			btnAdd.Enabled = add;
			btnEdit.Enabled = edit;
			btnDelete.Enabled = delete;
			btnSave.Enabled = save;
			btnCancel.Enabled = cancel;
		}

		private bool ValidateInput()
		{
			bool isValid = true;
			errorProvider.Clear();

			if (string.IsNullOrWhiteSpace(cbMaCa.Text))
			{
				errorProvider.SetError(cbMaCa, "Mã ca không được để trống!");
				isValid = false;
			}

			if (string.IsNullOrWhiteSpace(cbMaNV.Text))
			{
				errorProvider.SetError(txtTenNV, "Mã nhân viên không được để trống!");
				isValid = false;
			}

			return isValid;
		}

		private void ClearInputFields()
		{
			errorProvider.Clear();
			cbMaNV.SelectedIndex = -1;
			cbMaCa.SelectedIndex = -1;
			txtTenNV.Clear();
			txtTenCa.Clear();
			//dateNgayDK.Value = DateTime.Now;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			ClearInputFields();
			ShowDetail(true);
			SetButtonState(false, false, false, true, true);
			ResetFlags();
			isAdding = true;
			cbMaNV.Focus();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show($"Bạn có chắc chắn muốn xóa ca làm việc {cbMaCa.Text} của nhân viên {cbMaNV.Text} không?", "Xóa lịch làm việc", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				ResetFlags();
				chiTietLuongBLL.DeleteChiTietLuong(cbMaNV.Text, cbMaCa.Text, dateNgayDK.Value);
				ClearInputFields();
				LoadDataByDate(dateNgayDK.Value);
				SetButtonState(true, false, false, false, false);
				ShowDetail(false);
				cbSearch.Focus();
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			ShowDetail(true);
			SetButtonState(false, false, false, true, true);
			ResetFlags();
			isEditing = true;
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			ClearInputFields();
			LoadDataByDate(dateNgayDK.Value);
			SetButtonState(true, false, false, false, false);
			ShowDetail(false);
		}

		//tim lich lam viec theo ma nhan vien 
		private void btnSearch_Click(object sender, EventArgs e)
		{
			MessageBox.Show(cbSearch.Text);
			if (string.IsNullOrWhiteSpace(cbSearch.Text))
			{
				MessageBox.Show($"Không tìm thấy lịch làm việc nào cho nhân viên có mã {cbMaNV.Text}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				//LoadData();
				return;
			}
			if (chiTietLuongBLL.GetChiTietLuongByMaNV(cbSearch.Text).Count == 0)
			{
				MessageBox.Show($"Không tìm thấy lịch làm việc nào cho nhân viên có mã {cbMaNV.Text}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			else
			{
				dataLichLamViec.DataSource = chiTietLuongBLL.GetChiTietLuongByMaNV(cbSearch.Text);
				SetButtonState(false, false, false, false, true);
				ShowDetail(false);
				ClearInputFields();
			}
		}

		private void dateNgayDK_ValueChanged(object sender, EventArgs e)
		{
			DateTime selectedDate = dateNgayDK.Value;

			dataLichLamViec.DataSource = chiTietLuongBLL.GetChiTietLuongByDate(selectedDate); ;
		}

		private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbMaNV.SelectedIndex != -1)
			{
				//ep kieu ve nv do ban dau load obj nv vao cbMaNV
				txtTenNV.Text = ((NhanVien)cbMaNV.SelectedItem).TenNV;
			}
		}

		private void cbMaCa_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbMaCa.SelectedIndex != -1)
			{
				txtTenCa.Text = ((CaLamViec)cbMaCa.SelectedItem).TenCa;
			}
		}

		private void btnSaveHDB_Click(object sender, EventArgs e)
		{
			if (!ValidateInput()) return;

			var newChiTietLuong = new ChiTietLuong
			{
				MaNV = cbMaNV.Text,
				MaCa = cbMaCa.Text,
				Ngay = dateNgayDK.Value,
			};

			if (isAdding)
				chiTietLuongBLL.AddChiTietLuong(newChiTietLuong);
			else if (isEditing)
				chiTietLuongBLL.UpdateChiTietLuong(tmpChiTietLuong, newChiTietLuong);

			ClearInputFields();
			LoadDataByDate(dateNgayDK.Value);
			SetButtonState(true, false, false, false, false);
			ShowDetail(false);
			ResetFlags();
			cbSearch.Focus();
		}

		private void dataLichLamViec_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			errorProvider.Clear();
			ShowDetail(false);
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dataLichLamViec.Rows[e.RowIndex];
				cbMaNV.Text = row.Cells["MaNV"].Value.ToString();
				cbMaCa.Text = row.Cells["MaCa"].Value.ToString();
				dateNgayDK.Value = Convert.ToDateTime(row.Cells["Ngay"].Value);
				SetButtonState(false, true, true, false, true);

				tmpChiTietLuong = new ChiTietLuong
				{
					MaNV = cbMaNV.Text,
					MaCa = cbMaCa.Text,
					Ngay = dateNgayDK.Value
				};
			}
		}
	}
}
