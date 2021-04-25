using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Models.DTO
{
    public class ProjectMarksDTO
    {
        public int RegisterdId { get; set; }
        public byte? Review1 { get; set; }
        public byte? Review2 { get; set; }
        public byte? Review3 { get; set; }
    }
}
