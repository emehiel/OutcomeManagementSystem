using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OutcomeManagementSystem.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseCoordinators",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCoordinators", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProgramOutcome",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    PONumber = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Concentration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramOutcome", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StudentOutcome",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SONumber = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentOutcome", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Units = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Concentration = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Quarter = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    CourseCoordinatorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Course_CourseCoordinators_CourseCoordinatorID",
                        column: x => x.CourseCoordinatorID,
                        principalTable: "CourseCoordinators",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SO_KPI",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    StudentOutcomeID = table.Column<int>(nullable: false),
                    KPINumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SO_KPI", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SO_KPI_StudentOutcome_StudentOutcomeID",
                        column: x => x.StudentOutcomeID,
                        principalTable: "StudentOutcome",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CanvasAssessmentID = table.Column<int>(nullable: false),
                    SubmissionScore = table.Column<double>(nullable: false),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    OutcomeName = table.Column<string>(nullable: true),
                    CanvasOutcomeID = table.Column<int>(nullable: false),
                    OutcomeScore = table.Column<double>(nullable: false),
                    CanvasCourseID = table.Column<int>(nullable: false),
                    OutcomePointsPossible = table.Column<double>(nullable: false),
                    OutcomeMasteryScore = table.Column<double>(nullable: false),
                    CourseID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Assessments_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreReqs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    CourseDept = table.Column<string>(nullable: true),
                    CourseNumber = table.Column<int>(nullable: false),
                    PreReqDept = table.Column<string>(nullable: true),
                    PreReqNumber = table.Column<int>(nullable: false),
                    CourseID = table.Column<int>(nullable: false),
                    ReqCourseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreReqs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PreReqs_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PreReqs_Course_ReqCourseID",
                        column: x => x.ReqCourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    CourseID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SO_KPIID = table.Column<int>(nullable: false),
                    ProgramOutcomeID = table.Column<int>(nullable: false),
                    MasteryLevel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLO_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CLO_ProgramOutcome_ProgramOutcomeID",
                        column: x => x.ProgramOutcomeID,
                        principalTable: "ProgramOutcome",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CLO_SO_KPI_SO_KPIID",
                        column: x => x.SO_KPIID,
                        principalTable: "SO_KPI",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_CourseID",
                table: "Assessments",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CLO_CourseID",
                table: "CLO",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CLO_ProgramOutcomeID",
                table: "CLO",
                column: "ProgramOutcomeID");

            migrationBuilder.CreateIndex(
                name: "IX_CLO_SO_KPIID",
                table: "CLO",
                column: "SO_KPIID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseCoordinatorID",
                table: "Course",
                column: "CourseCoordinatorID");

            migrationBuilder.CreateIndex(
                name: "IX_PreReqs_CourseID",
                table: "PreReqs",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_PreReqs_ReqCourseID",
                table: "PreReqs",
                column: "ReqCourseID");

            migrationBuilder.CreateIndex(
                name: "IX_SO_KPI_StudentOutcomeID",
                table: "SO_KPI",
                column: "StudentOutcomeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "CLO");

            migrationBuilder.DropTable(
                name: "PreReqs");

            migrationBuilder.DropTable(
                name: "ProgramOutcome");

            migrationBuilder.DropTable(
                name: "SO_KPI");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "StudentOutcome");

            migrationBuilder.DropTable(
                name: "CourseCoordinators");
        }
    }
}
