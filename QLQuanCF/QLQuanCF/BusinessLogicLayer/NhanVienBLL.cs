﻿using QLQuanCF.DataAccessLayer;
using QLQuanCF.Model;
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

        public List<string> GetCaLamViecList()
        {
            return _nhanVienDAL.GetCaLamViecList();
        }
    }
}
