using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutcomeManagementSystem.Models
{
    public class ProgramOutcome
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
        public ICollection<CLO> CLOs { get; set; }
    }
}
