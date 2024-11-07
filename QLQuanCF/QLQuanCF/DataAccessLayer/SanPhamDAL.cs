using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.DataAccessLayer
{
    internal class SanPhamDAL
    {
        private readonly DbProcess dbProcess;

        public SanPhamDAL(string stringConnection)
        {
            dbProcess = new DbProcess(stringConnection);
        }

        public List<SanPham> GetAllSanPham()
        {
            DataTable dt = dbProcess.ExecuteQuery("GetAllSanPham", null);
            List<SanPham> sanPhams = new List<SanPham>();

            foreach (DataRow row in dt.Rows)
            {
                SanPham sp = new SanPham
                {
                    MaSP = row["MaSP"] != DBNull.Value ? row["MaSP"].ToString() : null,
                    TenSP = row["TenSP"] != DBNull.Value ? row["TenSP"].ToString() : null,
                    MaDM = row["MaDM"] != DBNull.Value ? row["MaDM"].ToString() : null,
                    Gia = row["Gia"] != DBNull.Value ? (decimal?)row["Gia"] : null
                };
                sanPhams.Add(sp);
            }
            return sanPhams;
        }

        public SanPham GetSanPhamByMaSanPham(string maSP)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaSP", maSP)
            };

            DataTable dt = dbProcess.ExecuteQuery("GetSanPhamByMaSanPham", parameters);
            if(dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new SanPham
                {
                    MaSP = row["MaSP"] != DBNull.Value ? row["MaSP"].ToString() : null,
                    TenSP = row["TenSP"] != DBNull.Value ? row["TenSP"].ToString() : null,
                    MaDM = row["MaDM"] != DBNull.Value ? row["MaDM"].ToString() : null,
                    Gia = row["Gia"] != DBNull.Value ? (decimal?)row["Gia"] : null
                };
            }
            
            return null;
        }
    }
}
