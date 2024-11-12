using QLQuanCF.BusinessLogicLayer;
using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanCF.PresentationLayer
{
    public partial class fSanPham : Form
    {
        private SanPhamBLL _sanPhamBLL;
        private DMSanPhamBLL _DMSanPhamBLL;
        private ErrorProvider errorProvider = new ErrorProvider();
        private string selectedImagePath;
        private bool isAdding, isEditing;

        public fSanPham()
        {
            InitializeComponent();
            _sanPhamBLL = new SanPhamBLL(Classes.DbConfig.connectString);
            _DMSanPhamBLL = new DMSanPhamBLL(Classes.DbConfig.connectString);
            LoadSanPhamData();
            ShowDetail(false);
            SetButtonState(true, false, false, false, false);
        }

        private void LoadSanPhamData()
        {
            var sanPhamList = _sanPhamBLL.GetAllSanPham();
            dataSP.DataSource = sanPhamList;
        }

        private void LoadDanhMucData()
        {
            var danhMucList = _DMSanPhamBLL.GetAllDanhMucSanPham();
            cbDM.DataSource = danhMucList;
            cbDM.DisplayMember = "TenDM"; 
            cbDM.ValueMember = "MaDM";
            cbDM.SelectedIndex = -1; 
        }


        private void ShowDetail(bool detail)
        {
            txtTenSP.Enabled = detail;
            txtGiaSP.Enabled = detail;
            cbDM.Enabled = detail;
            btnChon.Enabled = detail;
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

            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                errorProvider.SetError(txtTenSP, "Tên sản phẩm không được để trống!");
                isValid = false;
            }
            else if (txtTenSP.Text.Length > 100)
            {
                errorProvider.SetError(txtTenSP, "Tên sản phẩm không được vượt quá 100 ký tự!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtGiaSP.Text))
            {
                errorProvider.SetError(txtGiaSP, "Đơn giá không được để trống!");
                isValid = false;
            }
            else if (!decimal.TryParse(txtGiaSP.Text, out decimal gia) || gia <= 0)
            {
                errorProvider.SetError(txtGiaSP, "Đơn giá phải là số hợp lệ và lớn hơn 0!");
                isValid = false;
            }

            if (cbDM.SelectedIndex == -1)
            {
                errorProvider.SetError(cbDM, "Danh mục không được để trống!");
                isValid = false;
            }

            if (string.IsNullOrEmpty(pbSP.Text))
            {
                MessageBox.Show("Vui lòng chọn ảnh cho sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isValid = false;
            }

            return isValid;
        }

        private void ClearInputFields()
        {
            errorProvider.Clear();
            txtMaSP.Clear();
            cbDM.SelectedIndex = -1; 
            txtTenSP.Clear();
            txtGiaSP.Clear();
            pbSP.Image = null; 
            selectedImagePath = null; 
        }
        private void btnAddSP_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            ShowDetail(true);
            LoadDanhMucData();
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isAdding = true;
            txtTenSP.Focus();
        }

        private void btnUpdateSP_Click(object sender, EventArgs e)
        {
            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isEditing = true;
        }

        private void btnDeleteSP_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn sản phẩm này không?", "Xóa nhà sản phẩm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ResetFlags();
                _sanPhamBLL.DeleteSanPham(txtMaSP.Text);
                ClearInputFields();
                LoadSanPhamData();
                SetButtonState(true, false, false, false, false);
                ShowDetail(false);
                txtSearch.Focus();
            }
        }

        private void btnSearchSP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadSanPhamData(); return;
            }
            if (_sanPhamBLL.GetSanPhamByName(txtSearch.Text).Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dataSP.DataSource = _sanPhamBLL.GetSanPhamByName(txtSearch.Text);
                SetButtonState(false, false, false, false, true);
                ShowDetail(false);
                ClearInputFields();
            }
        }

        private void btnCancelSP_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadSanPhamData();
            SetButtonState(true, false, false, false, false);
            ShowDetail(false);
        }

        private void btnSaveNCC_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            // Kiểm tra mã sản phẩm có bị trùng lặp hay không
            if (_sanPhamBLL.IsProductNameExist(txtMaSP.Text))
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại. Vui lòng chọn mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal? gia = null;
            if (decimal.TryParse(txtGiaSP.Text, out decimal parsedGia))
            {
                gia = parsedGia;
            }

            var sanPham = new SanPham
            {
                MaSP = txtMaSP.Text,
                TenSP = txtTenSP.Text,
                Gia = gia,
                MaDM = cbDM.SelectedValue?.ToString(),
                Anh = !string.IsNullOrEmpty(pbSP.Text) ? pbSP.Text : null,
            };

            if (isAdding)
                _sanPhamBLL.AddSanPham(sanPham);
            else if (isEditing)
                _sanPhamBLL.UpdateSanPham(sanPham);

            ClearInputFields();
            LoadSanPhamData();
            SetButtonState(true, false, false, false, false);
            ShowDetail(false);
            ResetFlags();
            txtSearch.Focus();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName; // Store the selected image path
                    pbSP.Image = Image.FromFile(selectedImagePath); // Show image in PictureBox
                    pbSP.Text = Path.GetFileName(openFileDialog.FileName); // Set product name from file name
                }
            }
        }

        private void dataSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider.Clear();
            if (dataSP.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataSP.SelectedRows[0];
                txtMaSP.Text = row.Cells["MaSP"].Value.ToString();
                cbDM.Text = _DMSanPhamBLL.GetTenDanhMucSanPhamByMa(row.Cells["MaDM"].Value.ToString());
                txtTenSP.Text = row.Cells["TenSP"].Value.ToString();
                txtGiaSP.Text = row.Cells["Gia"].Value.ToString();
                SetButtonState(false, true, true, false, true);

                // Lấy tên ảnh từ cơ sở dữ liệu
                string imageName = row.Cells["Anh"].Value?.ToString();
                if (!string.IsNullOrEmpty(imageName))
                {
                    string imagePath = Path.Combine(Application.StartupPath, "Images", imageName);
                    if (File.Exists(imagePath))
                    {
                        pbSP.Image = Image.FromFile(imagePath); // Load image into PictureBox
                        pbSP.Text = imageName; // Lưu tên ảnh vào Text của PictureBox
                    }
                    else
                    {
                        pbSP.Image = null; // Reset if not found
                    }
                }
                else
                {
                    pbSP.Image = null; // Reset if no image
                    pbSP.Text = string.Empty; // Reset tên ảnh
                }
            }
        }

        private void btnExitNCC_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
