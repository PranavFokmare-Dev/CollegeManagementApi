using CollegeManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace CollegeManagementApi.Services
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetTeachers();
        Task<Teacher> GetTeachersByTeacherId(int id);
        Task<IEnumerable<Teacher>> GetTeachersBySchoolId(int id);
        Task<Teacher> PutTeacher(int id, Teacher teacher);
        Task<Teacher> PostTeacher(Teacher teacher);
        Task DeleteTeacher(Teacher teacher);



    }

    public class TeacherRepository : ITeacherRepository
    {
        private readonly CollegeManagementContext _context;
        public TeacherRepository(CollegeManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> GetTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetTeachersByTeacherId(int id)
        {
            Teacher teacher = await _context.Teachers.FindAsync(id);
            return teacher;
         }

        public async Task<IEnumerable<Teacher>> GetTeachersBySchoolId(int id)
        {
            IEnumerable<Teacher> teachers = _context.Teachers.Where(t => t.SchoolId == id);
            return teachers;
        }

        public async Task<Teacher> PutTeacher(int id, Teacher teacher)
        {

            Teacher teacher_update = await _context.Teachers.FindAsync(id);
            _context.Entry(teacher).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<Teacher> PostTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return teacher;          
        }

        public async Task DeleteTeacher(Teacher teacher)
        {
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }
    }
}
