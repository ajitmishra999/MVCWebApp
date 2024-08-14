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
            ViewBag.Action = "add";
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
            ViewBag.Action = "add";
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

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";
            var productViewModel = new ProductViewModel()
            {
                product = ProductsRepository.GetProductById(id, false) ?? new Product(),
                categories = CategoriesRepository.GetCategories()
            };
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if(ModelState.IsValid)
            {
                ProductsRepository.UpdateProduct(productViewModel.product.ProductId, productViewModel.product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "edit";
            productViewModel = bindProductCategories();
            return View(productViewModel);
        }

        public IActionResult Delete(int id)
        {
           ProductsRepository.DeleteProduct(id);
           return RedirectToAction(nameof(Index));
        }

        public IActionResult GetProductListByCategoryId(int categoryId)
        {
            var products = ProductsRepository.GetProductsByCategoryId(categoryId);

            return PartialView("_products", products);
        }
    }
}
