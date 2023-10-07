using Microsoft.AspNetCore.Mvc;
using TaskExcelDB.Repository.Product;

namespace TaskExcelDB.Views.Shared.ViewComponents
{
    public class ProductsViewComponent : ViewComponent
    {
        private readonly IProductRepository _productRepository;

        public ProductsViewComponent(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = _productRepository.GetAllProducts();
            return View(products);
        }
    }
}
