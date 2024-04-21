using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebServiceApp.Migrations
{
    /// <inheritdoc />
    public partial class StoreDesc11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createddate",
                table: "customers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updateddate",
                table: "customers",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createddate",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "updateddate",
                table: "customers");
        }
    }
}
