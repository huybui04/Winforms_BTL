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

        public fNhanVien()
        {
            InitializeComponent();
            _nhanVienBLL = new NhanVienBLL(Classes.DbConfig.connectString);
            LoadNhanVienData();
        }

        private void LoadNhanVienData()
        {
            var nhanVienList = _nhanVienBLL.GetAllNhanVien();
            dataNhanVien.DataSource = nhanVienList;
        }

        private void btnAddNV_Click(object sender, EventArgs e)
        {
            // Validate input before adding
            if (!ValidateInput())
            {
                return; // Stop execution if validation fails
            }

            var nhanVien = new NhanVien
            {
                MaCa = cbMaCa.Text,
                TenNV = txtTenNV.Text,
                ChucVu = cbChucVuNV.Text,
                GioiTinh = cbGioiTinhNV.Text,
                NgaySinh = dateNgaySinhNV.Value,
                DiaChi = txtDiaChiNV.Text,
                DienThoai = txtDienThoaiNV.Text
            };

            _nhanVienBLL.AddNhanVien(nhanVien);
            LoadNhanVienData();
            ClearInputFields();
        }

        private void btnUpdateNV_Click(object sender, EventArgs e)
        {
            // Validate input before updating
            if (!ValidateInput())
            {
                return; // Stop execution if validation fails
            }

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

            _nhanVienBLL.UpdateNhanVien(nhanVien);
            LoadNhanVienData();
            ClearInputFields();
        }

        private void btnDeleteNV_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            _nhanVienBLL.DeleteNhanVien(maNV);
            LoadNhanVienData();
            ClearInputFields();
        }

        private void btnSearchNV_Click(object sender, EventArgs e)
        {
            string tenNV = txtSearchNV.Text;
            var nhanVienList = _nhanVienBLL.GetNhanVienByName(tenNV);
            dataNhanVien.DataSource = nhanVienList;
        }

        private void btnCancelNV_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private bool ValidateInput()
        {
            bool isValid = true;

            // Clear previous errors
            errorProvider.Clear();

            // Validate TenNV
            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                errorProvider.SetError(txtTenNV, "Tên nhân viên không được để trống!");
                isValid = false;
            }

            // Validate DiaChi
            if (string.IsNullOrWhiteSpace(txtDiaChiNV.Text))
            {
                errorProvider.SetError(txtDiaChiNV, "Địa chỉ không được để trống!");
                isValid = false;
            }

            // Validate DienThoai
            if (string.IsNullOrWhiteSpace(txtDienThoaiNV.Text))
            {
                errorProvider.SetError(txtDienThoaiNV, "Điện thoại không được để trống!");
                isValid = false;
            }
            else if (!IsValidPhoneNumber(txtDienThoaiNV.Text))
            {
                errorProvider.SetError(txtDienThoaiNV, "Điện thoại không hợp lệ!");
                isValid = false;
            }

            // You can add more validations for other fields here
            return isValid;
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Implement phone number validation logic here
            // For example, check if it contains only digits and has the correct length
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
            dateNgaySinhNV.Value = DateTime.Now; // Reset to today's date
            txtDiaChiNV.Clear();
            txtDienThoaiNV.Clear();
        }

        private void dataGridViewNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (dataNhanVien.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataNhanVien.SelectedRows[0];
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                cbMaCa.Text = row.Cells["MaCa"].Value.ToString();
                txtTenNV.Text = row.Cells["TenNV"].Value.ToString();
                cbChucVuNV.Text = row.Cells["ChucVu"].Value.ToString();
                cbGioiTinhNV.Text = row.Cells["GioiTinh"].Value.ToString();
                dateNgaySinhNV.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                txtDiaChiNV.Text = row.Cells["DiaChi"].Value.ToString();
                txtDienThoaiNV.Text = row.Cells["DienThoai"].Value.ToString();
            }
        }
    }
}
