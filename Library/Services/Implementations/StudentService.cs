using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            _context.Students.Remove(new Student { Id = studentId });
            _context.SaveChanges();
        }

        public List<Order> GetActiveOrders(int studentId)
        {
            var orders = _context.Orders
                .Include(o => o.Book)
                .Where(o => o.StudentId == studentId && o.Returned == null)
                .ToList();
            return orders;
        }

        public Student GetStudent(int id)
        {
            var student = _context.Students.Single(o => o.Id == id);
            return student;
        }

        public List<Student> GetStudents()
        {
            return _context.Students
                .Include(s => s.Orders.Where(o => o.Returned == null))
                .OrderBy(s => s.LastName).ThenBy(s => s.FirstName).ToList();
        }
    }
}
