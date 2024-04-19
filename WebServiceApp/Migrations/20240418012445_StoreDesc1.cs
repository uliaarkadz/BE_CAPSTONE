using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebServiceApp.Migrations
{
    /// <inheritdoc />
    public partial class StoreDesc1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "customers");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "customers",
                newName: "zip");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "customers",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "customers",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "customers",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "customers",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "customers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "customers",
                newName: "dob");

            migrationBuilder.RenameColumn(
                name: "Address2",
                table: "customers",
                newName: "addresstwo");

            migrationBuilder.RenameColumn(
                name: "Address1",
                table: "customers",
                newName: "addressone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customers",
                table: "customers",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_customers",
                table: "customers");

            migrationBuilder.RenameTable(
                name: "customers",
                newName: "Customer");

            migrationBuilder.RenameColumn(
                name: "zip",
                table: "Customer",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "Customer",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "Customer",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "Customer",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Customer",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Customer",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "dob",
                table: "Customer",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "addresstwo",
                table: "Customer",
                newName: "Address2");

            migrationBuilder.RenameColumn(
                name: "addressone",
                table: "Customer",
                newName: "Address1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");
        }
    }
}
