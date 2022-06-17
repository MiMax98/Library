using Library.Data;
using Library.Models;

namespace Library.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Delete(int bookId)
        {
            _context.Books.Remove(new Book { Id = bookId });
            _context.SaveChanges();
        }

        public List<Book> GetAvailableBooks()
        {
            var books = _context.Books
                .Where(b => b.Orders.All(o => o.Returned != null))
                .ToList();
            return books;
        }

        public Book GetBook(int bookId)
        {
            return _context.Books.Single(b => b.Id == bookId);
        }
    }
}
