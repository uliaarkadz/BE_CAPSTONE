using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebServiceApp.Migrations
{
    /// <inheritdoc />
    public partial class StoreDesc8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cart_orders_cartid",
                table: "cart");

            migrationBuilder.DropIndex(
                name: "IX_cart_cartid",
                table: "cart");

            migrationBuilder.DropColumn(
                name: "cartid",
                table: "cart");

            migrationBuilder.AddColumn<int>(
                name: "cartid",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orders_cartid",
                table: "orders",
                column: "cartid");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_cart_cartid",
                table: "orders",
                column: "cartid",
                principalTable: "cart",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_cart_cartid",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_cartid",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "cartid",
                table: "orders");

            migrationBuilder.AddColumn<int>(
                name: "cartid",
                table: "cart",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cart_cartid",
                table: "cart",
                column: "cartid");

            migrationBuilder.AddForeignKey(
                name: "FK_cart_orders_cartid",
                table: "cart",
                column: "cartid",
                principalTable: "orders",
                principalColumn: "id");
        }
    }
}
