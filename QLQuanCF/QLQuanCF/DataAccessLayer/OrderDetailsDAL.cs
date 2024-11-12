using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.DataAccessLayer
{
	public class OrderDetailsDAL
	{
		private readonly DbProcess _dbProcess;
		public OrderDetailsDAL(string connectionString)
		{
			_dbProcess = new DbProcess(connectionString);
		}

		public void AddOrderItem(OrderDetails orderDetail)
		{
			SqlParameter[] parameters =
			{
				new SqlParameter("@MaBan", orderDetail.MaBan),
				new SqlParameter("@ItemName", orderDetail.ItemName),
				new SqlParameter("@Quantity", orderDetail.SoLuong),
				new SqlParameter("@Price", orderDetail.DonGia)
			};

			_dbProcess.ExecuteNonQuery("AddOrderItem", parameters);
		}

		// Thủ tục cập nhật số lượng món trong bàn
		public void UpdateOrderItem(string maBan, string itemName, int newQuantity)
		{
			SqlParameter[] parameters =
			{
				new SqlParameter("@MaBan", maBan),
				new SqlParameter("@ItemName", itemName),
				new SqlParameter("@NewQuantity", newQuantity)
			};

			_dbProcess.ExecuteNonQuery("UpdateOrderItem", parameters);
		}

		// Thủ tục xóa món trong bàn
		public void DeleteOrderItem(string maBan, string itemName)
		{
			SqlParameter[] parameters =
			{
				new SqlParameter("@MaBan", maBan),
				new SqlParameter("@ItemName", itemName)
			};

			_dbProcess.ExecuteNonQuery("DeleteOrderItem", parameters);
		}

		// Thủ tục lấy thông tin các món trong bàn
		public List<OrderDetails> GetOrderDetailsByTable(string maBan)
		{
			SqlParameter[] parameters =
			{
				new SqlParameter("@MaBan", maBan)
			};

			DataTable table = _dbProcess.ExecuteQuery("GetOrderDetailsByTable", parameters);

			List<OrderDetails> orderDetails = new List<OrderDetails>();
			foreach (DataRow row in table.Rows)
			{
				orderDetails.Add(new OrderDetails
				{
					ItemName = row["ItemName"].ToString(),
					SoLuong = Convert.ToInt32(row["Quantity"]),
					DonGia = Convert.ToDecimal(row["Price"]),
					ThanhTien = Convert.ToDecimal(row["TotalPrice"]) 
				});
			}

			return orderDetails;
		}

		public void DeleteOrderDetailsByTable(string maBan)
		{
			SqlParameter[] parameters =
			{
				new SqlParameter("@MaBan", maBan)
			};

			_dbProcess.ExecuteNonQuery("DeleteOrderDetailsByTable", parameters);
		}
	}
}