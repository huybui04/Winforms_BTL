using QLQuanCF.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.BusinessLogicLayer
{
    public class BaoCaoBLL
    {
        private readonly BaoCaoDAL _baoCaoDAL;

        public BaoCaoBLL(string connectionString)
        {
            _baoCaoDAL = new BaoCaoDAL(connectionString);
        }

        public DataTable GetBaoCaoByDateRange(DateTime tuNgay, DateTime denNgay)
        {
            return _baoCaoDAL.GetBaoCaoByDateRange(tuNgay, denNgay);
        }

        public decimal GetTongTienTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                return _baoCaoDAL.GetTotalByDateRange(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in BLL: " + ex.Message);
            }
        }

    }
}
