using QLQuanCF.DataAccessLayer;
using QLQuanCF.Models;
using System.Collections.Generic;

namespace QLQuanCF.BusinessLogicLayer
{
    public class NguyenLieuBLL
    {
        private readonly NguyenLieuDAL _nguyenLieuDAL;

        public NguyenLieuBLL(string connectionString)
        {
            _nguyenLieuDAL = new NguyenLieuDAL(connectionString);
        }

        public List<NguyenLieu> GetAllNguyenLieu()
        {
            return _nguyenLieuDAL.GetAllNguyenLieu();
        }

        public void AddNguyenLieu(NguyenLieu nguyenLieu)
        {
            _nguyenLieuDAL.AddNguyenLieu(nguyenLieu);
        }

        public void UpdateNguyenLieu(NguyenLieu nguyenLieu)
        {
            _nguyenLieuDAL.UpdateNguyenLieu(nguyenLieu);
        }

        public void DeleteNguyenLieu(string maNL)
        {
            _nguyenLieuDAL.DeleteNguyenLieu(maNL);
        }

        public List<NguyenLieu> SearchNguyenLieu(string tenNL)
        {
            return _nguyenLieuDAL.SearchNguyenLieu(tenNL);
        }
    }
}
