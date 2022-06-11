using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class StudentAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "Grade", "LastName" },
                values: new object[,]
                {
                    { 1, "Jan", 1, "Kowalski" },
                    { 2, "Jan", 1, "Nowak" },
                    { 3, "Marek", 2, "Potocki" },
                    { 4, "Zbigniew", 3, "Branicki" },
                    { 5, "Mateusz", 4, "Lewandowski" },
                    { 6, "Maksymilian", 5, "Piszczek" },
                    { 7, "Marcin", 6, "Zdun" },
                    { 8, "Aleksander", 1, "Kupaga" },
                    { 9, "Monika", 2, "Laskowska" },
                    { 10, "Ewelina", 3, "Kowalik" },
                    { 11, "Anna", 4, "Marcinkowska" },
                    { 12, "Jadwiga", 5, "Piotrowska" },
                    { 13, "Franciszek", 6, "Czartoryski" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
