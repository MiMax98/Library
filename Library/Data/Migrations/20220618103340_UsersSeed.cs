using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class UsersSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fe3f5314-b70b-4266-826d-f6cc6cb0d1bf", "1", "Librarian", "LIBRARIAN" },
                    { "fe756c0c-44ea-4482-9b15-a8fcb3c11f33", "2", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "209e7cbb-2b0c-4e7d-993c-a16bbf09ff3e", 0, "eb8c8d6b-5cab-457f-8b32-9d773949fd74", null, false, false, null, null, "BIBLIOTEKARZ", "AQAAAAEAACcQAAAAEKSnW6gsrst8MI5HU8BuTS60SPrwwSpLky+YTXcsuDBYWpYDDi4aUnymosiXJ30eog==", null, false, "0af8f3f8-907b-4e4a-85ac-2cb1c95dbd77", false, "bibliotekarz" },
                    { "69e3365c-ded9-4bbf-af5b-69fb12930d27", 0, "c3262b6b-b57b-4a97-bdbc-4feb655ee975", null, false, false, null, null, "ADMINISTRATOR", "AQAAAAEAACcQAAAAEOsjFlcReUp0Q4zwsZWBX7In9b5lMSV9PYigBf6kjjBYoZrQ9SqYWRg/VWeEoLBjcw==", null, false, "f313a8b9-5b3a-442b-8d3f-092a0bf1ba16", false, "administrator" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fe3f5314-b70b-4266-826d-f6cc6cb0d1bf", "209e7cbb-2b0c-4e7d-993c-a16bbf09ff3e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fe756c0c-44ea-4482-9b15-a8fcb3c11f33", "69e3365c-ded9-4bbf-af5b-69fb12930d27" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fe3f5314-b70b-4266-826d-f6cc6cb0d1bf", "209e7cbb-2b0c-4e7d-993c-a16bbf09ff3e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fe756c0c-44ea-4482-9b15-a8fcb3c11f33", "69e3365c-ded9-4bbf-af5b-69fb12930d27" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe3f5314-b70b-4266-826d-f6cc6cb0d1bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe756c0c-44ea-4482-9b15-a8fcb3c11f33");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "209e7cbb-2b0c-4e7d-993c-a16bbf09ff3e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69e3365c-ded9-4bbf-af5b-69fb12930d27");
        }
    }
}
