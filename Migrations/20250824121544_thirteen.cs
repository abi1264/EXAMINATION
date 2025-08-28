using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXAMINATION.Migrations
{
    /// <inheritdoc />
    public partial class thirteen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectiveSubject_Courses_CourseId",
                table: "ElectiveSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_ElectiveSubject_Students_StudentProfileId",
                table: "ElectiveSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ElectiveSubject",
                table: "ElectiveSubject");

            migrationBuilder.RenameTable(
                name: "ElectiveSubject",
                newName: "Electives");

            migrationBuilder.RenameIndex(
                name: "IX_ElectiveSubject_StudentProfileId",
                table: "Electives",
                newName: "IX_Electives_StudentProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ElectiveSubject_CourseId",
                table: "Electives",
                newName: "IX_Electives_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Electives",
                table: "Electives",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Electives_Courses_CourseId",
                table: "Electives",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Electives_Students_StudentProfileId",
                table: "Electives",
                column: "StudentProfileId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Electives_Courses_CourseId",
                table: "Electives");

            migrationBuilder.DropForeignKey(
                name: "FK_Electives_Students_StudentProfileId",
                table: "Electives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Electives",
                table: "Electives");

            migrationBuilder.RenameTable(
                name: "Electives",
                newName: "ElectiveSubject");

            migrationBuilder.RenameIndex(
                name: "IX_Electives_StudentProfileId",
                table: "ElectiveSubject",
                newName: "IX_ElectiveSubject_StudentProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Electives_CourseId",
                table: "ElectiveSubject",
                newName: "IX_ElectiveSubject_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ElectiveSubject",
                table: "ElectiveSubject",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectiveSubject_Courses_CourseId",
                table: "ElectiveSubject",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ElectiveSubject_Students_StudentProfileId",
                table: "ElectiveSubject",
                column: "StudentProfileId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
