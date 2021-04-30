using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Models.DTO
{
    public class CourseDTO
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public byte? Credits { get; set; }
        public string CourseType { get; set; }
        public string SyllabusPath { get; set; }
        public string CourseStatus { get; set; }

        public CourseDTO(Course course)
        {
            if (course != null)
            {
                this.CourseId = course.CourseId;
                this.CourseName = course.CourseName;
                this.CourseStatus = course.CourseStatus;
                this.CourseType = course.CourseType;
                this.Credits = course.Credits;
                this.SyllabusPath = course.SyllabusPath;
            }
           
        }

        public CourseDTO()
        {
        }
    }
}
