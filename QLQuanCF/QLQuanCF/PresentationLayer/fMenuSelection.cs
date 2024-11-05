<<<<<<< HEAD
﻿using QLQuanCF.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
﻿using System;
>>>>>>> 3e3d3c8db24084d5b82365d244268a861d54afcf
using System.Windows.Forms;

namespace QLQuanCF
{
    public partial class fMenuSelection : Form
    {
        private SanPhamBLL _sanPhamBLL;
        public fMenuSelection()
        {
            InitializeComponent();
            _sanPhamBLL = new SanPhamBLL(Classes.DbConfig.connectString);
            LoadSanPhamData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadSanPhamData()
        {
            var sanPhamList = _sanPhamBLL.GetAllSanPham();
            dataChonMon.DataSource = sanPhamList;
        }
    }
}
