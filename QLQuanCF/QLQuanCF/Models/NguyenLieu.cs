using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.Models
{
    public class NguyenLieu
    {
        public string MaNL { get; set; }      
        public string TenNL { get; set; }     
        public string DonVi { get; set; }     
        public decimal? Gia { get; set; }     
        public int? SoLuong { get; set; }   
        public DateTime? NgaySanXuat { get; set; } 
        public DateTime? HanSuDung { get; set; }    
    }


}
