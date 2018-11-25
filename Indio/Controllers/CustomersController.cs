using Microsoft.AspNetCore.Mvc;

namespace Indio.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}