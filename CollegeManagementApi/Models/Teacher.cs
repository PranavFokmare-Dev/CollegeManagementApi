using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

#nullable disable

namespace CollegeManagementApi.Models
{
    [DataContract]
    public partial class Teacher
    {
        public Teacher()
        {
            SchoolDeans = new HashSet<School>();
            SchoolHods = new HashSet<School>();
            Students = new HashSet<Student>();
            TaughtBies = new HashSet<TaughtBy>();
        }
        [DataMember]
        public int TeacherId { get; set; }
        [DataMember]
        public string RegisterNumber { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int? SchoolId { get; set; }
        [DataMember]
        public string ImagePath { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Emailid { get; set; }
        [DataMember]
        public int? DesignationId { get; set; }

        public virtual Designation Designation { get; set; }
        public virtual School School { get; set; }
    
        public virtual ICollection<School> SchoolDeans { get; set; }
        public virtual ICollection<School> SchoolHods { get; set; }
        public virtual ICollection<Student> Students { get; set; }  //Proctees
        public virtual ICollection<TaughtBy> TaughtBies { get; set; }   //Courses
    }
}
