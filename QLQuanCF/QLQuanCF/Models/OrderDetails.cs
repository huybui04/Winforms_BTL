using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.Models
{
	public class OrderDetails
	{
		public int OrderID { get; set; }
		public string MaBan { get; set; }
		public string ItemName { get; set; } 
		public int SoLuong { get; set; }
		public decimal DonGia { get; set; } 
		public decimal ThanhTien { get; set; } 
	} 
}
