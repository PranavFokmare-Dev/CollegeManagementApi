using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Models.DTO
{
    public class TeacherDTO
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Emailid { get; set; }
        public TeacherDTO(Teacher teach)
        {
            this.TeacherId = teach.TeacherId;
            this.Name = teach.Name;
            this.ImagePath = teach.ImagePath;
            this.Emailid = teach.Emailid;
        }
    }
}
