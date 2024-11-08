using QLQuanCF.BusinessLogicLayer;
using QLQuanCF.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QLQuanCF
{
    public partial class fNhanVien : Form
    {
        private NhanVienBLL _nhanVienBLL;
        private ErrorProvider errorProvider = new ErrorProvider();
        private bool isAdding, isEditing;

        public fNhanVien()
        {
            InitializeComponent();
            _nhanVienBLL = new NhanVienBLL(Classes.DbConfig.connectString);
            LoadNhanVienData();
            LoadComboBoxData();
            ShowDetail(false);
            SetButtonState(true, false, false, false, false);
        }

        private void LoadNhanVienData()
        {
            dataNhanVien.DataSource = _nhanVienBLL.GetAllNhanVien();
        }

        private void LoadComboBoxData()
        {
            cbMaCa.DataSource = _nhanVienBLL.GetCaLamViecList();
            cbChucVuNV.DataSource = new object[] { "Quản lý", "Nhân viên" };
            cbGioiTinhNV.DataSource = new object[] { "Nam", "Nữ" };
            cbChucVuNV.SelectedIndex = cbGioiTinhNV.SelectedIndex = cbMaCa.SelectedIndex = -1;
		}

        private void ShowDetail(bool detail)
        {
            txtTenNV.Enabled = detail;
            txtDiaChiNV.Enabled = detail;
            txtDienThoaiNV.Enabled = detail;
            cbMaCa.Enabled = detail;
            cbChucVuNV.Enabled = detail;
            cbGioiTinhNV.Enabled = detail;
            dateNgaySinhNV.Enabled = detail;
        }

        private void ResetFlags()
        {
            isAdding = isEditing = false;
        }

        private void SetButtonState(bool add, bool edit, bool delete, bool save, bool cancel)
        {
            btnAddNV.Enabled = add;
            btnEditNV.Enabled = edit;
            btnDeleteNV.Enabled = delete;
            btnSaveNV.Enabled = save;
            btnCancelNV.Enabled = cancel;
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

            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                errorProvider.SetError(txtTenNV, "Tên nhân viên không được để trống!");
                isValid = false;
            }

            if(string.IsNullOrWhiteSpace(cbChucVuNV.Text))
            {
                errorProvider.SetError(cbChucVuNV, "Chức vụ không được để trống!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(cbGioiTinhNV.Text))
            {
                errorProvider.SetError(cbGioiTinhNV, "Giới tính không được để trống!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChiNV.Text))
            {
                errorProvider.SetError(txtDiaChiNV, "Địa chỉ không được để trống!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtDienThoaiNV.Text) || !IsValidPhoneNumber(txtDienThoaiNV.Text))
            {
                errorProvider.SetError(txtDienThoaiNV, "Điện thoại không hợp lệ!");
                isValid = false;
            }

            return isValid;
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.All(char.IsDigit) && phoneNumber.Length >= 10;
        }

        private void ClearInputFields()
        {
            errorProvider.Clear();
            txtMaNV.Clear();
            cbMaCa.SelectedIndex = -1;
            txtTenNV.Clear();
            cbChucVuNV.SelectedIndex = -1;
            cbGioiTinhNV.SelectedIndex = -1;
            dateNgaySinhNV.Value = DateTime.Now;
            txtDiaChiNV.Clear();
            txtDienThoaiNV.Clear();
            txtSearchNV.Clear();
        }

        private void btnAddNV_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isAdding = true;
            cbMaCa.Focus();
        }

        private void btnEditNV_Click(object sender, EventArgs e)
        {
            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isEditing = true;
        }

        private void btnDeleteNV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xóa nhân viên", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ResetFlags();
                _nhanVienBLL.DeleteNhanVien(txtMaNV.Text);
                ClearInputFields();
                LoadNhanVienData();
                SetButtonState(true, false, false, false, false);
                ShowDetail(false);
                txtSearchNV.Focus();
            }
        }

        private void btnSearchNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchNV.Text))
            {
				LoadNhanVienData(); return;
			}
            if(_nhanVienBLL.GetNhanVienByName(txtSearchNV.Text).Count == 0)
			{
				MessageBox.Show("Không tìm thấy nhân viên nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
            else
			{
				dataNhanVien.DataSource = _nhanVienBLL.GetNhanVienByName(txtSearchNV.Text);
				SetButtonState(false, false, false, false, true);
				ShowDetail(false);
				ClearInputFields();
			}
		}

        private void btnCancelNV_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadNhanVienData();
            SetButtonState(true, false, false, false, false);
            ShowDetail(false);
        }

        private void btnSaveNV_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var nhanVien = new NhanVien
            {
                MaNV = txtMaNV.Text,
                MaCa = cbMaCa.Text,
                TenNV = txtTenNV.Text,
                ChucVu = cbChucVuNV.Text,
                GioiTinh = cbGioiTinhNV.Text,
                NgaySinh = dateNgaySinhNV.Value,
                DiaChi = txtDiaChiNV.Text,
                DienThoai = txtDienThoaiNV.Text
            };

            if (isAdding)
                _nhanVienBLL.AddNhanVien(nhanVien);
            else if (isEditing)
                _nhanVienBLL.UpdateNhanVien(nhanVien);

            ClearInputFields();
            LoadNhanVienData();
            SetButtonState(true, false, false, false, false);
            ShowDetail(false);
            ResetFlags();
            txtSearchNV.Focus();
        }

        private void dataNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider.Clear();
            ShowDetail(false);
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                cbMaCa.Text = row.Cells["MaCa"].Value.ToString();
                txtTenNV.Text = row.Cells["TenNV"].Value.ToString();
                cbChucVuNV.Text = row.Cells["ChucVu"].Value.ToString();
                cbGioiTinhNV.Text = row.Cells["GioiTinh"].Value.ToString();
                dateNgaySinhNV.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                txtDiaChiNV.Text = row.Cells["DiaChi"].Value.ToString();
                txtDienThoaiNV.Text = row.Cells["DienThoai"].Value.ToString();
                SetButtonState(false, true, true, false, true);
            }
        }

        private void btnExitNV_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
