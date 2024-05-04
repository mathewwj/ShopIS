using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CategoryChangedParams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shelf_categories_CategoryId",
                table: "shelf");

            migrationBuilder.DropIndex(
                name: "IX_shelf_CategoryId",
                table: "shelf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf9343bb-dc00-4947-821f-8e1b99d4d60d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4d14ad2-6c59-4244-9b5c-055bc5efcc58");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "shelf");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "shelf");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "shelf",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "415591a9-e21e-4407-9433-d73e6e7b8445", null, "User", "USER" },
                    { "c741a0ae-cd31-4fbc-8414-58c8aa6560b1", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "415591a9-e21e-4407-9433-d73e6e7b8445");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c741a0ae-cd31-4fbc-8414-58c8aa6560b1");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "shelf");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "shelf",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "shelf",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cf9343bb-dc00-4947-821f-8e1b99d4d60d", null, "Admin", "ADMIN" },
                    { "d4d14ad2-6c59-4244-9b5c-055bc5efcc58", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_shelf_CategoryId",
                table: "shelf",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_shelf_categories_CategoryId",
                table: "shelf",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
