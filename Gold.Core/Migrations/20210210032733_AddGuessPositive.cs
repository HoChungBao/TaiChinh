using Microsoft.EntityFrameworkCore.Migrations;

namespace Gold.Core.Migrations
{
    public partial class AddGuessPositive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPositive",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Field",
                table: "Events",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsGood",
                table: "Events",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPositiveFake",
                table: "Events",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPositiveReal",
                table: "Events",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Field",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "IsGood",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "IsPositiveFake",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "IsPositiveReal",
                table: "Events");

            migrationBuilder.AddColumn<bool>(
                name: "IsPositive",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
