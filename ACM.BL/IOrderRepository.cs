namespace CMS.BusinessLayer
{
    /// <summary>
    /// Defines the persistence operations required for orders.
    /// </summary>
    public interface IOrderRepository
    {
        Order GetById(int orderId);

        bool Save(Order order);
    }
}
