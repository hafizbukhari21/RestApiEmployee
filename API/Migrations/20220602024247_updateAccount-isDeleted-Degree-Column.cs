using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class updateAccountisDeletedDegreeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Degree",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Employees");
        }
    }
}
