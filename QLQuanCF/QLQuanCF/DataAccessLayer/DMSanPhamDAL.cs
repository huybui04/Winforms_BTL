using QLQuanCF.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QLQuanCF.DataAccessLayer
{
    public class DMSanPhamDAL
    {
        private readonly DbProcess _dbProcess;

        public DMSanPhamDAL(string connectionString)
        {
            _dbProcess = new DbProcess(connectionString);
        }

        public List<DanhMucSanPham> GetAllDanhMucSanPham()
        {
            DataTable dataTable = _dbProcess.ExecuteQuery("GetAllDanhMucSanPham", null);
            List<DanhMucSanPham> danhMucs = new List<DanhMucSanPham>();

            foreach (DataRow row in dataTable.Rows)
            {
                DanhMucSanPham danhMuc = new DanhMucSanPham
                {
                    MaDM = row["MaDM"].ToString(),
                    TenDM = row["TenDM"].ToString()
                };

                danhMucs.Add(danhMuc);
            }

            return danhMucs;
        }

        public void AddDanhMucSanPham(DanhMucSanPham danhMuc)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@TenDM", danhMuc.TenDM)
            };

            _dbProcess.ExecuteNonQuery("AddDanhMucSanPham", parameters);
        }

        public void UpdateDanhMucSanPham(DanhMucSanPham danhMuc)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaDM", danhMuc.MaDM),
                new SqlParameter("@TenDM", danhMuc.TenDM)
            };

            _dbProcess.ExecuteNonQuery("UpdateDanhMucSanPham", parameters);
        }

        public void DeleteDanhMucSanPham(string maDM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaDM", maDM)
            };

            _dbProcess.ExecuteNonQuery("DeleteDanhMucSanPham", parameters);
        }

        public List<DanhMucSanPham> GetDanhMucSanPhamByName(string tenDM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@TenDM", tenDM)
            };

            DataTable dataTable = _dbProcess.ExecuteQuery("GetDanhMucSanPhamByName", parameters);
            List<DanhMucSanPham> danhMucs = new List<DanhMucSanPham>();

            foreach (DataRow row in dataTable.Rows)
            {
                DanhMucSanPham danhMuc = new DanhMucSanPham
                {
                    MaDM = row["MaDM"].ToString(),
                    TenDM = row["TenDM"].ToString()
                };

                danhMucs.Add(danhMuc);
            }
            return danhMucs;
        }

        public string GetTenDanhMucSanPhamByMa(string maDM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaDM", maDM)
            };

            DataTable dataTable = _dbProcess.ExecuteQuery("GetTenDanhMucSanPhamByMa", parameters);

            if (dataTable.Rows.Count > 0)
            {
                return dataTable.Rows[0]["TenDM"].ToString();
            }

            return "";
        }

    }
}
