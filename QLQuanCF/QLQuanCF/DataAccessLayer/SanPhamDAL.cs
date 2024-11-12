using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLQuanCF.Models;
using System.Diagnostics;

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

        public SanPham GetSanPhamByMaSanPham(string maSP)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaSP", maSP)
            };
            DataTable dt = _dbProcess.ExecuteQuery("GetSanPhamByMaSanPham", parameters);
            if (dt.Rows.Count > 0)
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

		public List<SanPham> GetSanPhamByDanhMuc(string maDM)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
		        new SqlParameter("@MaDM", maDM) 
			};

			DataTable dataTable = _dbProcess.ExecuteQuery("GetSanPhamByDanhMuc", parameters);

			List<SanPham> sanPhamList = new List<SanPham>();
			foreach (DataRow row in dataTable.Rows)
			{
				SanPham sanPham = new SanPham
				{
					MaSP = row["MaSP"].ToString(),
					TenSP = row["TenSP"].ToString(),
					Gia = Convert.ToDecimal(row["Gia"]),
					Anh = row["Anh"].ToString()  
				};
				sanPhamList.Add(sanPham);
			}

			return sanPhamList;
		}
	}
}
