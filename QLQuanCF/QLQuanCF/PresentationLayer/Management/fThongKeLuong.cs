using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLQuanCF.Models;
using QLQuanCF.BusinessLogicLayer;
using QLQuanCF.DataAccessLayer;

namespace QLQuanCF.PresentationLayer.Management
{
    public partial class fThongKeLuong : Form
    {
        private NhanVienBLL nhanVienBLL;
        private ChiTietLuongBLL chiTietLuongBLL;
        private CaLamViecBLL caLamViecBLL;
        private bool isDetails, isCheck;

        public fThongKeLuong()
        {
            InitializeComponent();

            nhanVienBLL = new NhanVienBLL(Classes.DbConfig.connectString);
            caLamViecBLL = new CaLamViecBLL(Classes.DbConfig.connectString);
            chiTietLuongBLL = new ChiTietLuongBLL(Classes.DbConfig.connectString);
            isDetails = false;
            isCheck = false;
            dataLuong.Dock = DockStyle.Fill;
            dataChiTietLuong.Visible = false;
        }

        private void fThongKeLuong_Load(object sender, EventArgs e)
        {
            LoadCBNhanVien();
            LoadCBCaLamViec();
            LoadDataLuong();
            SetMaxDateForDateTimePicker();

            ClearFormInputs();
        }

        private void ClearFormInputs()
        {
            cbMaNV.SelectedIndex = -1;
            cbMaCa.SelectedIndex = -1;
            txtTenNV.Text = "";
            txtChucVu.Text = "";
            txtTenCa.Text = "";
            txtLuong.Text = "";
            txtTongLuong.Text = "";
        }

        private void LoadCBNhanVien()
        {
            cbMaNV.DataSource = nhanVienBLL.GetAllNhanVien();
            cbMaNV.DisplayMember = "MaNV";
            cbMaNV.ValueMember = "MaNV";
            cbMaNV.SelectedIndex = -1;

            cbSearch.DataSource = nhanVienBLL.GetAllNhanVien();
            cbSearch.DisplayMember = "MaNV";
            cbSearch.ValueMember = "MaNV";
            cbSearch.SelectedIndex = -1;
        }

        private void LoadCBCaLamViec()
        {
            cbMaCa.DataSource = caLamViecBLL.GetAllCaLamViec();
            cbMaCa.DisplayMember = "MaCa";
            cbMaCa.ValueMember = "MaCa";
            cbMaCa.SelectedIndex = -1;
        }

        private void LoadDataLuong()
        {
            dataLuong.DataSource = chiTietLuongBLL.GetLuongAndSoLuongMoiCa(dateNgayDK.Value);
        }

        private void LoadDataChiTietLuong()
        {
            if (cbMaNV.SelectedIndex != -1 && cbMaCa.SelectedIndex != -1)
            {
                string maNV = cbMaNV.SelectedValue.ToString();
                string maCa = cbMaCa.SelectedValue.ToString();
                DateTime thang = dateNgayDK.Value;

                dataChiTietLuong.DataSource = chiTietLuongBLL.GetChiTietThongKeLuong(maNV, maCa, thang);
            }
        }

        private void LoadDataFindSalaryByMaNV()
        {
            dataLuong.DataSource = chiTietLuongBLL.GetLuongThangByMaNV(cbSearch.SelectedValue.ToString(), dateNgayDK.Value);
        }

        private void ThongKeLuong()
        {
            dataLuong.DataSource = chiTietLuongBLL.ThongKeLuongThang(dateNgayDK.Value);
        }

        private void SetButtonState(bool details, bool print, bool cancel)
        {
            btnThongKe.Enabled = details;
            btnIn.Enabled = print;
            btnCancel.Enabled = cancel;
        }

        private void SetMaxDateForDateTimePicker()
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfCurrentMonth = new DateTime(today.Year, today.Month, 1);
            DateTime lastDayOfPreviousMonth = firstDayOfCurrentMonth.AddDays(-1);

            dateNgayDK.MaxDate = lastDayOfPreviousMonth;
        }

        private void dateNgayDK_ValueChanged(object sender, EventArgs e)
        {
            LoadDataLuong();
            if(dataLuong.Rows.Count == 0)
            {
                MessageBox.Show("Chưa thêm dữ liệu lương cho tháng này.");
            }
        }

        private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbMaNV.SelectedIndex != -1)
            {
                NhanVien nhanVien = (NhanVien)cbMaNV.SelectedItem;
                txtTenNV.Text = nhanVien.TenNV;
                txtChucVu.Text = nhanVien.ChucVu;
            }
        }

        private void cbMaCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaCa.SelectedIndex != -1)
            {
                CaLamViec caLamViec = (CaLamViec)cbMaCa.SelectedItem;
                txtTenCa.Text = caLamViec.TenCa;
                txtLuong.Text = caLamViec.Luong.ToString();
            }
        }

        private void btnExitHDB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataChiTietLuong.Visible = true;
            dataLuong.Dock = DockStyle.Top;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataLuong.Rows[e.RowIndex];
                DataGridViewColumn column = dataLuong.Columns[e.ColumnIndex];

                if (column.HeaderText == "SoLuongCa001")
                {
                    cbMaCa.Text = "CA001";
                    cbMaNV.Text = row.Cells["MaNV"].Value.ToString();
                    txtTongLuong.Text = row.Cells["TongTien"].Value.ToString();
                    LoadDataChiTietLuong();
                }
                else if (column.HeaderText == "SoLuongCa002")
                {
                    cbMaCa.Text = "CA002";
                    cbMaNV.Text = row.Cells["MaNV"].Value.ToString();
                    txtTongLuong.Text = row.Cells["TongTien"].Value.ToString();
                    LoadDataChiTietLuong();
                }
                else if (column.HeaderText == "SoLuongCa003")
                {
                    cbMaCa.Text = "CA003";
                    cbMaNV.Text = row.Cells["MaNV"].Value.ToString();
                    txtTongLuong.Text = row.Cells["TongTien"].Value.ToString();
                    LoadDataChiTietLuong();
                }

                if (isDetails)
                {
                    cbMaNV.Text = row.Cells["MaNV"].Value.ToString();
                    txtTongLuong.Text = row.Cells["TongLuong"].Value.ToString();
                    dataChiTietLuong.Visible = false;
                    dataLuong.Dock = DockStyle.Fill;
                }
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isCheck = true;
            isDetails = false;
            ClearFormInputs();
            LoadDataLuong();
            SetButtonState(true, false, false);
            dataChiTietLuong.Visible = true;
            dataLuong.Dock = DockStyle.Fill;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataLuong.Dock = DockStyle.Fill;
            dataChiTietLuong.Visible= false;
            if (string.IsNullOrWhiteSpace(cbSearch.Text))
            {
                MessageBox.Show($"Không tìm thấy thông tin về lương của nhân viên có mã {cbMaNV.Text}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (chiTietLuongBLL.GetLuongThangByMaNV(cbSearch.Text, dateNgayDK.Value).Count == 0)
            {
                MessageBox.Show($"Không tìm thấy thông tin về lương của nhân viên có mã {cbMaNV.Text}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dataLuong.DataSource = chiTietLuongBLL.GetLuongThangByMaNV(cbSearch.Text, dateNgayDK.Value);
                SetButtonState(true, false, true);
                ClearFormInputs();
                DataGridViewRow row = dataLuong.Rows[0];
                cbMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtTongLuong.Text = row.Cells["TongLuong"].Value.ToString();
                dataChiTietLuong.Visible = false;
                dataLuong.Dock = DockStyle.Fill;
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeLuong();
            dataChiTietLuong.DataSource = null;
            isDetails = true;

            ClearFormInputs();
            SetButtonState(false, true, true);
            dataChiTietLuong.Visible = false;
            dataLuong.Dock = DockStyle.Fill;
        }
    }
}
