
using Indio.Models;
using Indio.Models.Requests;
using Indio.Models.Responses;
using System.Collections.Generic;

namespace Indio.Services.Contracts
{
    public interface IUsersServices
    {
        IEnumerable<User> GetUsers();
        SignUpResponse SignUpUser(SignUpRequest request);
        User GetLoginUser(string email, string password);
    }
}
