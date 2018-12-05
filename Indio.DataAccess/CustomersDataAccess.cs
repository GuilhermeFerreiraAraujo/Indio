using System.Collections.Generic;
using System.Linq;
using Indio.DataAccess.Contracts;
using Indio.Models;

namespace Indio.DataAccess
{
    public class CustomersDataAccess : ICustomersDataAccess
    {
        private readonly IndioContext _context;

        public CustomersDataAccess(IndioContext context)
        {
            _context = context;
        }

        public List<Customer> Get()
        {
            return _context.Set<Customer>().ToList();
        }
    }
}
