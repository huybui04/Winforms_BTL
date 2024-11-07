using QLQuanCF.DataAccessLayer;
using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.BusinessLogicLayer
{
    internal class SanPhamBLL
    {
        private readonly SanPhamDAL sanPhamDAL;

        public SanPhamBLL(string stringConnection)
        {
            sanPhamDAL = new SanPhamDAL(stringConnection);
        }

        public List<SanPham> GetAllSanPham()
        {
            return sanPhamDAL.GetAllSanPham();
        }

        public SanPham GetSanPhamByMaSanPham(string maSP)
        {
            return sanPhamDAL.GetSanPhamByMaSanPham(maSP);
        }
    }
}
