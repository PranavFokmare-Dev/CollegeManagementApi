using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string RegisterNumber { get; set; }
        public string HashPassword { get; set; }
        public string Type { get; set; }
    }
}
