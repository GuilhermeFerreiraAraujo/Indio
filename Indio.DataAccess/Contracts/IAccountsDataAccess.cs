using Indio.Models;
using System.Collections.Generic;

namespace Indio.DataAccess.Contracts
{
    public interface IAccountsDataAccess
    {
        List<Account> Get();
    }
}
