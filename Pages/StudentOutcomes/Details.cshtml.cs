using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OutcomeManagementSystem.Data;
using OutcomeManagementSystem.Models;

namespace OutcomeManagementSystem.Pages.StudentOutcomes
{
    public class DetailsModel : PageModel
    {
        private readonly OutcomeManagementSystem.Data.OutcomeManagementSystemContext _context;

        public DetailsModel(OutcomeManagementSystem.Data.OutcomeManagementSystemContext context)
        {
            _context = context;
        }

        public StudentOutcome StudentOutcome { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudentOutcome = await _context.StudentOutcomes
                .Include(kpis => kpis.SO_KPIs)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (StudentOutcome == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
