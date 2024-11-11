using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.DataAccessLayer
{
	public class BaoCaoDAL
	{
		private readonly DbProcess dbProcess;

		public BaoCaoDAL(string connectionString)
		{
			dbProcess = new DbProcess(connectionString);
		}

		public DataTable GetBaoCaoByDateRange(DateTime tuNgay, DateTime denNgay)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@TuNgay", SqlDbType.Date) { Value = tuNgay },
				new SqlParameter("@DenNgay", SqlDbType.Date) { Value = denNgay }
			};

			return dbProcess.ExecuteQuery("BaoCaoTheoNgay", parameters);
		}
		public decimal GetTotalByDateRange(DateTime tuNgay, DateTime denNgay)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
			new SqlParameter("@TuNgay", SqlDbType.Date) { Value = tuNgay },
			new SqlParameter("@DenNgay", SqlDbType.Date) { Value = denNgay }
			};

			object result = dbProcess.ExecuteScalar("GetTongTienTheoNgay", parameters);

			return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
		}

	}
}
