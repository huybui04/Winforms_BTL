using QLQuanCF.BusinessLogicLayer;
using QLQuanCF.Models;
using System;
using System.Windows.Forms;

namespace QLQuanCF.PresentationLayer
{
	public partial class fKhuVuc : Form
	{
		private KhuVucBLL _khuVucBLL;
		private ErrorProvider errorProvider = new ErrorProvider();
		private bool isAdding, isEditing;

		public fKhuVuc()
		{
			InitializeComponent();
			_khuVucBLL = new KhuVucBLL(Classes.DbConfig.connectString);
			LoadKhuVucData();
			ShowDetail(false);
			SetButtonState(true, false, false, false, false);
		}

		private void LoadKhuVucData()
		{
			dataKhuVuc.DataSource = _khuVucBLL.GetAllKhuVuc();
		}

		private void ShowDetail(bool detail)
		{
			txtTenKhuVuc.Enabled = detail;
		}

		private void ResetFlags()
		{
			isAdding = isEditing = false;
		}

		private void SetButtonState(bool add, bool edit, bool delete, bool save, bool cancel)
		{
			btnAddKhuVuc.Enabled = add;
			btnEditKhuVuc.Enabled = edit;
			btnDeleteKhuVuc.Enabled = delete;
			btnSaveKhuVuc.Enabled = save;
			btnCancelKhuVuc.Enabled = cancel;
		}

		private bool ValidateInput()
		{
			bool isValid = true;
			errorProvider.Clear();

			if (string.IsNullOrWhiteSpace(txtTenKhuVuc.Text))
			{
				errorProvider.SetError(txtTenKhuVuc, "Vui lòng nhập tên khu vực!");
				isValid = false;
			}

			return isValid;
		}

		private void ClearInputFields()
		{
			errorProvider.Clear();
			txtMaKhuVuc.Clear();
			txtTenKhuVuc.Clear();
			txtSearchKhuVuc.Clear();
		}

		private void btnAddKV_Click(object sender, EventArgs e)
		{
			ClearInputFields();
			ShowDetail(true);
			SetButtonState(false, false, false, true, true);
			ResetFlags();
			isAdding = true;
		}

		private void btnDeleteKV_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Bạn có chắc chắn muốn xóa khu vực này không?", "Xóa khu vực", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				ResetFlags();
				_khuVucBLL.DeleteKhuVuc(txtMaKhuVuc.Text);
				ClearInputFields();
				LoadKhuVucData();
				SetButtonState(true, false, false, false, false);
				ShowDetail(false);
				txtSearchKhuVuc.Focus();
			}
		}

		private void btnEditKV_Click(object sender, EventArgs e)
		{
			ShowDetail(true);
			SetButtonState(false, false, false, true, true);
			ResetFlags();
			isEditing = true;
		}

		private void btnSearchKV_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtSearchKhuVuc.Text))
			{
				LoadKhuVucData(); return;
			}
			if(_khuVucBLL.GetKhuVucByName(txtSearchKhuVuc.Text).Count == 0)
			{
				MessageBox.Show("Không tìm thấy khu vực!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			else
			{
				dataKhuVuc.DataSource = _khuVucBLL.GetKhuVucByName(txtSearchKhuVuc.Text);
				SetButtonState(false, false, false, false, true);
				ShowDetail(false);
				ClearInputFields();
			}
		}

		private void btnCancelKV_Click(object sender, EventArgs e)
		{
			ClearInputFields();
			LoadKhuVucData();
			SetButtonState(true, false, false, false, false);
			ShowDetail(false);
		}

		private void btnSaveKV_Click(object sender, EventArgs e)
		{
			if (!ValidateInput()) return;

			var khuVuc = new KhuVuc
			{
				MaKV = txtMaKhuVuc.Text,
				TenKV = txtTenKhuVuc.Text
			};

			if (isAdding)
				_khuVucBLL.AddKhuVuc(khuVuc);
			else if (isEditing)
				_khuVucBLL.UpdateKhuVuc(khuVuc);

			ClearInputFields();
			LoadKhuVucData();
			SetButtonState(true, false, false, false, false);
			ShowDetail(false);
			ResetFlags();
			txtSearchKhuVuc.Focus();
		}

		private void dataKhuVuc_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			errorProvider.Clear();
			ShowDetail(false);
			if (e.RowIndex >= 0)
			{
				txtMaKhuVuc.Text = dataKhuVuc.Rows[e.RowIndex].Cells[0].Value.ToString();
				txtTenKhuVuc.Text = dataKhuVuc.Rows[e.RowIndex].Cells[1].Value.ToString();
				SetButtonState(false, true, true, false, true);
			}
		}

		private void btnExitKV_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
