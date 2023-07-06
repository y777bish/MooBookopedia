using Microsoft.AspNetCore.Mvc;
using MooBookopedia.Data;
using MooBookopedia.Data.ViewModels;

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
        public IActionResult Login()
        {
            return View(new LoginVM());
        }
    }
}
