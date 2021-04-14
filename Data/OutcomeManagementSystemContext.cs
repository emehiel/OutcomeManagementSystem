using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OutcomeManagementSystem.Models;

namespace OutcomeManagementSystem.Data
{
    public class OutcomeManagementSystemContext : DbContext
    {
        public OutcomeManagementSystemContext (DbContextOptions<OutcomeManagementSystemContext> options)
            : base(options)
        {
        }

        public DbSet<OutcomeManagementSystem.Models.Course> Courses { get; set; }

        public DbSet<OutcomeManagementSystem.Models.CLO> CLOs { get; set; }

        public DbSet<OutcomeManagementSystem.Models.PreReq> PreReqs { get; set; }

        public DbSet<OutcomeManagementSystem.Models.ProgramOutcome> ProgramOutcomes { get; set; }

        public DbSet<OutcomeManagementSystem.Models.SO_KPI> SO_KPIs { get; set; }

        public DbSet<OutcomeManagementSystem.Models.StudentOutcome> StudentOutcomes { get; set; }
        public DbSet<OutcomeManagementSystem.Models.PreReqMap> PreReqMaps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PreReqMap>()
                .HasOne(p => p.PreReq)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            /*
            modelBuilder.Entity<Course>()
                .HasMany(p => p.PreReqs)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
 */
            modelBuilder.Entity<StudentOutcome>().ToTable("StudentOutcome");
            modelBuilder.Entity<ProgramOutcome>().ToTable("ProgramOutcome");
            modelBuilder.Entity<SO_KPI>().ToTable("SO_KPI");
            modelBuilder.Entity<CLO>().ToTable("CLO");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<PreReq>().ToTable("PreReq");
        }

    }
}
