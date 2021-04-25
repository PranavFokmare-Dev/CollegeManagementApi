using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#nullable disable

namespace CollegeManagementApi.Models
{
    [DataContract]
    public partial class Course
    {
        public Course()
        {
            TaughtBies = new HashSet<TaughtBy>();
        }

        [DataMember]
        public int CourseId { get; set; }
        [DataMember]
        public string CourseName { get; set; }
        [DataMember]
        public byte? Credits { get; set; }
        [DataMember]
        public string CourseType { get; set; }
        [DataMember]
        public string SyllabusPath { get; set; }
        [DataMember]
        public string CourseStatus { get; set; }

        public virtual ICollection<TaughtBy> TaughtBies { get; set; }
    }
}
