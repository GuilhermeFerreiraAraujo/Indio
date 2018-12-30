using Indio.Models;
using Indio.Models.Requests;
using Indio.Models.Responses;
using System.Collections.Generic;

namespace Indio.DataAccess.Contracts
{
    public interface IUsersDataAccess
    {
        List<User> Get();
        SignUpResponse SignUpUser(SignUpRequest request);
        User GetLoginUser(string email, string password);
    }
}
