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
    public partial class fNguyenLieu : Form
    {
        private NguyenLieuBLL _nguyenLieuBLL;
        private ErrorProvider errorProvider = new ErrorProvider();

        public fNguyenLieu()
        {
            InitializeComponent();
            _nguyenLieuBLL = new NguyenLieuBLL(Classes.DbConfig.connectString);
            LoadNguyenLieuData();
        }

        private void LoadNguyenLieuData()
        {
            var nguyenLieuList = _nguyenLieuBLL.GetAllNguyenLieu();
            dataNL.DataSource = nguyenLieuList;
        }

        private void btnAddNL_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            var nguyenLieu = new NguyenLieu
            {
                MaNL = txtMaNguyenLieu.Text,
                TenNL = txtTenNguyenLieu.Text,
                DonVi = txtDVNL.Text,
                Gia = decimal.Parse(txtGiaNguyenLieu.Text),
                SoLuong = int.Parse(nupSLNL.Text),
                NgaySanXuat = dtpNSXNL.Value,
                HanSuDung = dtpHSDNL.Value
            };

            _nguyenLieuBLL.AddNguyenLieu(nguyenLieu);
            LoadNguyenLieuData();
            ClearInputFields();
        }

        private void btnUpdateNL_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return; // Stop execution if validation fails
            }

            var nguyenLieu = new NguyenLieu
            {
                MaNL = txtMaNguyenLieu.Text,
                TenNL = txtTenNguyenLieu.Text,
                DonVi = txtDVNL.Text,
                Gia = decimal.Parse(txtGiaNguyenLieu.Text),
                SoLuong = int.Parse(nupSLNL.Text),
                NgaySanXuat = dtpNSXNL.Value,
                HanSuDung = dtpHSDNL.Value
            };

            _nguyenLieuBLL.UpdateNguyenLieu(nguyenLieu);
            LoadNguyenLieuData();
            ClearInputFields();
        }

        private void btnDeleteNL_Click(object sender, EventArgs e)
        {
            string maNL = txtMaNguyenLieu.Text;
            _nguyenLieuBLL.DeleteNguyenLieu(maNL);
            LoadNguyenLieuData();
            ClearInputFields();
        }

        private void btnSearchNL_Click(object sender, EventArgs e)
        {
            string tenNL = txtSearchNL.Text;
            var nguyenLieuList = _nguyenLieuBLL.SearchNguyenLieu(tenNL);
            dataNL.DataSource = nguyenLieuList;
        }

        private void btnCancelNL_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private bool ValidateInput()
        {
            bool isValid = true;

            // Clear previous errors
            errorProvider.Clear();

            // Validate TenNL
            if (string.IsNullOrWhiteSpace(txtTenNguyenLieu.Text))
            {
                errorProvider.SetError(txtTenNguyenLieu, "Tên nguyên liệu không được để trống!");
                isValid = false;
            }

            // Validate Gia
            if (string.IsNullOrWhiteSpace(txtGiaNguyenLieu.Text) || !decimal.TryParse(txtGiaNguyenLieu.Text, out decimal gia) || gia < 0)
            {
                errorProvider.SetError(txtGiaNguyenLieu, "Giá không hợp lệ!");
                isValid = false;
            }

            // Validate SoLuong
            if (string.IsNullOrWhiteSpace(nupSLNL.Text) || !int.TryParse(nupSLNL.Text, out int soLuong) || soLuong < 0)
            {
                errorProvider.SetError(nupSLNL, "Số lượng không hợp lệ!");
                isValid = false;
            }

            return isValid;
        }

        private void ClearInputFields()
        {
            errorProvider.Clear();
            txtMaNguyenLieu.Clear();
            txtTenNguyenLieu.Clear();
            txtDVNL.Clear();
            txtGiaNguyenLieu.Clear();
            nupSLNL.Value = 0;
            dtpNSXNL.Value = DateTime.Now;
            dtpHSDNL.Value = DateTime.Now;
        }

        private void dataGridViewNguyenLieu_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider.Clear();
            if (dataNL.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataNL.SelectedRows[0];
                txtMaNguyenLieu.Text = row.Cells["MaNL"].Value.ToString();
                txtTenNguyenLieu.Text = row.Cells["TenNL"].Value.ToString();
                txtDVNL.Text = row.Cells["DonVi"].Value.ToString();
                txtGiaNguyenLieu.Text = row.Cells["Gia"].Value.ToString();
                nupSLNL.Value = Convert.ToDecimal(row.Cells["SoLuong"].Value); // Corrected reference to NumericUpDown
                dtpNSXNL.Value = Convert.ToDateTime(row.Cells["NgaySanXuat"].Value);
                dtpHSDNL.Value = Convert.ToDateTime(row.Cells["HanSuDung"].Value);
            }
        }
    }
}
