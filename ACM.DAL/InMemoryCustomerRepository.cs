using System.Collections.Generic;
using CMS.BusinessLayer;

namespace CMS.DataAccess
{
    /// <summary>
    /// Stores customer copies in memory for the CMS example.
    /// </summary>
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private readonly InMemoryStore<Customer> _store =
            new InMemoryStore<Customer>(customer => customer.CustomerId, Copy);

        public Customer GetById(int customerId)
        {
            return _store.GetById(customerId);
        }

        public IList<Customer> GetAll()
        {
            return _store.GetAll();
        }

        public int Save(Customer customer)
        {
            return _store.Save(customer);
        }

        private static Customer Copy(Customer customer, int customerId)
        {
            return new Customer(customerId)
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                EmailAddress = customer.EmailAddress,
                HomeAddress = Copy(customer.HomeAddress),
                WorkAddress = Copy(customer.WorkAddress)
            };
        }

        private static Address Copy(Address address)
        {
            if (address == null) return null;

            return new Address
            {
                StreetLine1 = address.StreetLine1,
                StreetLine2 = address.StreetLine2,
                City = address.City,
                StateOrProvince = address.StateOrProvince,
                PostalCode = address.PostalCode,
                Country = address.Country
            };
        }
    }
}
