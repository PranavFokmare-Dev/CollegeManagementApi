using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Models.DTO
{
    public class TeacherDTO
    {
        public int TeacherId { get; set; }
        public string RegisterNumber { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Emailid { get; set; }
        public TeacherDTO(Teacher teach)
        {
            if (teach != null)
            {
                this.TeacherId = teach.TeacherId;
                this.RegisterNumber = teach.RegisterNumber;
                this.Name = teach.Name;
                this.ImagePath = teach.ImagePath;
                this.Emailid = teach.Emailid;
            }

        }
    }
}
