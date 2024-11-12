using QLQuanCF.Models;
using QLQuanCF.PresentationLayer.Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.DataAccessLayer
{
    internal class ChiTietSanPhamDAL
    {
        private readonly DbProcess dbProcess;

        public ChiTietSanPhamDAL(string connectionString)
        {
            dbProcess = new DbProcess(connectionString);
        }

        public List<ChiTietSanPham> GetAllChiTietSanPham()
        {
            DataTable dt = dbProcess.ExecuteQuery("GetAllChiTietSanPham", null);
            List<ChiTietSanPham> chiTietSanPhams = new List<ChiTietSanPham>();
            foreach (DataRow row in dt.Rows)
            {
                ChiTietSanPham chiTietSanPham = new ChiTietSanPham
                {
                    MaSP = row["MaSP"] != DBNull.Value ? row["MaSP"].ToString() : null,
                    MaNL = row["MaNL"] != DBNull.Value ? row["MaNL"].ToString() : null,
                    SoLuong = row["SLSuDung"] != DBNull.Value ? (int?)row["SLSuDung"] : null
                };
                chiTietSanPhams.Add(chiTietSanPham);
            }
            return chiTietSanPhams;
        }

        public void DeleteCTSP(string maSP, string maNL)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaSP", maSP),
                new SqlParameter("@MaNL", maNL)
            };
            dbProcess.ExecuteNonQuery("DeleteCTSP", parameters);
        }

        public List<ChiTietSanPham> GetCTSPByMaSP(string maSP)
        {
            SqlParameter[] parameters =
            {
            new SqlParameter("@MaSP", maSP)
        };

            DataTable dt = dbProcess.ExecuteQuery("GetCTSPByMaSP", parameters);
            List<ChiTietSanPham> chiTietSanPhams = new List<ChiTietSanPham>();

            foreach (DataRow row in dt.Rows)
            {
                ChiTietSanPham chiTietSanPham = new ChiTietSanPham
                {
                    MaSP = row["MaSP"] != DBNull.Value ? row["MaSP"].ToString() : null,
                    MaNL = row["MaNL"] != DBNull.Value ? row["MaNL"].ToString() : null,
                    SoLuong = row["SLSuDung"] != DBNull.Value ? (int?)row["SLSuDung"] : null
                };
                chiTietSanPhams.Add(chiTietSanPham);
            }

            return chiTietSanPhams;
        }

        public void AddCTSP(ChiTietSanPham chiTietSanPham)
        {
            SqlParameter[] parameters =
            {
            new SqlParameter("@MaSP", chiTietSanPham.MaSP),
            new SqlParameter("@MaNL", chiTietSanPham.MaNL),
            new SqlParameter("@SoLuong", chiTietSanPham.SoLuong)
        };

            dbProcess.ExecuteNonQuery("AddCTSP", parameters);
        }

        public void UpdateCTSP(ChiTietSanPham chiTietSanPham)
        {
            SqlParameter[] parameters =
            {
            new SqlParameter("@MaSP", chiTietSanPham.MaSP),
            new SqlParameter("@MaNL", chiTietSanPham.MaNL),
            new SqlParameter("@SoLuong", chiTietSanPham.SoLuong)
        };

            dbProcess.ExecuteNonQuery("UpdateCTSP", parameters);
        }
    }
}
