using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        // Thêm nguyên liệu
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

        // Cập nhật nguyên liệu
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

        // Xóa nguyên liệu
        public void DeleteNguyenLieu(string maNL)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaNL", maNL)
            };

            _dbProcess.ExecuteNonQuery("DeleteNguyenLieu", parameters);
        }

        // Tìm kiếm nguyên liệu
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
    }
}
