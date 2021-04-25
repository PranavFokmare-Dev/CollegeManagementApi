﻿using CollegeManagementApi.Models;
using CollegeManagementApi.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Services
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseDTO>> GetCourses();
        Task<IEnumerable<TaughtByDTO>> GetTeachersByCourseId(int cid);
    }
    public class CourseRepository : ICourseRepository
    {
        private readonly CollegeManagementContext context;
        public CourseRepository(CollegeManagementContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<CourseDTO>> GetCourses()
        {
            return await context.Courses.Select(course => new CourseDTO(course)).ToListAsync();
        }
        public async Task<IEnumerable<TaughtByDTO>> GetTeachersByCourseId(int cid)
        {
            IEnumerable<TaughtBy> taughtBies = await context.TaughtBies.Where(tby => tby.CourseId == cid).Include(tby => tby.Teacher).ToListAsync();
            IEnumerable<TaughtByDTO> taughtBiesDtos = taughtBies.Select(
                    tby => new TaughtByDTO()
                    {
                        TaughtById = tby.TaughtById,
                        CourseId = (int)tby.CourseId,
                        Teacher = new TeacherDTO(tby.Teacher)
                    });
            return taughtBiesDtos;
        }
    }
}
