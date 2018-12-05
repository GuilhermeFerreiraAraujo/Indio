using System.Collections.Generic;
using System.Linq;
using Indio.DataAccess.Contracts;
using Indio.Models;

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
    }
}
