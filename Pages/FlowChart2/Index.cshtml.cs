using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OutcomeManagementSystem.Data;
using OutcomeManagementSystem.Models;
using OutcomeManagementSystem.Models.CMSViewModels;

namespace OutcomeManagementSystem.Pages.FlowChart2
{
    public class IndexModel : PageModel
    {
        private readonly OutcomeManagementSystem.Data.OutcomeManagementSystemContext _context;

        public IndexModel(OutcomeManagementSystem.Data.OutcomeManagementSystemContext context)
        {
            _context = context;
        }

        public CourseIndexData CourseData { get; set; } 
        public int CourseID { get; set; }


        public async Task OnGetAsync(int? id)
        {
            CourseData = new CourseIndexData();
            CourseData.Courses = await _context.Courses
                .Include(i => i.CLOs)
                .Include(i => i.PreReqs)
                .ThenInclude(pr => pr.Course)
                .AsNoTracking()
                .ToListAsync();

            if (id != null)
            {
                CourseID = id.Value;
                Course selectedCourse = CourseData.Courses
                    .Where(i => i.ID == CourseID).Single();
                var preReqMaps = selectedCourse.PreReqs.Where(pr => pr.CourseID == selectedCourse.ID);
                List<Course> preReqs = new List<Course>();
                foreach(var pr in preReqMaps)
                {
                    preReqs.Add(pr.Course);
                    CourseData.PreReqs = preReqs;
                }
                //CourseData.PreReqs = preReqMaps
                CourseData.CLOs = selectedCourse.CLOs;
           }
        }
    }
}
