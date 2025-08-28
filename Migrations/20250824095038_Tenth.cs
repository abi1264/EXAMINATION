using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXAMINATION.Migrations
{
    /// <inheritdoc />
    public partial class Tenth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Result_Courses_CourseId",
                table: "Result");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_Students_StudentProfileId",
                table: "Result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Result",
                table: "Result");

            migrationBuilder.RenameTable(
                name: "Result",
                newName: "Results");

            migrationBuilder.RenameIndex(
                name: "IX_Result_StudentProfileId",
                table: "Results",
                newName: "IX_Results_StudentProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Result_CourseId",
                table: "Results",
                newName: "IX_Results_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Results",
                table: "Results",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Courses_CourseId",
                table: "Results",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Students_StudentProfileId",
                table: "Results",
                column: "StudentProfileId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Courses_CourseId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Students_StudentProfileId",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Results",
                table: "Results");

            migrationBuilder.RenameTable(
                name: "Results",
                newName: "Result");

            migrationBuilder.RenameIndex(
                name: "IX_Results_StudentProfileId",
                table: "Result",
                newName: "IX_Result_StudentProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_CourseId",
                table: "Result",
                newName: "IX_Result_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Result",
                table: "Result",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Courses_CourseId",
                table: "Result",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Students_StudentProfileId",
                table: "Result",
                column: "StudentProfileId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
