using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class no_nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "08dee808-81fc-4285-b6dc-9571c8d23be2");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "252e4c0a-028e-45fb-af02-542b663cf086");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7325f9be-fec0-4854-b0ee-ab2c3ac262d4", null, "User", "USER" },
                    { "9dd65e0c-2486-4b94-a432-31baa100ba65", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "7325f9be-fec0-4854-b0ee-ab2c3ac262d4");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "9dd65e0c-2486-4b94-a432-31baa100ba65");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08dee808-81fc-4285-b6dc-9571c8d23be2", null, "User", "USER" },
                    { "252e4c0a-028e-45fb-af02-542b663cf086", null, "Admin", "ADMIN" }
                });
        }
    }
}
