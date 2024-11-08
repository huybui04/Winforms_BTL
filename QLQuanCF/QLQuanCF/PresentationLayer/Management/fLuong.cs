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
    public partial class fLuong : Form
    {
        private LuongBLL _luongBLL;
        private ErrorProvider errorProvider = new ErrorProvider();

        public fLuong()
        {
            InitializeComponent();
            _luongBLL = new LuongBLL(Classes.DbConfig.connectString);
            LoadLuongData();
        }

        private void LoadLuongData()
        {
            var luongList = _luongBLL.GetAllLuong();
            dataLuong.DataSource = luongList; // Assuming you have a DataGridView named dataLuong
        }

        private void btnAddLuong_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            var luong = new Luong
            {
                MaNV = txtMaNV.Text,
                MaCa = txtMaCa.Text,
                Ngay = dtpNgayLuong.Value // Assuming dtpNgay is a DateTimePicker
            };

            _luongBLL.AddLuong(luong);
            LoadLuongData();
            ClearInputFields();
        }

        private void btnUpdateLuong_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return; // Stop execution if validation fails
            }

            var luong = new Luong
            {
                MaNV = txtMaNV.Text,
                MaCa = txtMaCa.Text,
                Ngay = dtpNgayLuong.Value
            };

            _luongBLL.UpdateLuong(luong);
            LoadLuongData();
            ClearInputFields();
        }

        private void btnDeleteLuong_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string maCa = txtMaCa.Text;
            _luongBLL.DeleteLuong(maNV, maCa);
            LoadLuongData();
            ClearInputFields();
        }

        private void btnSearchLuong_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text; // Assuming you have a TextBox for searching
            var luongList = _luongBLL.SearchLuong(keyword);
            dataLuong.DataSource = luongList;
        }

        private void btnCancelLuong_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private bool ValidateInput()
        {
            bool isValid = true;

            // Clear previous errors
            errorProvider.Clear();

            // Validate MaNV
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                errorProvider.SetError(txtMaNV, "Mã nhân viên không được để trống!");
                isValid = false;
            }

            // Validate MaCa
            if (string.IsNullOrWhiteSpace(txtMaCa.Text))
            {
                errorProvider.SetError(txtMaCa, "Mã ca không được để trống!");
                isValid = false;
            }

            return isValid;
        }

        private void ClearInputFields()
        {
            errorProvider.Clear();
            txtMaNV.Clear();
            txtMaCa.Clear();
            dtpNgayLuong.Value = DateTime.Now; // Resetting DateTimePicker to current date
        }

        private void dataLuong_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider.Clear();
            if (dataLuong.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataLuong.SelectedRows[0];
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtMaCa.Text = row.Cells["MaCa"].Value.ToString();
                dtpNgayLuong.Value = Convert.ToDateTime(row.Cells["Ngay"].Value);
            }
        }
    }

}
