using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektRally_Lydighed.Migrations
{
    /// <inheritdoc />
    public partial class SignOpdateret : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sign_Exercise_ExerciseId",
                table: "Sign");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "Sign",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Sign",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Sign_Exercise_ExerciseId",
                table: "Sign",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sign_Exercise_ExerciseId",
                table: "Sign");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Sign");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "Sign",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sign_Exercise_ExerciseId",
                table: "Sign",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
