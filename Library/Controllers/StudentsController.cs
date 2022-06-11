using Microsoft.AspNetCore.Mvc;
using Library.Data;
using Library.Models;

namespace Library.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Students.ToList());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int studentId)
        {
            _context.Students.Remove(new Student { Id = studentId });
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
