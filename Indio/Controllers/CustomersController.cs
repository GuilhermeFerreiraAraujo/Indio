using Indio.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Indio.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomersServices _customersServices;

        public CustomersController(ICustomersServices customersServices)
        {
            _customersServices = customersServices;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            var result = _customersServices.GetCustomers();
            return Ok(result);
        }
    }
}