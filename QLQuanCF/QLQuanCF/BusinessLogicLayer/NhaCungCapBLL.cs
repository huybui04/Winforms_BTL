using QLQuanCF.DataAccessLayer;
using QLQuanCF.Models;
using System.Collections.Generic;

namespace QLQuanCF.BusinessLogicLayer
{
    public class NhaCungCapBLL
    {
        private readonly NhaCungCapDAL _nhaCungCapDAL;

        public NhaCungCapBLL(string connectionString)
        {
            _nhaCungCapDAL = new NhaCungCapDAL(connectionString);
        }

        public List<NhaCungCap> GetAllNhaCungCap()
        {
            return _nhaCungCapDAL.GetAllNhaCungCap();
        }

        public void AddNhaCungCap(NhaCungCap nhaCungCap)
        {
            _nhaCungCapDAL.AddNhaCungCap(nhaCungCap);
        }

        public void UpdateNhaCungCap(NhaCungCap nhaCungCap)
        {
            _nhaCungCapDAL.UpdateNhaCungCap(nhaCungCap);
        }

        public void DeleteNhaCungCap(string maNCC)
        {
            _nhaCungCapDAL.DeleteNhaCungCap(maNCC);
        }

        public List<NhaCungCap> GetNhaCungCapByName(string tenNCC)
        {
            return _nhaCungCapDAL.GetNhaCungCapByName(tenNCC);
        }
    }
}
