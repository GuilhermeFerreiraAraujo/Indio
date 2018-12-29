using Indio.Models.Requests;
using Indio.Services.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Indio.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersServices _usersServices;

        public UsersController(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        [HttpGet]
        [Route("IsAuthenticated")]
        public IActionResult IsAuthenticated()
        {
            return Ok();
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
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (LoginUser(request.Email, request.Password))
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, request.Email)
            };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                //Just redirect to our index after logging in. 
                return Ok();
            }
            return Ok();

        }


        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }


        private bool LoginUser(string username, string password)
        {
            //As an example. This method would go to our data store and validate that the combination is correct. 
            //For now just return true. 
            return true;
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