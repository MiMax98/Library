using Library.Models;
using Library.Repositories;
using Library.Services;
using Library.Services.Implementations;
using Moq;

namespace Library.Tests.Services
{
    public class BookServiceTests
    {
        private readonly Mock<IBookRepository> _bookRepository = new();

        //GetBook

        [Fact]
        public void Given_BookExists_When_GetBook_Then_Returned()
        {
            //Arrange
            int bookId = 1;
            _bookRepository.Setup(br => br.GetBook(bookId))
                .Returns(new Book { Id = bookId, Author = "J. K. Rowling", Title = "Harry Potter", Year = 2000 });
            var service = GetService();

            //Act
            var book = service.GetBook(bookId);

            //Assert
            Assert.NotNull(book);
            Assert.Equal(bookId, book.Id);
        }

        [Fact]
        public void Given_BookNotExists_When_GetBook_Then_Throws()
        {
            //Arrange
            int bookId = 1;
            _bookRepository.Setup(br => br.GetBook(bookId))
                .Returns<Book?>(null);
            var service = GetService();

            //Act
            var exception = Assert.Throws<InvalidOperationException>(() => service.GetBook(bookId));

            //Assert
            Assert.NotNull(exception);
        }

        //GetAvailableBooks
        [Fact]
        public void Given_BookNotOrdered_When_GetAvailableBooks_Then_Returned()
        {
            //Arrange
            _bookRepository.Setup(br => br.GetBooks())
                .Returns(new List<Book> 
                { 
                    new Book 
                    { 
                        Id = 1, 
                        Orders = new List<Order> { new Order { Id = 1, BookId = 1, StudentId = 1, Created = new DateTime(2000, 1, 1), Returned = new DateTime(2000, 2, 1) } } 
                    } 
                }.AsQueryable());
            var service = GetService();

            //Act
            var books = service.GetAvailableBooks();

            //Assert
            Assert.NotNull(books);
            Assert.Single(books);
            Assert.Collection(books, b => Assert.Equal(1, b.Id));
        }

        [Fact]
        public void Given_BookOrdered_When_GetAvailableBooks_Then_NotReturned()
        {
            //Arrange
            _bookRepository.Setup(br => br.GetBooks())
                .Returns(new List<Book>
                {
                    new Book
                    {
                        Id = 1,
                        Orders = new List<Order> { new Order { Id = 1, BookId = 1, StudentId = 1, Created = new DateTime(2000, 1, 1), Returned = null } }
                    }
                }.AsQueryable());
            var service = GetService();

            //Act
            var books = service.GetAvailableBooks();

            //Assert
            Assert.NotNull(books);
            Assert.Empty(books);
        }

        [Fact]
        public void When_AddBook_Then_BookAdded()
        {
            //Arrange
            var service = GetService();

            //Act
            service.AddBook(new Book { Author = "J. K. Rowling", Title = "Harry Potter", Year = 2000 });

            //Assert
            _bookRepository.Verify(br => br.AddBook(It.IsAny<Book>()));
        }

        [Fact]
        public void Given_BookExists_When_DeleteBook_Then_BookDeleted()
        {
            //Arrange
            int bookId = 1;
            _bookRepository.Setup(br => br.GetBook(bookId))
                .Returns(new Book { Id = bookId, Author = "J. K. Rowling", Title = "Harry Potter", Year = 2000 });
            var service = GetService();

            //Act
            service.Delete(bookId);

            //Assert
            _bookRepository.Verify(br => br.DeleteBook(It.Is<Book>(b => b.Id == 1)));
        }

        [Fact]
        public void Given_BookNotExists_When_DeleteBook_Then_Throws()
        {
            //Arrange
            int bookId = 1;
            _bookRepository.Setup(br => br.GetBook(bookId))
                .Returns(new Book { Id = bookId, Author = "J. K. Rowling", Title = "Harry Potter", Year = 2000 });
            var service = GetService();

            //Act
            var ex = Assert.Throws<InvalidOperationException>(() => service.Delete(2));

            //Assert
            Assert.NotNull(ex);
        }

        private IBookService GetService()
        {
            return new BookService(_bookRepository.Object);
        }
    }
}
