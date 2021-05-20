using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [Ignore]
        public StudentOutcome StudentOutcome { get; set; }
    }
}
