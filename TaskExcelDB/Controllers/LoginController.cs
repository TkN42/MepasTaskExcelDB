using Microsoft.AspNetCore.Mvc;
using TaskExcelDB.Models;
using TaskExcelDB.Repository.Login;

namespace TaskExcelDB.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        // GET: /Login
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Login
        [HttpPost]
        public async Task<IActionResult> Index(Users loginModel)
        {
            // Kullanıcı adı ve şifre doğruysa
            var user = _loginRepository.GetUserByUsernameAndPassword(loginModel.username, loginModel.password);
            if (user != null)
            {
                HttpContext.Session.SetString("userid", user.id.ToString());
                HttpContext.Session.SetString("username", user.username);
                return Json(new { success = true, redirectUrl = Url.Action("VerifySmsCode") });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı.");
                return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList() });
            }
        }


        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Oturumu temizle
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public IActionResult VerifySmsCode()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VerifySmsCode(string smsCode)
        {
            // Kullanıcının girdiği SMS kodunu alın
            string smsKodAl = "1111";
            //sms kodunu almış gibi yapıyoruz.

            if (smsCode == smsKodAl)
            {
                // SMS kodu doğruysa, oturumu başlatın ve ana sayfaya yönlendirin
                //HttpContext.Session.SetString("Username", user.Username); // Oturumu başlatın
                return RedirectToAction("Index", "Home"); // Ana sayfaya yönlendirin
            }

            // SMS kodu yanlışsa hata mesajı gösterin
            ModelState.AddModelError(smsCode, "SMS kodu yanlış.");
            return View();
        }

    }
}
