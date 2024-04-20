using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebServiceApp.Migrations
{
    /// <inheritdoc />
    public partial class StoreDesc7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_cart_productid",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_productid",
                table: "products");

            migrationBuilder.DropColumn(
                name: "productid",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "productid",
                table: "cart",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_cart_customerId",
                table: "cart",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_cart_productid",
                table: "cart",
                column: "productid");

            migrationBuilder.AddForeignKey(
                name: "FK_cart_customers_customerId",
                table: "cart",
                column: "customerId",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cart_products_productid",
                table: "cart",
                column: "productid",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cart_customers_customerId",
                table: "cart");

            migrationBuilder.DropForeignKey(
                name: "FK_cart_products_productid",
                table: "cart");

            migrationBuilder.DropIndex(
                name: "IX_cart_customerId",
                table: "cart");

            migrationBuilder.DropIndex(
                name: "IX_cart_productid",
                table: "cart");

            migrationBuilder.DropColumn(
                name: "productid",
                table: "cart");

            migrationBuilder.AddColumn<int>(
                name: "productid",
                table: "products",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_productid",
                table: "products",
                column: "productid");

            migrationBuilder.AddForeignKey(
                name: "FK_products_cart_productid",
                table: "products",
                column: "productid",
                principalTable: "cart",
                principalColumn: "id");
        }
    }
}
