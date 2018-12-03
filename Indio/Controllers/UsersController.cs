using Indio.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Indio.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersServices _usersServices;

        public UsersController(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            var result = _usersServices.GetUsers();
            return Ok(result);
        }
    }
}