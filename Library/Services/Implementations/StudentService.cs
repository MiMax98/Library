using Library.Models;
using Library.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IOrderRepository _orderRepository;

        public StudentService(
            IStudentRepository studentRepository,
            IOrderRepository orderRepository)
        {
            _studentRepository = studentRepository;
            _orderRepository = orderRepository;
        }

        public void AddStudent(Student student)
        {
            _studentRepository.AddStudent(student);
        }

        public void DeleteStudent(int studentId)
        {
            var student = _studentRepository.GetStudent(studentId);
            if (student == null)
            {
                throw new InvalidOperationException("Uczeń nie istnieje");
            }
            _studentRepository.DeleteStudent(student);
        }

        public List<Order> GetActiveOrders(int studentId)
        {
            var orders = _orderRepository.GetOrders()
                .Include(o => o.Book)
                .Where(o => o.StudentId == studentId && o.Returned == null)
                .ToList();
            return orders;
        }

        public Student GetStudent(int id)
        {
            var student = _studentRepository.GetStudent(id);
            if (student == null)
            {
                throw new InvalidOperationException("Uczeń nie istnieje");
            }
            return student;
        }

        public List<Student> GetStudents()
        {
            return _studentRepository.GetStudents()
                .Include(s => s.Orders.Where(o => o.Returned == null))
                .OrderBy(s => s.LastName).ThenBy(s => s.FirstName).ToList();
        }
    }
}
