using Microsoft.AspNetCore.Mvc;

namespace ChiliLabsHomework.Controllers
{
    public class SocketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
