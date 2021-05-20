using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OutcomeManagementSystem.Models
{
    public enum PreReqType
    {
        [Display(Name = "Pre-requisite")]
        PreReq,
        [Display(Name = "Co-requisite")]
        CoReq,
        [Display(Name = "Recomended")] 
        Recommended
    }
    public class PreReq
    {
        public int ID { get; set; }
        public PreReqType Type { get; set; }
        public string CourseDept { get; set; }
        public int CourseNumber { get; set; }
        public string PreReqDept { get; set; }
        public int PreReqNumber { get; set; }
        public int CourseID { get; set; }
        public int ReqCourseID { get; set; }
        public Course Course { get; set; }
        public Course ReqCourse { get; set; }
    }
}
