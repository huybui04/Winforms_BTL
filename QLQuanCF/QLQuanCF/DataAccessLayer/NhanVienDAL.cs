using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.DataAccessLayer
{
    public class NhanVienDAL
    {
        private readonly DbProcess _dbProcess;

        public NhanVienDAL(string connectionString)
        {
            _dbProcess = new DbProcess(connectionString);
        }

        // Lấy tất cả nhân viên
        public List<NhanVien> GetAllNhanVien()
        {
            DataTable dataTable = _dbProcess.ExecuteQuery("GetAllNhanVien", null);
            List<NhanVien> nhanViens = new List<NhanVien>();

            foreach (DataRow row in dataTable.Rows)
            {
                NhanVien nhanVien = new NhanVien
                {
                    MaNV = row["MaNV"].ToString(),
                    MaCa = row["MaCa"].ToString(),
                    TenNV = row["TenNV"].ToString(),
                    ChucVu = row["ChucVu"].ToString(),
                    GioiTinh = row["GioiTinh"].ToString(),
                    NgaySinh = row["NgaySinh"] != DBNull.Value ? (DateTime?)row["NgaySinh"] : null,
                    DiaChi = row["DiaChi"].ToString(),
                    DienThoai = row["DienThoai"].ToString()
                };

                nhanViens.Add(nhanVien);
            }

            return nhanViens;
        }

        // Thêm nhân viên
        public void AddNhanVien(NhanVien nhanVien)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaCa", nhanVien.MaCa),
                new SqlParameter("@TenNV", nhanVien.TenNV),
                new SqlParameter("@ChucVu", nhanVien.ChucVu),
                new SqlParameter("@GioiTinh", nhanVien.GioiTinh),
                new SqlParameter("@NgaySinh", nhanVien.NgaySinh),
                new SqlParameter("@DiaChi", nhanVien.DiaChi),
                new SqlParameter("@DienThoai", nhanVien.DienThoai)
            };

            _dbProcess.ExecuteNonQuery("AddNhanVien", parameters);
        }

        // Cập nhật nhân viên
        public void UpdateNhanVien(NhanVien nhanVien)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaNV", nhanVien.MaNV),
                new SqlParameter("@MaCa", nhanVien.MaCa),
                new SqlParameter("@TenNV", nhanVien.TenNV),
                new SqlParameter("@ChucVu", nhanVien.ChucVu),
                new SqlParameter("@GioiTinh", nhanVien.GioiTinh),
                new SqlParameter("@NgaySinh", nhanVien.NgaySinh),
                new SqlParameter("@DiaChi", nhanVien.DiaChi),
                new SqlParameter("@DienThoai", nhanVien.DienThoai)
            };

            _dbProcess.ExecuteNonQuery("UpdateNhanVien", parameters);
        }

        // Xóa nhân viên
        public void DeleteNhanVien(string maNV)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaNV", maNV)
            };

            _dbProcess.ExecuteNonQuery("DeleteNhanVien", parameters);
        }

        // Tìm kiếm nhân viên theo tên
        public List<NhanVien> GetNhanVienByName(string tenNV)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@TenNV", tenNV)
            };

            DataTable dataTable = _dbProcess.ExecuteQuery("GetNhanVienByName", parameters);
            List<NhanVien> nhanViens = new List<NhanVien>();

            foreach (DataRow row in dataTable.Rows)
            {
                NhanVien nhanVien = new NhanVien
                {
                    MaNV = row["MaNV"].ToString(),
                    MaCa = row["MaCa"].ToString(),
                    TenNV = row["TenNV"].ToString(),
                    ChucVu = row["ChucVu"].ToString(),
                    GioiTinh = row["GioiTinh"].ToString(),
                    NgaySinh = row["NgaySinh"] != DBNull.Value ? (DateTime?)row["NgaySinh"] : null,
                    DiaChi = row["DiaChi"].ToString(),
                    DienThoai = row["DienThoai"].ToString()
                };

                nhanViens.Add(nhanVien);
            }

            return nhanViens;
        }
    }
}
