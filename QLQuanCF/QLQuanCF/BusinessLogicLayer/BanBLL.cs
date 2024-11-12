using QLQuanCF.DataAccessLayer;
using QLQuanCF.Models;
using System.Collections.Generic;

namespace QLQuanCF.BusinessLogicLayer
{
	public class BanBLL
	{
		private readonly BanDAL _banDAL;

		public BanBLL(string connectionString)
		{
			_banDAL = new BanDAL(connectionString);
		}

		public List<Ban> GetAllBan()
		{
			return _banDAL.GetAllBan();
		}

		public void AddBan(Ban ban)
		{
			_banDAL.AddBan(ban);
		}

		public void UpdateBan(Ban ban)
		{
			_banDAL.UpdateBan(ban);
		}

		public void DeleteBan(string maBan)
		{
			_banDAL.DeleteBan(maBan);
		}

		public List<Ban> GetBanByName(string tenBan)
		{
			return _banDAL.GetBanByName(tenBan);
		}

		public List<string> GetKhuVucList()
		{
			return _banDAL.GetKhuVucList();
		}

		public List<string> GetTrangThaiList()
		{
			return _banDAL.GetTrangThaiList();
		}

		public List<Ban> GetBanByKhuVuc(string maKV)
		{
			return _banDAL.GetBanByKhuVuc(maKV);
		}
        public Ban GetBanByMaBan(string maBan)
        {
            return _banDAL.GetBanByMaBan(maBan);
        }

		public void UpdateTrangThaiBan(string maBan, string trangThai)
		{
			_banDAL.UpdateTrangThaiBan(maBan, trangThai);
		}
	}
}
