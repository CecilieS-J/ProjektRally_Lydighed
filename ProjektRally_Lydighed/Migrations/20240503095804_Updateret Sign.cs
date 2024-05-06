using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektRally_Lydighed.Migrations
{
    /// <inheritdoc />
    public partial class UpdateretSign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rotation",
                table: "Sign");

            migrationBuilder.DropColumn(
                name: "XCoordinate",
                table: "Sign");

            migrationBuilder.DropColumn(
                name: "YCoordinate",
                table: "Sign");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rotation",
                table: "Sign",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "XCoordinate",
                table: "Sign",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "YCoordinate",
                table: "Sign",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
