using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeJoinName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JoinProductShoppingLists_products_ProductId",
                table: "JoinProductShoppingLists");

            migrationBuilder.DropForeignKey(
                name: "FK_JoinProductShoppingLists_shopping_list_ShoppingListId",
                table: "JoinProductShoppingLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JoinProductShoppingLists",
                table: "JoinProductShoppingLists");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cb54fc7-a08f-45f6-a6f0-fa344c7a2280");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ec8b5d2-8b4d-4595-9cf1-b99a7cc20067");

            migrationBuilder.RenameTable(
                name: "JoinProductShoppingLists",
                newName: "join_product_shopping_list");

            migrationBuilder.RenameIndex(
                name: "IX_JoinProductShoppingLists_ProductId",
                table: "join_product_shopping_list",
                newName: "IX_join_product_shopping_list_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_join_product_shopping_list",
                table: "join_product_shopping_list",
                columns: new[] { "ShoppingListId", "ProductId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c5af1630-0d8f-4af2-915f-b5174ec67560", null, "Admin", "ADMIN" },
                    { "df514c44-37a6-4b49-85fe-918a5f65885c", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_join_product_shopping_list_products_ProductId",
                table: "join_product_shopping_list",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_join_product_shopping_list_shopping_list_ShoppingListId",
                table: "join_product_shopping_list",
                column: "ShoppingListId",
                principalTable: "shopping_list",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_join_product_shopping_list_products_ProductId",
                table: "join_product_shopping_list");

            migrationBuilder.DropForeignKey(
                name: "FK_join_product_shopping_list_shopping_list_ShoppingListId",
                table: "join_product_shopping_list");

            migrationBuilder.DropPrimaryKey(
                name: "PK_join_product_shopping_list",
                table: "join_product_shopping_list");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5af1630-0d8f-4af2-915f-b5174ec67560");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df514c44-37a6-4b49-85fe-918a5f65885c");

            migrationBuilder.RenameTable(
                name: "join_product_shopping_list",
                newName: "JoinProductShoppingLists");

            migrationBuilder.RenameIndex(
                name: "IX_join_product_shopping_list_ProductId",
                table: "JoinProductShoppingLists",
                newName: "IX_JoinProductShoppingLists_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JoinProductShoppingLists",
                table: "JoinProductShoppingLists",
                columns: new[] { "ShoppingListId", "ProductId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3cb54fc7-a08f-45f6-a6f0-fa344c7a2280", null, "User", "USER" },
                    { "8ec8b5d2-8b4d-4595-9cf1-b99a7cc20067", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_JoinProductShoppingLists_products_ProductId",
                table: "JoinProductShoppingLists",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JoinProductShoppingLists_shopping_list_ShoppingListId",
                table: "JoinProductShoppingLists",
                column: "ShoppingListId",
                principalTable: "shopping_list",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
