using Microsoft.EntityFrameworkCore.Migrations;

namespace OutcomeManagementSystem.Migrations
{
    public partial class initial : Migration
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
                    PreReqID = table.Column<int>(nullable: false),
                    CLOID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CLO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    SO_KPIID = table.Column<int>(nullable: false),
                    ProgramOutcomeID = table.Column<int>(nullable: false),
                    CourseID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLO_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreReq",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    CourseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreReq", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PreReq_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramOutcome",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    CLOID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramOutcome", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProgramOutcome_CLO_CLOID",
                        column: x => x.CLOID,
                        principalTable: "CLO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SO_KPI",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    StudentOutcomeID = table.Column<int>(nullable: false),
                    CLOID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SO_KPI", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SO_KPI_CLO_CLOID",
                        column: x => x.CLOID,
                        principalTable: "CLO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentOutcome",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    SO_KPIID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentOutcome", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentOutcome_SO_KPI_SO_KPIID",
                        column: x => x.SO_KPIID,
                        principalTable: "SO_KPI",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CLO_CourseID",
                table: "CLO",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_PreReq_CourseID",
                table: "PreReq",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramOutcome_CLOID",
                table: "ProgramOutcome",
                column: "CLOID");

            migrationBuilder.CreateIndex(
                name: "IX_SO_KPI_CLOID",
                table: "SO_KPI",
                column: "CLOID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentOutcome_SO_KPIID",
                table: "StudentOutcome",
                column: "SO_KPIID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreReq");

            migrationBuilder.DropTable(
                name: "ProgramOutcome");

            migrationBuilder.DropTable(
                name: "StudentOutcome");

            migrationBuilder.DropTable(
                name: "SO_KPI");

            migrationBuilder.DropTable(
                name: "CLO");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
