using Indio.DataAccess.Contracts;
using Indio.Models;
using Indio.Services.Contracts;
using System.Collections.Generic;

namespace Indio.Services
{
    public class AccountsServices : IAccountsServices
    {
        private readonly IAccountsDataAccess _accountsDataAccess;

        public AccountsServices(IAccountsDataAccess accountsDataAccess)
        {
            _accountsDataAccess = accountsDataAccess;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountsDataAccess.Get();
        }
    }
}
