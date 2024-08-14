using Microsoft.AspNetCore.Mvc;
using SuperMarketApp.Models;
using SuperMarketApp.ViewModels;

namespace SuperMarketApp.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            SalesViewModel salesViewModel = new SalesViewModel()
            {
                Categories = CategoriesRepository.GetCategories()
            };
            return View(salesViewModel);
        }
    }
}
