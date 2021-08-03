using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace OutcomeManagementSystem.Models
{
    public class StudentOutcome
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [Index(1)]
        [Display(Name ="Student Outcome Number")]
        public int SONumber { get; set; }
        [Index(2)]
        public string Description { get; set; }
        [Index(3)]
        [Display(Name ="Short Name")]
        public string ShortName { get; set; }
        [Ignore]
        [Display(Name ="Key Performance Indicators")]
        public ICollection<SO_KPI> SO_KPIs { get; set; }
    }
}
