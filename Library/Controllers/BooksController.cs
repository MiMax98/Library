using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.Books
                .Where(b => b.Orders.All(o => o.Returned != null))
                .ToList();
            return View(books);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int bookId)
        {
            _context.Books.Remove(new Book { Id=bookId });
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
