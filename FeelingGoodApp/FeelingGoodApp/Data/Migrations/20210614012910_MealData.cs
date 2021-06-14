using Microsoft.EntityFrameworkCore.Migrations;

namespace FeelingGoodApp.Data.Migrations
{
    public partial class MealData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MealData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    item_name = table.Column<string>(nullable: true),
                    nf_calories = table.Column<float>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealData");
        }
    }
}
