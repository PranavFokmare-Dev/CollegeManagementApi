using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#nullable disable

namespace CollegeManagementApi.Models
{
    [DataContract]
    public partial class Student
    {
        public Student()
        {
            Registerds = new HashSet<Registerd>();
        }

        public int StudentId { get; set; }
        [DataMember]
        public string RegisterNumber { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public short? YearOfJoining { get; set; }
        [DataMember]
        public DateTime? DateOfBirth { get; set; }
        [DataMember]
        public int? ProctorId { get; set; }
        [DataMember]
        public int? DegreeId { get; set; }
        [DataMember]
        public int? SchoolId { get; set; }
        [DataMember]
        public string ImagePath { get; set; }
        public string Password { get; set; }
        [DataMember]
        public string Emailid { get; set; }

        [DataMember]
        public virtual Degree Degree { get; set; }
        [DataMember]
        public virtual Teacher Proctor { get; set; }
        [DataMember]
        public virtual School School { get; set; }
        public virtual ICollection<Registerd> Registerds { get; set; }
    }
}
