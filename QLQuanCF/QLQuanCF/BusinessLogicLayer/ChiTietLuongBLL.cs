using QLQuanCF.DataAccessLayer;
using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.BusinessLogicLayer
{
    internal class ChiTietLuongBLL
    {
        private readonly ChiTietLuongDAL chiTietLuongDAL;

        public ChiTietLuongBLL(string connectString)
        {
            chiTietLuongDAL = new ChiTietLuongDAL(connectString);
        }

        public List<ChiTietLuong> GetChiTietLuongByDate(DateTime selectedDate)
        {
            return chiTietLuongDAL.GetChiTietLuongByDate(selectedDate);
        }

        public void AddChiTietLuong(ChiTietLuong ctl)
        {
            chiTietLuongDAL.AddChiTietLuong(ctl);
        }

        public List<ChiTietLuong> GetChiTietLuongByShiftAndDay(string maCa, DateTime ngay)
        {
            return chiTietLuongDAL.GetChiTietLuongByShiftAndDay(maCa, ngay);
        }

        public void DeleteChiTietLuong(string maNV, string maCa, DateTime ngay)
        {
            chiTietLuongDAL.DeleteChiTietLuong(maNV, maCa, ngay);
        }

        public List<ChiTietLuong> GetChiTietLuongByMaNV(string maNV)
        {
            return chiTietLuongDAL.GetChiTietLuongByMaNV(maNV);
        }
        
        public void UpdateChiTietLuong(ChiTietLuong chiTietLuong, ChiTietLuong newChiTietLuong)
        {
            chiTietLuongDAL.UpdateChiTietLuong(chiTietLuong, newChiTietLuong);
        }

        public List<ChiTietLuong> GetAllChiTietLuong()
        {
            return chiTietLuongDAL.GetAllChiTietLuong();
        }

        public List<dynamic> GetLuongAndSoLuongMoiCa(DateTime selectedDate)
        {
            return chiTietLuongDAL.GetLuongAndSoLuongMoiCa(selectedDate);
        }

        public List<dynamic> ThongKeLuongThang(DateTime selectedDate)
        {
            return chiTietLuongDAL.ThongKeLuongThang(selectedDate);
        }

        public List<dynamic> GetChiTietThongKeLuong(string maNV, string maCa, DateTime selectedDate)
        {
            return chiTietLuongDAL.GetChiTietThongKeLuong(maNV, maCa, selectedDate);
        }

        public List<dynamic> GetLuongThangByMaNV(string maNV, DateTime selectedDate)
        {
            return chiTietLuongDAL.GetLuongThangByMaNV(maNV, selectedDate);
        }
    }
}
