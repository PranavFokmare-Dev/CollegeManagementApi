using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Models.DTO
{
    public class RegisteredDTO
    {
        public int RegisterdId { get; set; }
        public CourseDTO course { get; set; }
        public TeacherDTO teacher { get; set; }

    }
}
