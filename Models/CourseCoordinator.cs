using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace OutcomeManagementSystem.Models
{
    public class CourseCoordinator : IEquatable<CourseCoordinator>
    {
        public int ID { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
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
        [Display(Name = "Assigned Courses")]
        public ICollection<Course> Courses { get; set; }

        public bool Equals(CourseCoordinator other)
        {
            if (other == null)
                return false;

            if (this.FullName == other.FullName)
                return true;
            else
                return false;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            CourseCoordinator courseCoordObj = obj as CourseCoordinator;
            if (courseCoordObj == null)
                return false;
            else
                return Equals(courseCoordObj);
        }

        public override int GetHashCode()
        {
            return this.FullName.GetHashCode();
        }

        public static bool operator ==(CourseCoordinator cc1, CourseCoordinator cc2)
        {
            if (((object)cc1) == null || ((object)cc2) == null)
                return Object.Equals(cc1, cc2);

            return cc1.Equals(cc2);
        }

        public static bool operator !=(CourseCoordinator cc1, CourseCoordinator cc2)
        {
            if (((object)cc1) == null || ((object)cc2) == null)
                return Object.Equals(cc1, cc2);

            return !(cc1.Equals(cc2));
        }
    }
}
