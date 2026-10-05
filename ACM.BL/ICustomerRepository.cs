using System.Collections.Generic;

namespace CMS.BusinessLayer
{
    /// <summary>
    /// Defines the persistence operations required for customers.
    /// </summary>
    public interface ICustomerRepository
    {
        Customer GetById(int customerId);

        IList<Customer> GetAll();

        /// <summary>
        /// Stores a customer and returns its assigned identifier.
        /// </summary>
        int Save(Customer customer);
    }
}
