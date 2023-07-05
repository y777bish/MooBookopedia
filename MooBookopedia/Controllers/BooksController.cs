using Microsoft.AspNetCore.Mvc;
using MooBookopedia.Models;

namespace MooBookopedia.Controllers
{
    public class BooksController : Controller
    {

        public BooksController()
        {

        }

        public IActionResult Index()
        {
            List<Books> data = DataBaseAccess.GetAllBooks();
            return View(data);
        }
    }
}
