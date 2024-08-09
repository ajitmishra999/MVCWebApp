using Microsoft.AspNetCore.Mvc;
using SuperMarketApp.Models;
using SuperMarketApp.ViewModels;

namespace SuperMarketApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var product = ProductsRepository.GetProducts(true);
            return View(product);
        }
        public IActionResult Add()
        {
            var productViewModel = bindProductCategories();
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.AddProduct(productViewModel.product);
                return RedirectToAction(nameof(Index));
            }
            productViewModel = bindProductCategories();
            return View(productViewModel);
        }

        private ProductViewModel bindProductCategories()
        {
            ProductViewModel productViewModel = new ProductViewModel()
            {
                categories = CategoriesRepository.GetCategories()
            };

            return productViewModel;
        }
    }
}
