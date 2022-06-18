using Library.Models;

namespace Library.Repositories
{
    public interface IStudentRepository
    {
        Student? GetStudent(int id);
        IQueryable<Student> GetStudents();
        void AddStudent(Student student);
        void DeleteStudent(Student student);
    }
}
