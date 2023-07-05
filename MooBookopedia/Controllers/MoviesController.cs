using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MooBookopedia.Models;

namespace MooBookopedia.Controllers
{
    public class MoviesController : Controller
    {
        //private readonly DataBaseAccess _context;

        public MoviesController()
        {
            //_context = new DataBaseAccess();
        }

        public IActionResult Index()
        {
            //List<Movies> data = _context.GetAllFilms();
            List<Movies> data = DataBaseAccess.GetAllFilms();
            return View(data);
        }
    }
}