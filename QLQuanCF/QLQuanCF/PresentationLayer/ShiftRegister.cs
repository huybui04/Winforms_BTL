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
    public partial class ShiftRegister : Form
    {
        private NhanVien _loggedInNhanVien;
        private CaLamViecBLL caLamViecBLL;
        private ChiTietLuongBLL chiTietLuongBLL;
        private bool isValid = false;

        public ShiftRegister(NhanVien loggedInNhanVien)
        {
            InitializeComponent();

            caLamViecBLL = new CaLamViecBLL(Classes.DbConfig.connectString);
            chiTietLuongBLL = new ChiTietLuongBLL(Classes.DbConfig.connectString);
            _loggedInNhanVien = loggedInNhanVien;
            btnRegister.Enabled = isValid;

        }

        //btn exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Load data
        private void ShiftRegister_Load(object sender, EventArgs e)
        {
            cbMaNV.Text = _loggedInNhanVien.MaNV;
            txtTenNV.Text = _loggedInNhanVien.TenNV;

            LoadCBCaLamViec();
            SetDateTimePickerRange(dateNgayDK);
            
        }

        private void LoadCBCaLamViec()
        {
            cbMaCa.DataSource = caLamViecBLL.GetAllCaLamViec();
            cbMaCa.DisplayMember = "MaCa";
            cbMaCa.ValueMember = "MaCa";
            cbMaCa.SelectedIndex = -1;
        }

        private void LoadDataNgayDK()
        {
            dataNgayDK.DataSource = chiTietLuongBLL.GetChiTietLuongByDate(dateNgayDK.Value);
        }

        //Hien thi ngay trong 1 tuan
        private void SetDateTimePickerRange(DateTimePicker dtp)
        {
            DateTime today = DateTime.Today;
            //DateTime today = new DateTime(2024, 11, 11);

             //Tính ngày đầu tuần (Thứ Hai) và ngày cuối tuần (Chủ Nhật)
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday+7);
            if (today.DayOfWeek == DayOfWeek.Sunday)
            {
                startOfWeek = startOfWeek.AddDays(-7);
            }
            DateTime endOfWeek = startOfWeek.AddDays(6);
            
            dtp.MinDate = startOfWeek;
            dtp.MaxDate = endOfWeek;
        }

        //cbMaCa
        private void cbMaCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbMaCa.SelectedIndex != -1)
            {
                isValid = true;
                txtTenCa.Text = ((CaLamViec)cbMaCa.SelectedItem).TenCa;
            }
        }

        //Xu ly event chon ngay
        private void dateNgayDK_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateNgayDK.Value;

            List<ChiTietLuong> chiTietLuongs = chiTietLuongBLL.GetChiTietLuongByDate(selectedDate);
            dataNgayDK.DataSource = chiTietLuongs;
        }

        //btn Dang ky
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(cbMaCa.Text == "")
            {
                MessageBox.Show("Vui lòng chọn ca làm việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ChiTietLuong ct = new ChiTietLuong();
            ct.MaNV = cbMaNV.Text;
            ct.MaCa = cbMaCa.Text;
            ct.Ngay = dateNgayDK.Value;

            if (chiTietLuongBLL.GetChiTietLuongByShiftAndDay(ct.MaCa, ct.Ngay).Count < 4 )
            {
                //kiem tra cac gtri da ton tai chua
                foreach (DataGridViewRow row in dataNgayDK.Rows)
                {
                    if (row.Cells["MaNV"].Value.ToString() == ct.MaNV && row.Cells["MaCa"].Value.ToString() == ct.MaCa &&
                        Convert.ToDateTime(row.Cells["Ngay"].Value) == ct.Ngay)
                    {
                        MessageBox.Show("Đã đăng ký ca làm việc này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                chiTietLuongBLL.AddChiTietLuong(ct);
                MessageBox.Show($"Đăng ký {ct.MaCa} vào ngày {ct.Ngay} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataNgayDK();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
