using System.Collections.Generic;
using Indio.DataAccess.Contracts;
using Indio.Models;
using Indio.Models.Requests;
using Indio.Models.Responses;
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

        public User GetLoginUser(string email, string password)
        {
            return _usersDataAccess.GetLoginUser(email, password);
        }

        public IEnumerable<User> GetUsers()
        {
            return _usersDataAccess.Get();
        }

        public SignUpResponse SignUpUser(SignUpRequest request)
        {
            return _usersDataAccess.SignUpUser(request);
        }
    }
}
