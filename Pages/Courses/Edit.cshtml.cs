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

namespace OutcomeManagementSystem.Pages.Courses
{
    public class EditModel : PageModel
    {
        private readonly OutcomeManagementSystem.Data.OutcomeManagementSystemContext _context;

        public EditModel(OutcomeManagementSystem.Data.OutcomeManagementSystemContext context)
        {
            _context = context;
            CourseIndex = new IndexEntity(0, _context.Courses.Count());
        }

        [BindProperty]
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

            Course = await _context.Courses.FirstOrDefaultAsync(m => m.ID == id);

            if (Course == null)
            {
                return NotFound();
            }
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

            _context.Attach(Course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(Course.ID))
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

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.ID == id);
        }
    }
}
