using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace OutcomeManagementSystem.Models
{
    public class ProgramOutcome
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [Index(1)]
        [Display(Name ="Program Outcome Number")]
        public int PONumber { get; set; }
        public string Description { get; set; }
        public string Concentration { get; set; }
        [Display(Name ="Course Learning Outcomes")]
        public ICollection<CLO> CLOs { get; set; }
    }
}
