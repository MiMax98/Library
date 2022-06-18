using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize(Roles = "Librarian")]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IStudentService _studentService;
        private readonly IBookService _bookService;

        public OrdersController(
            IOrderService orderService,
            IStudentService studentService,
            IBookService bookService)
        {
            _orderService = orderService;
            _studentService = studentService;
            _bookService = bookService;
        }

        public IActionResult Create(int bookId)
        {
            var students = _studentService.GetStudents();
            var book = _bookService.GetBook(bookId);
            var model = new CreateOrderViewModel(book, students);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(int bookId, int studentId)
        {
            _orderService.Create(bookId, studentId);
            return RedirectToAction("Index", "Books");
        }

        public IActionResult Return(int orderId)
        {
            _orderService.Return(orderId);
            return RedirectToAction("Index", "Students");
        }
    }
}
