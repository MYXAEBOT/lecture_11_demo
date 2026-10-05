namespace CMS.BusinessLayer
{
    /// <summary>
    /// Defines the persistence operations required for order items.
    /// </summary>
    public interface IOrderItemRepository
    {
        OrderItem GetById(int orderItemId);

        bool Save(OrderItem orderItem);
    }
}
