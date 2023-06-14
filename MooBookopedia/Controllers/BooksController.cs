using Microsoft.AspNetCore.Mvc;
using MooBookopedia.Data;

namespace MooBookopedia.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
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
