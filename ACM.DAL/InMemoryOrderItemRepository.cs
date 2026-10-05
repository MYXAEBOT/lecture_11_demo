using System;
using System.Collections.Generic;
using CMS.BusinessLayer;

namespace CMS.DataAccess
{
    /// <summary>
    /// Stores order item copies in memory for the CMS example.
    /// </summary>
    public class InMemoryOrderItemRepository : IOrderItemRepository
    {
        private readonly Dictionary<int, OrderItem> _orderItems = new Dictionary<int, OrderItem>();
        private int _nextId = 1;

        public OrderItem GetById(int orderItemId)
        {
            OrderItem orderItem;
            return _orderItems.TryGetValue(orderItemId, out orderItem) ? Copy(orderItem) : null;
        }

        public int Save(OrderItem orderItem)
        {
            if (orderItem == null) throw new ArgumentNullException("orderItem");

            var orderItemId = orderItem.OrderItemId > 0 ? orderItem.OrderItemId : _nextId;
            _orderItems[orderItemId] = Copy(orderItem, orderItemId);
            if (orderItemId >= _nextId) _nextId = orderItemId + 1;
            return orderItemId;
        }

        private static OrderItem Copy(OrderItem orderItem)
        {
            return Copy(orderItem, orderItem.OrderItemId);
        }

        private static OrderItem Copy(OrderItem orderItem, int orderItemId)
        {
            return new OrderItem(orderItemId)
            {
                OrderQuantity = orderItem.OrderQuantity,
                ProductId = orderItem.ProductId,
                PurchasePrice = orderItem.PurchasePrice
            };
        }
    }
}
