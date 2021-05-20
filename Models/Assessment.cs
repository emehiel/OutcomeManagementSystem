using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomeManagementSystem.Models
{
    public class Assessment
    {
        public int ID { get; set; }
        public int CanvasAssessmentID { get; set; }
        public double SubmissionScore { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string OutcomeName { get; set; }
        public int CanvasOutcomeID { get; set; }
        public double OutcomeScore { get; set; }
        public int CanvasCourseID { get; set; }
        public double OutcomePointsPossible { get; set; }
        public double OutcomeMasteryScore { get; set; }

        // Navigation Properties
        public Course Course { get; set; }
    }
}
