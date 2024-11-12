using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace QLQuanCF.DataAccessLayer
{
    public class HoaDonNhapDAL
    {
        private readonly DbProcess _dbProcess;

        public HoaDonNhapDAL(string connectionString)
        {
            _dbProcess = new DbProcess(connectionString);
        }

        public List<HoaDonNhap> GetAllHoaDonNhap()
        {
            DataTable dataTable = _dbProcess.ExecuteQuery("GetAllHoaDonNhap", null);
            List<HoaDonNhap> hoaDonNhapList = new List<HoaDonNhap>();

            foreach (DataRow row in dataTable.Rows)
            {
                HoaDonNhap hoaDonNhap = new HoaDonNhap
                {
                    MaHDN = row["MaHDN"].ToString(),
                    MaNV = row["MaNV"].ToString(),
                    MaNCC = row["MaNCC"].ToString(),
                    NgayNhap = row["NgayNhap"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgayNhap"]),
                    TriGia = row["TriGia"] == DBNull.Value ? 0 : Convert.ToDecimal(row["TriGia"])
                };
                hoaDonNhapList.Add(hoaDonNhap);
            }
            return hoaDonNhapList;
        }

        public void AddHoaDonNhap(HoaDonNhap hoaDonNhap)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaHDN", hoaDonNhap.MaHDN),
                new SqlParameter("@MaNV", hoaDonNhap.MaNV),
                new SqlParameter("@NgayNhap", hoaDonNhap.NgayNhap),
                new SqlParameter("@MaNCC", hoaDonNhap.MaNCC),
                new SqlParameter("@TriGia", hoaDonNhap.TriGia)
            };
            _dbProcess.ExecuteNonQuery("AddHoaDonNhap", parameters);
        }

        public void DeleteHoaDonNhap(string maHDN)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaHDN", maHDN)
            };
            _dbProcess.ExecuteNonQuery("DeleteHoaDonNhap", parameters);
        }

        public void UpdateHoaDonNhap(HoaDonNhap hoaDonNhap)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaHDN", hoaDonNhap.MaHDN),
                new SqlParameter("@MaNV", hoaDonNhap.MaNV),
                new SqlParameter("@MaNCC", hoaDonNhap.MaNCC),
                new SqlParameter("@NgayNhap", hoaDonNhap.NgayNhap),
                new SqlParameter("@TriGia", hoaDonNhap.TriGia)
            };
            _dbProcess.ExecuteNonQuery("UpdateHoaDonNhap", parameters);
        }

        public List<HoaDonNhap> SearchHoaDonNhap(string keyword)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Keyword", $"%{keyword}%")
            };

            DataTable dataTable = _dbProcess.ExecuteQuery("SearchHoaDonNhap", parameters);
            List<HoaDonNhap> hoaDonNhapList = new List<HoaDonNhap>();

            foreach (DataRow row in dataTable.Rows)
            {
                HoaDonNhap hoaDonNhap = new HoaDonNhap
                {
                    MaHDN = row["MaHDN"].ToString(),
                    MaNV = row["MaNV"].ToString(),
                    NgayNhap = Convert.ToDateTime(row["NgayNhap"]),
                    MaNCC = row["MaNCC"].ToString(),
                    TriGia = Convert.ToDecimal(row["TriGia"])
                };
                hoaDonNhapList.Add(hoaDonNhap);
            }

            return hoaDonNhapList;
        }
        public List<ChiTietHoaDonNhap> GetChiTietHoaDonNhapByMaHDN(string maHDN)
        {
            List<ChiTietHoaDonNhap> chiTietHoaDonNhaps = new List<ChiTietHoaDonNhap>();

            using (SqlConnection connection = _dbProcess.GetConnection())
            {
                SqlCommand command = new SqlCommand("GetChiTietHoaDonNhapByMaHDN", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaHDN", maHDN);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ChiTietHoaDonNhap chiTiet = new ChiTietHoaDonNhap
                    {
                        MaHDN = reader["MaHDN"].ToString(),
                        MaNL = reader["MaNL"].ToString(),
                        SLNhap = reader["SLNhap"] as int?,
                        ThanhTien = reader["ThanhTien"] as decimal?
                    };
                    chiTietHoaDonNhaps.Add(chiTiet);
                }
            }

            return chiTietHoaDonNhaps;
        }
        public decimal GetGiaNguyenLieu(string maNL)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaNL", maNL)
            };

            DataTable result = _dbProcess.ExecuteQuery("GetGiaNguyenLieu", parameters);

            if (result.Rows.Count > 0 && result.Rows[0]["Gia"] != DBNull.Value)
            {
                return Convert.ToDecimal(result.Rows[0]["Gia"]);
            }

            return 0;
        }
        public DataTable GetAllMaNguyenLieu()
        {
            return _dbProcess.ExecuteQuery("GetAllMaNguyenLieu", null);
        }
        public void UpdateChiTietHoaDonNhap(string maHDN, string maNL, int slNhap, decimal thanhTien)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaHDN", maHDN),
                new SqlParameter("@MaNL", maNL),
                new SqlParameter("@SLNhap", slNhap),
                new SqlParameter("@ThanhTien", thanhTien)
            };
            _dbProcess.ExecuteNonQuery("UpdateChiTietHoaDonNhap", parameters);
        }

        public void AddChiTietHoaDonNhap(string maHDN, string maNL, int slNhap, decimal thanhTien)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaHDN", maHDN),
                new SqlParameter("@MaNL", maNL),
                new SqlParameter("@SLNhap", slNhap),
                new SqlParameter("@ThanhTien", thanhTien)
            };
            _dbProcess.ExecuteNonQuery("AddChiTietHoaDonNhap", parameters);
        }
        public ChiTietHoaDonNhap GetChiTietHoaDonNhapByMaHDNAndMaNL(string maHDN, string maNL)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHDN", maHDN),
                new SqlParameter("@MaNL", maNL)
            };
            DataTable result = _dbProcess.ExecuteQuery("GetChiTietHoaDonNhapByMaHDNAndMaNL", parameters);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                return new ChiTietHoaDonNhap
                {
                    MaHDN = row["MaHDN"].ToString(),
                    MaNL = row["MaNL"].ToString(),
                    SLNhap = row["SLNhap"] == DBNull.Value ? 0 : Convert.ToInt32(row["SLNhap"]),
                    ThanhTien = row["ThanhTien"] == DBNull.Value ? 0 : Convert.ToDecimal(row["ThanhTien"])
                };
            }
            return null;
        }

        public void AddOrUpdateChiTietHoaDonNhap(string maHDN, string maNL, int slNhap, decimal thanhTien)
        {
            var existingChiTiet = GetChiTietHoaDonNhapByMaHDNAndMaNL(maHDN, maNL);
            if (existingChiTiet != null)
            {
                UpdateChiTietHoaDonNhap(maHDN, maNL, slNhap, thanhTien);
            }
            else
            {
                AddChiTietHoaDonNhap(maHDN, maNL, slNhap, thanhTien);
            }
            UpdateTriGiaHoaDonNhap(maHDN);
        }
        public void DeleteChiTietHoaDonNhap(string maHDN, string maNL)
        {
            SqlParameter[] parameters = 
            {
                new SqlParameter("@MaHDN", maHDN),
                new SqlParameter("@MaNL", maNL)
            };
            _dbProcess.ExecuteNonQuery("DeleteChiTietHoaDonNhap", parameters);
        }

        private void UpdateTriGiaHoaDonNhap(string maHDN)
        {
            SqlParameter[] parameters = 
            { 
                new SqlParameter("@MaHDN", maHDN) 
            };
            _dbProcess.ExecuteNonQuery("UpdateTriGiaHoaDonNhap", parameters);
        }

        public HoaDonNhap GetHoaDonNhapByMaHDN(string maHDN)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHDN", maHDN)
            };
            DataTable result = _dbProcess.ExecuteQuery("GetHoaDonNhapByMaHDN", parameters);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                return new HoaDonNhap
                {
                    MaHDN = row["MaHDN"].ToString(),
                    MaNV = row["MaNV"].ToString(),
                    MaNCC = row["MaNCC"].ToString(),
                    NgayNhap = row["NgayNhap"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgayNhap"]),
                    TriGia = row["TriGia"] == DBNull.Value ? 0 : Convert.ToDecimal(row["TriGia"])
                };
            }
            return null;
        }

    }
}
