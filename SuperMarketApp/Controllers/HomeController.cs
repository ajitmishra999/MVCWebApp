using Microsoft.AspNetCore.Mvc;

namespace SuperMarketApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
