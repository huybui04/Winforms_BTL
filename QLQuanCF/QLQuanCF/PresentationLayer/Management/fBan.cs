using QLQuanCF.BusinessLogicLayer;
using QLQuanCF.Models;
using System;
using System.Windows.Forms;

namespace QLQuanCF.PresentationLayer
{
	public partial class fBan : Form
	{
		private BanBLL _banBLL;
		private ErrorProvider errorProvider = new ErrorProvider();
		private bool isAdding, isEditing;

		public fBan()
		{
			InitializeComponent();
			_banBLL = new BanBLL(Classes.DbConfig.connectString);
			LoadBanData();
			LoadComboBoxData();
			ShowDetail(false);
			SetButtonState(true, false, false, false, false);
		}

		private void LoadBanData()
		{
			dataBan.DataSource = _banBLL.GetAllBan();
		}
		private void LoadComboBoxData()
		{
			cbMaKV.DataSource = _banBLL.GetKhuVucList();
			cbTrangThai.DataSource = _banBLL.GetTrangThaiList();
			cbTrangThai.SelectedIndex = cbMaKV.SelectedIndex = -1;
		}

		private void ShowDetail(bool detail)
		{
			cbTrangThai.Enabled = detail;
			cbMaKV.Enabled = detail;
		}

		private void ResetFlags()
		{
			isAdding = isEditing = false;
		}

		private void SetButtonState(bool add, bool edit, bool delete, bool save, bool cancel)
		{
			btnAddBan.Enabled = add;
			btnEditBan.Enabled = edit;
			btnDeleteBan.Enabled = delete;
			btnSaveBan.Enabled = save;
			btnCancelBan.Enabled = cancel;
		}

		private bool ValidateInput()
		{
			bool isValid = true;
			errorProvider.Clear();

			if (cbTrangThai.SelectedIndex == -1)
			{
				errorProvider.SetError(cbTrangThai, "Vui lòng chọn trạng thái!");
				isValid = false;
			}

			if (cbMaKV.SelectedIndex == -1)
			{
				errorProvider.SetError(cbMaKV, "Vui lòng chọn khu vực!");
				isValid = false;
			}

			return isValid;
		}

		private void ClearInputFields()
		{
			errorProvider.Clear();
			txtMaBan.Clear();
			txtTenBan.Clear();
			cbTrangThai.SelectedIndex = cbMaKV.SelectedIndex = -1;
			txtSearchBan.Clear();
		}

		private void btnAddBan_Click(object sender, EventArgs e)
		{
			ClearInputFields();
			ShowDetail(true);
			SetButtonState(false, false, false, true, true);
			ResetFlags();
			isAdding = true;
		}

		private void btnDeleteBan_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Bạn có chắc chắn muốn xóa bàn này không?", "Xóa bàn", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				ResetFlags();
				_banBLL.DeleteBan(txtMaBan.Text);
				ClearInputFields();
				LoadBanData();
				SetButtonState(true, false, false, false, false);
				ShowDetail(false);
				txtSearchBan.Focus();
			}
		}

		private void btnEditBan_Click(object sender, EventArgs e)
		{
			ShowDetail(true);
			SetButtonState(false, false, false, true, true);
			ResetFlags();
			isEditing = true;
		}

		private void btnSearchBan_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtSearchBan.Text))
			{
				LoadBanData(); return;
			}
			if (_banBLL.GetBanByName(txtSearchBan.Text).Count == 0)
			{
				MessageBox.Show("Không tìm thấy bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			else
			{
				dataBan.DataSource = _banBLL.GetBanByName(txtSearchBan.Text);
				SetButtonState(false, false, false, false, true);
				ShowDetail(false);
				ClearInputFields();
			}
		}

		private void btnCancelBan_Click(object sender, EventArgs e)
		{
			ClearInputFields();
			LoadBanData();
			SetButtonState(true, false, false, false, false);
			ShowDetail(false);
		}

		private void btnSaveBan_Click(object sender, EventArgs e)
		{
			if (!ValidateInput()) return;

			var ban = new Ban
			{
				MaBan = txtMaBan.Text,
				TenBan = txtTenBan.Text,
				TrangThai = cbTrangThai.Text,
				MaKV = cbMaKV.Text
			};

			if (isAdding)
				_banBLL.AddBan(ban);
			else if (isEditing)
				_banBLL.UpdateBan(ban);

			ClearInputFields();
			LoadBanData();
			SetButtonState(true, false, false, false, false);
			ShowDetail(false);
			ResetFlags();
			txtSearchBan.Focus();
		}

		private void dataBan_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			errorProvider.Clear();
			ShowDetail(false);
			if (e.RowIndex >= 0)
			{
				txtMaBan.Text = dataBan.Rows[e.RowIndex].Cells[0].Value.ToString();
				txtTenBan.Text = dataBan.Rows[e.RowIndex].Cells[1].Value.ToString();
				cbMaKV.Text = dataBan.Rows[e.RowIndex].Cells[2].Value.ToString();
				cbTrangThai.Text = dataBan.Rows[e.RowIndex].Cells[3].Value.ToString();
				SetButtonState(false, true, true, false, true);
			}
		}

		private void btnExitBan_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}