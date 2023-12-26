using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PashaBank.Repository.Migrations
{
    public partial class changedBonusMOdel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_RecommenderId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Bonuses");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Bonuses",
                newName: "BonusAssignDate");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_RecommenderId",
                table: "Users",
                column: "RecommenderId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_RecommenderId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "BonusAssignDate",
                table: "Bonuses",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Bonuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_RecommenderId",
                table: "Users",
                column: "RecommenderId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
