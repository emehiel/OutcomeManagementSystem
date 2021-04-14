using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OutcomeManagementSystem.Data;
using OutcomeManagementSystem.Models;

namespace OutcomeManagementSystem.Pages.PreReqs
{
    public class DeleteModel : PageModel
    {
        private readonly OutcomeManagementSystem.Data.OutcomeManagementSystemContext _context;

        public DeleteModel(OutcomeManagementSystem.Data.OutcomeManagementSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PreReq PreReq { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PreReq = await _context.PreReqs
                .Include(p => p.Course).FirstOrDefaultAsync(m => m.ID == id);

            if (PreReq == null)
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

            PreReq = await _context.PreReqs.FindAsync(id);

            if (PreReq != null)
            {
                _context.PreReqs.Remove(PreReq);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
