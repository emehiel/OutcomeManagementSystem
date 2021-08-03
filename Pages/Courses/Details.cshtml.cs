using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OutcomeManagementSystem.Data;
using OutcomeManagementSystem.Models;

namespace OutcomeManagementSystem.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly OutcomeManagementSystem.Data.OutcomeManagementSystemContext _context;

        public DetailsModel(OutcomeManagementSystem.Data.OutcomeManagementSystemContext context)
        {
            _context = context;
            CourseIndex = new IndexEntity(0, _context.Courses.Count());
        }

        public Course Course { get; set; }
        public IndexEntity CourseIndex { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CourseIndex.Index = (int)id;
            CourseIndex.TotalEntities = _context.Courses.Count();

            Course = await _context.Courses
                .Include(c => c.CLOs)
                .ThenInclude(clo => clo.ProgramOutcome)
                .Include(c => c.CLOs)
                .ThenInclude(sokpi => sokpi.SO_KPI)
                .ThenInclude(so => so.StudentOutcome)
                .Include(s => s.PreReqs)
                .ThenInclude(pr => pr.ReqCourse)
                .Include(c => c.CourseCoordinator)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
