using QLQuanCF.DataAccessLayer;
using QLQuanCF.Models;
using System.Collections.Generic;
using System.Data;

namespace QLQuanCF.BusinessLogicLayer
{
    public class HoaDonNhapBLL
    {
        private readonly HoaDonNhapDAL _hoaDonNhapDAL;
        public HoaDonNhapBLL(string connectionString)
        {
            _hoaDonNhapDAL = new HoaDonNhapDAL(connectionString);
        }
        public List<HoaDonNhap> GetAllHoaDonNhap()
        {
            return _hoaDonNhapDAL.GetAllHoaDonNhap();
        }
        public void AddHoaDonNhap(HoaDonNhap hoaDonNhap)
        {
            _hoaDonNhapDAL.AddHoaDonNhap(hoaDonNhap);
        }
        public void UpdateHoaDonNhap(HoaDonNhap hoaDonNhap)
        {
            _hoaDonNhapDAL.UpdateHoaDonNhap(hoaDonNhap);
        }
        public void DeleteHoaDonNhap(string maHDN)
        {
            _hoaDonNhapDAL.DeleteHoaDonNhap(maHDN);
        }
        public List<HoaDonNhap> SearchHoaDonNhap(string maHDN)
        {
            return _hoaDonNhapDAL.SearchHoaDonNhap(maHDN);
        }
        public List<ChiTietHoaDonNhap> GetChiTietHoaDonNhapByMaHDN(string maHDN)
        {
            return _hoaDonNhapDAL.GetChiTietHoaDonNhapByMaHDN(maHDN);
        }
        public decimal GetGiaNguyenLieu(string maNL)
        {
            return _hoaDonNhapDAL.GetGiaNguyenLieu(maNL);
        }
        public DataTable GetAllMaNguyenLieu()
        {
            return _hoaDonNhapDAL.GetAllMaNguyenLieu();
        }
        public void UpdateChiTietHoaDonNhap(string maHDN, string maNL, int slNhap, decimal thanhTien)
        {
            _hoaDonNhapDAL.UpdateChiTietHoaDonNhap(maHDN, maNL, slNhap, thanhTien);
        }

        public void AddChiTietHoaDonNhap(string maHDN, string maNL, int slNhap, decimal thanhTien)
        {
            _hoaDonNhapDAL.AddChiTietHoaDonNhap(maHDN, maNL, slNhap, thanhTien);
        }
        public void AddOrUpdateChiTietHoaDonNhap(string maHDN, string maNL, int slNhap, decimal thanhTien)
        {
            _hoaDonNhapDAL.AddOrUpdateChiTietHoaDonNhap(maHDN, maNL, slNhap, thanhTien);
        }

        public HoaDonNhap GetHoaDonNhapByMaHDN(string maHDN)
        {
            return _hoaDonNhapDAL.GetHoaDonNhapByMaHDN(maHDN);
        }
        public ChiTietHoaDonNhap GetChiTietHoaDonNhapByMaHDNAndMaNL(string maHDN, string maNL)
        {
            return _hoaDonNhapDAL.GetChiTietHoaDonNhapByMaHDNAndMaNL(maHDN, maNL);
        }
        public void DeleteChiTietHoaDonNhap(string maHDN, string maNL)
        {
            _hoaDonNhapDAL.DeleteChiTietHoaDonNhap(maHDN, maNL);
        }

    }
}