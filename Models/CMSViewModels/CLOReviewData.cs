using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomeManagementSystem.Models.CMSViewModels
{
    public class CLOReviewData
    {
        public IEnumerable<CourseCoordinator> CourseCoordinators { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<CLO> CLOs { get; set; }
        public IEnumerable<Course> PreReqs { get; set; }
    }
}
