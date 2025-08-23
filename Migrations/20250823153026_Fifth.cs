using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXAMINATION.Migrations
{
    /// <inheritdoc />
    public partial class Fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Semester_SemesterId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Semester_SemesterId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Semester_Program_ProgramId",
                table: "Semester");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Semester_SemesterId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Semester",
                table: "Semester");

            migrationBuilder.RenameTable(
                name: "Semester",
                newName: "Semesters");

            migrationBuilder.RenameIndex(
                name: "IX_Semester_ProgramId",
                table: "Semesters",
                newName: "IX_Semesters_ProgramId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Semesters",
                table: "Semesters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Semesters_SemesterId",
                table: "Applications",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Semesters_SemesterId",
                table: "Course",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Semesters_Program_ProgramId",
                table: "Semesters",
                column: "ProgramId",
                principalTable: "Program",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Semesters_SemesterId",
                table: "Students",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Semesters_SemesterId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Semesters_SemesterId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Semesters_Program_ProgramId",
                table: "Semesters");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Semesters_SemesterId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Semesters",
                table: "Semesters");

            migrationBuilder.RenameTable(
                name: "Semesters",
                newName: "Semester");

            migrationBuilder.RenameIndex(
                name: "IX_Semesters_ProgramId",
                table: "Semester",
                newName: "IX_Semester_ProgramId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Semester",
                table: "Semester",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Semester_SemesterId",
                table: "Applications",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Semester_SemesterId",
                table: "Course",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Semester_Program_ProgramId",
                table: "Semester",
                column: "ProgramId",
                principalTable: "Program",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Semester_SemesterId",
                table: "Students",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
