using Microsoft.EntityFrameworkCore.Migrations;

namespace FeelingGoodApp.Data.Migrations
{
    public partial class AppUserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "IndexViewModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "IndexViewModel",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Height_cm",
                table: "IndexViewModel",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Weight_kg",
                table: "IndexViewModel",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "IndexViewModel");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "IndexViewModel");

            migrationBuilder.DropColumn(
                name: "Height_cm",
                table: "IndexViewModel");

            migrationBuilder.DropColumn(
                name: "Weight_kg",
                table: "IndexViewModel");
        }
    }
}
