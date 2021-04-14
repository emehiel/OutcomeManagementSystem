using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OutcomeManagementSystem.Data;
using OutcomeManagementSystem.Models;

namespace OutcomeManagementSystem.Pages.SO_KPIs
{
    public class DetailsModel : PageModel
    {
        private readonly OutcomeManagementSystem.Data.OutcomeManagementSystemContext _context;

        public DetailsModel(OutcomeManagementSystem.Data.OutcomeManagementSystemContext context)
        {
            _context = context;
        }

        public SO_KPI SO_KPI { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SO_KPI = await _context.SO_KPIs
                .Include(s => s.StudentOutcome)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (SO_KPI == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
