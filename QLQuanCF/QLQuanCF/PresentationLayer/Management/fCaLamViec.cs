using QLQuanCF.BusinessLogicLayer;
using QLQuanCF.DataAccessLayer;
using QLQuanCF.Model;
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
    public partial class fCaLamViec : Form
    {
        private CaLamViecBLL _caLamViecBLL;
        private ErrorProvider errorProvider = new ErrorProvider();
        private bool isAdding, isEditing;

        public fCaLamViec()
        {
            InitializeComponent();
            _caLamViecBLL = new CaLamViecBLL(Classes.DbConfig.connectString);

            LoadCaLamViecData();
            ShowDetail(false);
            SetButtonState(true, false, false, false, false);
        }

        // tinh nang phu
        private void LoadCaLamViecData()
        {
            dataCaLamViec.DataSource = _caLamViecBLL.GetAllCaLamViec();

            cbSearchCaLamViec.DataSource = _caLamViecBLL.GetAllCaLamViec();
            cbSearchCaLamViec.DisplayMember = "TenCa";
            cbSearchCaLamViec.ValueMember = "TenCa";
            cbSearchCaLamViec.SelectedIndex = -1;
        }
        private void ShowDetail(bool detail)
        {
            //txtMaCa.Enabled = detail;
            txtTenCa.Enabled = detail;
            txtLuongCLV.Enabled = detail;
            timeGioBatDauCLV.Enabled = detail;
            timeGioKetThucCLV.Enabled = detail;
        }

        private void SetButtonState(bool add, bool edit, bool delete, bool save, bool cancel)
        {
            btnAddCaLamViec.Enabled = add;
            btnEditCaLamViec.Enabled = edit;
            btnDeleteCaLamViec.Enabled = delete;
            btnSaveCaLamViec.Enabled = save;
            btnCancelCaLamViec.Enabled = cancel;
        }

        private void ResetFlags()
        {
            isAdding = isEditing = false;
        }

        private bool ValidateInput()
        {
            bool isValid = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtTenCa.Text))
            {
                errorProvider.SetError(txtTenCa, "Tên ca làm việc không được để trống!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtLuongCLV.Text))
            {
                errorProvider.SetError(txtLuongCLV, "Mức lương của ca làm việc mới không được để trống!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(timeGioBatDauCLV.Text))
            {
                errorProvider.SetError(timeGioBatDauCLV, "Giờ bắt đầu vào ca làm việc không được để trống!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(timeGioKetThucCLV.Text))
            {
                errorProvider.SetError(timeGioKetThucCLV, "Giờ kết thúc ca làm việc không được để trống!");
                isValid = false;
            }

            return isValid;
        }

        private void ClearInputFields()
        {
            errorProvider.Clear();
            txtMaCa.Clear();
            txtTenCa.Clear();
            txtLuongCLV.Clear();
            timeGioBatDauCLV.Value = DateTime.Now;
            timeGioKetThucCLV.Value = DateTime.Now;
        }

        private void btnAddCaLamViec_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isAdding = true;
        }

        private void btnDeleteCaLamViec_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ca làm việc này không?", "Xóa ca làm việc", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ResetFlags();
                _caLamViecBLL.DeleteCaLamViec(txtMaCa.Text);
                ClearInputFields();
                LoadCaLamViecData();
                SetButtonState(true, false, false, false, false);
                ShowDetail(false);
                cbSearchCaLamViec.Focus();
            }
        }

        private void btnEditCaLamViec_Click(object sender, EventArgs e)
        {
            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isEditing = true;
        }

        private void btnSaveCaLamViec_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var ca = new CaLamViec
            {
                MaCa = txtMaCa.Text,
                TenCa = txtTenCa.Text,
                Luong = Decimal.Parse(txtLuongCLV.Text),
                GioBatDau = timeGioBatDauCLV.Value.TimeOfDay,
                GioKetThuc = timeGioKetThucCLV.Value.TimeOfDay
            };

            if (isAdding)
                _caLamViecBLL.AddCaLamViec(ca);
            else if (isEditing)
                _caLamViecBLL.UpdateCaLamViec(ca);

            ClearInputFields();
            LoadCaLamViecData();
            SetButtonState(true, false, false, false, false);
            ShowDetail(false);
            ResetFlags();
            cbSearchCaLamViec.Focus();
        }

        private void btnCancelCaLamViec_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadCaLamViecData();
            SetButtonState(true, false, false, false, false);
            ShowDetail(false);
        }

        private void btnSearchCaLamViec_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbSearchCaLamViec.Text))
            {
                LoadCaLamViecData();
                return;
            }
            if (_caLamViecBLL.GetCaLamViecByName(cbSearchCaLamViec.Text).Count == 0)
            {
                MessageBox.Show("Không tìm thấy ca nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dataCaLamViec.DataSource = _caLamViecBLL.GetCaLamViecByName(cbSearchCaLamViec.Text);
                SetButtonState(false, false, false, false, true);
                ShowDetail(false);
                ClearInputFields();
            }
        }

        private void dataCaLamViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider.Clear();
            ShowDetail(false);
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataCaLamViec.Rows[e.RowIndex];
                txtMaCa.Text = row.Cells["MaCa"].Value.ToString();
                txtTenCa.Text = row.Cells["TenCa"].Value.ToString();
                txtLuongCLV.Text = row.Cells["Luong"].Value.ToString();
                timeGioBatDauCLV.Value = row.Cells["GioBatDau"].Value != null ? DateTime.Today.Add((TimeSpan)row.Cells["GioBatDau"].Value) : DateTime.Now;
                timeGioKetThucCLV.Value = row.Cells["GioKetThuc"].Value != null ? DateTime.Today.Add((TimeSpan)row.Cells["GioKetThuc"].Value) : DateTime.Now;
                SetButtonState(false, true, true, false, true);
            }
        }

        private void btnExitCaLamViec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
