using Indio.Models.Requests;
using Indio.Models.Responses;
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

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            return Ok();
        }

        [HttpPost]
        [Route("SignUps")]
        public IActionResult SignUp([FromBody]SignUpRequest request)
        {
            var result = _usersServices.SignUpUser(request);

            return Ok(result);
        }

    }
}