using System.Collections.Generic;
using System.Linq;
using Indio.DataAccess.Contracts;
using Indio.Models;

namespace Indio.DataAccess
{
    public class AccountsDataAccess : IAccountsDataAccess
    {
        private readonly IndioContext _context;

        public AccountsDataAccess(IndioContext context)
        {
            _context = context;
        }

        public List<Account> Get()
        {
            return _context.Set<Account>().ToList();
        }
    }
}
