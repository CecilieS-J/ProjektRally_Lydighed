using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektRally_Lydighed.Migrations
{
    /// <inheritdoc />
    public partial class TrackTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Template",
                table: "Track",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Template",
                table: "Track");
        }
    }
}
