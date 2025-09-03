using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Infrasturcture.Migrations
{
    /// <inheritdoc />
    public partial class addedavailablestock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "AvailableStock",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableStock",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "StockQuantity",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
