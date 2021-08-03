using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace OutcomeManagementSystem.Models
{
    public class CLO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int CourseID { get; set; }
        public string Description { get; set; }
        [Display(Name ="KPI Number")]
        public int SO_KPIID { get; set; }
        public int ProgramOutcomeID { get; set; }
        [Display(Name ="Mastery Level")]
        public string MasteryLevel { get; set; }
        [Ignore]
        [Display(Name ="CLO Code")]
        public string CLOCode
        {
            get
            {
                return "SO " + SO_KPI.StudentOutcome.SONumber + ".KPI " + SO_KPI.KPINumber + "--" + SO_KPI.Description;
            }
        }
        // Navigation Properties
        [Ignore]
        [Display(Name ="Associated KPI")]
        public SO_KPI SO_KPI { get; set; }
        [Ignore]
        [Display(Name = "Associated Program Outcome")]
        public ProgramOutcome ProgramOutcome { get; set; }
        [Ignore]
        [Display(Name = "Associated Course")]
        public Course Course { get; set; }
    }
}
