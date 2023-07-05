using Microsoft.AspNetCore.Mvc;
using MooBookopedia.Models;

namespace MooBookopedia.Controllers
{
    public class MoviesController : Controller
    {
        private readonly DataBaseAccess _context;

        public MoviesController(DataBaseAccess context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Movies> data = _context.GetAllFilms();
            return View();
        }
    }
}
