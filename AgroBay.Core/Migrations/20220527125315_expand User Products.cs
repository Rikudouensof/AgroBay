using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroBay.Core.Migrations
{
    public partial class expandUserProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvailableQuantity",
                table: "UserProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "UserProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "UserProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isSold",
                table: "UserProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableQuantity",
                table: "UserProducts");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "UserProducts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "UserProducts");

            migrationBuilder.DropColumn(
                name: "isSold",
                table: "UserProducts");
        }
    }
}
