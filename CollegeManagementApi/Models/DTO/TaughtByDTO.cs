using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Models.DTO
{
    public class TaughtByDTO
    {
        public int TaughtById { get; set; }
        public int CourseId { get; set; }
        public TeacherDTO Teacher { get; set; }
    }
}
