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

        public fSanPham()
        {
            InitializeComponent();
            _sanPhamBLL = new SanPhamBLL(Classes.DbConfig.connectString);
            LoadSanPhamData();
        }

        private void LoadSanPhamData()
        {
            var sanPhamList = _sanPhamBLL.GetAllSanPham();
            dataSP.DataSource = sanPhamList;
        }

        private void btnAddSP_Click(object sender, EventArgs e)
        {
            // Validate input before adding
            if (!ValidateInput())
            {
                return; // Stop execution if validation fails
            }

            // Extract the image name from the selected image path
            string imageFileName = Path.GetFileName(selectedImagePath); // Get only the file name

            var sanPham = new SanPham
            {
                MaSP = txtMaSP.Text,
                TenSP = txtTenSP.Text,
                MaDM = cbMaDM.Text, // Assuming cbMaDM is a ComboBox for category
                Gia = decimal.Parse(txtGiaSP.Text),
                Anh = imageFileName // Save the image file name
            };

            // Copy the image to the Images folder
            string destPath = Path.Combine(Application.StartupPath, "Images", imageFileName);
            File.Copy(selectedImagePath, destPath, true); // Overwrite if exists

            _sanPhamBLL.AddSanPham(sanPham);
            LoadSanPhamData();
            ClearInputFields();
        }

        private void btnUpdateSP_Click(object sender, EventArgs e)
        {
            // Validate input before updating
            if (!ValidateInput())
            {
                return; // Stop execution if validation fails
            }

            // Ensure that an image has been selected
            //if (string.IsNullOrEmpty(selectedImagePath))
            //{
            //    MessageBox.Show("Please select an image.");
            //    return;
            //}

            // Extract the image name from the selected image path
            string imageFileName = Path.GetFileName(selectedImagePath); // Get only the file name

            var sanPham = new SanPham
            {
                MaSP = txtMaSP.Text,
                TenSP = txtTenSP.Text,
                MaDM = cbMaDM.Text,
                Gia = decimal.Parse(txtGiaSP.Text),
                Anh = imageFileName // Save the image file name to the database
            };

            // Define the destination folder for storing the image
            string imagesFolder = Path.Combine(Application.StartupPath, "Images");

            // Ensure the Images folder exists
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            // Copy the image to the Images folder in the Debug directory
            string destPath = Path.Combine(imagesFolder, imageFileName);
            try
            {
                File.Copy(selectedImagePath, destPath, true); // Overwrite if exists
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error copying image: " + ex.Message);
                return;
            }

            // Update the product information in the database
            _sanPhamBLL.UpdateSanPham(sanPham);

            // Refresh the data grid or list to reflect the updated product
            LoadSanPhamData();

            // Clear input fields after updating
            ClearInputFields();
        }


        private void btnDeleteSP_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text;
            _sanPhamBLL.DeleteSanPham(maSP);
            LoadSanPhamData();
            ClearInputFields();
        }

        private void btnSearchSP_Click(object sender, EventArgs e)
        {
            string tenSP = txtSearch.Text;
            var sanPhamList = _sanPhamBLL.GetSanPhamByName(tenSP);
            dataSP.DataSource = sanPhamList;
        }

        private void btnCancelSP_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private bool ValidateInput()
        {
            bool isValid = true;

            // Clear previous errors
            errorProvider.Clear();

            // Validate TenSP
            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                errorProvider.SetError(txtTenSP, "Tên sản phẩm không được để trống!");
                isValid = false;
            }

            // Validate DonGia
            if (string.IsNullOrWhiteSpace(txtGiaSP.Text))
            {
                errorProvider.SetError(txtGiaSP, "Đơn giá không được để trống!");
                isValid = false;
            }
            else if (!decimal.TryParse(txtGiaSP.Text, out _))
            {
                errorProvider.SetError(txtGiaSP, "Đơn giá không hợp lệ!");
                isValid = false;
            }

            // You can add more validations for other fields here
            return isValid;
        }

        private void ClearInputFields()
        {
            errorProvider.Clear();
            txtMaSP.Clear();
            cbMaDM.SelectedIndex = -1; // Reset the category ComboBox
            txtTenSP.Clear();
            txtGiaSP.Clear();
            pbSP.Image = null; // Reset the PictureBox
            selectedImagePath = null; // Clear the selected image path
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
                    //txtTenSP.Text = Path.GetFileNameWithoutExtension(openFileDialog.FileName); // Set product name from file name
                }
            }
        }

        private void dataSanPham_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider.Clear();
            if (dataSP.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataSP.SelectedRows[0];
                txtMaSP.Text = row.Cells["MaSP"].Value.ToString();
                cbMaDM.Text = row.Cells["MaDM"].Value.ToString();
                txtTenSP.Text = row.Cells["TenSP"].Value.ToString();
                txtGiaSP.Text = row.Cells["Gia"].Value.ToString();

                // Load image from the Images folder
                string imageName = row.Cells["Anh"].Value?.ToString();
                if (!string.IsNullOrEmpty(imageName))
                {
                    string imagePath = Path.Combine(Application.StartupPath, "Images", imageName);
                    //  D:\Semester_1_2024_2025\LTTQ\Winforms_BTL\QLQuanCF\QLQuanCF\bin\Images
                    if (File.Exists(imagePath))
                    {
                        
                        pbSP.Image = Image.FromFile(imagePath); // Load image into PictureBox
                    }
                    else
                    {
                        pbSP.Image = null; // Reset if not found
                    }
                }
                else
                {
                    pbSP.Image = null; // Reset if no image
                        
                }

            }
        }
    }
}
