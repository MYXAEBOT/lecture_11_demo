using System;
using System.Collections.Generic;
using CMS.BusinessLayer;

namespace CMS.DataAccess
{
    /// <summary>
    /// Stores product copies in memory for the CMS example.
    /// </summary>
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly Dictionary<int, Product> _products = new Dictionary<int, Product>();
        private int _nextId = 1;

        public Product GetById(int productId)
        {
            Product product;
            return _products.TryGetValue(productId, out product) ? Copy(product) : null;
        }

        public int Save(Product product)
        {
            if (product == null) throw new ArgumentNullException("product");

            var productId = product.ProductId > 0 ? product.ProductId : _nextId;
            _products[productId] = Copy(product, productId);
            if (productId >= _nextId) _nextId = productId + 1;
            return productId;
        }

        private static Product Copy(Product product)
        {
            return Copy(product, product.ProductId);
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
