using Library.Models;

namespace Library.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student GetStudent(int id);
        void AddStudent(Student student);
        void DeleteStudent(int studentId);
        List<Order> GetActiveOrders(int studentId);
    }
}
