using Indio.Models;
using Indio.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Indio.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {

        private readonly IAccountsServices _accountsServices;

        public AccountsController(IAccountsServices accountsServices)
        {
            _accountsServices = accountsServices;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            var result = _accountsServices.GetAccounts();
            return Ok(result);
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromBody]Account account)
        {
            var acc = _accountsServices.Save(account);
            return Ok(acc);
        }
    }
}