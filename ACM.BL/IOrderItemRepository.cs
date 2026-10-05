namespace CMS.BusinessLayer
{
    /// <summary>
    /// Defines the persistence operations required for order items.
    /// </summary>
    public interface IOrderItemRepository
    {
        OrderItem GetById(int orderItemId);

        /// <summary>
        /// Stores an order item and returns its assigned identifier.
        /// </summary>
        int Save(OrderItem orderItem);
    }
}
