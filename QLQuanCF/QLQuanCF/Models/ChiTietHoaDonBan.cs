using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.Models
{
    public class ChiTietHoaDonBan
    {
        public string MaHDB { get; set; }
        public string MaSP { get; set; }
        public int? SLBan { get; set; }
        public string KhuyenMai { get; set; }
        public decimal? ThanhTien { get; set; }
    }
}
