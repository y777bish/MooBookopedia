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
                TempData["Error"] = "This username or email is already in use";
                return View(registerVM);
            }
            return View("~/Views/Home/Index.cshtml");

        }

        public IActionResult Login()
        {
            return View(new LoginVM());
        }
    }
}
