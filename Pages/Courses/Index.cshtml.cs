using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OutcomeManagementSystem.Data;
using OutcomeManagementSystem.Models;

namespace OutcomeManagementSystem.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly OutcomeManagementSystemContext _context;
        private readonly IConfiguration _configuration;

        public IndexModel(OutcomeManagementSystemContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public string NumberSort { get; set; }
        public string TitleSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Course> Courses { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NumberSort = String.IsNullOrEmpty(sortOrder) ? "number_desc" : "";
            TitleSort = sortOrder == "Title" ? "title_desc" : "Title";
            
            if (searchString != null)
                pageIndex = 1;
            else
                searchString = currentFilter;

            CurrentFilter = searchString;

            IQueryable<Course> coursesIQ = from s in _context.Courses
                                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                coursesIQ = coursesIQ.Where(s => s.Title.Contains(searchString)
                || Convert.ToString(s.Number).Contains(searchString));
            }

            switch (sortOrder)
            {
                case "number_desc":
                    coursesIQ = coursesIQ.OrderByDescending(s => s.Number);
                    break;
                case "Title":
                    coursesIQ = coursesIQ.OrderBy(s => s.Title);
                    break;
                case "title_desc":
                    coursesIQ = coursesIQ.OrderByDescending(s => s.Title);
                    break;
                default:
                    coursesIQ = coursesIQ.OrderBy(s => s.Number);
                    break;
            }

            var pageSize = _configuration.GetValue("PageSize", 10);
            Courses = await PaginatedList<Course>.CreateAsync(
                coursesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
