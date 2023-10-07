using Microsoft.AspNetCore.Mvc;
using TaskExcelDB.Models;
using TaskExcelDB.Repository;
using TaskExcelDB.Repository.User;

namespace TaskExcelDB.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _UserRepository;

        public UsersController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public IActionResult Index()
        {
            //var User = _UserRepository.GetAllUser();
            //return View(User);
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Users User)
        {
            if (ModelState.IsValid)
            {
                User.status = true;
                _UserRepository.AddUser(User);
                return RedirectToAction("Index");
            }
            return View(User);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var User = _UserRepository.GetUserById(id);

            if (User == null)
            {
                return NotFound();
            }

            return View(User);
        }

        public IActionResult Edit(int id)
        {
            var User = _UserRepository.GetUserById(id);
            if (User == null)
            {
                return NotFound();
            }
            return View(User);
        }

        [HttpPost]
        public IActionResult Edit(Users User)
        {
            if (ModelState.IsValid)
            {
                _UserRepository.UpdateUser(User);
                return RedirectToAction("Index");
            }
            return View(User);
        }

        public IActionResult Delete(int id)
        {
            var User = _UserRepository.GetUserById(id);
            if (User == null)
            {
                return NotFound();
            }
            return View(User);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _UserRepository.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}
