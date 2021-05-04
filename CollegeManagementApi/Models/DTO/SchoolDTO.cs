using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Models.DTO
{
    public class SchoolDTO
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string BuildingName { get; set; }
        public virtual TeacherDTO Dean { get; set; }
        public virtual TeacherDTO Hod { get; set; }

        public SchoolDTO(School school)
        {
            if (school != null)
            {
                this.SchoolId = school.SchoolId;
                this.SchoolName = school.SchoolName;
                this.BuildingName = school.BuildingName;
            }
           
            
        }
    }
}
