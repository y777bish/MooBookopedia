using Microsoft.AspNetCore.Mvc;
using MooBookopedia.Data;

namespace MooBookopedia.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            /*var data = _context.Movies.ToList()*/; // Do odkomentowania jak będzie działała baza a później AppDbContext
            return View();
        }
    }
}
