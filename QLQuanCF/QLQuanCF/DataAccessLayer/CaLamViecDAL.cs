using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.DataAccessLayer
{
    internal class CaLamViecDAL
    {
        private readonly DbProcess dbProcess;

        public CaLamViecDAL(string connectionString)
        {
            dbProcess = new DbProcess(connectionString);
        }

        public List<CaLamViec> GetAllCaLamViec()
        {
            DataTable dt = dbProcess.ExecuteQuery("GetAllCaLamViec", null);
            List<CaLamViec> caLamViecs = new List<CaLamViec>();

            foreach (DataRow row in dt.Rows)
            {
                CaLamViec ca = new CaLamViec
                {
                    MaCa = row["MaCa"] != DBNull.Value ? row["MaCa"].ToString() : null,
                    TenCa = row["TenCa"] != DBNull.Value ? row["TenCa"].ToString() : null,
                    Luong = row["Luong"] != DBNull.Value ? (decimal?)row["Luong"] : null,
                    GioBatDau = row["GioBatDau"] != DBNull.Value ? (TimeSpan?)row["GioBatDau"] : null,
                    GioKetThuc = row["GioKetThuc"] != DBNull.Value ? (TimeSpan?)row["GioKetThuc"] : null
                };
                caLamViecs.Add(ca);
            }
            return caLamViecs;
        }
        public void DeleteCaLamViec(string maCa)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaCa", maCa)
            };
            dbProcess.ExecuteNonQuery("DeleteCaLamViec", parameters);
        }

        public List<CaLamViec> GetCaLamViecByName(string tenCa)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@TenCa", tenCa)
            };

            DataTable dt = dbProcess.ExecuteQuery("GetCaLamViecByName", parameters);
            List<CaLamViec> caLamViecs = new List<CaLamViec>();

            foreach (DataRow row in dt.Rows)
            {
                CaLamViec ca = new CaLamViec
                {
                    MaCa = row["MaCa"] != DBNull.Value ? row["MaCa"].ToString() : null,
                    TenCa = row["TenCa"] != DBNull.Value ? row["TenCa"].ToString() : null,
                    Luong = row["Luong"] != DBNull.Value ? (decimal?)row["Luong"] : null,
                    GioBatDau = row["GioBatDau"] != DBNull.Value ? (TimeSpan?)row["GioBatDau"] : null,
                    GioKetThuc = row["GioKetThuc"] != DBNull.Value ? (TimeSpan?)row["GioKetThuc"] : null
                };
                caLamViecs.Add(ca);
            }
            return caLamViecs;
        }

        public void AddCaLamViec(CaLamViec ca)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@TenCa", ca.TenCa),
                new SqlParameter("@Luong", ca.Luong),
                new SqlParameter("@GioBatDau", ca.GioBatDau),
                new SqlParameter("@GioKetThuc", ca.GioKetThuc)
            };
            dbProcess.ExecuteNonQuery("AddCaLamViec", parameters);
        }

        public void UpdateCaLamViec(CaLamViec ca)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaCa", ca.MaCa),
                new SqlParameter("@TenCa", ca.TenCa),
                new SqlParameter("@Luong", ca.Luong),
                new SqlParameter("@GioBatDau", ca.GioBatDau),
                new SqlParameter("@GioKetThuc", ca.GioKetThuc)
            };
            dbProcess.ExecuteNonQuery("UpdateCaLamViec", parameters);
        }
    }
}
