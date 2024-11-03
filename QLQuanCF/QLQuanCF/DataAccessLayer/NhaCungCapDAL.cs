using QLQuanCF.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QLQuanCF.DataAccessLayer
{
    public class NhaCungCapDAL
    {
        private readonly DbProcess _dbProcess;

        public NhaCungCapDAL(string connectionString)
        {
            _dbProcess = new DbProcess(connectionString);
        }

        public List<NhaCungCap> GetAllNhaCungCap()
        {
            DataTable dataTable = _dbProcess.ExecuteQuery("GetAllNhaCungCap", null);
            List<NhaCungCap> nhaCungCaps = new List<NhaCungCap>();

            foreach (DataRow row in dataTable.Rows)
            {
                NhaCungCap nhaCungCap = new NhaCungCap
                {
                    MaNCC = row["MaNCC"].ToString(),
                    TenNCC = row["TenNCC"].ToString(),
                    DiaChi = row["DiaChi"].ToString()
                };

                nhaCungCaps.Add(nhaCungCap);
            }

            return nhaCungCaps;
        }

        public void AddNhaCungCap(NhaCungCap nhaCungCap)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@TenNCC", nhaCungCap.TenNCC),
                new SqlParameter("@DiaChi", nhaCungCap.DiaChi)
            };

            _dbProcess.ExecuteNonQuery("AddNhaCungCap", parameters);
        }

        public void UpdateNhaCungCap(NhaCungCap nhaCungCap)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaNCC", nhaCungCap.MaNCC),
                new SqlParameter("@TenNCC", nhaCungCap.TenNCC),
                new SqlParameter("@DiaChi", nhaCungCap.DiaChi)
            };

            _dbProcess.ExecuteNonQuery("UpdateNhaCungCap", parameters);
        }

        public void DeleteNhaCungCap(string maNCC)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaNCC", maNCC)
            };

            _dbProcess.ExecuteNonQuery("DeleteNhaCungCap", parameters);
        }

        public List<NhaCungCap> GetNhaCungCapByName(string tenNCC)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@TenNCC", tenNCC)
            };

            DataTable dataTable = _dbProcess.ExecuteQuery("GetNhaCungCapByName", parameters);
            List<NhaCungCap> nhaCungCaps = new List<NhaCungCap>();

            foreach (DataRow row in dataTable.Rows)
            {
                NhaCungCap nhaCungCap = new NhaCungCap
                {
                    MaNCC = row["MaNCC"].ToString(),
                    TenNCC = row["TenNCC"].ToString(),
                    DiaChi = row["DiaChi"].ToString()
                };

                nhaCungCaps.Add(nhaCungCap);
            }

            return nhaCungCaps;
        }
    }
}
