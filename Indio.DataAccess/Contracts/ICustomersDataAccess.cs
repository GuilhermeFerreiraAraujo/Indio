using Indio.Models;
using System.Collections.Generic;

namespace Indio.DataAccess.Contracts
{
    public interface ICustomersDataAccess
    {
        List<Customer> Get();

        Customer Save(Customer customer);
    }
}
