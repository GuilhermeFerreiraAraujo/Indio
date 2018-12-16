using System.Collections.Generic;
using System.Linq;
using Indio.DataAccess.Contracts;
using Indio.Models;
using Indio.Models.Requests;
using Indio.Models.Responses;

namespace Indio.DataAccess
{
    public class UsersDataAccess : IUsersDataAccess
    {
        private readonly IndioContext _context;

        public UsersDataAccess(IndioContext context)
        {
            _context = context;
        }

        public List<User> Get()
        {
            return _context.Set<User>().ToList();
        }

        public SignUpResponse SignUpUser(SignUpRequest request)
        {

            var user = new User
            {
                Email = request.Email,
                Name = request.Name,
                Password = request.Password
            };

            _context.Add(user);
            _context.SaveChanges();
            return new SignUpResponse();

        }
    }
}
