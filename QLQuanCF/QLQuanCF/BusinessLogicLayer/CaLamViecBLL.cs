using QLQuanCF.DataAccessLayer;
using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.BusinessLogicLayer
{
    internal class CaLamViecBLL
    {
        private readonly CaLamViecDAL caLamViecDAL;

        public CaLamViecBLL(string stringConnection)
        {
            caLamViecDAL = new CaLamViecDAL(stringConnection);
        }

        public List<CaLamViec> GetAllCaLamViec()
        {
            return caLamViecDAL.GetAllCaLamViec();
        }
        public void DeleteCaLamViec(string maCa)
        {
            caLamViecDAL.DeleteCaLamViec(maCa);
        }
        public List<CaLamViec> GetCaLamViecByName(string tenCa)
        {
            return caLamViecDAL.GetCaLamViecByName(tenCa);
        }
        public void AddCaLamViec(CaLamViec caLamViec)
        {
            caLamViecDAL.AddCaLamViec(caLamViec);
        }
        public void UpdateCaLamViec(CaLamViec ca)
        {
            caLamViecDAL.UpdateCaLamViec(ca);
        }
    }
}
