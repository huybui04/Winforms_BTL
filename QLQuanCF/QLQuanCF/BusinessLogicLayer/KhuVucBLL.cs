using QLQuanCF.DataAccessLayer;
using QLQuanCF.Models;
using System.Collections.Generic;

namespace QLQuanCF.BusinessLogicLayer
{
	public class KhuVucBLL
	{
		private readonly KhuVucDAL _khuVucDAL;

		public KhuVucBLL(string connectionString)
		{
			_khuVucDAL = new KhuVucDAL(connectionString);
		}

		public List<KhuVuc> GetAllKhuVuc()
		{
			return _khuVucDAL.GetAllKhuVuc();
		}

		public void AddKhuVuc(KhuVuc khuVuc)
		{
			_khuVucDAL.AddKhuVuc(khuVuc);
		}

		public void UpdateKhuVuc(KhuVuc khuVuc)
		{
			_khuVucDAL.UpdateKhuVuc(khuVuc);
		}

		public void DeleteKhuVuc(string maKV)
		{
			_khuVucDAL.DeleteKhuVuc(maKV);
		}

		public List<KhuVuc> GetKhuVucByName(string tenKV)
		{
			return _khuVucDAL.GetKhuVucByName(tenKV);
		}
	}
}
