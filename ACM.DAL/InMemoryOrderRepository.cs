using System;
using System.Collections.Generic;
using CMS.BusinessLayer;

namespace CMS.DataAccess
{
    /// <summary>
    /// Stores order copies in memory for the CMS example.
    /// </summary>
    public class InMemoryOrderRepository : IOrderRepository
    {
        private readonly Dictionary<int, Order> _orders = new Dictionary<int, Order>();
        private int _nextId = 1;

        public Order GetById(int orderId)
        {
            Order order;
            return _orders.TryGetValue(orderId, out order) ? Copy(order) : null;
        }

        public int Save(Order order)
        {
            if (order == null) throw new ArgumentNullException("order");

            var orderId = order.OrderId > 0 ? order.OrderId : _nextId;
            _orders[orderId] = Copy(order, orderId);
            if (orderId >= _nextId) _nextId = orderId + 1;
            return orderId;
        }

        private static Order Copy(Order order)
        {
            return Copy(order, order.OrderId);
        }

        private static Order Copy(Order order, int orderId)
        {
            return new Order(orderId) { OrderDate = order.OrderDate };
        }
    }
}
