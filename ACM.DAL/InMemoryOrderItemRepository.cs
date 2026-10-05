using CMS.BusinessLayer;

namespace CMS.DataAccess
{
    /// <summary>
    /// Stores order item copies in memory for the CMS example.
    /// </summary>
    public class InMemoryOrderItemRepository : IOrderItemRepository
    {
        private readonly InMemoryStore<OrderItem> _store =
            new InMemoryStore<OrderItem>(orderItem => orderItem.OrderItemId, Copy);

        public OrderItem GetById(int orderItemId)
        {
            return _store.GetById(orderItemId);
        }

        public int Save(OrderItem orderItem)
        {
            return _store.Save(orderItem);
        }

        private static OrderItem Copy(OrderItem orderItem, int orderItemId)
        {
            return new OrderItem(orderItemId)
            {
                OrderId = orderItem.OrderId,
                OrderQuantity = orderItem.OrderQuantity,
                ProductId = orderItem.ProductId,
                PurchasePrice = orderItem.PurchasePrice
            };
        }
    }
}
