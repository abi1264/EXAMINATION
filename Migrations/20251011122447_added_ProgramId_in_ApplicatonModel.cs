using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXAMINATION.Migrations
{
    /// <inheritdoc />
    public partial class added_ProgramId_in_ApplicatonModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgramId",
                table: "Applications",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ApplicationCourse",
                columns: table => new
                {
                    ApplicationsId = table.Column<int>(type: "integer", nullable: false),
                    CoursesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationCourse", x => new { x.ApplicationsId, x.CoursesId });
                    table.ForeignKey(
                        name: "FK_ApplicationCourse_Applications_ApplicationsId",
                        column: x => x.ApplicationsId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationCourse_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ProgramId",
                table: "Applications",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationCourse_CoursesId",
                table: "ApplicationCourse",
                column: "CoursesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Programs_ProgramId",
                table: "Applications",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Programs_ProgramId",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "ApplicationCourse");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ProgramId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "Applications");
        }
    }
}
