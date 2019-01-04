using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamsSystem.Data.Implementation.Migrations
{
    public partial class Migration_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classrooms_Exams_ExamId",
                table: "Classrooms");

            migrationBuilder.DropIndex(
                name: "IX_Classrooms_ExamId",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Classrooms");

            migrationBuilder.CreateTable(
                name: "ClassroomExams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassroomId = table.Column<int>(nullable: false),
                    ExamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassroomExams_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassroomExams_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomExams_ClassroomId",
                table: "ClassroomExams",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomExams_ExamId",
                table: "ClassroomExams",
                column: "ExamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassroomExams");

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "Classrooms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_ExamId",
                table: "Classrooms",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classrooms_Exams_ExamId",
                table: "Classrooms",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
