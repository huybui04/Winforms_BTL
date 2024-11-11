using QLQuanCF.DataAccessLayer;
using QLQuanCF.Models;
using System.Collections.Generic;

namespace QLQuanCF.BusinessLogicLayer
{
    public class DMSanPhamBLL
    {
        private readonly DMSanPhamDAL _danhMucSanPhamDAL;

        public DMSanPhamBLL(string connectionString)
        {
            _danhMucSanPhamDAL = new DMSanPhamDAL(connectionString);
        }

        public List<DanhMucSanPham> GetAllDanhMucSanPham()
        {
            return _danhMucSanPhamDAL.GetAllDanhMucSanPham();
        }

        public void AddDanhMucSanPham(DanhMucSanPham danhMuc)
        {
            _danhMucSanPhamDAL.AddDanhMucSanPham(danhMuc);
        }

        public void UpdateDanhMucSanPham(DanhMucSanPham danhMuc)
        {
            _danhMucSanPhamDAL.UpdateDanhMucSanPham(danhMuc);
        }

        public void DeleteDanhMucSanPham(string maDM)
        {
            _danhMucSanPhamDAL.DeleteDanhMucSanPham(maDM);
        }

        public List<DanhMucSanPham> GetDanhMucSanPhamByName(string tenDM)
        {
            return _danhMucSanPhamDAL.GetDanhMucSanPhamByName(tenDM);
        }

        public string GetTenDanhMucSanPhamByMa(string maDM)
        {
            return _danhMucSanPhamDAL.GetTenDanhMucSanPhamByMa(maDM);
        }
    }
}
