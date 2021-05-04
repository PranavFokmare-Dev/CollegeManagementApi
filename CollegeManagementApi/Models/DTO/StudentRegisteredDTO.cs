using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Models.DTO
{
    public class StudentRegisteredDTO
    {
        public int RegisterdId { get; set; }
        public StudentDTO student { get; set; }
    }
}
