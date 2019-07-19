using System.Collections.Generic;
using Indio.DataAccess.Contracts;
using Indio.Models;
using Indio.Services.Contracts;

namespace Indio.Services
{
    public class CustomersServices : ICustomersServices
    {
        private readonly ICustomersDataAccess _customersDataAccess;

        public CustomersServices(ICustomersDataAccess customersDataAccess)
        {
            _customersDataAccess = customersDataAccess;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customersDataAccess.Get();
        }

        public Customer Save(Customer customer)
        {
            return _customersDataAccess.Save(customer);
        }
    }
}
