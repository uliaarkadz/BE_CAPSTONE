using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebServiceApp.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    dob = table.Column<DateOnly>(type: "date", nullable: false),
                    addressone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    addresstwo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    city = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    state = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    zip = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    createddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    price = table.Column<double>(type: "double precision", maxLength: 500, nullable: true),
                    image = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    serial = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    inventory = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    createddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<int>(type: "integer", nullable: false),
                    password = table.Column<int>(type: "integer", nullable: false),
                    customerid = table.Column<int>(type: "integer", nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_customers_customerid",
                        column: x => x.customerid,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customerId = table.Column<int>(type: "integer", nullable: false),
                    productid = table.Column<int>(type: "integer", nullable: false),
                    totalamount = table.Column<double>(type: "double precision", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    isProccesed = table.Column<bool>(type: "boolean", nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart", x => x.id);
                    table.ForeignKey(
                        name: "FK_cart_customers_customerId",
                        column: x => x.customerId,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cart_products_productid",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cartid = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    orderstatus = table.Column<string>(type: "text", nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_cart_cartid",
                        column: x => x.cartid,
                        principalTable: "cart",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cart_customerId",
                table: "cart",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_cart_productid",
                table: "cart",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_orders_cartid",
                table: "orders",
                column: "cartid");

            migrationBuilder.CreateIndex(
                name: "IX_users_customerid",
                table: "users",
                column: "customerid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "cart");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
