using CMS.BusinessLayer;

namespace CMS.DataAccess
{
    /// <summary>
    /// Stores product copies in memory for the CMS example.
    /// </summary>
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly InMemoryStore<Product> _store =
            new InMemoryStore<Product>(product => product.ProductId, Copy);

        public Product GetById(int productId)
        {
            return _store.GetById(productId);
        }

        public int Save(Product product)
        {
            return _store.Save(product);
        }

        private static Product Copy(Product product, int productId)
        {
            return new Product(productId)
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                CurrentPrice = product.CurrentPrice
            };
        }
    }
}
