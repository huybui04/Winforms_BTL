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

namespace QLQuanCF.PresentationLayer.Management
{
    public partial class fHoaDonBan : Form
    {
        private HoaDonBanBLL _hoaDonBanBLL;
        private KhachHangBLL _khachHangBLL;
        private SanPhamBLL _sanPhamBLL;
        private BanBLL _banBLL;

        private ErrorProvider errorProvider = new ErrorProvider();
        private bool isAdding, isEditing, isEditingDetails;
        private NhanVien _loggedInNhanVien;

        public fHoaDonBan(NhanVien loggedInNhanVien)
        {
            InitializeComponent();
            _hoaDonBanBLL = new HoaDonBanBLL(Classes.DbConfig.connectString);
            _khachHangBLL = new KhachHangBLL(Classes.DbConfig.connectString);
            _sanPhamBLL = new SanPhamBLL(Classes.DbConfig.connectString);
            _banBLL = new BanBLL(Classes.DbConfig.connectString);

            _loggedInNhanVien = loggedInNhanVien;

            LoadData();
            ShowDetail(false);
            SetButtonState(true, false, false, false, false);
            dataHDB.Dock = DockStyle.Fill;
            txtTenNV.Text = _loggedInNhanVien.TenNV;
            cbMaNV.Text = _loggedInNhanVien.MaNV;
        }

        private void LoadData()
        {
            LoadHDBData();
            LoadKhachHangToComboBox();
            LoadSanPhamToComboBox();
            LoadBanToComboBox();
        }

        private void LoadHDBData()
        {
            dataHDB.DataSource = _hoaDonBanBLL.GetAllHDB();

            cbSearchHDB.DataSource = _hoaDonBanBLL.GetAllHDB();
            cbSearchHDB.DisplayMember = "MaHDB";
            cbSearchHDB.ValueMember = "MaHDB";
            cbSearchHDB.SelectedIndex = -1;
        }
        private void LoadKhachHangToComboBox()
        {
            cbMaKH.DataSource = _khachHangBLL.GetAllKhachHang();
            cbMaKH.DisplayMember = "MaKH";
            cbMaKH.ValueMember = "MaKH";
            cbMaKH.SelectedIndex = -1;
        }

        private void LoadSanPhamToComboBox()
        {
            cbMaSP.DataSource = _sanPhamBLL.GetAllSanPham();
            cbMaSP.DisplayMember = "MaSP";
            cbMaSP.ValueMember = "MaSP";
            cbMaSP.SelectedIndex = -1;
        }

        private void LoadBanToComboBox()
        {
            cbMaBan.DataSource = _banBLL.GetAllBan();
            cbMaBan.DisplayMember = "MaBan";
            cbMaBan.ValueMember = "MaBan";
            cbMaBan.SelectedIndex = -1;
        }

        private void ShowDetail(bool detail)
        {
            cbMaKH.Enabled = detail;
            txtTenKH.Enabled = detail;
            txtDiaChi.Enabled = detail;
            txtSDT.Enabled = detail;

            cbMaSP.Enabled = detail;
            nudSoLuong.Enabled = detail;
            txtKhuyenMai.Enabled = detail;
            txtTenBan.Enabled = detail;

            cbMaBan.Enabled = detail;

            dateNgayBanHDB.Enabled = detail;

        }

        private void ResetFlags()
        {
            isAdding = isEditing = false;
        }

        private void SetButtonState(bool add, bool edit, bool delete, bool save, bool cancel)
        {
            btnAddHDB.Enabled = add;
            btnEditHDB.Enabled = edit;
            btnDeleteHDB.Enabled = delete;
            btnSaveHDB.Enabled = save;
            btnCancelHDB.Enabled = cancel;
        }

        private bool ValidateInput()
        {
            bool isValid = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(cbMaKH.Text))
            {
                errorProvider.SetError(cbMaKH, "Mã nhân viên thực hiện thanh toán không được để trống!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(cbMaNV.Text))
            {
                errorProvider.SetError(cbMaNV, "Mã khách hàng không được để trống!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(dateNgayBanHDB.Text))
            {
                errorProvider.SetError(dateNgayBanHDB, "Ngày tạo hóa đơn không được để trống!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(cbMaBan.Text))
            {
                errorProvider.SetError(txtTenNV, "Mã bàn khách hàng sử dụng không được để trống!");
                isValid = false;
            }

            return isValid;
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.All(char.IsDigit) && phoneNumber.Length >= 10;
        }

        private void ClearInputFields()
        {
            errorProvider.Clear();
            txtMaHDB.Text = "";

            cbMaKH.SelectedIndex = -1;
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";

            cbMaSP.SelectedIndex = -1;
            txtTenSP.Text = "";
            txtDonGia.Text = "";
            nudSoLuong.Value = 0;
            txtKhuyenMai.Text = "";

            cbMaBan.SelectedIndex = -1;
            txtTenBan.Text = "";

            txtThanhTien.Text = "";
            txtTriGia.Text = "";

            dateNgayBanHDB.Value = DateTime.Now;
            cbSearchHDB.SelectedIndex = -1;
        }

        private void ClearDataChiTietHoaDonBan()
        {
            dataChiTietHoaDonBan.DataSource = null;
            dataChiTietHoaDonBan.Rows.Clear();
            dataChiTietHoaDonBan.Columns.Clear();
            dataChiTietHoaDonBan.Refresh();
        }

        private void btnAddHDB_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            dataHDB.Dock = DockStyle.Top;
            dataChiTietHoaDonBan.Visible = true;

            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isAdding = true;
            cbMaKH.Focus();

            if (dataChiTietHoaDonBan.Columns.Count == 0)
            {
                dataChiTietHoaDonBan.Columns.Add("MaSP", "MaSP");
                dataChiTietHoaDonBan.Columns.Add("SLBan", "SLBan");
                dataChiTietHoaDonBan.Columns.Add("KhuyenMai", "KhuyenMai");
                dataChiTietHoaDonBan.Columns.Add("ThanhTien", "ThanhTien");
            }
        }

        private void btnDeleteHDB_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn bán hàng này không?", "Xóa hóa đơn", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ResetFlags();
                _hoaDonBanBLL.DeleteHDB(txtMaHDB.Text);

                ClearInputFields();
                LoadHDBData();
                SetButtonState(true, false, false, false, false);
                ShowDetail(false);
                cbSearchHDB.Focus();
                dataChiTietHoaDonBan.Refresh();
            }
        }

        private void btnEditHDB_Click(object sender, EventArgs e)
        {
            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isEditing = true;

        }

        private void btnExitHDB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveHDB_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                HoaDonBan hoaDonBan = new HoaDonBan
                {
                    MaNV = cbMaNV.Text.ToString(),
                    MaKH = cbMaKH.Text.ToString(),
                    MaBan = cbMaBan.Text.ToString(),
                    NgayBan = dateNgayBanHDB.Value,
                    TriGia = Convert.ToDecimal(txtTriGia.Text),
                    ChiTietHoaDonBans = new List<ChiTietHoaDonBan>()
                };

                foreach (DataGridViewRow row in dataChiTietHoaDonBan.Rows)
                {
                    if (row.Cells["MaSP"].Value != null)
                    {
                        ChiTietHoaDonBan chiTiet = new ChiTietHoaDonBan
                        {
                            MaSP = row.Cells["MaSP"].Value.ToString(),
                            SLBan = Convert.ToInt32(row.Cells["SLBan"].Value),
                            KhuyenMai = row.Cells["KhuyenMai"].Value.ToString(),
                            ThanhTien = Convert.ToDecimal(row.Cells["ThanhTien"].Value)
                        };
                        
                        hoaDonBan.ChiTietHoaDonBans.Add(chiTiet);
                    }
                }

                if (isAdding)
                {
                    _hoaDonBanBLL.AddHDB(hoaDonBan);
                }
                else if (isEditing)
                {
                    hoaDonBan.MaHDB = txtMaHDB.Text;
                    _hoaDonBanBLL.UpdateHoaDonBan(hoaDonBan);
                    if (isEditingDetails)
                    {
                        _hoaDonBanBLL.UpdateChiTietHoaDonBan(hoaDonBan);
                    }
                }

                ClearInputFields();
                ClearDataChiTietHoaDonBan();
                LoadData();
                SetButtonState(true, false, false, false, false);
                ShowDetail(false);
                ResetFlags();
        }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void btnCancelHDB_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            ClearDataChiTietHoaDonBan();
            dataChiTietHoaDonBan.Visible = false;
            dataHDB.Dock = DockStyle.Fill;

            LoadHDBData();
            SetButtonState(true, false, false, false, false);
            ShowDetail(false);
        }

        private void btnSearchHDB_Click(object sender, EventArgs e)
        {
            dataHDB.Dock = DockStyle.Fill;
            dataChiTietHoaDonBan.Visible = false;
            if (string.IsNullOrWhiteSpace(cbSearchHDB.Text))
            {
                LoadData(); return;
            }
            List<HoaDonBan> searchResults = _hoaDonBanBLL.GetHDBByMaHDB(cbSearchHDB.Text);

            if (_hoaDonBanBLL.GetHDBByMaHDB(cbSearchHDB.Text) == null)
            {
                MessageBox.Show($"Không tìm thấy hóa đơn nào có mã {cbSearchHDB.Text}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dataHDB.DataSource = _hoaDonBanBLL.GetHDBByMaHDB(cbSearchHDB.Text);
                SetButtonState(false, false, false, false, true);
                ShowDetail(false);
                ClearInputFields();
            }
        }


        //TODO: nhấn vào đôi lúc các textbox k nhận luôn mà phải nhấn các ô lân cận, có thể xem lại để cải thiện
        private void dataHDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;

            if (dataGridView == null)
                return;

            errorProvider.Clear();
            ShowDetail(false);
            dataChiTietHoaDonBan.Visible = true;
            dataHDB.Dock = DockStyle.Top;

            if (dataGridView.Name == "dataHDB")
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataHDB.Rows.Count)
                {
                    isEditing = true;
                    isEditingDetails = false;

                    DataGridViewRow row = dataHDB.Rows[e.RowIndex];
                    txtMaHDB.Text = row.Cells["MaHDB"].Value.ToString();
                    cbMaNV.Text = row.Cells["MaNV"].Value.ToString();
                    cbMaKH.Text = row.Cells["MaKH"].Value.ToString();
                    cbMaBan.Text = row.Cells["MaBan"].Value.ToString();
                    dateNgayBanHDB.Value = Convert.ToDateTime(row.Cells["NgayBan"].Value);
                    txtTriGia.Text = row.Cells["TriGia"].Value.ToString();
                    SetButtonState(false, true, true, false, true);

                    // Hien thi tren dgv chitietHDB
                    string maHDB = dataHDB.Rows[e.RowIndex].Cells["MaHDB"].Value.ToString();
                    LoadChiTietHoaDonBan(maHDB);
                }
            }
            else if (dataGridView.Name == "dataChiTietHoaDonBan")
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        isEditing = true;
                        isEditingDetails = true;

                        DataGridViewRow row = dataChiTietHoaDonBan.Rows[e.RowIndex];
                        cbMaSP.Text = row.Cells["MaSP"].Value.ToString();
                        nudSoLuong.Value = Convert.ToInt32(row.Cells["SLBan"].Value);
                        txtKhuyenMai.Text = row.Cells["KhuyenMai"].Value.ToString();
                        txtThanhTien.Text = row.Cells["ThanhTien"].Value.ToString();
                        SetButtonState(false, true, true, false, true);
                    }
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Hãy thêm thông tin vào chi tiết hóa đơn trước khi muốn chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataChiTietHoaDonBan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn bán hàng này không?", "Xóa hóa đơn", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        DataGridViewRow row = dataChiTietHoaDonBan.Rows[e.RowIndex];
                        string maHDB = txtMaHDB.Text;
                        string maSP = row.Cells["MaSP"].Value.ToString();
                        
                        _hoaDonBanBLL.DeleteChiTietHoaDonBan(maHDB, maSP);
                        var dataSource = (List<ChiTietHoaDonBan>)dataChiTietHoaDonBan.DataSource;
                        dataSource.RemoveAt(e.RowIndex);
                        dataChiTietHoaDonBan.DataSource = null;
                        dataChiTietHoaDonBan.DataSource = dataSource;
                        
                        UpdateTriGia();
                        SaveUpdatedTriGia();

                        dataHDB.DataSource = null;
                        LoadHDBData();
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine($"Xảy ra lỗi: {ex.Message}");
                    }
                }
            }
        }

        private void SaveUpdatedTriGia()
        {
            string maHDB = txtMaHDB.Text;
            decimal triGia = Convert.ToDecimal(txtTriGia.Text);

            HoaDonBan hoaDonBan = new HoaDonBan
            {
                MaHDB = maHDB,
                TriGia = triGia
            };

            _hoaDonBanBLL.UpdateTriGiaHDB(hoaDonBan);
        }

        private void LoadChiTietHoaDonBan(string maHDB)
        {
            List<ChiTietHoaDonBan> chiTietHoaDonBans = _hoaDonBanBLL.GetChiTietHoaDonBanByMaHDB(maHDB);

            if (chiTietHoaDonBans == null || chiTietHoaDonBans.Count == 0)
            {
                MessageBox.Show("Không có chi tiết hóa đơn nào trong thông tin hóa đơn bán này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataChiTietHoaDonBan.DataSource = chiTietHoaDonBans;
        }


        //KhachHang
        private void txtSDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string diaChi = txtDiaChi.Text.Trim();
                string tenKH = txtTenKH.Text.Trim();
                string sdt = txtSDT.Text.Trim();

                KhachHang khachHang = _khachHangBLL.GetKhachHangBySDT(sdt);

                do
                {
                    if ((string.IsNullOrWhiteSpace(diaChi) || string.IsNullOrWhiteSpace(tenKH) || string.IsNullOrWhiteSpace(sdt)) && IsValidPhoneNumber(sdt))
                    {
                        MessageBox.Show("Hãy nhập đầy đủ thông tin về khách hàng mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                } while (string.IsNullOrWhiteSpace(diaChi) || string.IsNullOrWhiteSpace(tenKH) || string.IsNullOrWhiteSpace(sdt));


                if (khachHang == null)
                {
                    khachHang = new KhachHang
                    {
                        TenKH = tenKH,
                        DiaChi = diaChi,
                        DienThoai = sdt
                    };

                    _khachHangBLL.AddKhachHang(khachHang);
                    MessageBox.Show("Tạo khách hàng mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                cbMaKH.Text = khachHang.MaKH;
                txtTenKH.Text = khachHang.TenKH;
                txtDiaChi.Text = khachHang.DiaChi;
            }
        }
        private void cbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaKH.SelectedIndex != -1)
            {
                string selectedMaKH = cbMaKH.SelectedValue.ToString();
                KhachHang selectedKH = _khachHangBLL.GetKhachHangByMaKH(selectedMaKH);
                if (selectedKH != null)
                {
                    txtTenKH.Text = selectedKH.TenKH;
                    txtDiaChi.Text = selectedKH.DiaChi;
                    txtSDT.Text = selectedKH.DienThoai;
                }
            }
        }

        //SanPham
        private void cbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaSP.SelectedIndex != -1)
            {
                string selectedMaSP = cbMaSP.SelectedValue.ToString();
                SanPham selectedSanPham = _sanPhamBLL.GetSanPhamByMaSanPham(selectedMaSP);
                if (selectedSanPham != null)
                {
                    txtTenSP.Text = selectedSanPham.TenSP;
                    txtDonGia.Text = selectedSanPham.Gia.ToString();
                }
            }
        }

        private void txtKhuyenMai_Leave(object sender, EventArgs e)
        {
            if(txtKhuyenMai.Text != "" && nudSoLuong.Value != 0)
            {
                int soLuong = Convert.ToInt32(nudSoLuong.Value);
                if (decimal.TryParse(txtDonGia.Text, out decimal donGia) && decimal.TryParse(txtKhuyenMai.Text, out decimal khuyenMai))
                {
                    decimal thanhTien = donGia * soLuong * (1 - khuyenMai / 100);
                    txtThanhTien.Text = thanhTien.ToString("F2");
                }
                else
                {
                    txtThanhTien.Text = "0.00";
                }
                AddChiTietHoaDonBanToDataHDB();
            }
        }
        private void AddChiTietHoaDonBanToDataHDB()
        {
            if (cbMaSP.SelectedIndex != -1)
            {
                string selectedMaSP = cbMaSP.SelectedValue.ToString();
                int soLuong = Convert.ToInt32(nudSoLuong.Value);
                decimal donGia = decimal.Parse(txtDonGia.Text);
                decimal khuyenMai = decimal.Parse(txtKhuyenMai.Text);
                decimal thanhTien = donGia * soLuong * (1 - khuyenMai / 100);

                bool productExists = false;

                foreach (DataGridViewRow row in dataChiTietHoaDonBan.Rows)
                {
                    if (row.Cells["MaSP"].Value != null && row.Cells["MaSP"].Value.ToString() == selectedMaSP)
                    {
                        int existingQuantity = Convert.ToInt32(row.Cells["SLBan"].Value);
                        if (isEditingDetails)
                        {
                            row.Cells["SLBan"].Value = soLuong;
                        }
                        else
                        {
                            row.Cells["SLBan"].Value = existingQuantity + soLuong;
                        }
                        row.Cells["ThanhTien"].Value = (existingQuantity + soLuong) * donGia * (1 - khuyenMai / 100);
                        productExists = true;
                        break;
                    }
                }

                if (!productExists)
                {
                    dataChiTietHoaDonBan.Rows.Add(selectedMaSP, soLuong, khuyenMai, thanhTien);
                }

                UpdateTriGia();

                //xoa 1 so txtbox de them sp vao cthdb moi
                CreateNewCTHDB();
            }
        }

        private void UpdateTriGia()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataChiTietHoaDonBan.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                }
            }
            txtTriGia.Text = total.ToString("F2");
        }

        private void CreateNewCTHDB()
        {
            cbMaSP.SelectedIndex = -1;
            txtTenSP.Text = "";
            txtDonGia.Text = "";
            nudSoLuong.Value = 0;
            txtKhuyenMai.Text = "";
            txtThanhTien.Text = "";
        }

        //Ban
        private void cbMaBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaBan.SelectedIndex != -1)
            {
                string selectedMaBan = cbMaBan.SelectedValue.ToString();
                Ban selectedBan = _banBLL.GetBanByMaBan(selectedMaBan);
                if (selectedBan != null)
                {
                    txtTenBan.Text = selectedBan.TenBan;
                }
            }
        }
    }
}
