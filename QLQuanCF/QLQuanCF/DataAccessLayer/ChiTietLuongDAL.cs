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
    internal class ChiTietLuongDAL
    {
        private readonly DbProcess dbProcess;

        public ChiTietLuongDAL(string connectString)
        {
            dbProcess = new DbProcess(connectString);
        }

        public List<ChiTietLuong> GetChiTietLuongByDate(DateTime selectedDate)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@SelectedDate", selectedDate)
            };

            DataTable dataTable = dbProcess.ExecuteQuery("GetChiTietLuongByDate", parameters);
            List<ChiTietLuong> chiTietLuongList = new List<ChiTietLuong>();

            foreach (DataRow row in dataTable.Rows)
            {
                ChiTietLuong chiTietLuong = new ChiTietLuong
                {
                    MaNV = row["MaNV"].ToString(),
                    MaCa = row["MaCa"].ToString(),
                    Ngay = Convert.ToDateTime(row["Ngay"])
                };

                chiTietLuongList.Add(chiTietLuong);
            }

            return chiTietLuongList;
        }

        public void AddChiTietLuong(ChiTietLuong chiTietLuong)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaNV", chiTietLuong.MaNV),
                new SqlParameter("@MaCa", chiTietLuong.MaCa),
                new SqlParameter("@Ngay", chiTietLuong.Ngay)
            };

            dbProcess.ExecuteNonQuery("AddChiTietLuong", parameters);
        }

        public List<ChiTietLuong> GetChiTietLuongByShiftAndDay(string maCa, DateTime ngay)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaCa", maCa),
                new SqlParameter("@Ngay", ngay)
            };

            DataTable dt = dbProcess.ExecuteQuery("GetChiTietLuongByShiftAndDay", parameters);
            List<ChiTietLuong> chiTietLuongList = new List<ChiTietLuong>();

            foreach (DataRow row in dt.Rows)
            {
                ChiTietLuong ctl = new ChiTietLuong
                {
                    MaNV = row["MaNV"].ToString(),
                    MaCa = row["MaCa"].ToString(),
                    Ngay = Convert.ToDateTime(row["Ngay"])
                };
                chiTietLuongList.Add(ctl);
            }
            return chiTietLuongList;
        }

        public void DeleteChiTietLuong(string maNV, string maCa, DateTime ngay)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@MaCa", maCa),
                new SqlParameter("@Ngay", ngay)
            };

            dbProcess.ExecuteNonQuery("DeleteChiTietLuong", parameters);
        }

        public List<ChiTietLuong> GetChiTietLuongByMaNV(string maNV)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaNV", maNV)
            };

            DataTable dt = dbProcess.ExecuteQuery("GetChiTietLuongByMaNV", parameters);
            List<ChiTietLuong> chiTietLuongs = new List<ChiTietLuong>();
            foreach (DataRow row in dt.Rows)
            {
                ChiTietLuong ctl = new ChiTietLuong
                {
                    MaNV = row["MaNV"].ToString(),
                    MaCa = row["MaCa"].ToString(),
                    Ngay = Convert.ToDateTime(row["Ngay"])
                };

                chiTietLuongs.Add(ctl);
            }
            return chiTietLuongs;
        }

        public void UpdateChiTietLuong(ChiTietLuong chiTietLuong, ChiTietLuong newChiTietLuong)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNV", chiTietLuong.MaNV),
                new SqlParameter("@MaCa", chiTietLuong.MaCa),
                new SqlParameter("@Ngay", chiTietLuong.Ngay),
                new SqlParameter("@NewMaNV", newChiTietLuong.MaNV),
                new SqlParameter("@NewMaCa", newChiTietLuong.MaCa),
                new SqlParameter("@NewNgay", newChiTietLuong.Ngay)
            };

            dbProcess.ExecuteNonQuery("UpdateChiTietLuong", parameters);
        }

        public List<ChiTietLuong> GetAllChiTietLuong()
        {
            DataTable dt = dbProcess.ExecuteQuery("GetAllChiTietLuong", null);
            List<ChiTietLuong> chiTietLuongs = new List<ChiTietLuong>();

            foreach (DataRow row in dt.Rows)
            {
                ChiTietLuong ctl = new ChiTietLuong
                {
                    MaNV = row["MaNV"].ToString(),
                    MaCa = row["MaCa"].ToString(),
                    Ngay = Convert.ToDateTime(row["Ngay"])
                };
                chiTietLuongs.Add(ctl);
            }
            return chiTietLuongs;
        }
    }
}
