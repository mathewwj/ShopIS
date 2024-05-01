using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Req_FK_II : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "b9207861-6fc0-4153-8e27-29fcba33e95d");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "de3f53a9-a2a5-49aa-99a0-c97c7511b381");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08dee808-81fc-4285-b6dc-9571c8d23be2", null, "User", "USER" },
                    { "252e4c0a-028e-45fb-af02-542b663cf086", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "b9207861-6fc0-4153-8e27-29fcba33e95d", null, "User", "USER" },
                    { "de3f53a9-a2a5-49aa-99a0-c97c7511b381", null, "Admin", "ADMIN" }
                });
        }
    }
}
