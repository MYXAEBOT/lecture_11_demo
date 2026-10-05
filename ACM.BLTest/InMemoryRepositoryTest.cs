using System;
using CMS.BusinessLayer;
using CMS.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CMS.BusinessLayerTest
{
    [TestClass]
    public class InMemoryRepositoryTest
    {
        [TestMethod]
        public void CustomerRepositoryAssignsIdAndReturnsIndependentCopies()
        {
            var repository = new InMemoryCustomerRepository();
            var customerId = repository.Save(new Customer
            {
                FirstName = "Bilbo",
                LastName = "Baggins",
                EmailAddress = "bilbo@example.com",
                HomeAddress = new Address { City = "Hobbiton" }
            });

            var customer = repository.GetById(customerId);
            Assert.AreEqual(1, customerId);
            Assert.AreEqual("Baggins", customer.LastName);
            Assert.AreEqual("Hobbiton", customer.HomeAddress.City);

            customer.LastName = "Changed";
            customer.HomeAddress.City = "Changed";
            var storedCustomer = repository.GetById(customerId);
            Assert.AreEqual("Baggins", storedCustomer.LastName);
            Assert.AreEqual("Hobbiton", storedCustomer.HomeAddress.City);
            Assert.AreEqual(1, repository.GetAll().Count);
        }

        [TestMethod]
        public void CustomerRepositoryUpdatesAnExistingId()
        {
            var repository = new InMemoryCustomerRepository();
            repository.Save(new Customer(8) { LastName = "Baggins" });
            repository.Save(new Customer(8) { LastName = "Took" });

            Assert.AreEqual("Took", repository.GetById(8).LastName);
            Assert.AreEqual(1, repository.GetAll().Count);
        }

        [TestMethod]
        public void ProductRepositoryStoresAndRetrievesProduct()
        {
            var repository = new InMemoryProductRepository();
            var productId = repository.Save(new Product
            {
                ProductName = "Pipe-weed",
                ProductDescription = "Longbottom leaf",
                CurrentPrice = 4.25m
            });

            var product = repository.GetById(productId);
            Assert.AreEqual(1, product.ProductId);
            Assert.AreEqual("Pipe-weed", product.ProductName);
            Assert.AreEqual(4.25m, product.CurrentPrice);
        }

        [TestMethod]
        public void OrderRepositoryCopiesShippingAddress()
        {
            var repository = new InMemoryOrderRepository();
            var orderId = repository.Save(new Order
            {
                CustomerId = 4,
                OrderDate = new DateTimeOffset(2026, 10, 6, 0, 0, 0, TimeSpan.Zero),
                ShippingAddress = new Address { City = "Bree" }
            });

            var order = repository.GetById(orderId);
            Assert.AreEqual(1, order.OrderId);
            Assert.AreEqual(4, order.CustomerId);
            Assert.AreEqual("Bree", order.ShippingAddress.City);
            order.ShippingAddress.City = "Changed";
            Assert.AreEqual("Bree", repository.GetById(orderId).ShippingAddress.City);
        }

        [TestMethod]
        public void OrderItemRepositoryStoresAndRetrievesOrderItem()
        {
            var repository = new InMemoryOrderItemRepository();
            var orderItemId = repository.Save(new OrderItem
            {
                OrderId = 3,
                OrderQuantity = 2,
                ProductId = 7,
                PurchasePrice = 8.50m
            });

            var orderItem = repository.GetById(orderItemId);
            Assert.AreEqual(1, orderItem.OrderItemId);
            Assert.AreEqual(3, orderItem.OrderId);
            Assert.AreEqual(2, orderItem.OrderQuantity);
            Assert.AreEqual(7, orderItem.ProductId);
            Assert.AreEqual(8.50m, orderItem.PurchasePrice);
        }

        [TestMethod]
        public void RepositoriesReturnNullWhenRecordIsMissing()
        {
            Assert.IsNull(new InMemoryCustomerRepository().GetById(1));
            Assert.IsNull(new InMemoryProductRepository().GetById(1));
            Assert.IsNull(new InMemoryOrderRepository().GetById(1));
            Assert.IsNull(new InMemoryOrderItemRepository().GetById(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CustomerRepositoryRejectsNull()
        {
            new InMemoryCustomerRepository().Save(null);
        }
    }
}
