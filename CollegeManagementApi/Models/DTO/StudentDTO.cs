using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Models.DTO
{
    public class StudentDTO
    {
        public string RegisterNumber { get; set; }
        public string Name { get; set; }
        public short? YearOfJoining { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ImagePath { get; set; }
        public string Emailid { get; set; }

        public virtual TeacherDTO Proctor { get; set; }

        public virtual DegreeDTO Degree { get; set; }
        public virtual SchoolDTO School { get; set; }

    }
}
