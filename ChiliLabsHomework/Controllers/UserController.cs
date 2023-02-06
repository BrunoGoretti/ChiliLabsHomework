using Microsoft.AspNetCore.Mvc;

namespace ChiliLabsHomework.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
