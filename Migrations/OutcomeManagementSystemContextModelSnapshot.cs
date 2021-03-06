// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OutcomeManagementSystem.Data;

namespace OutcomeManagementSystem.Migrations
{
    [DbContext(typeof(OutcomeManagementSystemContext))]
    partial class OutcomeManagementSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OutcomeManagementSystem.Models.Assessment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CanvasAssessmentID")
                        .HasColumnType("int");

                    b.Property<int>("CanvasCourseID")
                        .HasColumnType("int");

                    b.Property<int>("CanvasOutcomeID")
                        .HasColumnType("int");

                    b.Property<int?>("CourseID")
                        .HasColumnType("int");

                    b.Property<double>("OutcomeMasteryScore")
                        .HasColumnType("float");

                    b.Property<string>("OutcomeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("OutcomePointsPossible")
                        .HasColumnType("float");

                    b.Property<double>("OutcomeScore")
                        .HasColumnType("float");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("SubmissionScore")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.ToTable("Assessments");
                });

            modelBuilder.Entity("OutcomeManagementSystem.Models.CLO", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasteryLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProgramOutcomeID")
                        .HasColumnType("int");

                    b.Property<int>("SO_KPIID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("ProgramOutcomeID");

                    b.HasIndex("SO_KPIID");

                    b.ToTable("CLO");
                });

            modelBuilder.Entity("OutcomeManagementSystem.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Concentration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseCoordinatorID")
                        .HasColumnType("int");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Quarter")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Units")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CourseCoordinatorID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("OutcomeManagementSystem.Models.CourseCoordinator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CourseCoordinators");
                });

            modelBuilder.Entity("OutcomeManagementSystem.Models.PreReq", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseDept")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("CourseNumber")
                        .HasColumnType("int");

                    b.Property<string>("PreReqDept")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PreReqNumber")
                        .HasColumnType("int");

                    b.Property<int>("ReqCourseID")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("ReqCourseID");

                    b.ToTable("PreReqs");
                });

            modelBuilder.Entity("OutcomeManagementSystem.Models.ProgramOutcome", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Concentration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PONumber")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ProgramOutcome");
                });

            modelBuilder.Entity("OutcomeManagementSystem.Models.SO_KPI", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KPINumber")
                        .HasColumnType("int");

                    b.Property<int>("StudentOutcomeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StudentOutcomeID");

                    b.ToTable("SO_KPI");
                });

            modelBuilder.Entity("OutcomeManagementSystem.Models.StudentOutcome", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SONumber")
                        .HasColumnType("int");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("StudentOutcome");
                });

            modelBuilder.Entity("OutcomeManagementSystem.Models.Assessment", b =>
                {
                    b.HasOne("OutcomeManagementSystem.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID");
                });

            modelBuilder.Entity("OutcomeManagementSystem.Models.CLO", b =>
                {
                    b.HasOne("OutcomeManagementSystem.Models.Course", "Course")
                        .WithMany("CLOs")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OutcomeManagementSystem.Models.ProgramOutcome", "ProgramOutcome")
                        .WithMany("CLOs")
                        .HasForeignKey("ProgramOutcomeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OutcomeManagementSystem.Models.SO_KPI", "SO_KPI")
                        .WithMany()
                        .HasForeignKey("SO_KPIID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OutcomeManagementSystem.Models.Course", b =>
                {
                    b.HasOne("OutcomeManagementSystem.Models.CourseCoordinator", "CourseCoordinator")
                        .WithMany("Courses")
                        .HasForeignKey("CourseCoordinatorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OutcomeManagementSystem.Models.PreReq", b =>
                {
                    b.HasOne("OutcomeManagementSystem.Models.Course", "Course")
                        .WithMany("PreReqs")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OutcomeManagementSystem.Models.Course", "ReqCourse")
                        .WithMany()
                        .HasForeignKey("ReqCourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OutcomeManagementSystem.Models.SO_KPI", b =>
                {
                    b.HasOne("OutcomeManagementSystem.Models.StudentOutcome", "StudentOutcome")
                        .WithMany("SO_KPIs")
                        .HasForeignKey("StudentOutcomeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
