using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.Models
{
    public class HoaDonNhap
    {
        public string MaHDN { get; set; }
        public string MaNV { get; set; }
        public DateTime? NgayNhap { get; set; }
        public string MaNCC { get; set; }
        public decimal? TriGia { get; set; }
    }
}
