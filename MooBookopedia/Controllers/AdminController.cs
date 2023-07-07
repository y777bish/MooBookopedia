using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using MooBookopedia.Data;
using MooBookopedia.Data.ViewModels;
using MooBookopedia.Models;

namespace MooBookopedia.Controllers
{
    public class AdminController : Controller
    {

        public AdminController()
        {
        }
        public IActionResult Index()
        {
            if (DataBaseAccess.IsLoggedUserAdmin())
            {
            return View();
            }
            return View("~/Views/Home/Index.cshtml");
        }
    }
}