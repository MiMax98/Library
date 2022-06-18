using Library.Models;
using Microsoft.AspNetCore.Identity;
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
        public DbSet<Student> Students { get; set; }
        public DbSet<Order> Orders { get; set; }
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

            builder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Jan", LastName = "Kowalski", Grade = 1 },
                new Student { Id = 2, FirstName = "Jan", LastName = "Nowak", Grade = 1 },
                new Student { Id = 3, FirstName = "Marek", LastName = "Potocki", Grade = 2 },
                new Student { Id = 4, FirstName = "Zbigniew", LastName = "Branicki", Grade = 3 },
                new Student { Id = 5, FirstName = "Mateusz", LastName = "Lewandowski", Grade = 4 },
                new Student { Id = 6, FirstName = "Maksymilian", LastName = "Piszczek", Grade = 5 },
                new Student { Id = 7, FirstName = "Marcin", LastName = "Zdun", Grade = 6 },
                new Student { Id = 8, FirstName = "Aleksander", LastName = "Kupaga", Grade = 1 },
                new Student { Id = 9, FirstName = "Monika", LastName = "Laskowska", Grade = 2 },
                new Student { Id = 10, FirstName = "Ewelina", LastName = "Kowalik", Grade = 3 },
                new Student { Id = 11, FirstName = "Anna", LastName = "Marcinkowska", Grade = 4 },
                new Student { Id = 12, FirstName = "Jadwiga", LastName = "Piotrowska", Grade = 5 },
                new Student { Id = 13, FirstName = "Franciszek", LastName = "Czartoryski", Grade = 6 });

            SeedUsers(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            var librarianRole = new IdentityRole 
            { 
                Id = "fe3f5314-b70b-4266-826d-f6cc6cb0d1bf", 
                Name = "Librarian", 
                ConcurrencyStamp = "1", 
                NormalizedName = "LIBRARIAN" 
            };
            var adminRole = new IdentityRole
            {
                Id = "fe756c0c-44ea-4482-9b15-a8fcb3c11f33",
                Name = "Admin",
                ConcurrencyStamp = "2",
                NormalizedName = "ADMIN" 
            };
            builder.Entity<IdentityRole>().HasData(librarianRole, adminRole);

            var passwordHasher = new PasswordHasher<IdentityUser>();

            var librarian = new IdentityUser
            {
                Id = "209e7cbb-2b0c-4e7d-993c-a16bbf09ff3e",
                UserName = "bibliotekarz",
                NormalizedUserName = "BIBLIOTEKARZ"
            };
            librarian.PasswordHash = passwordHasher.HashPassword(librarian, "bibliotekarz123");

            var admin = new IdentityUser
            {
                Id = "69e3365c-ded9-4bbf-af5b-69fb12930d27",
                UserName = "administrator",
                NormalizedUserName = "ADMINISTRATOR"
            };
            admin.PasswordHash = passwordHasher.HashPassword(admin, "administrator123");

            builder.Entity<IdentityUser>().HasData(librarian, admin);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = librarianRole.Id, UserId = librarian.Id },
                new IdentityUserRole<string> { RoleId = adminRole.Id, UserId = admin.Id });
        }
    }
}
