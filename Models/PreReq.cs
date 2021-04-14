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
        public int CourseID { get; set; }
        //public int ReqID { get; set; }
        public Course Course { get; set; }
        //public PreReq Req { get; set; }
    }
}
