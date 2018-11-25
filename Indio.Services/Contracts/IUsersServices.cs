
using Indio.Models;
using System.Collections.Generic;

namespace Indio.Services.Contracts
{
    public interface IUsersServices
    {
        IEnumerable<Users> GetUsers();
    }
}
