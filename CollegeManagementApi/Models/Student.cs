using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementApi.Models
{
    public partial class Student
    {
        public Student()
        {
            Registerds = new HashSet<Registerd>();
        }

        public int StudentId { get; set; }
        public string RegisterNumber { get; set; }
        public string Name { get; set; }
        public short? YearOfJoining { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? ProctorId { get; set; }
        public int? DegreeId { get; set; }
        public int? SchoolId { get; set; }
        public string ImagePath { get; set; }
        public string Password { get; set; }
        public string Emailid { get; set; }

        public virtual Degree Degree { get; set; }
        public virtual Teacher Proctor { get; set; }
        public virtual School School { get; set; }
        public virtual ICollection<Registerd> Registerds { get; set; }
    }
}
