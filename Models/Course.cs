using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Display(Name = "Spring")]
        Spring,

        [Display(Name = "unknown")] 
        unknown
    }
    public enum Type
    {
        [Display(Name ="Major")]
        Major,
        [Display(Name = "Support")]
        Support,
        [Display(Name = "Concentration")]
        Concentration,
        [Display(Name = "General Education")]
        GeneralEducation
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
        public Type Type { get; set; }

        public int CourseCoordinatorID { get; set; }
        public CourseCoordinator CourseCoordinator { get; set; }
        public ICollection<PreReq> PreReqs { get; set; }
        public ICollection<CLO> CLOs { get; set; }
       
    }
}
