using QLQuanCF.BusinessLogicLayer;
using QLQuanCF.Models;
using System;
using System.Windows.Forms;

namespace QLQuanCF.PresentationLayer
{
    public partial class fNguyenLieu : Form
    {
        private NguyenLieuBLL _nguyenLieuBLL;
        private ErrorProvider errorProvider = new ErrorProvider();
        private bool isAdding, isEditing;

        public fNguyenLieu()
        {
            InitializeComponent();
            _nguyenLieuBLL = new NguyenLieuBLL(Classes.DbConfig.connectString);
            LoadNguyenLieuData();
            ShowDetail(false);
            SetButtonState(true, false, false, false, false);
        }

        private void LoadNguyenLieuData()
        {
            dataNL.DataSource = _nguyenLieuBLL.GetAllNguyenLieu();
        }

        private void ShowDetail(bool detail)
        {
            txtTenNL.Enabled = detail;
            txtDVNL.Enabled = detail;
            txtGiaNL.Enabled = detail;
            nupSLNL.Enabled = detail;
            dtpNSXNL.Enabled = detail;
            dtpHSDNL.Enabled = detail;
        }

        private void ResetFlags()
        {
            isAdding = isEditing = false;
        }

        private void SetButtonState(bool add, bool edit, bool delete, bool save, bool cancel)
        {
            btnAddNL.Enabled = add;
            btnEditNL.Enabled = edit;
            btnDeleteNL.Enabled = delete;
            btnSaveNL.Enabled = save;
            btnCancelNL.Enabled = cancel;
        }

        private bool ValidateInput()
        {
            bool isValid = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtTenNL.Text))
            {
                errorProvider.SetError(txtTenNL, "Tên nguyên liệu không được để trống!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtDVNL.Text))
            {
                errorProvider.SetError(txtDVNL, "Đơn vị không được để trống!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtGiaNL.Text) || !decimal.TryParse(txtGiaNL.Text, out decimal gia) || gia < 0)
            {
                errorProvider.SetError(txtGiaNL, "Giá không hợp lệ!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(nupSLNL.Text) || !int.TryParse(nupSLNL.Text, out int soLuong) || soLuong < 0)
            {
                errorProvider.SetError(nupSLNL, "Số lượng không hợp lệ!");
                isValid = false;
            }

            if (dtpNSXNL.Value > DateTime.Now)
            {
                errorProvider.SetError(dtpNSXNL, "Ngày sản xuất không hợp lệ!");
                isValid = false;
            }

            if (dtpHSDNL.Value < dtpNSXNL.Value)
            {
                errorProvider.SetError(dtpHSDNL, "Hạn sử dụng không hợp lệ!");
                isValid = false;
            }

            return isValid;
        }

        private void ClearInputFields()
        {
            errorProvider.Clear();
            txtMaNL.Clear();
            txtTenNL.Clear();
            txtDVNL.Clear();
            txtGiaNL.Clear();
            nupSLNL.Value = 0;
            dtpNSXNL.Value = DateTime.Now;
            dtpHSDNL.Value = DateTime.Now;
            txtSearchNL.Clear();
        }
        private void btnAddNL_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isAdding = true;
            txtTenNL.Focus();
        }

        private void btnEditNL_Click(object sender, EventArgs e)
        {
            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isEditing = true;
        }

        private void btnDeleteNL_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nguyên liệu này không?", "Xóa nguyên liệu", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ResetFlags();
                _nguyenLieuBLL.DeleteNguyenLieu(txtMaNL.Text);
                ClearInputFields();
                LoadNguyenLieuData();
                SetButtonState(true, false, false, false, false);
                ShowDetail(false);
                txtSearchNL.Focus();
            }
        }

        private void btnSearchNL_Click(object sender, EventArgs e)
        {
			if (string.IsNullOrWhiteSpace(txtSearchNL.Text))
			{
				LoadNguyenLieuData(); return;
			}
            if(_nguyenLieuBLL.SearchNguyenLieu(txtSearchNL.Text).Count == 0)
			{
				MessageBox.Show("Không tìm thấy nguyên liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
            else
            {
				dataNL.DataSource = _nguyenLieuBLL.SearchNguyenLieu(txtSearchNL.Text);
				SetButtonState(false, false, false, false, true);
				ShowDetail(false);
				ClearInputFields();
			}
		}

        private void btnCancelNL_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadNguyenLieuData();
            SetButtonState(true, false, false, false, false);
            ShowDetail(false);
        }

        private void btnSaveNL_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var nguyenLieu = new NguyenLieu
            {
                MaNL = txtMaNL.Text,
                TenNL = txtTenNL.Text,
                DonVi = txtDVNL.Text,
                Gia = decimal.Parse(txtGiaNL.Text),
                SoLuong = (int)nupSLNL.Value,
                NgaySanXuat = dtpNSXNL.Value,
                HanSuDung = dtpHSDNL.Value
            };

            if (isAdding)
                _nguyenLieuBLL.AddNguyenLieu(nguyenLieu);
            else if (isEditing)
                _nguyenLieuBLL.UpdateNguyenLieu(nguyenLieu);

            ClearInputFields();
            LoadNguyenLieuData();
            SetButtonState(true, false, false, false, false);
            ShowDetail(false);
            ResetFlags();
            txtSearchNL.Focus();
        }

        private void dataNL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider.Clear();
            ShowDetail(false);
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataNL.Rows[e.RowIndex];
                txtMaNL.Text = row.Cells["MaNL"].Value.ToString();
                txtTenNL.Text = row.Cells["TenNL"].Value.ToString();
                txtDVNL.Text = row.Cells["DonVi"].Value.ToString();
                txtGiaNL.Text = row.Cells["Gia"].Value.ToString();
                nupSLNL.Value = Convert.ToDecimal(row.Cells["SoLuong"].Value);
                dtpNSXNL.Value = Convert.ToDateTime(row.Cells["NgaySanXuat"].Value);
                dtpHSDNL.Value = Convert.ToDateTime(row.Cells["HanSuDung"].Value);
                SetButtonState(false, true, true, false, true);
            }
        }

        private void btnExitNL_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
