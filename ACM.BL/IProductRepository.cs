namespace CMS.BusinessLayer
{
    /// <summary>
    /// Defines the persistence operations required for products.
    /// </summary>
    public interface IProductRepository
    {
        Product GetById(int productId);

        /// <summary>
        /// Stores a product and returns its assigned identifier.
        /// </summary>
        int Save(Product product);
    }
}
