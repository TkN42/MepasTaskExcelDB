using Microsoft.AspNetCore.Mvc;
using TaskExcelDB.Models;
using TaskExcelDB.Repository;
using TaskExcelDB.Repository.Categori;
using TaskExcelDB.Repository.Product;

namespace TaskExcelDB.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository; 
        private readonly ICategoriRepository _categoriRepository;

        public ProductsController(IProductRepository productRepository, ICategoriRepository categoriRepository)
        {
            _productRepository = productRepository;
            _categoriRepository = categoriRepository;
        }

        public IActionResult Index()
        {
            //var products = _productRepository.GetAllProducts();
            //return View(products);
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _categoriRepository.GetAllCategoris();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Products product)
        {
            if (ModelState.IsValid)
            {
                product.added_user_id = Convert.ToInt32(HttpContext.Session.GetString("userid"));
                product.created_date = DateTime.Now;
                product.updated_date = null;
                _productRepository.AddProduct(product);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, " null olamaz ");
            return RedirectToAction("Create",ModelState);
            //return View(product);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = _productRepository.GetProductById(id);

            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _categoriRepository.GetAllCategoris();
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Products product)
        {
            if (ModelState.IsValid)
            {
                product.updated_date = DateTime.Now;
                product.updated_user_id = Convert.ToInt32(HttpContext.Session.GetString("userid"));
                _productRepository.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, " null olamaz ");
            return RedirectToAction("Edit", ModelState);
            //return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _productRepository.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
