using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementApi.Models
{
    public partial class CoursePage
    {
        public int? TaughtById { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        public virtual TaughtBy TaughtBy { get; set; }
    }
}
