using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomeManagementSystem.Models
{
    public class CLOMap
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int CLOID { get; set; }
        public Course Course { get; set; }
        public PreReq CLO { get; set; }
    }
}
