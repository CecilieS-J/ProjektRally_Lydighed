using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjektRally_Lydighed.Migrations
{
    /// <inheritdoc />
    public partial class ExerciseModify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sign_Exercise_ExerciseId",
                table: "Sign");

            migrationBuilder.DropIndex(
                name: "IX_Sign_ExerciseId",
                table: "Sign");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81320319-93c2-4b29-af7f-1c5608143df1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "906d8d67-44f5-45a5-84ad-cc0be3a6b34d");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Sign");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "96c823e2-29e9-4744-9ea0-b22894caef39", null, "Member", "MEMBER" },
                    { "bd2f58f2-8450-45f3-a803-641d4936b7bb", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96c823e2-29e9-4744-9ea0-b22894caef39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2f58f2-8450-45f3-a803-641d4936b7bb");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Sign",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "81320319-93c2-4b29-af7f-1c5608143df1", null, "Visitor", "VISITOR" },
                    { "906d8d67-44f5-45a5-84ad-cc0be3a6b34d", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sign_ExerciseId",
                table: "Sign",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sign_Exercise_ExerciseId",
                table: "Sign",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id");
        }
    }
}
