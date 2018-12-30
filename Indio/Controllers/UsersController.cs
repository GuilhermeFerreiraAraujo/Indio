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
    [Authorize(Roles = "Users")]
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
            var user = _usersServices.GetLoginUser(request.Email, request.Password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email)
                };

                user.UserPermissions.ForEach(x =>
                {
                    claims.Add(new Claim(ClaimTypes.Role, x.Permission.Name));
                });

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                return Ok();
            }
            return NotFound();
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
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