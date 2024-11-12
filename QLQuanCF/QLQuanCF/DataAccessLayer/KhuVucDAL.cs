using QLQuanCF.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QLQuanCF.DataAccessLayer
{
	public class KhuVucDAL
	{
		private readonly DbProcess _dbProcess;
		public KhuVucDAL(string connectionString)
		{
			_dbProcess = new DbProcess(connectionString);
		}

		public List<KhuVuc> GetAllKhuVuc()
		{
			DataTable dataTable = _dbProcess.ExecuteQuery("GetAllKhuVuc", null);
			List<KhuVuc> khuVucs = new List<KhuVuc>();

			foreach (DataRow row in dataTable.Rows)
			{
				KhuVuc khuVuc = new KhuVuc
				{
					MaKV = row["MaKV"].ToString(),
					TenKV = row["TenKV"].ToString()
				};

				khuVucs.Add(khuVuc);
			}

			return khuVucs;
		}

		public void AddKhuVuc(KhuVuc khuVuc)
		{
			SqlParameter[] parameters =
			{
				new SqlParameter("@TenKV", khuVuc.TenKV)
			};

			_dbProcess.ExecuteNonQuery("AddKhuVuc", parameters);
		}

		public void UpdateKhuVuc(KhuVuc khuVuc)
		{
			SqlParameter[] parameters =
			{
				new SqlParameter("@MaKV", khuVuc.MaKV),
				new SqlParameter("@TenKV", khuVuc.TenKV)
			};

			_dbProcess.ExecuteNonQuery("UpdateKhuVuc", parameters);
		}

		public void DeleteKhuVuc(string maKV)
		{
			SqlParameter[] parameters =
			{
				new SqlParameter("@MaKV", maKV)
			};

			_dbProcess.ExecuteNonQuery("DeleteKhuVuc", parameters);
		}

		public List<KhuVuc> GetKhuVucByName(string tenKV)
		{
			SqlParameter[] parameters =
			{
				new SqlParameter("@TenKV", tenKV)
			};

			DataTable dataTable = _dbProcess.ExecuteQuery("GetKhuVucByName", parameters);
			List<KhuVuc> khuVucs = new List<KhuVuc>();

			foreach (DataRow row in dataTable.Rows)
			{
				KhuVuc khuVuc = new KhuVuc
				{
					MaKV = row["MaKV"].ToString(),
					TenKV = row["TenKV"].ToString()
				};

				khuVucs.Add(khuVuc);
			}

			return khuVucs;
		}
	}
}
