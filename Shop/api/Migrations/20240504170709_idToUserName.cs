using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class idToUserName : Migration
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
                keyValue: "38c3fb90-0bfc-43bb-be34-d3c6e9bd62d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d5ee86e-ced9-4f8f-8d3a-69b385c15c0f");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "38c3fb90-0bfc-43bb-be34-d3c6e9bd62d5", null, "User", "USER" },
                    { "9d5ee86e-ced9-4f8f-8d3a-69b385c15c0f", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_shopping_list_AspNetUsers_AppUserId",
                table: "shopping_list",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
