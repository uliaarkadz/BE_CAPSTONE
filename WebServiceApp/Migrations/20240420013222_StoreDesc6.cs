using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebServiceApp.Migrations
{
    /// <inheritdoc />
    public partial class StoreDesc6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cart_orders_OrderId",
                table: "cart");

            migrationBuilder.DropForeignKey(
                name: "FK_products_cart_CartId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "cartid",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "productid",
                table: "cart");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "products",
                newName: "productid");

            migrationBuilder.RenameIndex(
                name: "IX_products_CartId",
                table: "products",
                newName: "IX_products_productid");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "cart",
                newName: "cartid");

            migrationBuilder.RenameIndex(
                name: "IX_cart_OrderId",
                table: "cart",
                newName: "IX_cart_cartid");

            migrationBuilder.AddForeignKey(
                name: "FK_cart_orders_cartid",
                table: "cart",
                column: "cartid",
                principalTable: "orders",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_cart_productid",
                table: "products",
                column: "productid",
                principalTable: "cart",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cart_orders_cartid",
                table: "cart");

            migrationBuilder.DropForeignKey(
                name: "FK_products_cart_productid",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "products",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_products_productid",
                table: "products",
                newName: "IX_products_CartId");

            migrationBuilder.RenameColumn(
                name: "cartid",
                table: "cart",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_cart_cartid",
                table: "cart",
                newName: "IX_cart_OrderId");

            migrationBuilder.AddColumn<int>(
                name: "cartid",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "productid",
                table: "cart",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_cart_orders_OrderId",
                table: "cart",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_cart_CartId",
                table: "products",
                column: "CartId",
                principalTable: "cart",
                principalColumn: "id");
        }
    }
}
