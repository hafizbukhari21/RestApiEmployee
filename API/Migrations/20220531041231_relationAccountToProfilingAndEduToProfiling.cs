using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class relationAccountToProfilingAndEduToProfiling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    degree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    university_id = table.Column<int>(type: "int", nullable: false),
                    universityid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.id);
                    table.ForeignKey(
                        name: "FK_Education_University_universityid",
                        column: x => x.universityid,
                        principalTable: "University",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profilings",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    education_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profilings", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_Profilings_Accounts_NIK",
                        column: x => x.NIK,
                        principalTable: "Accounts",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profilings_Education_education_id",
                        column: x => x.education_id,
                        principalTable: "Education",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Education_universityid",
                table: "Education",
                column: "universityid");

            migrationBuilder.CreateIndex(
                name: "IX_Profilings_education_id",
                table: "Profilings",
                column: "education_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profilings");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "University");
        }
    }
}
