using QLQuanCF.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QLQuanCF.DataAccessLayer
{
	public class BanDAL
	{
		private readonly DbProcess _dbProcess;

		public BanDAL(string connectionString)
		{
			_dbProcess = new DbProcess(connectionString);
		}

		public List<Ban> GetAllBan()
		{
			DataTable dataTable = _dbProcess.ExecuteQuery("GetAllBan", null);
			List<Ban> bans = new List<Ban>();

			foreach (DataRow row in dataTable.Rows)
			{
				Ban ban = new Ban
				{
					MaBan = row["MaBan"].ToString(),
					TenBan = row["TenBan"].ToString(),
					MaKV = row["MaKV"].ToString(),
					TrangThai = row["TrangThai"].ToString()
				};

				bans.Add(ban);
			}

			return bans;
		}

		public void AddBan(Ban ban)
		{
			SqlParameter[] parameters =
			{
				new SqlParameter("@MaKV", ban.MaKV),
				new SqlParameter("@TrangThai", ban.TrangThai)
			};

			_dbProcess.ExecuteNonQuery("AddBan", parameters);
		}

		public void UpdateBan(Ban ban)
		{
			SqlParameter[] parameters =
			{
				new SqlParameter("@MaBan", ban.MaBan),
				new SqlParameter("@TenBan", ban.TenBan),
				new SqlParameter("@MaKV", ban.MaKV),
				new SqlParameter("@TrangThai", ban.TrangThai)
			};

			_dbProcess.ExecuteNonQuery("UpdateBan", parameters);
		}

		public void DeleteBan(string maBan)
		{
			SqlParameter[] parameters =
			{
				new SqlParameter("@MaBan", maBan)
			};

			_dbProcess.ExecuteNonQuery("DeleteBan", parameters);
		}

		public List<Ban> GetBanByName(string tenBan)
		{
			SqlParameter[] parameters =
			{
				new SqlParameter("@TenBan", tenBan)
			};

			DataTable dataTable = _dbProcess.ExecuteQuery("GetBanByName", parameters);
			List<Ban> bans = new List<Ban>();

			foreach (DataRow row in dataTable.Rows)
			{
				Ban ban = new Ban
				{
					MaBan = row["MaBan"].ToString(),
					TenBan = row["TenBan"].ToString(),
					MaKV = row["MaKV"].ToString(),
					TrangThai = row["TrangThai"].ToString()
				};

				bans.Add(ban);
			}

			return bans;
		}

		public List<string> GetKhuVucList()
		{
			DataTable dataTable = _dbProcess.ExecuteQuery("GetKhuVucList", null);
			List<string> khuVucs = new List<string>();

			foreach (DataRow row in dataTable.Rows)
			{
				khuVucs.Add(row["MaKV"].ToString());
			}

			return khuVucs;
		}

		public List<string> GetTrangThaiList()
		{
			DataTable dataTable = _dbProcess.ExecuteQuery("GetTrangThaiList", null);
			List<string> trangThais = new List<string>();

			foreach (DataRow row in dataTable.Rows)
			{
				trangThais.Add(row["TrangThai"].ToString());
			}

			return trangThais;
		}

		public List<Ban> GetBanByKhuVuc(string maKV)
		{
			SqlParameter[] parameters =
			{
				new SqlParameter("@MaKV", maKV)
			};

			DataTable dataTable = _dbProcess.ExecuteQuery("GetBanByKhuVuc", parameters);
			List<Ban> bans = new List<Ban>();

			foreach (DataRow row in dataTable.Rows)
			{
				Ban ban = new Ban
				{
					MaBan = row["MaBan"].ToString(),
					TenBan = row["TenBan"].ToString(),
					MaKV = row["MaKV"].ToString(),
					TrangThai = row["TrangThai"].ToString()
				};

				bans.Add(ban);
			}

			return bans;
		}

		public Ban GetBanByMaBan(string maBan)
		{
            SqlParameter[] parameters =
			{
				new SqlParameter("@MaBan", maBan)
			};

            DataTable dataTable = _dbProcess.ExecuteQuery("GetBanByMaBan", parameters);

            if (dataTable.Rows.Count > 0)
            {
				DataRow row = dataTable.Rows[0];
                return new Ban
                {
                    MaBan = row["MaBan"].ToString(),
                    TenBan = row["TenBan"].ToString(),
                    MaKV = row["MaKV"].ToString(),
                    TrangThai = row["TrangThai"].ToString()
                };
            }

            return null;
        }

		public void UpdateTrangThaiBan(string maBan, string trangThai)
		{
			SqlParameter[] parameters =
			{
				new SqlParameter("@MaBan", maBan),
				new SqlParameter("@TrangThai", trangThai)
			};

			_dbProcess.ExecuteNonQuery("UpdateTrangThaiBan", parameters);
		}
	}
}
