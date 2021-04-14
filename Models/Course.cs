using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OutcomeManagementSystem.Models
{
    public enum YearType
    {
        [Display(Name ="First")]
        First,

        [Display(Name = "Second")]
        Second,

        [Display(Name = "Third")] 
        Third,

        [Display(Name = "Fourth")] 
        Fourth,

        [Display(Name = "unknown")] 
        unknown
    }

    public enum QuarterType
    {
        [Display(Name ="Fall")]
        Fall,

        [Display(Name = "Winter")]
        Winter,

        [Display(Name = "Srping")]
        Spring,

        [Display(Name = "unknown")] 
        unknown
    }
    public class Course
    {
        public int ID { get; set; }
        public string Department { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public int Units { get; set; }
        public string Description { get; set; }
        public string Concentration { get; set; }


        [Required]
        public YearType Year { get; set; }
        public QuarterType Quarter { get; set; }

        //public int PreReqID { get; set; }
        //public int CLOID { get; set; }

        public ICollection<PreReqMap> PreReqMaps { get; set; }
        public ICollection<CLO> CLOs { get; set; }
       
    }
}
