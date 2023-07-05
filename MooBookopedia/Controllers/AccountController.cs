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
        private AppDbContext _context;

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
            if (!ModelState.IsValid) return View(registerVM);

            //var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            //if (user != null)
            //{
            //TempData["Error"] = "This email address is already in use";
            //return View(registerVM);
            //}
            if(!DataBaseAccess.CreateAccount(registerVM.FullName, registerVM.EmailAddress, registerVM.Password))
            {
                TempData["Error"] = "This username or email is already in use";
                return View(registerVM);
            }
            return View("~/Views/Home/Index.cshtml");
            //var newUser = new ApplicationUser()
            //{
            //    FullName = registerVM.FullName,
            //    Email = registerVM.EmailAddress,
            //    UserName = registerVM.EmailAddress
            //};
            //var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            //if (newUserResponse.Succeeded)
            //    await _userManager.AddToRoleAsync(newUser, UserRoles.User);


        }

        public IActionResult Login()
        {
            return View(new LoginVM());
        }
    }
}
