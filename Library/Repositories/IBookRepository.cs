using Library.Models;

namespace Library.Repositories
{
    public interface IBookRepository
    {
        IQueryable<Book> GetBooks();
        Book? GetBook(int id);
        void AddBook(Book book);
        void DeleteBook(Book book);
    }
}
