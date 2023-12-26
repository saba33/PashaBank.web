using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PashaBank.Repository.Migrations
{
    public partial class fixedrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_Users_UserId",
                table: "Recommendations");

            migrationBuilder.DropIndex(
                name: "IX_Recommendations_UserId",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Recommendations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Recommendations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_UserId",
                table: "Recommendations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_Users_UserId",
                table: "Recommendations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
