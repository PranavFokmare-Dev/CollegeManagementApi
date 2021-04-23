using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementApi.Models
{
    public partial class Designation
    {
        public Designation()
        {
            Teachers = new HashSet<Teacher>();
        }

        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public decimal? Salary { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
