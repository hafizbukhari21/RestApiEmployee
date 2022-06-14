using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profilings_Education_education_id",
                table: "Profilings");

            migrationBuilder.DropIndex(
                name: "IX_Profilings_education_id",
                table: "Profilings");

            migrationBuilder.AddColumn<int>(
                name: "educationid",
                table: "Profilings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profilings_educationid",
                table: "Profilings",
                column: "educationid");

            migrationBuilder.AddForeignKey(
                name: "FK_Profilings_Education_educationid",
                table: "Profilings",
                column: "educationid",
                principalTable: "Education",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profilings_Education_educationid",
                table: "Profilings");

            migrationBuilder.DropIndex(
                name: "IX_Profilings_educationid",
                table: "Profilings");

            migrationBuilder.DropColumn(
                name: "educationid",
                table: "Profilings");

            migrationBuilder.CreateIndex(
                name: "IX_Profilings_education_id",
                table: "Profilings",
                column: "education_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profilings_Education_education_id",
                table: "Profilings",
                column: "education_id",
                principalTable: "Education",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
