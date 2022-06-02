using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class revert2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GPA",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "degree",
                table: "Education");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GPA",
                table: "Education",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "degree",
                table: "Education",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
