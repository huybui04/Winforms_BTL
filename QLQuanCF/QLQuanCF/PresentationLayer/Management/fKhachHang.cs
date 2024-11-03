using QLQuanCF.BusinessLogicLayer;
using QLQuanCF.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QLQuanCF.PresentationLayer
{
    public partial class fKhachHang : Form
    {
        private KhachHangBLL _khachHangBLL;
        private ErrorProvider errorProvider = new ErrorProvider();
        private bool isAdding, isEditing;

        public fKhachHang()
        {
            InitializeComponent();
            _khachHangBLL = new KhachHangBLL(Classes.DbConfig.connectString);
            LoadKhachHangData();
            ShowDetail(false);
            SetButtonState(true, false, false, false, false);
        }

        private void LoadKhachHangData()
        {
            dataKhachHang.DataSource = _khachHangBLL.GetAllKhachHang();
        }

        private void ShowDetail(bool detail)
        {
            txtTenKH.Enabled = detail;
            txtDiaChiKH.Enabled = detail;
            txtDienThoaiKH.Enabled = detail;
        }

        private void ResetFlags()
        {
            isAdding = isEditing = false;
        }

        private void SetButtonState(bool add, bool edit, bool delete, bool save, bool cancel)
        {
            btnAddKH.Enabled = add;
            btnEditKH.Enabled = edit;
            btnDeleteKH.Enabled = delete;
            btnSaveKH.Enabled = save;
            btnCancelKH.Enabled = cancel;
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

            if (string.IsNullOrWhiteSpace(txtDiaChiKH.Text))
            {
                errorProvider.SetError(txtDiaChiKH, "Địa chỉ không được để trống!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtDienThoaiKH.Text) || !IsValidPhoneNumber(txtDienThoaiKH.Text))
            {
                errorProvider.SetError(txtDienThoaiKH, "Điện thoại không hợp lệ!");
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
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDiaChiKH.Clear();
            txtDienThoaiKH.Clear();
            txtSearchKH.Clear();
        }

        private void btnAddKH_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isAdding = true;
            txtTenKH.Focus();
        }

        private void btnDeleteKH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xóa khách hàng", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ResetFlags();
                _khachHangBLL.DeleteKhachHang(txtMaKH.Text);
                ClearInputFields();
                LoadKhachHangData();
                SetButtonState(true, false, false, false, false);
                ShowDetail(false);
                txtSearchKH.Focus();
            }
        }

        private void btnEditKH_Click(object sender, EventArgs e)
        {
            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isEditing = true;
        }

        private void btnSearchKH_Click(object sender, EventArgs e)
        {
			if (string.IsNullOrWhiteSpace(txtSearchKH.Text))
			{
				LoadKhachHangData(); return;
			}
			if (_khachHangBLL.GetKhachHangByName(txtSearchKH.Text).Count == 0)
			{
				MessageBox.Show("Không tìm thấy khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
            else
            {
				dataKhachHang.DataSource = _khachHangBLL.GetKhachHangByName(txtSearchKH.Text);
				SetButtonState(false, false, false, false, true);
				ShowDetail(false);
				ClearInputFields();
			}
		}

        private void btnCancelKH_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadKhachHangData();
            SetButtonState(true, false, false, false, false);
            ShowDetail(false);
        }

        private void btnSaveKH_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var khachHang = new KhachHang
            {
                MaKH = txtMaKH.Text,
                TenKH = txtTenKH.Text,
                DiaChi = txtDiaChiKH.Text,
                DienThoai = txtDienThoaiKH.Text
            };

            if (isAdding)
                _khachHangBLL.AddKhachHang(khachHang);
            else if (isEditing)
                _khachHangBLL.UpdateKhachHang(khachHang);

            ClearInputFields();
            LoadKhachHangData();
            SetButtonState(true, false, false, false, false);
            ShowDetail(false);
            ResetFlags();
            txtSearchKH.Focus();
        }

        private void dataKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider.Clear();
            ShowDetail(false);
            if (e.RowIndex >= 0)
            {
                txtMaKH.Text = dataKhachHang.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenKH.Text = dataKhachHang.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDiaChiKH.Text = dataKhachHang.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDienThoaiKH.Text = dataKhachHang.Rows[e.RowIndex].Cells[3].Value.ToString();
                SetButtonState(false, true, true, false, true);
            }
        }

        private void btnExitKH_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
