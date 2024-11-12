using QLQuanCF.BusinessLogicLayer;
using QLQuanCF.DataAccessLayer;
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
    public partial class fUser : Form
    {
        private UserBLL _userBLL;
        private NhanVienBLL _nhanVienBLL;
        private ErrorProvider errorProvider = new ErrorProvider();
        private bool isAdding, isEditing;

        public fUser()
        {
            InitializeComponent();
            _userBLL = new UserBLL(Classes.DbConfig.connectString);
            _nhanVienBLL = new NhanVienBLL(Classes.DbConfig.connectString);
            LoadUserData();
            LoadNhanVien();
            ShowDetail(false);
            SetButtonState(true, false, false, false, false);

            cbRole.Items.Clear();  
            cbRole.Items.Add("Admin");  
            cbRole.Items.Add("Staff");  
            cbRole.SelectedIndex = 1;   
        }

        private void LoadNhanVien()
        {
            try
            {
                var maNVList = _nhanVienBLL.GetALlMaNV();

                if (maNVList == null || maNVList.Count == 0)
                {
                    MessageBox.Show("No employee IDs found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbNV.Items.Clear();
                }
                else
                {
                    cbNV.Items.Clear(); // Clear previous items
                    foreach (var maNV in maNVList)
                    {
                        cbNV.Items.Add(maNV); // Add new employee IDs to ComboBox
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee IDs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbNV.Items.Clear(); // Clear ComboBox in case of error
            }
        }


        private void LoadUserData()
        {
            dataUser.DataSource = _userBLL.GetAllUsers();
        }

        private void ShowDetail(bool detail)
        {
            txtUserName.Enabled = detail;
            txtPassword.Enabled = detail;
            cbRole.Enabled = detail;
            cbNV.Enabled = detail; 
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

            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                errorProvider.SetError(txtUserName, "Vui lòng nhập tên người dùng!");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, "Vui lòng nhập mật khẩu!");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(cbRole.Text))
            {
                errorProvider.SetError(cbRole, "Vui lòng chọn quyền người dùng!");
                isValid = false;
            }

            return isValid;
        }

        private void ClearInputFields()
        {
            errorProvider.Clear();
            txtUserID.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            cbRole.Items.Clear();
            txtSearch.Clear();
            cbNV.Items.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isAdding = true;
            LoadNhanVien();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này không?", "Xóa người dùng", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ResetFlags();
                _userBLL.DeleteUser(txtUserID.Text);
                ClearInputFields();
                LoadUserData();
                LoadNhanVien();
                SetButtonState(true, false, false, false, false);
                ShowDetail(false);
                txtSearch.Focus();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isEditing = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadUserData();
                return;
            }

            List<User> users = _userBLL.GetAllUserByUsername(txtSearch.Text);
            if (users.Count == 0)
            {
                MessageBox.Show("Không tìm thấy người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dataUser.DataSource = users;
                SetButtonState(false, false, false, false, true);
                ShowDetail(false);
                ClearInputFields();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadUserData();
            SetButtonState(true, false, false, false, false);
            ShowDetail(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var user = new User
            {
                UserID = txtUserID.Text,
                Username = txtUserName.Text,
                Password = txtPassword.Text,
                Role = cbRole.Text,
                MaNV = cbNV.Text
            };

            // Check if the username already exists
            if (isAdding && _userBLL.CheckIfUsernameExists(user.Username))
            {
                MessageBox.Show("Tên người dùng đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Proceed to add or update the user if the username is unique
            if (isAdding)
            {
                _userBLL.AddUser(user);
            }
            else if (isEditing)
            {
                _userBLL.UpdateUser(user);
            }

            ClearInputFields();
            LoadUserData();
            LoadNhanVien();
            SetButtonState(true, false, false, false, false);
            ShowDetail(false);
            ResetFlags();
            txtSearch.Focus();
        }


        private void dataUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider.Clear();
            ShowDetail(false);
            if (e.RowIndex >= 0)
            {
                txtUserID.Text = dataUser.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtUserName.Text = dataUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPassword.Text = dataUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbRole.Text = dataUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                cbNV.Text = dataUser.Rows[e.RowIndex].Cells[4].Value.ToString();
                SetButtonState(false, true, true, false, true);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

