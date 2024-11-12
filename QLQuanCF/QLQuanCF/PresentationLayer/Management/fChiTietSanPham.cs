using QLQuanCF.BusinessLogicLayer;
using QLQuanCF.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QLQuanCF.PresentationLayer.Management
{
    public partial class fChiTietSanPham : Form
    {
        private SanPhamBLL sanPhamBLL;
        private NguyenLieuBLL nguyenLieuBLL;
        private ChiTietSanPhamBLL chiTietSanPhamBLL;

        private ErrorProvider errorProvider = new ErrorProvider();
        private bool isAdding, isEditing;

        public fChiTietSanPham()
        {
            InitializeComponent();

            sanPhamBLL = new SanPhamBLL(Classes.DbConfig.connectString);
            nguyenLieuBLL = new NguyenLieuBLL(Classes.DbConfig.connectString);
            chiTietSanPhamBLL = new ChiTietSanPhamBLL(Classes.DbConfig.connectString);

            LoadCBNguyenLieu();
            LoadCBSanPham();
            LoadDataChiTietSanPham();
        }

        private void LoadCBSanPham()
        {
            cbMaSP.DataSource = sanPhamBLL.GetAllSanPham();
            cbMaSP.DisplayMember = "MaSP";
            cbMaSP.ValueMember = "MaSP";
            cbMaSP.SelectedIndex = -1;

            cbSearch.DataSource = sanPhamBLL.GetAllSanPham();
            cbSearch.DisplayMember = "MaSP";
            cbSearch.ValueMember = "MaSP";
            cbSearch.SelectedIndex = -1;
        }

        private void LoadCBNguyenLieu()
        {
            cbMaNL.DataSource = nguyenLieuBLL.GetAllNguyenLieu();
            cbMaNL.DisplayMember = "MaNL";
            cbMaNL.ValueMember = "MaNL";
            cbMaNL.SelectedIndex = -1;
        }

        private void LoadDataChiTietSanPham()
        {
            dataCTSP.DataSource = chiTietSanPhamBLL.GetAllChiTietSanPham();
        }

        private void ShowDetail(bool detail)
        {
            cbMaSP.Enabled = detail;
            cbMaNL.Enabled = detail;
            nudSL.Enabled = detail;
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

            if (string.IsNullOrWhiteSpace(cbMaNL.Text))
            {
                errorProvider.SetError(cbMaNL, "Mã nguyên liệu không được để trống!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(cbMaSP.Text))
            {
                errorProvider.SetError(cbMaSP, "Mã sản phẩm không được để trống!");
                isValid = false;
            }

            return isValid;
        }

        private void ClearInputFields()
        {
            errorProvider.Clear();
            cbMaSP.SelectedIndex = -1;
            cbMaNL.SelectedIndex = -1;
            nudSL.Value = 0;
            txtTenNL.Clear();
            txtTenSP.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isAdding = true;
            cbMaSP.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa chi tiết sản phẩm này không?", "Xóa chi tiết sản phẩm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ResetFlags();
                chiTietSanPhamBLL.DeleteCTSP(cbMaSP.Text, cbMaNL.Text);
                ClearInputFields();
                LoadDataChiTietSanPham();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var ctsp = new ChiTietSanPham
            {
                MaSP = cbMaSP.Text,
                MaNL = cbMaNL.Text,
                SoLuong = (int)nudSL.Value
            };

            if (isAdding)
                chiTietSanPhamBLL.AddCTSP(ctsp);
            else if (isEditing)
                chiTietSanPhamBLL.UpdateCTSP(ctsp);

            ClearInputFields();
            LoadDataChiTietSanPham();
            SetButtonState(true, false, false, false, false);
            ShowDetail(false);
            ResetFlags();
            cbSearch.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadDataChiTietSanPham();
            SetButtonState(true, false, false, false, false);
            ShowDetail(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbSearch.Text))
            {
                LoadDataChiTietSanPham(); return;
            }
            if (chiTietSanPhamBLL.GetCTSPByMaSP(cbSearch.Text) == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dataCTSP.DataSource = chiTietSanPhamBLL.GetCTSPByMaSP(cbSearch.Text);
                SetButtonState(false, false, false, false, true);
                ShowDetail(false);
                ClearInputFields();
            }
        }

        private void dataCTSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider.Clear();
            ShowDetail(false);
            if (e.RowIndex >= 0)
            {
                cbMaSP.Text = dataCTSP.Rows[e.RowIndex].Cells["MaSP"].Value.ToString();
                cbMaNL.Text = dataCTSP.Rows[e.RowIndex].Cells["MaNL"].Value.ToString();
                nudSL.Value = Convert.ToInt32(dataCTSP.Rows[e.RowIndex].Cells["SoLuong"].Value);
                SetButtonState(false, true, true, false, true);
            }
        }

        private void cbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbMaSP.SelectedIndex != -1)
            {
                txtTenSP.Text = ((SanPham)cbMaSP.SelectedItem).TenSP;
            }
        }

        private void cbMaNL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbMaNL.SelectedIndex != -1)
            {
                txtTenNL.Text = ((NguyenLieu)cbMaNL.SelectedItem).TenNL;

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
