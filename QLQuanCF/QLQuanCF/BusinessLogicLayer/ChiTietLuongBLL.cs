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
    }
}
