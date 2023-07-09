using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using MooBookopedia.Data.ViewModels;
using MooBookopedia.Models;
using System.Diagnostics;
using System.Security.Principal;

namespace MooBookopedia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Authors()
        {
            return View();
        }

        public IActionResult AddMovie()
        {
            if(DataBaseAccess.GetSession() == -1) return View("~/Views/Account/Login.cshtml");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddMovie(AddMovieVM addMovieVM)
        {
            if (!ModelState.IsValid) return View(addMovieVM);
            int userId = DataBaseAccess.GetSession();
            if (userId == -1) return View("");
            DataBaseAccess.CreatePost(addMovieVM.Name, addMovieVM.Director, addMovieVM.Actors, addMovieVM.Year, addMovieVM.Desctiption, addMovieVM.ImageLink, userId, "M");
            TempData["Success"] = "Twój film czeka na potwierdzenie przez administratora.";
            return View();

        }
        public IActionResult AddBook()
        {
            if (DataBaseAccess.GetSession() == -1) return View("~/Views/Account/Login.cshtml");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookVM addBookVM)
        {
            if (!ModelState.IsValid) return View(addBookVM);
            int userId = DataBaseAccess.GetSession();
            if (userId == -1) return View("~/Views/Account/Login.cshtml");
            DataBaseAccess.CreatePost(addBookVM.Name, addBookVM.Director, "", addBookVM.Year, addBookVM.Desctiption, addBookVM.ImageLink, userId, "B");
            TempData["Success"] = "Twoja książka czeka na potwierdzenie przez administratora.";
            return View();

        }
        public IActionResult ViewMovie(int id)
        {
            if(id == 0) return View("~/Views/Home/Index.cshtml");
            Movies film = DataBaseAccess.GetMovie(id);
            if (film.borm == "M") return View (film);
            return View("~/Views/Home/Index.cshtml");
        }
        public IActionResult ViewBook(int id)
        {
            if (id == 0) return View("~/Views/Home/Index.cshtml");
            Movies book = DataBaseAccess.GetMovie(id);
            if (book.borm == "B") return View(book);
            return View("~/Views/Home/Index.cshtml");
        }
        public IActionResult MoviesList()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}