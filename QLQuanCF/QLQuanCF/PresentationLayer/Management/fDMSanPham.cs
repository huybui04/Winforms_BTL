using QLQuanCF.BusinessLogicLayer;
using QLQuanCF.Models;
using System;
using System.Windows.Forms;

namespace QLQuanCF.PresentationLayer
{
    public partial class fDMSanPham : Form
    {
        private DMSanPhamBLL _danhMucSanPhamBLL;
        private ErrorProvider errorProvider = new ErrorProvider();
        private bool isAdding, isEditing;

        public fDMSanPham()
        {
            InitializeComponent();
            _danhMucSanPhamBLL = new DMSanPhamBLL(Classes.DbConfig.connectString);
            LoadDanhMucData();
            ShowDetail(false);
            SetButtonState(true, false, false, false, false);
        }
        private void LoadDanhMucData()
        {
            dataDMSP.DataSource = _danhMucSanPhamBLL.GetAllDanhMucSanPham();
        }

        private void ShowDetail(bool detail)
        {
            txtTenDMSP.Enabled = detail;
        }

        private void ResetFlags()
        {
            isAdding = isEditing = false;
        }

        private void SetButtonState(bool add, bool edit, bool delete, bool save, bool cancel)
        {
            btnAddDMSP.Enabled = add;
            btnEditDMSP.Enabled = edit;
            btnDeleteDMSP.Enabled = delete;
            btnSaveDMSP.Enabled = save;
            btnCancelDMSP.Enabled = cancel;
        }

        private bool ValidateInput()
        {
            bool isValid = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtTenDMSP.Text))
            {
                errorProvider.SetError(txtTenDMSP, "Tên danh mục không được để trống!");
                isValid = false;
            }

            return isValid;
        }

        private void ClearInputFields()
        {
            errorProvider.Clear();
            txtMaDMSP.Clear();
            txtTenDMSP.Clear();
            txtSearchDMSP.Clear();
        }

        private void btnAddDM_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isAdding = true;
            txtTenDMSP.Focus();
        }

        private void btnDeleteDM_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này không?", "Xóa danh mục", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ResetFlags();
                _danhMucSanPhamBLL.DeleteDanhMucSanPham(txtMaDMSP.Text);
                ClearInputFields();
                LoadDanhMucData();
                SetButtonState(true, false, false, false, false);
                ShowDetail(false);
                txtSearchDMSP.Focus();
            }
        }

        private void btnEditDM_Click(object sender, EventArgs e)
        {
            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isEditing = true;
        }

        private void btnSearchDM_Click(object sender, EventArgs e)
        {
			if (string.IsNullOrWhiteSpace(txtSearchDMSP.Text))
            {
                LoadDanhMucData(); return;
			}
			if (_danhMucSanPhamBLL.GetDanhMucSanPhamByName(txtSearchDMSP.Text).Count == 0)
			{
				MessageBox.Show("Không tìm thấy danh mục sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
            else
            {
				dataDMSP.DataSource = _danhMucSanPhamBLL.GetDanhMucSanPhamByName(txtSearchDMSP.Text);
				SetButtonState(false, false, false, false, true);
				ShowDetail(false);
				ClearInputFields();
			}
		}

        private void btnCancelDM_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadDanhMucData();
            SetButtonState(true, false, false, false, false);
            ShowDetail(false);
        }

        private void btnSaveDM_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var danhMuc = new DanhMucSanPham
            {
                MaDM = txtMaDMSP.Text,
                TenDM = txtTenDMSP.Text
            };

            if (isAdding)
                _danhMucSanPhamBLL.AddDanhMucSanPham(danhMuc);
            else if (isEditing)
                _danhMucSanPhamBLL.UpdateDanhMucSanPham(danhMuc);

            ClearInputFields();
            LoadDanhMucData();
            SetButtonState(true, false, false, false, false);
            ShowDetail(false);
            ResetFlags();
            txtSearchDMSP.Focus();
        }

        private void dataDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider.Clear();
            ShowDetail(false);
            if (e.RowIndex >= 0)
            {
                txtMaDMSP.Text = dataDMSP.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenDMSP.Text = dataDMSP.Rows[e.RowIndex].Cells[1].Value.ToString();
                SetButtonState(false, true, true, false, true);
            }
        }

        private void btnExitDM_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
