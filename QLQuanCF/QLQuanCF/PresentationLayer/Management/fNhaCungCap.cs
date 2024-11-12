using QLQuanCF.BusinessLogicLayer;
using QLQuanCF.Models;
using System;
using System.Windows.Forms;

namespace QLQuanCF.PresentationLayer
{
    public partial class fNhaCungCap : Form
    {
        private NhaCungCapBLL _nhaCungCapBLL;
        private ErrorProvider errorProvider = new ErrorProvider();
        private bool isAdding, isEditing;

        public fNhaCungCap()
        {
            InitializeComponent();
            _nhaCungCapBLL = new NhaCungCapBLL(Classes.DbConfig.connectString);
            LoadNhaCungCapData();
            ShowDetail(false);
            SetButtonState(true, false, false, false, false);
        }
        private void LoadNhaCungCapData()
        {
            dataNCC.DataSource = _nhaCungCapBLL.GetAllNhaCungCap();
        }

        private void ShowDetail(bool detail)
        {
            txtTenNCC.Enabled = detail;
            txtDiaChiNCC.Enabled = detail;
        }

        private void ResetFlags()
        {
            isAdding = isEditing = false;
        }

        private void SetButtonState(bool add, bool edit, bool delete, bool save, bool cancel)
        {
            btnAddNCC.Enabled = add;
            btnEditNCC.Enabled = edit;
            btnDeleteNCC.Enabled = delete;
            btnSaveNCC.Enabled = save;
            btnCancelNCC.Enabled = cancel;
        }

        private bool ValidateInput()
        {
            bool isValid = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                errorProvider.SetError(txtTenNCC, "Tên nhà cung cấp không được để trống!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChiNCC.Text))
            {
                errorProvider.SetError(txtDiaChiNCC, "Địa chỉ không được để trống!");
                isValid = false;
            }

            return isValid;
        }

        private void ClearInputFields()
        {
            errorProvider.Clear();
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChiNCC.Clear();
            txtSearchNCC.Clear();
        }

        private void btnAddNCC_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isAdding = true;
            txtTenNCC.Focus();
        }

        private void btnDeleteNCC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này không?", "Xóa nhà cung cấp", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ResetFlags();
                _nhaCungCapBLL.DeleteNhaCungCap(txtMaNCC.Text);
                ClearInputFields();
                LoadNhaCungCapData();
                SetButtonState(true, false, false, false, false);
                ShowDetail(false);
                txtSearchNCC.Focus();
            }
        }

        private void btnEditNCC_Click(object sender, EventArgs e)
        {
            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isEditing = true;
        }

        private void btnSearchNCC_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtSearchNCC.Text))
			{
				LoadNhaCungCapData(); return;
			}
            if(_nhaCungCapBLL.GetNhaCungCapByName(txtSearchNCC.Text).Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
            else
            {
				dataNCC.DataSource = _nhaCungCapBLL.GetNhaCungCapByName(txtSearchNCC.Text);
				SetButtonState(false, false, false, false, true);
				ShowDetail(false);
				ClearInputFields();
			}
		}

        private void btnCancelNCC_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadNhaCungCapData();
            SetButtonState(true, false, false, false, false);
            ShowDetail(false);
        }

        private void btnSaveNCC_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var nhaCungCap = new NhaCungCap
            {
                MaNCC = txtMaNCC.Text,
                TenNCC = txtTenNCC.Text,
                DiaChi = txtDiaChiNCC.Text
            };

            if (isAdding)
                _nhaCungCapBLL.AddNhaCungCap(nhaCungCap);
            else if (isEditing)
                _nhaCungCapBLL.UpdateNhaCungCap(nhaCungCap);

            ClearInputFields();
            LoadNhaCungCapData();
            SetButtonState(true, false, false, false, false);
            ShowDetail(false);
            ResetFlags();
            txtSearchNCC.Focus();
        }

        private void dataNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider.Clear();
            ShowDetail(false);
            if (e.RowIndex >= 0)
            {
                txtMaNCC.Text = dataNCC.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenNCC.Text = dataNCC.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDiaChiNCC.Text = dataNCC.Rows[e.RowIndex].Cells[2].Value.ToString();
                SetButtonState(false, true, true, false, true);
            }
        }

        private void btnExitNCC_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}