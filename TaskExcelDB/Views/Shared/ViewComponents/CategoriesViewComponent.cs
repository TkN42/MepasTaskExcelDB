using Microsoft.AspNetCore.Mvc;
using TaskExcelDB.Repository.Categori;

namespace TaskExcelDB.Views.Shared.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoriRepository _categoriRepository;

        public CategoriesViewComponent(ICategoriRepository categoriRepository)
        {
            _categoriRepository = categoriRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoris = _categoriRepository.GetAllCategoris();
            return View(categoris);
        }
    }
}
