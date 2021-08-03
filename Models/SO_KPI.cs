using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration.Attributes;

namespace OutcomeManagementSystem.Models
{
    public class SO_KPI
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Description { get; set; }
        public int StudentOutcomeID { get; set; }
        [Index(2)]
        [Display(Name ="KPI Number")]
        public int KPINumber { get; set; }
        [Ignore]
        [Display(Name="Student Outcome")]
        public StudentOutcome StudentOutcome { get; set; }

    }
}
