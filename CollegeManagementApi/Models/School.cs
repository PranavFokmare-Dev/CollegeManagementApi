using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementApi.Models
{
    public partial class School
    {
        public School()
        {
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public int? HodId { get; set; }
        public int? DeanId { get; set; }
        public string BuildingName { get; set; }

        public virtual Teacher Dean { get; set; }
        public virtual Teacher Hod { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
