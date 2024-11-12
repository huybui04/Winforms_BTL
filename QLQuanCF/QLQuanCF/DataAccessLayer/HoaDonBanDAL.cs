using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanCF.DataAccessLayer
{
    internal class HoaDonBanDAL
    {
        private readonly DbProcess dbProcess;

        public HoaDonBanDAL(string connectionString)
        {
            dbProcess = new DbProcess(connectionString);
        }

        public List<HoaDonBan> GetAllHDB()
        {
            DataTable dt = dbProcess.ExecuteQuery("GetAllHDB", null);
            List<HoaDonBan> hoaDonBans = new List<HoaDonBan>();
            foreach (DataRow row in dt.Rows)
            {
                HoaDonBan hdb = new HoaDonBan
                {
                    MaHDB = row["MaHDB"] != DBNull.Value ? row["MaHDB"].ToString() : null,
                    MaNV = row["MaNV"] != DBNull.Value ? row["MaNV"].ToString() : null,
                    MaKH = row["MaKH"] != DBNull.Value ? row["MaKH"].ToString() : null,
                    MaBan = row["MaBan"] != DBNull.Value ? row["MaBan"].ToString() : null,
                    NgayBan = row["NgayBan"] != DBNull.Value ? (DateTime?)row["NgayBan"] : null,
                    TriGia = row["TriGia"] != DBNull.Value ? (decimal?)row["TriGia"] : null
                };
                hoaDonBans.Add(hdb);
            }
            return hoaDonBans;
        }

        public List<ChiTietHoaDonBan> GetChiTietHoaDonBanByMaHDB(string maHDB)
        {
            List<ChiTietHoaDonBan> chiTietHoaDonBans = new List<ChiTietHoaDonBan>();

            using (SqlConnection connection = dbProcess.GetConnection())
            {
                SqlCommand command = new SqlCommand("spGetChiTietHoaDonBanByMaHDB", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaHDB", maHDB);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ChiTietHoaDonBan chiTiet = new ChiTietHoaDonBan
                    {
                        MaHDB = reader["MaHDB"].ToString(),
                        MaSP = reader["MaSP"].ToString(),
                        SLBan = Convert.ToInt32(reader["SLBan"]),
                        KhuyenMai = reader["KhuyenMai"].ToString(),
                        ThanhTien = Convert.ToDecimal(reader["ThanhTien"])
                    };
                    chiTietHoaDonBans.Add(chiTiet);
                }
            }

            return chiTietHoaDonBans;
        }

        public List<HoaDonBan> GetHDBByMaHDB(string maHDB)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaHDB", maHDB)
            };

            DataTable dt = dbProcess.ExecuteQuery("GetHDBByMaHDB", parameters);
            List<HoaDonBan> hoaDonBans = new List<HoaDonBan>();
            foreach (DataRow row in dt.Rows)
            {
                HoaDonBan hdb = new HoaDonBan
                {
                    MaHDB = row["MaHDB"] != DBNull.Value ? row["MaHDB"].ToString() : null,
                    MaNV = row["MaNV"] != DBNull.Value ? row["MaNV"].ToString() : null,
                    MaKH = row["MaKH"] != DBNull.Value ? row["MaKH"].ToString() : null,
                    MaBan = row["MaBan"] != DBNull.Value ? row["MaBan"].ToString() : null,
                    NgayBan = row["NgayBan"] != DBNull.Value ? (DateTime?)row["NgayBan"] : null,
                    TriGia = row["TriGia"] != DBNull.Value ? (decimal?)row["TriGia"] : null
                };
                hoaDonBans.Add(hdb);
            }
            return hoaDonBans;
        }

        public void DeleteHoaDonBan(string maHDB)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter ("@MaHDB", maHDB)
            };
            dbProcess.ExecuteNonQuery("DeleteHoaDonBan", parameters);
        }

        public void AddHDB(HoaDonBan hoaDonBan)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaNV", hoaDonBan.MaNV),
                new SqlParameter("@MaKH", hoaDonBan.MaKH),
                new SqlParameter("@MaBan", hoaDonBan.MaBan),
                new SqlParameter("@NgayBan", hoaDonBan.NgayBan),
                new SqlParameter("@TriGia", hoaDonBan.TriGia)
            };

            dbProcess.ExecuteNonQuery("AddHoaDonBan", parameters);

            string lastestMaHDB = dbProcess.ExecuteScalar("GetLastMaHDB", null).ToString();

            foreach (var chiTiet in hoaDonBan.ChiTietHoaDonBans)
            {
                chiTiet.MaHDB = lastestMaHDB; 

                SqlParameter[] chiTietParameters =
                {
                    new SqlParameter("@MaHDB", chiTiet.MaHDB),
                    new SqlParameter("@MaSP", chiTiet.MaSP),
                    new SqlParameter("@SLBan", chiTiet.SLBan),
                    new SqlParameter("@KhuyenMai", chiTiet.KhuyenMai),
                    new SqlParameter("@ThanhTien", chiTiet.ThanhTien)
                };

                dbProcess.ExecuteNonQuery("AddChiTietHoaDonBan", chiTietParameters);
            }
        }

        public void UpdateHoaDonBan(HoaDonBan hoaDonBan)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaHDB", hoaDonBan.MaHDB),
                new SqlParameter("@MaNV", hoaDonBan.MaNV),
                new SqlParameter("@MaBan", hoaDonBan.MaBan),
                new SqlParameter("@NgayBan", hoaDonBan.NgayBan),
                new SqlParameter("@MaKH", hoaDonBan.MaKH),
            };

            dbProcess.ExecuteNonQuery("UpdateHoaDonBan", parameters);
        }

        public void UpdateChiTietHoaDonBan(HoaDonBan hoaDonBan)
        {
            foreach (var chiTiet in hoaDonBan.ChiTietHoaDonBans)
            {
                SqlParameter[] chiTietParameters =
                {
                    new SqlParameter("@MaHDB", hoaDonBan.MaHDB),
                    new SqlParameter("@MaSP", chiTiet.MaSP),
                    new SqlParameter("@SLBan", chiTiet.SLBan),
                    new SqlParameter("@KhuyenMai", chiTiet.KhuyenMai),
                };

                dbProcess.ExecuteNonQuery("UpdateChiTietHoaDonBan", chiTietParameters);
            }
        }

        public string GetLastMaHDB()
		{
			return dbProcess.ExecuteScalar("GetLastMaHDB", null).ToString();
		}

        public void UpdateTriGiaHDB(HoaDonBan hoaDonBan)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHDB", hoaDonBan.MaHDB),
                new SqlParameter("@TriGia", hoaDonBan.TriGia)
            };

            dbProcess.ExecuteNonQuery("UpdateTriGiaHDB", parameters);
        }

        public void DeleteChiTietHoaDonBan(string maHDB, string maSP)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHDB", maHDB),
                new SqlParameter("@MaSP", maSP)
            };

            dbProcess.ExecuteNonQuery("DeleteChiTietHoaDonBan", parameters);
        }
    }
}
