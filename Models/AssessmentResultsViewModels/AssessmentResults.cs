using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomeManagementSystem.Models.AssessmentResultsViewModels
{
    public class AssessmentResults
    {
        public IEnumerable<Assessment> Assessments { get; set; }
    }
}
