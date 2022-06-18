using Library.Models;
using Library.Repositories;

namespace Library.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public void AddBook(Book book)
        {
            _bookRepository.AddBook(book);
        }

        public void Delete(int bookId)
        {
            var book = _bookRepository.GetBook(bookId);
            if (book == null)
            {
                throw new InvalidOperationException("Książka nie istnieje");
            }
            _bookRepository.DeleteBook(book);
        }

        public List<Book> GetAvailableBooks()
        {
            var books = _bookRepository.GetBooks()
                .Where(b => b.Orders.All(o => o.Returned != null))
                .ToList();
            return books;
        }

        public Book GetBook(int bookId)
        {
            var book = _bookRepository.GetBook(bookId);
            if (book == null)
            {
                throw new InvalidOperationException("Książka nie istnieje");
            }
            return book;
        }
    }
}
