using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration.Attributes;

namespace OutcomeManagementSystem.Models
{
    public class CLO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int CourseID { get; set; }
        public string Description { get; set; }
        public int SO_KPIID { get; set; }
        public int ProgramOutcomeID { get; set; }

        // Navigation Properties
        [Ignore]
        public SO_KPI SO_KPI { get; set; }
        [Ignore]
        public ProgramOutcome ProgramOutcome { get; set; }
        [Ignore]
        public Course Course { get; set; }
    }
}
