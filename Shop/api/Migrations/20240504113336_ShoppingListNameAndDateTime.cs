using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingListNameAndDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5af1630-0d8f-4af2-915f-b5174ec67560");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df514c44-37a6-4b49-85fe-918a5f65885c");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "shopping_list",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "shopping_list",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46155bfd-c81c-4aa5-b9f8-560fb0491347", null, "Admin", "ADMIN" },
                    { "c01896a1-a270-45a5-b913-e9174155354e", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46155bfd-c81c-4aa5-b9f8-560fb0491347");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c01896a1-a270-45a5-b913-e9174155354e");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "shopping_list");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "shopping_list");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c5af1630-0d8f-4af2-915f-b5174ec67560", null, "Admin", "ADMIN" },
                    { "df514c44-37a6-4b49-85fe-918a5f65885c", null, "User", "USER" }
                });
        }
    }
}
