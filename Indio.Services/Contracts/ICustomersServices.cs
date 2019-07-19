
using Indio.Models;
using System.Collections.Generic;

namespace Indio.Services.Contracts
{
    public interface ICustomersServices
    {
        IEnumerable<Customer> GetCustomers();

        Customer Save(Customer customer);
    }
}
