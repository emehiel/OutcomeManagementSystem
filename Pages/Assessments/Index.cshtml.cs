using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OutcomeManagementSystem.Data;
using OutcomeManagementSystem.Models;
using OutcomeManagementSystem.Models.AssessmentResultsViewModels;
using OutcomeManagementSystem.Models.CanvasAPI;

namespace OutcomeManagementSystem.Pages.Assessments
{
    public class IndexModel : PageModel
    {
        private readonly OutcomeManagementSystem.Data.OutcomeManagementSystemContext _context;

        public IndexModel(OutcomeManagementSystem.Data.OutcomeManagementSystemContext context)
        {
            _context = context;
        }

        public IList<Assessment> Assessment { get;set; }
        public AssessmentResults AssessmentResults { get; set; }
        public string MasteryResults { get; set; }
        public string MasteryLabels { get; set; }
        public List<string> OutcomeNames { get; set; }
        public string OutcomeNamesString { get; set; }
        public APIFunctions CanvasAPI = new APIFunctions();

        public async Task OnGetAsync()
        {
            var OutcomeResults = CanvasAPI.GetOutcomeResults(45619);
            AssessmentResults = new AssessmentResults
            {
                Assessments = await _context.Assessments.ToListAsync()
            };

            MasteryLabels = @"[[""Exceeds Mastery"", ""Mastery"",""Near Mastery"", ""Below Mastery""],
                              [""Exceeds Expectations"", ""Meets Expectations"",""Approaches Expectations"", ""Needs More Time/Practice to Develop""]]";
            
            OutcomeNames = AssessmentResults.Assessments.Select(ar => ar.OutcomeName).Distinct().ToList();

            MasteryResults = new string("[");

            OutcomeNamesString = "[";

            foreach(var on in OutcomeNames)
            {
                OutcomeNamesString += @"""" + on + @""",";

                var outcomeScores = AssessmentResults.Assessments.Where(os => os.OutcomeName == on);
                var totalAssessments = outcomeScores.Count()/100.0;
                MasteryResults += "[" + Convert.ToString(outcomeScores.Where(ar => ar.OutcomeScore == 4).Count() / totalAssessments) + ", ";
                MasteryResults += Convert.ToString(outcomeScores.Where(ar => ar.OutcomeScore == 3).Count() / totalAssessments) + ", ";
                MasteryResults += Convert.ToString(outcomeScores.Where(ar => ar.OutcomeScore == 2).Count() / totalAssessments) + ", ";
                MasteryResults += Convert.ToString(outcomeScores.Where(ar => ar.OutcomeScore == 1).Count() / totalAssessments) + "],";
            }
            MasteryResults += "]";
            OutcomeNamesString += "]";
        }

        /*
        public async Task<ActionResult> OnGetInvoiceChartData()
        {
            var assID = await _context.AssessmentData.Select(j => j.CanvasAssessmentID).ToListAsync();
            var assOutcome = _context.AssessmentData.Select(j => j.OutcomeScore).ToListAsync();
            var countException = _context.AssessmentData.Select(j => j.OutcomeScore).ToListAsync();

            return new JsonResult(new { myAssID = assID, myAssOutcome = assOutcome });
        }
        public async Task<ActionResult> Index()
        {

            //var date = await _context.Job.Select(j => j.JobCompletion).Distinct().ToListAsync();
            var date = await _context.AssessmentData.Select(j => j.CanvasAssessmentID).ToListAsync();
            var countSuccess = _context.AssessmentData.Select(j => j.OutcomeScore).ToListAsync();
            var countException = _context.AssessmentData.Select(j => j.OutcomeScore).ToListAsync();
            /*
            var success = _context.Job
                .Where(j => j.JobStatus == "Success")
                .GroupBy(j => j.JobCompletion)
                .Select(group => new {
                    JobCompletion = group.Key,
                    Count = group.Count()
                });
            var countSuccess = success.Select(a => a.Count).ToArray();
            var exception = _context.Job
                .Where(j => j.JobStatus == "Exception")
                .GroupBy(j => j.JobCompletion)
                .Select(group => new {
                    JobCompletion = group.Key,
                    Count = group.Count()
                });
            var countException = exception.Select(a => a.Count).ToArray();
            
            return new JsonResult(new { myDate = date, mySuccess = countSuccess, myException = countException });
        }
        */
    }
}
