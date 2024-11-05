using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.Models
{
    internal class CaLamViec
    {
        public string MaCa { get; set; }
        public string TenCa { get; set; }
        public decimal? Luong { get; set; }
        public DateTime? GioBatDau { get; set; }
        public DateTime? GioKetThuc { get; set; }
    }
}
