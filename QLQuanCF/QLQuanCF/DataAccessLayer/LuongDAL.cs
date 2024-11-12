using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.DataAccessLayer
{
	public class LuongDAL
	{
		private readonly DbProcess _dbProcess;

		public LuongDAL(string connectionString)
		{
			_dbProcess = new DbProcess(connectionString);
		}

		// Get all records of Luong
		public List<Luong> GetAllLuong()
		{
			DataTable dataTable = _dbProcess.ExecuteQuery("GetAllLuong", null);
			List<Luong> lstLuong = new List<Luong>();

			foreach (DataRow row in dataTable.Rows)
			{
				Luong luong = new Luong
				{
					MaNV = row["MaNV"].ToString(),
					MaCa = row["MaCa"].ToString(),
					Ngay = row["Ngay"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["Ngay"])
				};

				lstLuong.Add(luong);
			}

			return lstLuong;
		}

		// Add a new record of Luong
		public void AddLuong(Luong luong)
		{
			SqlParameter[] parameters =
			{
			new SqlParameter("@MaNV", luong.MaNV),
			new SqlParameter("@MaCa", luong.MaCa),
			new SqlParameter("@Ngay", luong.Ngay)
		};

			_dbProcess.ExecuteNonQuery("AddLuong", parameters);
		}

		// Update a record of Luong
		public void UpdateLuong(Luong luong)
		{
			SqlParameter[] parameters =
			{
			new SqlParameter("@MaNV", luong.MaNV),
			new SqlParameter("@MaCa", luong.MaCa),
			new SqlParameter("@Ngay", luong.Ngay)
		};

			_dbProcess.ExecuteNonQuery("UpdateLuong", parameters);
		}

		// Delete a record of Luong by MaNV and MaCa
		public void DeleteLuong(string maNV, string maCa)
		{
			SqlParameter[] parameters =
			{
			new SqlParameter("@MaNV", maNV),
			new SqlParameter("@MaCa", maCa)
		};

			_dbProcess.ExecuteNonQuery("DeleteLuong", parameters);
		}

		// Search Luong by a keyword (can be used for MaNV or MaCa)
		public List<Luong> SearchLuong(string keyword)
		{
			SqlParameter[] parameters =
			{
			new SqlParameter("@Keyword", keyword)
		};

			DataTable dataTable = _dbProcess.ExecuteQuery("SearchLuong", parameters);
			List<Luong> lstLuong = new List<Luong>();

			foreach (DataRow row in dataTable.Rows)
			{
				Luong luong = new Luong
				{
					MaNV = row["MaNV"].ToString(),
					MaCa = row["MaCa"].ToString(),
					Ngay = row["Ngay"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["Ngay"])
				};

				lstLuong.Add(luong);
			}

			return lstLuong;
		}
	}

}
