using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using QLQuanCF.DataAccessLayer;

namespace QLQuanCF.BusinessLogicLayer
{
    public class NguyenLieuDAL
    {
        private readonly DbProcess _dbProcess;

        public NguyenLieuDAL(string connectionString)
        {
            _dbProcess = new DbProcess(connectionString);
        }

        public List<NguyenLieu> GetAllNguyenLieu()
        {
            DataTable dataTable = _dbProcess.ExecuteQuery("GetAllNguyenLieu", null);
            List<NguyenLieu> lstNguyenLieu = new List<NguyenLieu>();

            foreach (DataRow row in dataTable.Rows)
            {
                NguyenLieu nl = new NguyenLieu
                {
                    MaNL = row["MaNL"].ToString(),
                    TenNL = row["TenNL"].ToString(),
                    DonVi = row["DonVi"].ToString(),
                    Gia = row["Gia"] == DBNull.Value ? 0 : Convert.ToDecimal(row["Gia"]),
                    SoLuong = row["SoLuong"] == DBNull.Value ? 0 : Convert.ToInt32(row["SoLuong"]),
                    NgaySanXuat = row["NgaySanXuat"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgaySanXuat"]),
                    HanSuDung = row["HanSuDung"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["HanSuDung"])
                };

                lstNguyenLieu.Add(nl);
            }

            return lstNguyenLieu;
        }

        public void AddNguyenLieu(NguyenLieu nl)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@TenNL", nl.TenNL),
                new SqlParameter("@DonVi", nl.DonVi),
                new SqlParameter("@Gia", nl.Gia),
                new SqlParameter("@SoLuong", nl.SoLuong),
                new SqlParameter("@NgaySanXuat", nl.NgaySanXuat),
                new SqlParameter("@HanSuDung", nl.HanSuDung)
            };

            _dbProcess.ExecuteNonQuery("spAddNguyenLieu", parameters);
        }

        public void UpdateNguyenLieu(NguyenLieu nl)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaNL", nl.MaNL),
                new SqlParameter("@TenNL", nl.TenNL),
                new SqlParameter("@DonVi", nl.DonVi),
                new SqlParameter("@Gia", nl.Gia),
                new SqlParameter("@SoLuong", nl.SoLuong),
                new SqlParameter("@NgaySanXuat", nl.NgaySanXuat),
                new SqlParameter("@HanSuDung", nl.HanSuDung)
            };

            _dbProcess.ExecuteNonQuery("UpdateNguyenLieu", parameters);
        }

        public void DeleteNguyenLieu(string maNL)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaNL", maNL)
            };

            _dbProcess.ExecuteNonQuery("DeleteNguyenLieu", parameters);
        }

        public List<NguyenLieu> SearchNguyenLieu(string keyword)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Keyword", keyword)
            };

            DataTable dataTable = _dbProcess.ExecuteQuery("SearchNguyenLieu", parameters);
            List<NguyenLieu> lstNguyenLieu = new List<NguyenLieu>();

            foreach (DataRow row in dataTable.Rows)
            {
                NguyenLieu nl = new NguyenLieu
                {
                    MaNL = row["MaNL"].ToString(),
                    TenNL = row["TenNL"].ToString(),
                    DonVi = row["DonVi"].ToString(),
                    Gia = Convert.ToDecimal(row["Gia"]),
                    SoLuong = Convert.ToInt32(row["SoLuong"]),
                    NgaySanXuat = Convert.ToDateTime(row["NgaySanXuat"]),
                    HanSuDung = Convert.ToDateTime(row["HanSuDung"])
                };

                lstNguyenLieu.Add(nl);
            }

            return lstNguyenLieu;
        }

        public bool CheckNguyenLieuConHayHet(string tenSP)
        {
            // Tạo tham số cho stored procedure
            SqlParameter[] parameters =
            {
                new SqlParameter("@TenSP", tenSP)
            };

            // Thực thi câu lệnh SQL để kiểm tra nguyên liệu
            DataTable dataTable = _dbProcess.ExecuteQuery("CheckNguyenLieuConHayHet", parameters);

            // Kiểm tra nếu có ít nhất một nguyên liệu hết
            // Nếu có, trả về false (nguyên liệu hết)
            if (dataTable.Rows.Count > 0 && Convert.ToInt32(dataTable.Rows[0]["Result"]) == 0)
            {
                return false; // Có nguyên liệu hết
            }

            return true; // Tất cả nguyên liệu còn
        }

    }
}
