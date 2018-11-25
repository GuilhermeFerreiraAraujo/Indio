using Microsoft.AspNetCore.Mvc;

namespace Indio.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}