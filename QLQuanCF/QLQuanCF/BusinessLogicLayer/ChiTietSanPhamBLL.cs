using QLQuanCF.DataAccessLayer;
using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.BusinessLogicLayer
{
    internal class ChiTietSanPhamBLL
    {
        private readonly ChiTietSanPhamDAL chiTietSanPhamDAL;

        public ChiTietSanPhamBLL(string connectionString)
        {
            chiTietSanPhamDAL = new ChiTietSanPhamDAL(connectionString);
        }

        public List<ChiTietSanPham> GetAllChiTietSanPham()
        {
            return chiTietSanPhamDAL.GetAllChiTietSanPham();
        }

        public void DeleteCTSP(string maSP, string maNL)
        {
            chiTietSanPhamDAL.DeleteCTSP(maSP, maNL);
        }

        public List<ChiTietSanPham> GetCTSPByMaSP(string maSP)
        {
            return chiTietSanPhamDAL.GetCTSPByMaSP(maSP);
        }

        public void AddCTSP(ChiTietSanPham chiTietSanPham)
        {
            chiTietSanPhamDAL.AddCTSP(chiTietSanPham);
        }

        public void UpdateCTSP(ChiTietSanPham chiTietSanPham)
        {
            chiTietSanPhamDAL.UpdateCTSP(chiTietSanPham);
        }
    }
}
