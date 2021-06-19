using Microsoft.EntityFrameworkCore.Migrations;

namespace FeelingGoodApp.Data.Migrations
{
    public partial class Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseInfo_ExerciseInfo_ExerciseInfoId",
                table: "ExerciseInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseInfo_ExercisePhoto_photoId",
                table: "ExerciseInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseInfo",
                table: "ExerciseInfo");

            migrationBuilder.RenameTable(
                name: "ExerciseInfo",
                newName: "Exercises");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseInfo_photoId",
                table: "Exercises",
                newName: "IX_Exercises_photoId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseInfo_ExerciseInfoId",
                table: "Exercises",
                newName: "IX_Exercises_ExerciseInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Exercises_ExerciseInfoId",
                table: "Exercises",
                column: "ExerciseInfoId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_ExercisePhoto_photoId",
                table: "Exercises",
                column: "photoId",
                principalTable: "ExercisePhoto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Exercises_ExerciseInfoId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_ExercisePhoto_photoId",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "ExerciseInfo");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_photoId",
                table: "ExerciseInfo",
                newName: "IX_ExerciseInfo_photoId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_ExerciseInfoId",
                table: "ExerciseInfo",
                newName: "IX_ExerciseInfo_ExerciseInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseInfo",
                table: "ExerciseInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseInfo_ExerciseInfo_ExerciseInfoId",
                table: "ExerciseInfo",
                column: "ExerciseInfoId",
                principalTable: "ExerciseInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseInfo_ExercisePhoto_photoId",
                table: "ExerciseInfo",
                column: "photoId",
                principalTable: "ExercisePhoto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
