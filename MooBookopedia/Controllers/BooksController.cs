using Microsoft.AspNetCore.Mvc;
using MooBookopedia.Models;

namespace MooBookopedia.Controllers
{
    public class BooksController : Controller
    {
        private readonly DataBaseAccess _context;

        public BooksController(DataBaseAccess context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            /*var data = _context.Movies.ToList()*/ // Do odkomentowania jak będzie działała baza a później AppDbContext
            return View();
        }
    }
}
