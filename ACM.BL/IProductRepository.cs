namespace CMS.BusinessLayer
{
    /// <summary>
    /// Defines the persistence operations required for products.
    /// </summary>
    public interface IProductRepository
    {
        Product GetById(int productId);

        bool Save(Product product);
    }
}
