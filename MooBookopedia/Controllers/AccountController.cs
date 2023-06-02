using Microsoft.AspNetCore.Mvc;
using MooBookopedia.Data;
using MooBookopedia.Data.ViewModels;

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
    }
}
