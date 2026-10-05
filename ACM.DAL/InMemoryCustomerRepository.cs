using System;
using System.Collections.Generic;
using CMS.BusinessLayer;

namespace CMS.DataAccess
{
    /// <summary>
    /// Stores customer copies in memory for the CMS example.
    /// </summary>
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private readonly Dictionary<int, Customer> _customers = new Dictionary<int, Customer>();
        private int _nextId = 1;

        public Customer GetById(int customerId)
        {
            Customer customer;
            return _customers.TryGetValue(customerId, out customer) ? Copy(customer) : null;
        }

        public IList<Customer> GetAll()
        {
            var customers = new List<Customer>();
            foreach (var customer in _customers.Values)
            {
                customers.Add(Copy(customer));
            }
            return customers;
        }

        public int Save(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException("customer");

            var customerId = customer.CustomerId > 0 ? customer.CustomerId : _nextId;
            _customers[customerId] = Copy(customer, customerId);
            if (customerId >= _nextId) _nextId = customerId + 1;
            return customerId;
        }

        private static Customer Copy(Customer customer)
        {
            return Copy(customer, customer.CustomerId);
        }

        private static Customer Copy(Customer customer, int customerId)
        {
            return new Customer(customerId)
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                EmailAddress = customer.EmailAddress
            };
        }
    }
}
