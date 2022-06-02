using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class relationAccountToProfilingAndEduToProfiling2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_University_Universityid",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Profilings_Education_educationid",
                table: "Profilings");

            migrationBuilder.DropIndex(
                name: "IX_Profilings_educationid",
                table: "Profilings");

            migrationBuilder.DropColumn(
                name: "educationid",
                table: "Profilings");

            migrationBuilder.RenameColumn(
                name: "Universityid",
                table: "Education",
                newName: "universityid");

            migrationBuilder.RenameIndex(
                name: "IX_Education_Universityid",
                table: "Education",
                newName: "IX_Education_universityid");

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

            migrationBuilder.AddColumn<int>(
                name: "university_id",
                table: "Education",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Profilings_education_id",
                table: "Profilings",
                column: "education_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_University_universityid",
                table: "Education",
                column: "universityid",
                principalTable: "University",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profilings_Education_education_id",
                table: "Profilings",
                column: "education_id",
                principalTable: "Education",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_University_universityid",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Profilings_Education_education_id",
                table: "Profilings");

            migrationBuilder.DropIndex(
                name: "IX_Profilings_education_id",
                table: "Profilings");

            migrationBuilder.DropColumn(
                name: "GPA",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "degree",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "university_id",
                table: "Education");

            migrationBuilder.RenameColumn(
                name: "universityid",
                table: "Education",
                newName: "Universityid");

            migrationBuilder.RenameIndex(
                name: "IX_Education_universityid",
                table: "Education",
                newName: "IX_Education_Universityid");

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
                name: "FK_Education_University_Universityid",
                table: "Education",
                column: "Universityid",
                principalTable: "University",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profilings_Education_educationid",
                table: "Profilings",
                column: "educationid",
                principalTable: "Education",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
