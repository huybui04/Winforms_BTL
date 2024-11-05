using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLQuanCF.Models;

namespace QLQuanCF.DataAccessLayer
{
    public class SanPhamDAL
    {
        private readonly DbProcess _dbProcess;

        public SanPhamDAL(string connectionString)
        {
            _dbProcess = new DbProcess(connectionString);
        }

        public List<SanPham> GetAllSanPham()
        {
            DataTable dataTable = _dbProcess.ExecuteQuery("GetAllSanPham", null);
            List<SanPham> sanPhams = new List<SanPham>();

            foreach (DataRow row in dataTable.Rows)
            {
                SanPham sanPham = new SanPham
                {
                    MaSP = row["MaSP"].ToString(),
                    TenSP = row["TenSP"].ToString(),
                    MaDM = row["MaDM"].ToString(),
                    Gia = row["Gia"] != DBNull.Value ? (decimal?)row["Gia"] : null,
                    Anh = row["Anh"].ToString()
                };

                sanPhams.Add(sanPham);
            }

            return sanPhams;
        }

        // Thêm sản phẩm
        public void AddSanPham(SanPham sanPham)
        {
            SqlParameter[] parameters =
            {
            new SqlParameter("@TenSP", sanPham.TenSP),
            new SqlParameter("@MaDM", sanPham.MaDM),
            new SqlParameter("@Gia", sanPham.Gia),
            new SqlParameter("@Anh", sanPham.Anh)
        };

            _dbProcess.ExecuteNonQuery("AddSanPham", parameters);
        }

        // Cập nhật sản phẩm
        public void UpdateSanPham(SanPham sanPham)
        {
            SqlParameter[] parameters =
            {
            new SqlParameter("@MaSP", sanPham.MaSP),
            new SqlParameter("@TenSP", sanPham.TenSP),
            new SqlParameter("@MaDM", sanPham.MaDM),
            new SqlParameter("@Gia", sanPham.Gia),
            new SqlParameter("@Anh", sanPham.Anh)
        };

            _dbProcess.ExecuteNonQuery("UpdateSanPham", parameters);
        }

        // Xóa sản phẩm
        public void DeleteSanPham(string maSP)
        {
            SqlParameter[] parameters =
            {
            new SqlParameter("@MaSP", maSP)
        };

            _dbProcess.ExecuteNonQuery("DeleteSanPham", parameters);
        }

        // Tìm kiếm sản phẩm theo tên
        public List<SanPham> GetSanPhamByName(string tenSP)
        {
            SqlParameter[] parameters =
            {
            new SqlParameter("@Keyword", tenSP)
        };

            DataTable dataTable = _dbProcess.ExecuteQuery("SearchSanPham", parameters);
            List<SanPham> sanPhams = new List<SanPham>();

            foreach (DataRow row in dataTable.Rows)
            {
                SanPham sanPham = new SanPham
                {
                    MaSP = row["MaSP"].ToString(),
                    TenSP = row["TenSP"].ToString(),
                    MaDM = row["MaDM"].ToString(),
                    Gia = row["Gia"] != DBNull.Value ? (decimal?)row["Gia"] : null,
                    Anh = row["Anh"].ToString()
                };

                sanPhams.Add(sanPham);
            }

            return sanPhams;
        }
    }
}
