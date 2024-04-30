using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class warehouse_shelf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "280553c1-c59c-4fa1-a4ed-44c22c61c61c");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "3039e955-8350-472a-ba97-71dc1845a2fd");

            migrationBuilder.AddColumn<bool>(
                name: "IsInWarehouse",
                table: "shelf",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4278327a-1471-4816-aa2c-eb31b0c16685", null, "User", "USER" },
                    { "ba5ef1c4-375a-493c-8e69-3236762c2fe2", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "4278327a-1471-4816-aa2c-eb31b0c16685");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "ba5ef1c4-375a-493c-8e69-3236762c2fe2");

            migrationBuilder.DropColumn(
                name: "IsInWarehouse",
                table: "shelf");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "280553c1-c59c-4fa1-a4ed-44c22c61c61c", null, "Admin", "ADMIN" },
                    { "3039e955-8350-472a-ba97-71dc1845a2fd", null, "User", "USER" }
                });
        }
    }
}
