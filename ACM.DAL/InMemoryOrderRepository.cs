using CMS.BusinessLayer;

namespace CMS.DataAccess
{
    /// <summary>
    /// Stores order copies in memory for the CMS example.
    /// </summary>
    public class InMemoryOrderRepository : IOrderRepository
    {
        private readonly InMemoryStore<Order> _store =
            new InMemoryStore<Order>(order => order.OrderId, Copy);

        public Order GetById(int orderId)
        {
            return _store.GetById(orderId);
        }

        public int Save(Order order)
        {
            return _store.Save(order);
        }

        private static Order Copy(Order order, int orderId)
        {
            return new Order(orderId)
            {
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                ShippingAddress = Copy(order.ShippingAddress)
            };
        }

        private static Address Copy(Address address)
        {
            if (address == null) return null;

            return new Address
            {
                StreetLine1 = address.StreetLine1,
                StreetLine2 = address.StreetLine2,
                City = address.City,
                StateOrProvince = address.StateOrProvince,
                PostalCode = address.PostalCode,
                Country = address.Country
            };
        }
    }
}
