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
        private ErrorProvider errorProvider = new ErrorProvider();
        private string selectedImagePath; // Variable to store the selected image path
        private bool isAdding, isEditing;

        public fSanPham()
        {
            InitializeComponent();
            _sanPhamBLL = new SanPhamBLL(Classes.DbConfig.connectString);
            LoadSanPhamData();
            ShowDetail(false);
            SetButtonState(true, false, false, false, false);
        }

        private void LoadSanPhamData()
        {
            var sanPhamList = _sanPhamBLL.GetAllSanPham();
            dataSP.DataSource = sanPhamList;
        }

        private void ShowDetail(bool detail)
        {
            txtTenSP.Enabled = detail;
            txtGiaSP.Enabled = detail;
            cbMaDM.Enabled = detail;
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

            return isValid;
        }


        private void ClearInputFields()
        {
            errorProvider.Clear();
            txtMaSP.Clear();
            cbMaDM.SelectedIndex = -1; 
            txtTenSP.Clear();
            txtGiaSP.Clear();
            pbSP.Image = null; 
            selectedImagePath = null; 
        }
        private void btnAddSP_Click(object sender, EventArgs e)
        {
            //// Validate input before adding
            //if (!ValidateInput())
            //{
            //    return; // Stop execution if validation fails
            //}

            //// Extract the image name from the selected image path
            //string imageFileName = Path.GetFileName(selectedImagePath); // Get only the file name

            //var sanPham = new SanPham
            //{
            //    MaSP = txtMaSP.Text,
            //    TenSP = txtTenSP.Text,
            //    MaDM = cbMaDM.Text, // Assuming cbMaDM is a ComboBox for category
            //    Gia = decimal.Parse(txtGiaSP.Text),
            //    Anh = imageFileName // Save the image file name
            //};

            //// Copy the image to the Images folder
            //string destPath = Path.Combine(Application.StartupPath, "Images", imageFileName);
            //File.Copy(selectedImagePath, destPath, true); // Overwrite if exists

            //_sanPhamBLL.AddSanPham(sanPham);
            //LoadSanPhamData();
            //ClearInputFields();

            ClearInputFields();
            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isAdding = true;
            txtTenSP.Focus();
        }

        private void btnUpdateSP_Click(object sender, EventArgs e)
        {
            //// Validate input before updating
            //if (!ValidateInput())
            //{
            //    return; // Stop execution if validation fails
            //}

            //// Ensure that an image has been selected
            ////if (string.IsNullOrEmpty(selectedImagePath))
            ////{
            ////    MessageBox.Show("Please select an image.");
            ////    return;
            ////}

            //// Extract the image name from the selected image path
            //string imageFileName = Path.GetFileName(selectedImagePath); // Get only the file name

            //var sanPham = new SanPham
            //{
            //    MaSP = txtMaSP.Text,
            //    TenSP = txtTenSP.Text,
            //    MaDM = cbMaDM.Text,
            //    Gia = decimal.Parse(txtGiaSP.Text),
            //    Anh = imageFileName // Save the image file name to the database
            //};

            //// Define the destination folder for storing the image
            //string imagesFolder = Path.Combine(Application.StartupPath, "Images");

            //// Ensure the Images folder exists
            //if (!Directory.Exists(imagesFolder))
            //{
            //    Directory.CreateDirectory(imagesFolder);
            //}

            //// Copy the image to the Images folder in the Debug directory
            //string destPath = Path.Combine(imagesFolder, imageFileName);
            //try
            //{
            //    File.Copy(selectedImagePath, destPath, true); // Overwrite if exists
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error copying image: " + ex.Message);
            //    return;
            //}

            //// Update the product information in the database
            //_sanPhamBLL.UpdateSanPham(sanPham);

            //// Refresh the data grid or list to reflect the updated product
            //LoadSanPhamData();

            //// Clear input fields after updating
            //ClearInputFields();

            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isEditing = true;
        }


        private void btnDeleteSP_Click(object sender, EventArgs e)
        {
            //string maSP = txtMaSP.Text;
            //_sanPhamBLL.DeleteSanPham(maSP);
            //LoadSanPhamData();
            //ClearInputFields();
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
            //string tenSP = txtSearch.Text;
            //var sanPhamList = _sanPhamBLL.GetSanPhamByName(tenSP);
            //dataSP.DataSource = sanPhamList;

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

            decimal? gia = null;
            if (decimal.TryParse(txtGiaSP.Text, out decimal parsedGia))
            {
                gia = parsedGia;
            }

            // Lưu tên ảnh vào cơ sở dữ liệu
            var sanPham = new SanPham
            {
                MaSP = txtMaSP.Text,
                TenSP = txtTenSP.Text,
                Gia = gia,
                MaDM = cbMaDM.Text,
                Anh = !string.IsNullOrEmpty(pbSP.Text) ? pbSP.Text : null, // Lưu tên ảnh nếu có
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
                cbMaDM.Text = row.Cells["MaDM"].Value.ToString();
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
