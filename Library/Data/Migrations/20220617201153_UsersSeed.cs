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
                    { "fe3f5314-b70b-4266-826d-f6cc6cb0d1bf", "1", "Bibliotekarz", "Bibliotekarz" },
                    { "fe756c0c-44ea-4482-9b15-a8fcb3c11f33", "2", "Administrator", "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "209e7cbb-2b0c-4e7d-993c-a16bbf09ff3e", 0, "c6a5b68c-dc49-46fb-bbcc-ee8b05b2f3e8", null, false, false, null, null, "BIBLIOTEKARZ", "AQAAAAEAACcQAAAAEFo9e+2v8L0bW74qvzSIxE7CohSc6hi8e1scNW2RtO9nfCBMaea1c8M2whXG62kT2w==", null, false, "5e546310-a38d-486c-b1eb-afc842922b5a", false, "bibliotekarz" },
                    { "69e3365c-ded9-4bbf-af5b-69fb12930d27", 0, "deee4ce1-01a9-4725-aa96-a32ba047e29e", null, false, false, null, null, "ADMINISTRATOR", "AQAAAAEAACcQAAAAEP2TSJJTer9+QkAOuBmIhMxYHwigDKUDU45cdVrdEAuKii6oI3qdAZiAtxI17h6+YA==", null, false, "91462d40-cb16-4a48-a635-825299020043", false, "administrator" }
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
