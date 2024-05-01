using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class category_name_change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_product_categories_CategoryId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_shelf_product_categories_CategoryId",
                table: "shelf");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product_categories",
                table: "product_categories");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "4278327a-1471-4816-aa2c-eb31b0c16685");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "ba5ef1c4-375a-493c-8e69-3236762c2fe2");

            migrationBuilder.RenameTable(
                name: "product_categories",
                newName: "categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "Id");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2919f78b-ccf7-4d90-99e8-863ffc65b590", null, "User", "USER" },
                    { "8ddf4a2e-6914-4bbc-98b6-d21ab12cf94b", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_products_categories_CategoryId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_shelf_categories_CategoryId",
                table: "shelf");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "2919f78b-ccf7-4d90-99e8-863ffc65b590");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "8ddf4a2e-6914-4bbc-98b6-d21ab12cf94b");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "product_categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product_categories",
                table: "product_categories",
                column: "Id");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4278327a-1471-4816-aa2c-eb31b0c16685", null, "User", "USER" },
                    { "ba5ef1c4-375a-493c-8e69-3236762c2fe2", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_products_product_categories_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "product_categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shelf_product_categories_CategoryId",
                table: "shelf",
                column: "CategoryId",
                principalTable: "product_categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
