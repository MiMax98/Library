using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            var students = _studentService.GetStudents();
            return View(students);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Student student)
        {
            _studentService.AddStudent(student);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int studentId)
        {
            _studentService.DeleteStudent(studentId);
            return RedirectToAction("Index");
        }

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
