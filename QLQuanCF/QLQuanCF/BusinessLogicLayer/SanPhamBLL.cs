using QLQuanCF.DataAccessLayer;
using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.BusinessLogicLayer
{
    public class SanPhamBLL
    {
        private readonly SanPhamDAL _sanPhamDAL;

        public SanPhamBLL(string connectionString)
        {
            _sanPhamDAL = new SanPhamDAL(connectionString);
        }

        // Lấy tất cả sản phẩm
        public List<SanPham> GetAllSanPham()
        {
            return _sanPhamDAL.GetAllSanPham();
        }

        // Thêm sản phẩm
        public void AddSanPham(SanPham sanPham)
        {
            // You may add additional business logic here if needed
            _sanPhamDAL.AddSanPham(sanPham);
        }

        // Cập nhật sản phẩm
        public void UpdateSanPham(SanPham sanPham)
        {
            // You may add additional business logic here if needed
            _sanPhamDAL.UpdateSanPham(sanPham);
        }

        // Xóa sản phẩm
        public void DeleteSanPham(string maSP)
        {
            // You may add additional business logic here if needed
            _sanPhamDAL.DeleteSanPham(maSP);
        }

        // Tìm kiếm sản phẩm theo tên
        public List<SanPham> GetSanPhamByName(string tenSP)
        {
            return _sanPhamDAL.GetSanPhamByName(tenSP);
        }

        public SanPham GetSanPhamByMaSanPham(string maSP)
        {
            return _sanPhamDAL.GetSanPhamByMaSanPham(maSP);
        }
    }
}
