using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCrud.Migrations
{
    /// <inheritdoc />
    public partial class changefieldsname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StoreOwner",
                table: "Store",
                newName: "Owner");

            migrationBuilder.RenameColumn(
                name: "StoreName",
                table: "Store",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Product",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProductDescription",
                table: "Product",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Owner",
                table: "Store",
                newName: "StoreOwner");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Store",
                newName: "StoreName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Product",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Product",
                newName: "ProductDescription");
        }
    }
}
