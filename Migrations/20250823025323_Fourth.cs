using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXAMINATION.Migrations
{
    /// <inheritdoc />
    public partial class Fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Semester_SemesterId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_Students_StudentProfileId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_Users_UserId",
                table: "Application");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Application",
                table: "Application");

            migrationBuilder.RenameTable(
                name: "Application",
                newName: "Applications");

            migrationBuilder.RenameIndex(
                name: "IX_Application_UserId",
                table: "Applications",
                newName: "IX_Applications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Application_StudentProfileId",
                table: "Applications",
                newName: "IX_Applications_StudentProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Application_SemesterId",
                table: "Applications",
                newName: "IX_Applications_SemesterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Semester_SemesterId",
                table: "Applications",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Students_StudentProfileId",
                table: "Applications",
                column: "StudentProfileId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_UserId",
                table: "Applications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Semester_SemesterId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Students_StudentProfileId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_UserId",
                table: "Applications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.RenameTable(
                name: "Applications",
                newName: "Application");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_UserId",
                table: "Application",
                newName: "IX_Application_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_StudentProfileId",
                table: "Application",
                newName: "IX_Application_StudentProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_SemesterId",
                table: "Application",
                newName: "IX_Application_SemesterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Application",
                table: "Application",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Semester_SemesterId",
                table: "Application",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Students_StudentProfileId",
                table: "Application",
                column: "StudentProfileId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Users_UserId",
                table: "Application",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
