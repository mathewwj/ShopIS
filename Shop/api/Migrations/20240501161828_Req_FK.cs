using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Req_FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shelf_categories_CategoryId",
                table: "shelf");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "f0af5ffc-476e-415a-a074-43d2e02ee041");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "f38dedba-c02f-416b-ab36-8f693e399109");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "shelf",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b9207861-6fc0-4153-8e27-29fcba33e95d", null, "User", "USER" },
                    { "de3f53a9-a2a5-49aa-99a0-c97c7511b381", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_shelf_categories_CategoryId",
                table: "shelf",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shelf_categories_CategoryId",
                table: "shelf");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "b9207861-6fc0-4153-8e27-29fcba33e95d");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "de3f53a9-a2a5-49aa-99a0-c97c7511b381");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "shelf",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f0af5ffc-476e-415a-a074-43d2e02ee041", null, "Admin", "ADMIN" },
                    { "f38dedba-c02f-416b-ab36-8f693e399109", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_shelf_categories_CategoryId",
                table: "shelf",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id");
        }
    }
}
