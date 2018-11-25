using Indio.Models;
using Indio.Services.Contracts;
using System.Collections.Generic;

namespace Indio.Services
{
    public class AccountsServices : IAccountsServices
    {
        public IEnumerable<Accounts> GetAccounts()
        {

            return new List<Accounts>();
        }
    }
}
