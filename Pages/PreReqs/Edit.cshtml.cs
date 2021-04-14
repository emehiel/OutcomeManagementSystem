using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OutcomeManagementSystem.Data;
using OutcomeManagementSystem.Models;

namespace OutcomeManagementSystem.Pages.PreReqs
{
    public class EditModel : PageModel
    {
        private readonly OutcomeManagementSystem.Data.OutcomeManagementSystemContext _context;

        public EditModel(OutcomeManagementSystem.Data.OutcomeManagementSystemContext context)
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
           ViewData["CourseID"] = new SelectList(_context.Courses, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PreReq).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreReqExists(PreReq.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PreReqExists(int id)
        {
            return _context.PreReqs.Any(e => e.ID == id);
        }
    }
}
