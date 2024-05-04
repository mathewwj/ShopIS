using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03615317-4718-4798-80e0-c2c6b42cd918");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb68d55a-970c-49da-accc-96e5d28125e9");

            migrationBuilder.CreateTable(
                name: "shopping_list",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopping_list", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shopping_list_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JoinProductShoppingLists",
                columns: table => new
                {
                    ShoppingListId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoinProductShoppingLists", x => new { x.ShoppingListId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_JoinProductShoppingLists_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JoinProductShoppingLists_shopping_list_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "shopping_list",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3cb54fc7-a08f-45f6-a6f0-fa344c7a2280", null, "User", "USER" },
                    { "8ec8b5d2-8b4d-4595-9cf1-b99a7cc20067", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JoinProductShoppingLists_ProductId",
                table: "JoinProductShoppingLists",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_shopping_list_AppUserId",
                table: "shopping_list",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JoinProductShoppingLists");

            migrationBuilder.DropTable(
                name: "shopping_list");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cb54fc7-a08f-45f6-a6f0-fa344c7a2280");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ec8b5d2-8b4d-4595-9cf1-b99a7cc20067");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03615317-4718-4798-80e0-c2c6b42cd918", null, "Admin", "ADMIN" },
                    { "cb68d55a-970c-49da-accc-96e5d28125e9", null, "User", "USER" }
                });
        }
    }
}
