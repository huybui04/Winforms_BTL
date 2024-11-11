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

		/*public HoaDonBan GetHoaDonInfoByMaBan(string maBan)
		{

			SqlParameter[] parameters = new SqlParameter[]
			{
		        new SqlParameter("@MaBan", SqlDbType.NVarChar) { Value = maBan }
			};

			DataTable dt = dbProcess.ExecuteQuery("GetHoaDonInfoByMaBan", parameters);

			// Kiểm tra nếu có dữ liệu trả về
			if (dt.Rows.Count > 0)
			{
				// Lấy dữ liệu từ DataTable và chuyển đổi thành đối tượng HoaDonBan
				DataRow row = dt.Rows[0]; // Giả sử chỉ có một kết quả
				HoaDonBan hoaDonBan = new HoaDonBan
				{
					MaHDB = row["MaHDB"].ToString(),
					NgayBan = row["NgayVao"] != DBNull.Value ? (DateTime?)row["NgayVao"] : null,
					MaNV = row["TenNhanVien"].ToString(),
					MaKH = row["TenKhachHang"].ToString(),
					TriGia = row["TongTien"] != DBNull.Value ? (decimal?)row["TongTien"] : null
				};
			}

			return null;
		}*/

		/*public HoaDonBan ShowBill(string maBan)
		{
			// Lấy thông tin hóa đơn từ mã bàn
			HoaDonBan hoaDonBan = GetHoaDonInfoByMaBan(maBan);

			if (hoaDonBan == null)
			{
				// Nếu không có hóa đơn, trả về null hoặc thông báo lỗi
				return null;
			}

			// Lấy chi tiết hóa đơn bán từ mã hóa đơn
			List<ChiTietHoaDonBan> chiTietHoaDonBans = GetChiTietHoaDonBanByMaHDB(hoaDonBan.MaHDB);

			// Gắn chi tiết hóa đơn vào thông tin hóa đơn
			hoaDonBan.ChiTietHoaDonBans = chiTietHoaDonBans;

			// Trả về hóa đơn đã đầy đủ thông tin
			return hoaDonBan;
		}*/
	}
}
