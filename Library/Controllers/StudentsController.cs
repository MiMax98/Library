using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Authorize(Roles = "Admin,Librarian")]
        public IActionResult Index()
        {
            var students = _studentService.GetStudents();
            return View(students);
        }

        [Authorize(Roles = "Admin")]

        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(Student student)
        {
            _studentService.AddStudent(student);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _studentService.DeleteStudent(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Librarian")]
        public IActionResult Orders(int id)
        {
            var orders = _studentService.GetActiveOrders(id);
            var student = _studentService.GetStudent(id);
            var model = new StudentOrdersViewModel
            {
                Orders = orders,
                Student = student
            };
            return View(model);
        }
    }
}
