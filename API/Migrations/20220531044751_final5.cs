using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class final5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_University_universityid",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "education_id",
                table: "Profilings");

            migrationBuilder.DropColumn(
                name: "university_id",
                table: "Education");

            migrationBuilder.AlterColumn<int>(
                name: "universityid",
                table: "Education",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Education_University_universityid",
                table: "Education",
                column: "universityid",
                principalTable: "University",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_University_universityid",
                table: "Education");

            migrationBuilder.AddColumn<int>(
                name: "education_id",
                table: "Profilings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "universityid",
                table: "Education",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "university_id",
                table: "Education",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Education_University_universityid",
                table: "Education",
                column: "universityid",
                principalTable: "University",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
