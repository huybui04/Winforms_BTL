using QLQuanCF.DataAccessLayer;
using QLQuanCF.Models;
using System;
using System.Collections.Generic;

namespace QLQuanCF.BusinessLogicLayer
{
    public class NhanVienBLL
    {
        private readonly NhanVienDAL _nhanVienDAL;

        public NhanVienBLL(string connectionString)
        {
            _nhanVienDAL = new NhanVienDAL(connectionString);
        }

        public List<string> GetALlMaNV()
        {
            return _nhanVienDAL.GetAllMaNV();
        }

        public List<NhanVien> GetAllNhanVien()
        {
            return _nhanVienDAL.GetAllNhanVien();
        }

        public void AddNhanVien(NhanVien nhanVien)
        {
            _nhanVienDAL.AddNhanVien(nhanVien);
        }

        public void UpdateNhanVien(NhanVien nhanVien)
        {
            _nhanVienDAL.UpdateNhanVien(nhanVien);
        }

        public void DeleteNhanVien(string maNV)
        {
            _nhanVienDAL.DeleteNhanVien(maNV);
        }

        public List<NhanVien> GetNhanVienByName(string tenNV)
        {
            return _nhanVienDAL.GetNhanVienByName(tenNV);
        }

        public NhanVien GetNhanVienByMaNV(string maNV)
        {
            return _nhanVienDAL.GetNhanVienByMaNV(maNV);
        }
    }
}
