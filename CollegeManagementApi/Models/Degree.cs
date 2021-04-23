using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementApi.Models
{
    public partial class Degree
    {
        public Degree()
        {
            Students = new HashSet<Student>();
        }

        public int DegreeId { get; set; }
        public string DegreeName { get; set; }
        public string DegreeType { get; set; }
        public byte? DegreeDuration { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
