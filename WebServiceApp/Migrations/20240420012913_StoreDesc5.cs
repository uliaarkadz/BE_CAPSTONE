using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebServiceApp.Migrations
{
    /// <inheritdoc />
    public partial class StoreDesc5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cart_customers_customerid",
                table: "cart");

            migrationBuilder.DropForeignKey(
                name: "FK_cart_products_productid",
                table: "cart");

            migrationBuilder.DropIndex(
                name: "IX_cart_customerid",
                table: "cart");

            migrationBuilder.DropIndex(
                name: "IX_cart_productid",
                table: "cart");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "cart");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "cart");

            migrationBuilder.RenameColumn(
                name: "customerid",
                table: "cart",
                newName: "customerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "cart",
                newName: "customerid");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "cart",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "cart",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_cart_customerid",
                table: "cart",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_cart_productid",
                table: "cart",
                column: "productid");

            migrationBuilder.AddForeignKey(
                name: "FK_cart_customers_customerid",
                table: "cart",
                column: "customerid",
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
    }
}
