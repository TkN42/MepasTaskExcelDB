using Microsoft.AspNetCore.Mvc;
using TaskExcelDB.Models;
using TaskExcelDB.Repository;
using TaskExcelDB.Repository.Categori;

namespace TaskExcelDB.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriRepository _CategoriRepository;

        public CategoriesController(ICategoriRepository CategoriRepository)
        {
            _CategoriRepository = CategoriRepository;
        }

        public IActionResult Index()
        {
            //var Categoris = _CategoriRepository.GetAllCategoris();
            //return View(Categoris);
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categories Categori)
        {
            if (ModelState.IsValid)
            {
                _CategoriRepository.AddCategori(Categori);
                return RedirectToAction("Index");
            }
            return View(Categori);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Categoris = _CategoriRepository.GetCategoriById(id);

            if (Categoris == null)
            {
                return NotFound();
            }

            return View(Categoris);
        }

        public IActionResult Edit(int id)
        {
            var Categori = _CategoriRepository.GetCategoriById(id);
            if (Categori == null)
            {
                return NotFound();
            }
            return View(Categori);
        }

        [HttpPost]
        public IActionResult Edit(Categories Categori)
        {
            if (ModelState.IsValid)
            {
                _CategoriRepository.UpdateCategori(Categori);
                return RedirectToAction("Index");
            }
            return View(Categori);
        }

        public IActionResult Delete(int id)
        {
            var Categori = _CategoriRepository.GetCategoriById(id);
            if (Categori == null)
            {
                return NotFound();
            }
            return View(Categori);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _CategoriRepository.DeleteCategori(id);
            return RedirectToAction("Index");
        }
    }
}
