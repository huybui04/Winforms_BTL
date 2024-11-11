using QLQuanCF.BusinessLogicLayer;
using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QLQuanCF
{
    public partial class fMenuSelection : Form
    {
		private DMSanPhamBLL _danhMucBLL = new DMSanPhamBLL(Classes.DbConfig.connectString);
		private SanPhamBLL _sanPhamBLL = new SanPhamBLL(Classes.DbConfig.connectString);

		private Dictionary<string, bool> checkboxStates = new Dictionary<string, bool>();
		private List<SanPham> listSanPham = new List<SanPham>();
		private List<SanPham> selectedSanPhamList = new List<SanPham>();


		public fMenuSelection()
        {
            InitializeComponent();
			LoadDanhMuc();
			LoadDgvSanPham();
		}

		private void LoadDanhMuc()
		{
			List<DanhMucSanPham> danhMucList = _danhMucBLL.GetAllDanhMucSanPham();

			foreach (DanhMucSanPham danhMuc in danhMucList)
			{
				cbDM.Items.Add(danhMuc);
			}

			cbDM.DisplayMember = "TenDM";  
			cbDM.ValueMember = "MaDM";    
		}

		private void LoadDgvSanPham()
		{
			if (dgvSP.Columns.Count == 0)
			{
				CreateCheckBoxColumn();
			}

			List<SanPham> sanPhamList = _sanPhamBLL.GetAllSanPham();
			dgvSP.Rows.Clear();
			listSanPham.Clear(); 

			foreach (SanPham sanPham in sanPhamList)
			{
				listSanPham.Add(sanPham); 
				AddSanPhamRow(sanPham);  
			}
		}

		private void AddSanPhamRow(SanPham sanPham)
		{
			string imagePath = Path.Combine(Application.StartupPath, "Images", sanPham.Anh);
			Image image = File.Exists(imagePath) ? Image.FromFile(imagePath) : null;

			bool isChecked = checkboxStates.ContainsKey(sanPham.TenSP) && checkboxStates[sanPham.TenSP];
			dgvSP.Rows.Add(isChecked, sanPham.TenSP, sanPham.Gia, image);
		}

		private void CreateCheckBoxColumn()
		{
			dgvSP.Columns.Clear();

			DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
			chk.HeaderText = "Chọn";
			chk.Name = "chkSelect";
			chk.Width = 50;
			chk.TrueValue = true;
			chk.FalseValue = false;

			dgvSP.Columns.Add(chk);

			dgvSP.Columns.Add("TenSP", "Tên Sản Phẩm");
			dgvSP.Columns["TenSP"].Width = 200;

			dgvSP.Columns.Add("Gia", "Giá");
			dgvSP.Columns["Gia"].Width = 100;

			DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
			imgColumn.HeaderText = "Ảnh";
			imgColumn.Name = "Anh";
			imgColumn.Width = 100;
			imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
			dgvSP.Columns.Add(imgColumn);

			dgvSP.RowTemplate.Height = 80;
		}

		private void cbDM_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbDM.SelectedItem is DanhMucSanPham selectedDanhMuc)
			{
				string maDM = selectedDanhMuc.MaDM;
				LoadSanPhamTheoDanhMuc(maDM);
			}
		}

		private void LoadSanPhamTheoDanhMuc(string maDM)
		{
			dgvSP.Rows.Clear();

			List<SanPham> sanPhamList = _sanPhamBLL.GetSanPhamByDanhMuc(maDM);

			foreach (SanPham sanPham in sanPhamList)
			{
				AddSanPhamRow(sanPham);
			}
		}

		private void btnSearchMon_Click(object sender, EventArgs e)
		{
			string searchTerm = txtSearchMon.Text.Trim();

			if (!string.IsNullOrEmpty(searchTerm))
			{
				dgvSP.Rows.Clear();
				LoadSanPhamTheoTen(searchTerm);
			}
			else
			{
				MessageBox.Show("Vui lòng nhập tên sản phẩm để tìm kiếm.");
			}
		}

		private void LoadSanPhamTheoTen(string tenSP)
		{
			try
			{
				List<SanPham> sanPhamList = _sanPhamBLL.GetSanPhamByName(tenSP);

				foreach (SanPham sanPham in sanPhamList)
				{
					AddSanPhamRow(sanPham);
				}

				dgvSP.ClearSelection();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tìm kiếm sản phẩm: " + ex.Message);
			}
		}	

		private void dgvSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && dgvSP.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
			{
				string tenSP = dgvSP.Rows[e.RowIndex].Cells["TenSP"].Value?.ToString();
				if (!string.IsNullOrEmpty(tenSP))
				{
					bool isChecked = Convert.ToBoolean(dgvSP.Rows[e.RowIndex].Cells["chkSelect"].EditedFormattedValue);
					checkboxStates[tenSP] = isChecked;
				}
			}
		}

		private void btnThoat_Click(object sender, EventArgs e)
        {
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btnChonMon_Click(object sender, EventArgs e)
		{
			LayDanhSachMonDaChon();

			fMain formMain = (fMain)Application.OpenForms["fMain"];
			if (formMain == null)
			{
				MessageBox.Show("Không tìm thấy form chính.");
				return;
			}

			if (selectedSanPhamList.Count > 0)
			{
				// Thêm các món vào danh sách trong form chính, tránh trùng lặp
				foreach (var sanPham in selectedSanPhamList)
				{
					if (!formMain.selectedSanPhamList.Any(sp => sp.MaSP == sanPham.MaSP))
					{
						formMain.selectedSanPhamList.Add(sanPham);
					}
				}
				MessageBox.Show("Đã thêm món vào danh sách thành công.");

				// Đặt DialogResult thành OK để form chính biết rằng đã có món được chọn
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				MessageBox.Show("Vui lòng chọn ít nhất một món.");
			}
		}

		private void LayDanhSachMonDaChon()
		{
			selectedSanPhamList.Clear(); 

			foreach (DataGridViewRow row in dgvSP.Rows)
			{
				// Giả sử có cột checkbox để xác định món được chọn
				bool isSelected = Convert.ToBoolean(row.Cells["chkSelect"].Value);
				if (isSelected)
				{
					SanPham sp = new SanPham
					{
						TenSP = row.Cells["TenSP"].Value.ToString(),
						Gia = Convert.ToDecimal(row.Cells["Gia"].Value)
					};
					selectedSanPhamList.Add(sp);
				}
			}
		}

		private void dgvSP_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == dgvSP.Columns["chkSelect"].Index && e.RowIndex >= 0)
			{
				fMain formMain = (fMain)Application.OpenForms["fMain"];
				if (formMain == null) return;

				string tenSP = dgvSP.Rows[e.RowIndex].Cells["TenSP"].Value?.ToString();
				decimal gia = Convert.ToDecimal(dgvSP.Rows[e.RowIndex].Cells["Gia"].Value);

				SanPham selectedSanPham = listSanPham.FirstOrDefault(sp => sp.TenSP == tenSP);
				if (selectedSanPham != null)
				{
					if (Convert.ToBoolean(dgvSP.Rows[e.RowIndex].Cells["chkSelect"].Value))
					{
						if (!formMain.selectedSanPhamList.Any(sp => sp.TenSP == selectedSanPham.TenSP))
						{
							formMain.selectedSanPhamList.Add(new SanPham
							{
								MaSP = selectedSanPham.MaSP,
								TenSP = selectedSanPham.TenSP,
								Gia = gia
							});
						}
					}
					else
					{
						var itemToRemove = formMain.selectedSanPhamList.FirstOrDefault(sp => sp.TenSP == selectedSanPham.TenSP);
						if (itemToRemove != null)
						{
							formMain.selectedSanPhamList.Remove(itemToRemove);
						}
					}

					formMain.DisplaySelectedProducts(formMain.selectedSanPhamList);
				}
			}
		}

	}
}
