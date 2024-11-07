using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.Models
{
    internal class HoaDonBan
    {
        public string MaHDB { get; set; }
        public string MaNV { get; set; }
        public string MaBan { get; set; }
        public DateTime? NgayBan { get; set; }
        public string MaKH { get; set; }
        public decimal? TriGia { get; set; }
        public List<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; }
    }
}
