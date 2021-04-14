using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomeManagementSystem.Models
{
    public class PreReqMap
    {
        public int ID { get; set; }
        public int PreReqID { get; set; }
        public int CourseID { get; set; }
        public PreReq PreReq { get; set; }
        public Course Course { get; set; }
    }
}
