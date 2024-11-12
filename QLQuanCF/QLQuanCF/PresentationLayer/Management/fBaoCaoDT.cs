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
            LoadTongTien();
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
                    // Bind the data to the DataGridView
                    dgvBaoCao.DataSource = baoCaoData;
                }
                else
                {
                    MessageBox.Show("Không có báo cáo nào được tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Get the selected dates from the DateTimePickers (ensure they are not null)
                DateTime tuNgay = dtpTu.Checked ? dtpTu.Value : DateTime.Now.AddDays(-7); // Default to 7 days ago if not checked
                DateTime denNgay = dtpDen.Checked ? dtpDen.Value : DateTime.Now; // Default to today if not checked

                // Calculate the total amount
                decimal tongTien = _baoCaoBLL.GetTongTienTheoNgay(tuNgay, denNgay);

                // Display the total amount in the TextBox
                txtTongCong.Text = tongTien.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the user selected dates from DateTimePickers
                DateTime? tuNgay = dtpTu.Checked ? (DateTime?)dtpTu.Value : null; // Use selected date or null if unchecked
                DateTime? denNgay = dtpDen.Checked ? (DateTime?)dtpDen.Value : null; // Use selected date or null if unchecked

                // Call LoadBaoCaoData with the selected date range
                LoadBaoCaoData(tuNgay, denNgay);

                // Call LoadTongTien to calculate the total amount
                LoadTongTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
