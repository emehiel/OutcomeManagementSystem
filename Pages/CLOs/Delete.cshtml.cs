using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OutcomeManagementSystem.Data;
using OutcomeManagementSystem.Models;

namespace OutcomeManagementSystem.Pages.CLOs
{
    public class DeleteModel : PageModel
    {
        private readonly OutcomeManagementSystem.Data.OutcomeManagementSystemContext _context;

        public DeleteModel(OutcomeManagementSystem.Data.OutcomeManagementSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CLO CLO { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CLO = await _context.CLOs.FirstOrDefaultAsync(m => m.ID == id);

            if (CLO == null)
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

            CLO = await _context.CLOs.FindAsync(id);

            if (CLO != null)
            {
                _context.CLOs.Remove(CLO);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
