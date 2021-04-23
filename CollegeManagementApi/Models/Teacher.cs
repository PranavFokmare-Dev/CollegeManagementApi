using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementApi.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            SchoolDeans = new HashSet<School>();
            SchoolHods = new HashSet<School>();
            Students = new HashSet<Student>();
            TaughtBies = new HashSet<TaughtBy>();
        }

        public int TeacherId { get; set; }
        public string RegisterNumber { get; set; }
        public string Name { get; set; }
        public int? SchoolId { get; set; }
        public string ImagePath { get; set; }
        public string Password { get; set; }
        public string Emailid { get; set; }
        public int? DesignationId { get; set; }

        public virtual Designation Designation { get; set; }
        public virtual School School { get; set; }
        public virtual ICollection<School> SchoolDeans { get; set; }
        public virtual ICollection<School> SchoolHods { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<TaughtBy> TaughtBies { get; set; }
    }
}
