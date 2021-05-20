using Microsoft.EntityFrameworkCore.Migrations;

namespace OutcomeManagementSystem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Quarter = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProgramOutcome",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true)
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
                    Description = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentOutcome", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CourseCoordinators",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CourseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCoordinators", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CourseCoordinators_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreReqMaps",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreReqDept = table.Column<string>(nullable: true),
                    PreReqNumber = table.Column<int>(nullable: false),
                    CourseDept = table.Column<string>(nullable: true),
                    CourseNumber = table.Column<int>(nullable: false),
                    PreReqID = table.Column<int>(nullable: false),
                    CourseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreReqMaps", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PreReqMaps_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreReqMaps_Course_PreReqID",
                        column: x => x.PreReqID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SO_KPI",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    StudentOutcomeID = table.Column<int>(nullable: false)
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
                name: "CLO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    CourseID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SO_KPIID = table.Column<int>(nullable: false),
                    ProgramOutcomeID = table.Column<int>(nullable: false)
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
                name: "IX_CourseCoordinators_CourseID",
                table: "CourseCoordinators",
                column: "CourseID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreReqMaps_CourseID",
                table: "PreReqMaps",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_PreReqMaps_PreReqID",
                table: "PreReqMaps",
                column: "PreReqID");

            migrationBuilder.CreateIndex(
                name: "IX_SO_KPI_StudentOutcomeID",
                table: "SO_KPI",
                column: "StudentOutcomeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLO");

            migrationBuilder.DropTable(
                name: "CourseCoordinators");

            migrationBuilder.DropTable(
                name: "PreReqMaps");

            migrationBuilder.DropTable(
                name: "ProgramOutcome");

            migrationBuilder.DropTable(
                name: "SO_KPI");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "StudentOutcome");
        }
    }
}
