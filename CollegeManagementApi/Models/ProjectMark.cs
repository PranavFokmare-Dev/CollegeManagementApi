using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementApi.Models
{
    public partial class ProjectMark
    {
        public int RegisterdId { get; set; }
        public byte? Review1 { get; set; }
        public byte? Review2 { get; set; }
        public byte? Review3 { get; set; }
    }
}
