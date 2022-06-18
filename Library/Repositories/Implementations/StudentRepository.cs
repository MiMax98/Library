using Library.Data;
using Library.Models;

namespace Library.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public Student? GetStudent(int id)
        {
            return _context.Students.SingleOrDefault(o => o.Id == id);
        }

        public IQueryable<Student> GetStudents()
        {
            return _context.Students;
        }
    }
}
