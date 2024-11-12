using QLQuanCF.DataAccessLayer;
using QLQuanCF.Models;
using System.Collections.Generic;

namespace QLQuanCF.BusinessLogicLayer
{
    public class KhachHangBLL
    {
        private readonly KhachHangDAL _khachHangDAL;

        public KhachHangBLL(string connectionString)
        {
            _khachHangDAL = new KhachHangDAL(connectionString);
        }

        public List<KhachHang> GetAllKhachHang()
        {
            return _khachHangDAL.GetAllKhachHang();
        }

        public void AddKhachHang(KhachHang khachHang)
        {
            _khachHangDAL.AddKhachHang(khachHang);
        }

        public void UpdateKhachHang(KhachHang khachHang)
        {
            _khachHangDAL.UpdateKhachHang(khachHang);
        }

        public void DeleteKhachHang(string maKH)
        {
            _khachHangDAL.DeleteKhachHang(maKH);
        }

        public List<KhachHang> GetKhachHangByName(string tenKH)
        {
            return _khachHangDAL.GetKhachHangByName(tenKH);
        }

        public KhachHang GetKhachHangBySDT(string sdt)
        {
            return _khachHangDAL.GetKhachHangBySDT(sdt);
        }

        public KhachHang GetKhachHangByMaKH(string maKH)
        {
            return _khachHangDAL.GetKhachHangByMaKH(maKH);
        }
    }
}
