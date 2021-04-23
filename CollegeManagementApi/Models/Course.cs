using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementApi.Models
{
    public partial class Course
    {
        public Course()
        {
            TaughtBies = new HashSet<TaughtBy>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public byte? Credits { get; set; }
        public string CourseType { get; set; }
        public string SyllabusPath { get; set; }
        public string CourseStatus { get; set; }

        public virtual ICollection<TaughtBy> TaughtBies { get; set; }
    }
}
