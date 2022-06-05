using Library.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Harry Potter i Kamień Filozoficzny", Author = "J. K. Rowling", Year = 1997 },
                new Book { Id = 2, Title = "Harry Potter i Komnata Tajemnic", Author = "J. K. Rowling", Year = 1998 },
                new Book { Id = 3, Title = "Harry Potter i Więzień Azkabanu", Author = "J. K. Rowling", Year = 1999 },
                new Book { Id = 4, Title = "Harry Potter i Czara Ognia", Author = "J. K. Rowling", Year = 2000 },
                new Book { Id = 5, Title = "Harry Potter i Zakon Feniksa", Author = "J. K. Rowling", Year = 2003 },
                new Book { Id = 6, Title = "Harry Potter i Książę Półkrwi", Author = "J. K. Rowling", Year = 2005 },
                new Book { Id = 7, Title = "Harry Potter i Insygnia Śmierci", Author = "J. K. Rowling", Year = 2007 });
        }
    }
}