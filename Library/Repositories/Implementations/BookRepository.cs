using Library.Data;
using Library.Models;

namespace Library.Repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public Book? GetBook(int bookId)
        {
            return _context.Books.SingleOrDefault(b => b.Id == bookId);
        }

        public IQueryable<Book> GetBooks()
        {
            return _context.Books;
        }
    }
}
