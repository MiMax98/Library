using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class BooksAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "J. K. Rowling", "Harry Potter i Kamień Filozoficzny", 1997 },
                    { 2, "J. K. Rowling", "Harry Potter i Komnata Tajemnic", 1998 },
                    { 3, "J. K. Rowling", "Harry Potter i Więzień Azkabanu", 1999 },
                    { 4, "J. K. Rowling", "Harry Potter i Czara Ognia", 2000 },
                    { 5, "J. K. Rowling", "Harry Potter i Zakon Feniksa", 2003 },
                    { 6, "J. K. Rowling", "Harry Potter i Książę Półkrwi", 2005 },
                    { 7, "J. K. Rowling", "Harry Potter i Insygnia Śmierci", 2007 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
