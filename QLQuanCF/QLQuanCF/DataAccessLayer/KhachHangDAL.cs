using QLQuanCF.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QLQuanCF.DataAccessLayer
{
    public class KhachHangDAL
    {
        private readonly DbProcess _dbProcess;

        public KhachHangDAL(string connectionString)
        {
            _dbProcess = new DbProcess(connectionString);
        }

        public List<KhachHang> GetAllKhachHang()
        {
            DataTable dataTable = _dbProcess.ExecuteQuery("GetAllKhachHang", null);
            List<KhachHang> khachHangs = new List<KhachHang>();

            foreach (DataRow row in dataTable.Rows)
            {
                KhachHang khachHang = new KhachHang
                {
                    MaKH = row["MaKH"].ToString(),
                    TenKH = row["TenKH"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    DienThoai = row["DienThoai"].ToString()
                };

                khachHangs.Add(khachHang);
            }

            return khachHangs;
        }

        public void AddKhachHang(KhachHang khachHang)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@TenKH", khachHang.TenKH),
                new SqlParameter("@DiaChi", khachHang.DiaChi),
                new SqlParameter("@DienThoai", khachHang.DienThoai)
            };

            _dbProcess.ExecuteNonQuery("AddKhachHang", parameters);
        }

        public void UpdateKhachHang(KhachHang khachHang)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaKH", khachHang.MaKH),
                new SqlParameter("@TenKH", khachHang.TenKH),
                new SqlParameter("@DiaChi", khachHang.DiaChi),
                new SqlParameter("@DienThoai", khachHang.DienThoai)
            };

            _dbProcess.ExecuteNonQuery("UpdateKhachHang", parameters);
        }

        public void DeleteKhachHang(string maKH)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaKH", maKH)
            };

            _dbProcess.ExecuteNonQuery("DeleteKhachHang", parameters);
        }

        public List<KhachHang> GetKhachHangByName(string tenKH)
        {
            SqlParameter[] parameters =
{
                new SqlParameter("@TenKH", tenKH)
            };

            DataTable dataTable = _dbProcess.ExecuteQuery("GetKhachHangByName", parameters);
            List<KhachHang> khachHangs = new List<KhachHang>();

            foreach (DataRow row in dataTable.Rows)
            {
                KhachHang khachHang = new KhachHang
                {
                    MaKH = row["MaKH"].ToString(),
                    TenKH = row["TenKH"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    DienThoai = row["DienThoai"].ToString()
                };

                khachHangs.Add(khachHang);
            }
            return khachHangs;
        }
    }
}
