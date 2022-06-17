using Library.Models;

namespace Library.Services
{
    public interface IBookService
    {
        List<Book> GetAvailableBooks();
        void AddBook(Book book);
        void Delete(int bookId);
        Book GetBook(int bookId);
    }
}
