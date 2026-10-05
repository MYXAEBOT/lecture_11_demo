namespace CMS.BusinessLayer
{
    /// <summary>
    /// Defines the persistence operations required for orders.
    /// </summary>
    public interface IOrderRepository
    {
        Order GetById(int orderId);

        /// <summary>
        /// Stores an order and returns its assigned identifier.
        /// </summary>
        int Save(Order order);
    }
}
