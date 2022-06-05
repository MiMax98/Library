using Microsoft.AspNetCore.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            List<Book> books = new List<Book> 
            { 
                new Book { Author = "Alfred", Id = 1, Title = "Tomek w krainie kangurow", Year = 1888 },
                new Book { Author = "Marcin", Id = 2, Title = "Tomek u zrodel Amazonki", Year = 1999 } 
            };

            return View(books);
        }
    }
}
