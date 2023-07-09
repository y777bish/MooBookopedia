using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using MooBookopedia.Data;
using MooBookopedia.Data.ViewModels;
using MooBookopedia.Models;

namespace MooBookopedia.Controllers
{
    public class AccountController : Controller
    {

        public AccountController()
        {
        }
        public IActionResult Register()
        {
            return View(new RegisterVM());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if(!ModelState.IsValid) return View(registerVM);

            if(!DataBaseAccess.CreateAccount(registerVM.FullName, registerVM.EmailAddress, registerVM.Password))
            {
                TempData["Error"] = "Nazwa użytkownika lub email jest zajęty";
                return View(registerVM);
            }
            return View("~/Views/Account/Login.cshtml");
            
        }

        public IActionResult Login()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            int userId = DataBaseAccess.Login(loginVM.EmailAddress, loginVM.Password);

            if (userId == -1)
            {
                TempData["Error"] = "Niepoprawne dane";
                return View(loginVM);
            }
            DataBaseAccess.AddSession(userId);
            return View("~/Views/Home/Index.cshtml");

        }
        public IActionResult Logout()
        {
            DataBaseAccess.Logout();
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
