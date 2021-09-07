using Microsoft.EntityFrameworkCore.Migrations;

namespace App.DataAccess.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "orders",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "orders",
                newName: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "orders",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "orders",
                newName: "State");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
