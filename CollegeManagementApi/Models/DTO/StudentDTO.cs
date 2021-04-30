using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Models.DTO
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string RegisterNumber { get; set; }
        public string Name { get; set; }
        public short? YearOfJoining { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ImagePath { get; set; }
        public string Emailid { get; set; }

        public virtual TeacherDTO Proctor { get; set; }

        public virtual DegreeDTO Degree { get; set; }
        public virtual SchoolDTO School { get; set; }
        public StudentDTO(Student s)
        {
            if (s != null)
            {
                this.StudentId = s.StudentId;
                this.RegisterNumber = s.RegisterNumber;
                this.Name = s.Name;
                this.YearOfJoining = s.YearOfJoining;
                this.DateOfBirth = s.DateOfBirth;
                this.ImagePath = s.ImagePath;
                this.Emailid = s.Emailid;
            }
        }

    }
}
