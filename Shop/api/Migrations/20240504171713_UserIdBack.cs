using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UserIdBack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shopping_list_AspNetUsers_AppUserId",
                table: "shopping_list");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967cecd1-b844-4579-a325-4aa97782f107");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5a1b812-7860-4d94-b6d2-efa8cc3e7fa8");

            migrationBuilder.DropColumn(
                name: "AppUserName",
                table: "shopping_list");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "shopping_list",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cf9343bb-dc00-4947-821f-8e1b99d4d60d", null, "Admin", "ADMIN" },
                    { "d4d14ad2-6c59-4244-9b5c-055bc5efcc58", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_shopping_list_AspNetUsers_AppUserId",
                table: "shopping_list",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shopping_list_AspNetUsers_AppUserId",
                table: "shopping_list");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf9343bb-dc00-4947-821f-8e1b99d4d60d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4d14ad2-6c59-4244-9b5c-055bc5efcc58");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "shopping_list",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserName",
                table: "shopping_list",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "967cecd1-b844-4579-a325-4aa97782f107", null, "Admin", "ADMIN" },
                    { "d5a1b812-7860-4d94-b6d2-efa8cc3e7fa8", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_shopping_list_AspNetUsers_AppUserId",
                table: "shopping_list",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
