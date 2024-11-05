﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.Models
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string MaCa { get; set; }
        public string TenNV { get; set; }
        public string ChucVu { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
    }
}
