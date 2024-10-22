using QLQuanCF.DataAccessLayer;
using QLQuanCF.Model;
using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.BusinessLogicLayer
{
    public class NguyenLieuBLL
    {
        private readonly NguyenLieuDAL _nguyenLieuDAL;

        public NguyenLieuBLL(string connectionString)
        {
            _nguyenLieuDAL = new NguyenLieuDAL(connectionString);
        }

        // Method to get all raw materials
        public List<NguyenLieu> GetAllNguyenLieu()
        {
            return _nguyenLieuDAL.GetAllNguyenLieu();
        }

        // Method to add a raw material
        public void AddNguyenLieu(NguyenLieu nguyenLieu)
        {
            _nguyenLieuDAL.AddNguyenLieu(nguyenLieu);
        }

        // Method to update a raw material
        public void UpdateNguyenLieu(NguyenLieu nguyenLieu)
        {
            _nguyenLieuDAL.UpdateNguyenLieu(nguyenLieu);
        }

        // Method to delete a raw material by its ID
        public void DeleteNguyenLieu(string maNL)
        {
            _nguyenLieuDAL.DeleteNguyenLieu(maNL);
        }

        // Method to get raw materials by their name
        public List<NguyenLieu> SearchNguyenLieu(string tenNL)
        {
            return _nguyenLieuDAL.SearchNguyenLieu(tenNL);
        }
    }
}
