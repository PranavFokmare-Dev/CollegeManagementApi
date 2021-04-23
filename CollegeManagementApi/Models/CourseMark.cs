using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementApi.Models
{
    public partial class CourseMark
    {
        public int RegisteredId { get; set; }
        public byte? Cat1 { get; set; }
        public byte? Cat2 { get; set; }
        public byte? Fat { get; set; }
        public byte? Da1 { get; set; }
        public byte? Da2 { get; set; }
        public byte? Quiz1 { get; set; }
        public byte? Quiz2 { get; set; }
    }
}
