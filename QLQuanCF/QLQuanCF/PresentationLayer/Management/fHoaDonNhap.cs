using QLQuanCF.BusinessLogicLayer;
using QLQuanCF.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLQuanCF.PresentationLayer.Management
{
    public partial class fHoaDonNhap : Form
    {
        private HoaDonNhapBLL _hoaDonNhapBLL;
        private ErrorProvider errorProvider = new ErrorProvider();
        private bool isAdding, isEditing;

        public fHoaDonNhap()
        {
            InitializeComponent();
            _hoaDonNhapBLL = new HoaDonNhapBLL(Classes.DbConfig.connectString);
            LoadHoaDonNhapData();
            ShowDetail(false);
            SetButtonState(true, false, false, false, false);

            btnAddHDN.Paint += Button_Paint;
            btnEditHDN.Paint += Button_Paint;
            btnDeleteHDN.Paint += Button_Paint;
            btnSaveHDN.Paint += Button_Paint;
            btnCancelHDN.Paint += btnCancel_Paint;
            btnSearchHDN.Paint += Button_Paint;
            btnExitHDN.Paint += Button_Paint;
        }

        private void LoadHoaDonNhapData()
        {
            dataHDN.DataSource = _hoaDonNhapBLL.GetAllHoaDonNhap();
        }
        private void LoadChiTietHoaDonNhap()
        {
            dataChiTietHoaDonNhap.DataSource = _hoaDonNhapBLL.GetChiTietHoaDonNhapByMaHDN(txtMaHDN.Text);

        }

        private void fHoaDonNhap_Load(object sender, EventArgs e)
        {
            DataTable maNguyenLieuTable = _hoaDonNhapBLL.GetAllMaNguyenLieu();
            cbMaNLHDN.DataSource = maNguyenLieuTable;
            cbMaNLHDN.DisplayMember = "MaNL";
            cbMaNLHDN.ValueMember = "MaNL";
            nudSLNhapHDN.ValueChanged += (s, ev) => UpdateThanhTien();
            cbMaNLHDN.SelectedIndexChanged += (s, ev) => UpdateThanhTien();

            dataHDN.CellClick += new DataGridViewCellEventHandler(dataHDN_CellClick);
            dataChiTietHoaDonNhap.CellClick += new DataGridViewCellEventHandler(dataChiTietHoaDonNhap_CellClick);
            btnAddHDN.Click += new EventHandler(btnAddHDN_Click);
            btnEditHDN.Click += new EventHandler(btnEditHDN_Click);
            btnSaveHDN.Click += new EventHandler(btnSaveHDN_Click);
            btnDeleteHDN.Click += new EventHandler(btnDeleteHDN_Click);
            btnCancelHDN.Click += new EventHandler(btnCancelHDN_Click);
            btnSearchHDN.Click += new EventHandler(btnSearchHDN_Click);
        }
        private void Button_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            int textX = (btn.Width - TextRenderer.MeasureText(btn.Text, btn.Font).Width) / 2;

            if (btn.Enabled)
            {
                e.Graphics.Clear(btn.BackColor);
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, new Rectangle(textX, 0, btn.Width - textX, btn.Height), Color.White, TextFormatFlags.VerticalCenter);
            }
            else
            {
                e.Graphics.Clear(Color.Gray);
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, new Rectangle(textX, 0, btn.Width - textX, btn.Height), Color.White, TextFormatFlags.VerticalCenter);
            }
        }
        private void btnCancel_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            if (btn.Enabled)
            {
                e.Graphics.Clear(Color.White);
                ControlPaint.DrawBorder(e.Graphics, btn.ClientRectangle, Color.RoyalBlue, ButtonBorderStyle.Solid);
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, Color.RoyalBlue, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter); // Chữ màu royal blue
            }
            else
            {
                e.Graphics.Clear(Color.Gray);
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter); // Chữ màu trắng
            }
        }

        private void ShowDetail(bool detail)
        {
            txtTriGiaHDN.Enabled = detail;
        }

        private void ResetFlags()
        {
            isAdding = isEditing = false;
        }

        private void SetButtonState(bool add, bool edit, bool delete, bool save, bool cancel)
        {
            btnAddHDN.Enabled = add;
            btnEditHDN.Enabled = edit;
            btnDeleteHDN.Enabled = delete;
            btnSaveHDN.Enabled = save;
            btnCancelHDN.Enabled = cancel;
            btnCancelHDN.Invalidate();
        }
        private bool ValidateInput()
        {
            bool isValid = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtTriGiaHDN.Text))
            {
                errorProvider.SetError(txtTriGiaHDN, "Trị giá không được để trống!");
                isValid = false;
            }

            return isValid;
        }

        private void ClearInputField()
        {
            errorProvider.Clear();
            txtMaHDN.Clear();
            txtTriGiaHDN.Clear();
            txtMaNVHDN.Clear();
            txtMaNCCHDN.Clear();
            dtpNgayNhapHDN.Value = DateTime.Now;
        }

        private void btnDeleteHDN_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn nhập này không?", "Xóa hóa đơn nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ResetFlags();
                _hoaDonNhapBLL.DeleteHoaDonNhap(txtMaHDN.Text);
                ClearInputField();
                LoadHoaDonNhapData();
                SetButtonState(true, false, false, false, false);
                ShowDetail(false);
                MessageBox.Show("Hóa đơn nhập và các chi tiết của nó đã được xóa.", "Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearchHDN.Focus();
            }
            else if (result == DialogResult.No)
            {
                var detailResult = MessageBox.Show("Bạn có muốn xóa chi tiết hóa đơn nhập này không?", "Xóa Chi Tiết Hóa Đơn Nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (detailResult == DialogResult.Yes)
                {
                    DeleteChiTietHoaDonNhap();
                }
            }
        }
        private void DeleteHoaDonNhap()
        {
            if (!string.IsNullOrEmpty(txtMaHDN.Text))
            {
                _hoaDonNhapBLL.DeleteHoaDonNhap(txtMaHDN.Text);
                LoadHoaDonNhapData();
                LoadChiTietHoaDonNhap();
                MessageBox.Show("Hóa đơn nhập và tất cả các chi tiết của nó đã được xóa.", "Xóa Thành Công");
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã hóa đơn nhập để xóa.", "Thông báo");
            }
        }
        private void DeleteChiTietHoaDonNhap()
        {
            if (dataChiTietHoaDonNhap.SelectedRows.Count > 0)
            {
                var selectedRow = dataChiTietHoaDonNhap.SelectedRows[0];
                string maHDN = txtMaHDN.Text;
                string maNL = selectedRow.Cells["MaNL"].Value.ToString();
                var hoaDonNhap = new HoaDonNhap
                {
                    MaHDN = txtMaHDN.Text,
                    MaNV = txtMaNVHDN.Text,
                    MaNCC = txtMaNCCHDN.Text,
                    NgayNhap = dtpNgayNhapHDN.Value,
                    TriGia = decimal.Parse(txtTriGiaHDN.Text)
                };

                _hoaDonNhapBLL.DeleteChiTietHoaDonNhap(maHDN, maNL);

                _hoaDonNhapBLL.UpdateHoaDonNhap(hoaDonNhap);
                LoadChiTietHoaDonNhap();
                LoadHoaDonNhapData();

                MessageBox.Show("Chi tiết hóa đơn nhập đã được xóa và trị giá hóa đơn đã được cập nhật.", "Xóa Thành Công");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một chi tiết hóa đơn nhập để xóa.", "Thông báo");
            }
        }

        private void btnEditHDN_Click(object sender, EventArgs e)
        {
            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isEditing = true;
        }

        private void btnSaveHDN_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var hoaDonNhap = new HoaDonNhap
            {
                MaHDN = txtMaHDN.Text,
                MaNV = txtMaNVHDN.Text,
                MaNCC = txtMaNCCHDN.Text,
                NgayNhap = dtpNgayNhapHDN.Value,
                TriGia = decimal.Parse(txtTriGiaHDN.Text)
            };

            string maNL = cbMaNLHDN.SelectedValue.ToString();
            int slNhap = (int)nudSLNhapHDN.Value;
            decimal giaNL = _hoaDonNhapBLL.GetGiaNguyenLieu(maNL);
            decimal thanhTien = slNhap * giaNL;

            if (isAdding)
            {
                var existingHoaDonNhap = _hoaDonNhapBLL.GetHoaDonNhapByMaHDN(hoaDonNhap.MaHDN);
                if (existingHoaDonNhap == null)
                {
                    _hoaDonNhapBLL.AddHoaDonNhap(hoaDonNhap);
                }
                _hoaDonNhapBLL.AddOrUpdateChiTietHoaDonNhap(txtMaHDN.Text, maNL, slNhap, thanhTien);
            }
            else if (isEditing)
            {
                if (originalMaNL != null && originalMaNL != maNL)
                {
                    _hoaDonNhapBLL.DeleteChiTietHoaDonNhap(txtMaHDN.Text, originalMaNL);
                    _hoaDonNhapBLL.AddChiTietHoaDonNhap(txtMaHDN.Text, maNL, slNhap, thanhTien);
                }
                else
                {
                    _hoaDonNhapBLL.UpdateChiTietHoaDonNhap(txtMaHDN.Text, maNL, slNhap, thanhTien);
                }
            }
            ClearInputField();
            LoadHoaDonNhapData();
            SetButtonState(true, false, false, false, false);
            ShowDetail(false);
            ResetFlags();
            txtSearchHDN.Focus();
        }
        private string originalMaNL;

        private void btnSearchHDN_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchHDN.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadHoaDonNhapData();
                return;
            }

            var result = _hoaDonNhapBLL.SearchHoaDonNhap(keyword);

            if (result == null || result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hóa đơn nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataHDN.DataSource = result;
            SetButtonState(false, false, false, false, true);
            ShowDetail(false);
            ClearInputField();
        }

        private void btnCancelHDN_Click(object sender, EventArgs e)
        {
            ClearInputField();
            LoadHoaDonNhapData();
            SetButtonState(true, false, false, false, false);
            dataChiTietHoaDonNhap.DataSource = null;
            cbMaNLHDN.Text = string.Empty;
            nudSLNhapHDN.Value = 0;
            txtThanhTienHDN.Text = string.Empty;
        }

        private void dataHDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider.Clear();
            ShowDetail(false);

            if (e.RowIndex >= 0)
            {
                string maHDN = dataHDN.Rows[e.RowIndex].Cells["MaHDN"].Value.ToString();

                DataGridViewRow row = dataHDN.Rows[e.RowIndex];
                txtMaHDN.Text = row.Cells["MaHDN"].Value.ToString();
                txtMaNVHDN.Text = row.Cells["MaNV"].Value.ToString();
                txtMaNCCHDN.Text = row.Cells["MaNCC"].Value.ToString();
                dtpNgayNhapHDN.Value = Convert.ToDateTime(row.Cells["NgayNhap"].Value);
                txtTriGiaHDN.Text = row.Cells["TriGia"].Value?.ToString();

                dataChiTietHoaDonNhap.DataSource = _hoaDonNhapBLL.GetChiTietHoaDonNhapByMaHDN(maHDN);

                SetButtonState(false, true, true, false, true);
                txtThanhTienHDN.Text = string.Empty;
            }
        }
        private void dataChiTietHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider.Clear();
            ShowDetail(false);

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataChiTietHoaDonNhap.Rows[e.RowIndex];

                cbMaNLHDN.Text = row.Cells["MaNL"].Value?.ToString();
                nudSLNhapHDN.Value = row.Cells["SLNhap"].Value != null
                    ? Convert.ToDecimal(row.Cells["SLNhap"].Value)
                    : 0;

                txtThanhTienHDN.Text = row.Cells["ThanhTien"].Value?.ToString();
                originalMaNL = row.Cells["MaNL"].Value?.ToString();
            }
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void btnExitHDN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel49_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddHDN_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDeleteHDN_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAddHDN_Click(object sender, EventArgs e)
        {
            ClearInputField();
            ShowDetail(true);
            SetButtonState(false, false, false, true, true);
            ResetFlags();
            isAdding = true;
            txtTriGiaHDN.Focus();
            LoadChiTietHoaDonNhap();
        }
        private void UpdateThanhTien()
        {
            if (cbMaNLHDN.SelectedItem != null && nudSLNhapHDN.Value > 0)
            {
                string maNL = cbMaNLHDN.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(maNL))
                    return;

                decimal giaNL = _hoaDonNhapBLL.GetGiaNguyenLieu(maNL);

                decimal thanhTien = giaNL * nudSLNhapHDN.Value;
                txtThanhTienHDN.Text = thanhTien.ToString("N2");

                if (dataChiTietHoaDonNhap.CurrentRow != null)
                {
                    dataChiTietHoaDonNhap.CurrentRow.Cells["ThanhTien"].Value = thanhTien;
                }
                UpdateTriGiaHDN();
            }
        }

        private decimal CalculateTriGiaHDN()
        {
            decimal triGia = 0;

            foreach (DataGridViewRow row in dataChiTietHoaDonNhap.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null && row.Cells["ThanhTien"].Value != DBNull.Value)
                {
                    triGia += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                }
            }
            return triGia;
        }

        private void txtThanhTienHDN_TextChanged(object sender, EventArgs e)
        {
            UpdateTriGiaHDN();
        }

        private void dataChiTietHoaDonNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UpdateTriGiaHDN()
        {
            decimal triGia = 0;

            foreach (DataGridViewRow row in dataChiTietHoaDonNhap.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null && row.Cells["ThanhTien"].Value != DBNull.Value)
                {
                    triGia += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                }
            }

            txtTriGiaHDN.Text = triGia.ToString("N2");
        }
    }
}