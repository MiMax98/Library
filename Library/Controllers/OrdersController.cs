using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create(int bookId)
        {
            var students = _context.Students.OrderBy(s => s.LastName).ThenBy(s => s.FirstName).ToList();
            var book = _context.Books.Single(b => b.Id == bookId);
            var model = new CreateOrderViewModel(book, students);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(int bookId, int studentId)
        {
            var order = new Order
            {
                BookId = bookId,
                StudentId = studentId,
                Created = DateTime.Now
            };
            _context.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToAction("Index", "Books");
        }
    }
}
