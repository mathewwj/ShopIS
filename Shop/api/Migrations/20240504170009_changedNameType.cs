using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class changedNameType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48c2cd50-0d83-44df-b14f-e39457ec202d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77ce546f-fc84-42d0-93a6-dc3f98f80200");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "shopping_list",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38c3fb90-0bfc-43bb-be34-d3c6e9bd62d5", null, "User", "USER" },
                    { "9d5ee86e-ced9-4f8f-8d3a-69b385c15c0f", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38c3fb90-0bfc-43bb-be34-d3c6e9bd62d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d5ee86e-ced9-4f8f-8d3a-69b385c15c0f");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "shopping_list",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48c2cd50-0d83-44df-b14f-e39457ec202d", null, "User", "USER" },
                    { "77ce546f-fc84-42d0-93a6-dc3f98f80200", null, "Admin", "ADMIN" }
                });
        }
    }
}
