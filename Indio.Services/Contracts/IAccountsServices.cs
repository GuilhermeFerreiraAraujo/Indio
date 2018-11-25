using Indio.Models;
using System.Collections.Generic;

namespace Indio.Services.Contracts
{
    public interface IAccountsServices
    {
        IEnumerable<Accounts> GetAccounts(); 
    }
}
