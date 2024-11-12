using QLQuanCF.DataAccessLayer;
using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.BusinessLogicLayer
{
    internal class HoaDonBanBLL
    {
        private readonly HoaDonBanDAL hoaDonBanDAL;

        public HoaDonBanBLL(string stringConnection)
        {
            hoaDonBanDAL = new HoaDonBanDAL(stringConnection);
        }

        public List<HoaDonBan> GetAllHDB()
        {
            return hoaDonBanDAL.GetAllHDB();
        }

        public List<ChiTietHoaDonBan> GetChiTietHoaDonBanByMaHDB(string maHDB)
        {
            return hoaDonBanDAL.GetChiTietHoaDonBanByMaHDB(maHDB);
        }
        
        public List<HoaDonBan> GetHDBByMaHDB(string maHDB)
        {
            return hoaDonBanDAL.GetHDBByMaHDB(maHDB);
        }

        public void DeleteHDB(string maHDB)
        {
            hoaDonBanDAL.DeleteHoaDonBan(maHDB);
        }

        public void AddHDB(HoaDonBan hoaDonBan)
        {
            hoaDonBanDAL.AddHDB(hoaDonBan);
        }

        public void UpdateHoaDonBan(HoaDonBan hoaDonBan)
        {
            hoaDonBanDAL.UpdateHoaDonBan(hoaDonBan);
        }

        public void UpdateChiTietHoaDonBan(HoaDonBan hoaDonBan)
        {
            hoaDonBanDAL.UpdateChiTietHoaDonBan(hoaDonBan);
        }

        public string GetLastMaHDB()
		{
			return hoaDonBanDAL.GetLastMaHDB();
		}

        /*public HoaDonBan GetHoaDonInfoByMaBan(string maBan)
		{
			return hoaDonBanDAL.GetHoaDonInfoByMaBan(maBan);
		}

        public HoaDonBan showBill(string maBan)
		{
			return hoaDonBanDAL.ShowBill(maBan);
		}*/

        public void UpdateTriGiaHDB(HoaDonBan hoaDonBan)
        {
            hoaDonBanDAL.UpdateTriGiaHDB(hoaDonBan);
        }

        public void DeleteChiTietHoaDonBan(string maHDB, string maSP)
        {
            hoaDonBanDAL.DeleteChiTietHoaDonBan(maHDB, maSP);
        }

    }
}
