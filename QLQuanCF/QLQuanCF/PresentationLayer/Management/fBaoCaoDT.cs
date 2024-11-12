using QLQuanCF.BusinessLogicLayer;
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
    public partial class fBaoCaoDT : Form
    {
        private readonly BaoCaoBLL _baoCaoBLL = new BaoCaoBLL(Classes.DbConfig.connectString);

        public fBaoCaoDT()
        {
            InitializeComponent();
            LoadBaoCaoData(); 
        }

        private void LoadBaoCaoData(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            try
            {
                // Nếu không có tham số tuNgay, mặc định là 7 ngày trước
                tuNgay = tuNgay ?? DateTime.Now.AddDays(-7);

                // Nếu không có tham số denNgay, mặc định là hôm nay
                denNgay = denNgay ?? DateTime.Now;

                // Retrieve the report data as a DataTable using the date range
                DataTable baoCaoData = _baoCaoBLL.GetBaoCaoByDateRange(tuNgay.Value, denNgay.Value);

                // Check if there is data to display
                if (baoCaoData != null && baoCaoData.Rows.Count > 0)
                {
                    // Assuming you have a DataGridView named dgvBaoCao on the form
                    dgvBaoCao.DataSource = baoCaoData; // Bind the data to the DataGridView
                }
                else
                {
                    MessageBox.Show("No data found for the report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during data retrieval
                MessageBox.Show("An error occurred while loading report data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTongTien()
        {
            try
            {
                DateTime tuNgay = dtpTu.Value;
                DateTime denNgay = dtpDen.Value;

                BaoCaoBLL baoCaoBLL = new BaoCaoBLL(Classes.DbConfig.connectString);
                decimal tongTien = baoCaoBLL.GetTongTienTheoNgay(tuNgay, denNgay);

                // Hiển thị tổng tiền vào TextBox
                txtTongCong.Text = tongTien.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu người dùng chọn ngày từ DateTimePicker
            DateTime? tuNgay = (dtpTu.Checked) ? dtpTu.Value : (DateTime?)null;
            DateTime? denNgay = (dtpDen.Checked) ? dtpDen.Value : (DateTime?)null;

            LoadBaoCaoData(tuNgay, denNgay); // Gọi phương thức LoadBaoCaoData với tham số ngày
            LoadTongTien();
        }


    }
}
