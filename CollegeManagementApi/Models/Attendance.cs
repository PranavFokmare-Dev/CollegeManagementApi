using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementApi.Models
{
    public partial class Attendance
    {
        public int? RegisterdId { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }

        public virtual Registerd Registerd { get; set; }
    }
}
