using System.Collections.Generic;
using Indio.DataAccess.Contracts;
using Indio.Models;
using Indio.Services.Contracts;

namespace Indio.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IUsersDataAccess _usersDataAccess;

        public UsersServices(IUsersDataAccess usersDataAccess)
        {
            _usersDataAccess = usersDataAccess;
        }

        public IEnumerable<User> GetUsers()
        {
            return _usersDataAccess.Get();
        }
    }
}
