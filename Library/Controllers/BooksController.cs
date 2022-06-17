using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetAvailableBooks();
            return View(books);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            _bookService.AddBook(book);
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int bookId)
        {
            _bookService.Delete(bookId);
            return RedirectToAction("Index");
        }
    }
}
