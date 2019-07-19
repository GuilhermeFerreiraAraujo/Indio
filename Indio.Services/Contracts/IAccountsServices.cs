using Indio.Models;
using System.Collections.Generic;

namespace Indio.Services.Contracts
{
    public interface IAccountsServices
    {
        IEnumerable<Account> GetAccounts();
        Account Save(Account account);
    }
}
