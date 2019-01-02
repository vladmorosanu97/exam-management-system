using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamsSystem.Data.Implementation.Migrations
{
    public partial class Migration_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Professors_ProfessorId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_ProfessorId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentCourses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "Exams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProfessorCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProfessorId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessorCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorCourses_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ProfessorId",
                table: "Exams",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorCourses_CourseId",
                table: "ProfessorCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorCourses_ProfessorId",
                table: "ProfessorCourses",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Professors_ProfessorId",
                table: "Exams",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Professors_ProfessorId",
                table: "Exams");

            migrationBuilder.DropTable(
                name: "ProfessorCourses");

            migrationBuilder.DropIndex(
                name: "IX_Exams_ProfessorId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Exams");

            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ProfessorId",
                table: "Courses",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Professors_ProfessorId",
                table: "Courses",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
