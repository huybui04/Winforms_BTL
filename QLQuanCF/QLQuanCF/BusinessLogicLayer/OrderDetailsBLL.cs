using QLQuanCF.DataAccessLayer;
using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.BusinessLogicLayer
{
	public class OrderDetailsBLL
	{
		private readonly OrderDetailsDAL _orderDetailsDAL;

		public OrderDetailsBLL(string connectionString)
		{
			_orderDetailsDAL = new OrderDetailsDAL(connectionString);
		}

		public void AddOrderItem(OrderDetails orderDetail)
		{
			_orderDetailsDAL.AddOrderItem(orderDetail);
		}

		public void UpdateOrderItem(string maBan, string itemName, int newQuantity)
		{
			_orderDetailsDAL.UpdateOrderItem(maBan, itemName, newQuantity);
		}

		public void DeleteOrderItem(string maBan, string itemName)
		{
			_orderDetailsDAL.DeleteOrderItem(maBan, itemName);
		}

		public List<OrderDetails> GetOrderDetailsByTable(string maBan)
		{
			return _orderDetailsDAL.GetOrderDetailsByTable(maBan);
		}

		public void DeleteOrderDetailsByTable(string maBan)
		{
			_orderDetailsDAL.DeleteOrderDetailsByTable(maBan);
		}
	}
}
