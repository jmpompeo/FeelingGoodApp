using Microsoft.EntityFrameworkCore.Migrations;

namespace FeelingGoodApp.Data.Migrations
{
    public partial class RegisterDataWithHeight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Height",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "IndexViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    item_name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Radius = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Query = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexViewModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndexViewModel");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "AspNetUsers");
        }
    }
}
