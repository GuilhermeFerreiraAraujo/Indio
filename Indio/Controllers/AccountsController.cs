

using Indio.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Indio.Controllers
{
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

        public IActionResult Index()
        {
            return View();
        }
    }
}