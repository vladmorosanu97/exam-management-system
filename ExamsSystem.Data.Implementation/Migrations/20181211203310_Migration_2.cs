using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamsSystem.Data.Implementation.Migrations
{
    public partial class Migration_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Professors_ProfessorId",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "ProfessorId",
                table: "Exams",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_ProfessorId",
                table: "Exams",
                newName: "IX_Exams_CourseId");

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CourseId",
                table: "StudentCourse",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Courses_CourseId",
                table: "Exams",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Courses_CourseId",
                table: "Exams");

            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Exams",
                newName: "ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_CourseId",
                table: "Exams",
                newName: "IX_Exams_ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Professors_ProfessorId",
                table: "Exams",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
