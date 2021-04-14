using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OutcomeManagementSystem.Data;
using OutcomeManagementSystem.Models;

namespace OutcomeManagementSystem.Pages.ProgramOutcomes
{
    public class DeleteModel : PageModel
    {
        private readonly OutcomeManagementSystem.Data.OutcomeManagementSystemContext _context;

        public DeleteModel(OutcomeManagementSystem.Data.OutcomeManagementSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProgramOutcome ProgramOutcome { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProgramOutcome = await _context.ProgramOutcomes.FirstOrDefaultAsync(m => m.ID == id);

            if (ProgramOutcome == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProgramOutcome = await _context.ProgramOutcomes.FindAsync(id);

            if (ProgramOutcome != null)
            {
                _context.ProgramOutcomes.Remove(ProgramOutcome);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
