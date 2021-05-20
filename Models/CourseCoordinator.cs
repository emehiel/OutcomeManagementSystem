using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace OutcomeManagementSystem.Models
{
    public class CourseCoordinator
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Ignore]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        [Ignore]
        public int CourseID { get; set; }
        [Ignore]
        public Course Courses { get; set; } 
    }
}
