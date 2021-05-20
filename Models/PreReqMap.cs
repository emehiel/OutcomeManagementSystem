using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomeManagementSystem.Models
{
    public class PreReqMap
    {
        public int ID { get; set; }
        public string PreReqDept { get; set; }
        public int PreReqNumber { get; set; }
        public string CourseDept { get; set; }
        public int CourseNumber { get; set; }
        public int PreReqID { get; set; }
        public int CourseID { get; set; }
        public Course PreReq { get; set; }
        public Course Course { get; set; }
    }
}
