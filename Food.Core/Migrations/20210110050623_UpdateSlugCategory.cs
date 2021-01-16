using Microsoft.EntityFrameworkCore.Migrations;

namespace Food.Core.Migrations
{
    public partial class UpdateSlugCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Vegetable_Fruit",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Vegetable_Fruit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Category",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Vegetable_Fruit");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Vegetable_Fruit",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);
        }
    }
}
