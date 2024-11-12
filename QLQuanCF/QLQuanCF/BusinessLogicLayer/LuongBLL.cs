using QLQuanCF.DataAccessLayer;
using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.BusinessLogicLayer
{
    public class LuongBLL
    {
        private readonly LuongDAL _luongDAL;

        public LuongBLL(string connectionString)
        {
            _luongDAL = new LuongDAL(connectionString);
        }

        // Method to get all records of Luong
        public List<Luong> GetAllLuong()
        {
            return _luongDAL.GetAllLuong();
        }

        // Method to add a new Luong record
        public void AddLuong(Luong luong)
        {
            _luongDAL.AddLuong(luong);
        }

        // Method to update an existing Luong record
        public void UpdateLuong(Luong luong)
        {
            _luongDAL.UpdateLuong(luong);
        }

        // Method to delete a Luong record by MaNV and MaCa
        public void DeleteLuong(string maNV, string maCa)
        {
            _luongDAL.DeleteLuong(maNV, maCa);
        }

        // Method to search for Luong records by keyword (can be MaNV or MaCa)
        public List<Luong> SearchLuong(string keyword)
        {
            return _luongDAL.SearchLuong(keyword);
        }
    }

}
