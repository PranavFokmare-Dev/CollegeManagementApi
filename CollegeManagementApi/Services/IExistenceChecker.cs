
using CollegeManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollegeManagementApi.Services
{
    public interface IExistenceChecker
    {
        Task<bool> StudentExists(int id);
        Task<bool> CourseExists(int id);
        Task<bool> TeacherExists(int id);
        Task<bool> RegisterExists(int id);
        Task<bool> RegisterExists(int sid, int tbyid);
        Task<bool> TaughtByExists(int id);
        Task<bool> AttendanceExists(int id);
    }
    public class ExistenceChecker : IExistenceChecker
    {
        private readonly CollegeManagementContext _context;

        public ExistenceChecker(CollegeManagementContext _context)
        {
            this._context = _context;
        }
        public async Task<bool> StudentExists(int id)
        {
            return await _context.Students.AnyAsync(s => s.StudentId == id);
        }
        public async Task<bool> TeacherExists(int id)
        {
            return await _context.Teachers.AnyAsync(t => t.TeacherId == id);
        }
        public async Task<bool> CourseExists(int id)
        {
            return await _context.Courses.AnyAsync(c => c.CourseId == id);
        }
        public async Task<bool> RegisterExists(int id)
        {
            return await _context.Registerds.AnyAsync(r => r.RegisterdId == id);
        }
        public async Task<bool> RegisterExists(int sid, int tbyid)
        {
            return await _context.Registerds.AnyAsync(r => r.TaughtById == tbyid && r.StudentId == sid);
        }
        public async Task<bool> TaughtByExists(int id)
        {
            return await _context.TaughtBies.AnyAsync(tby => tby.TaughtById == id);
        }
        public async Task<bool> AttendanceExists(int id)
        {
            return await _context.Attendances.AnyAsync(a => a.RegisterdId == id);
        }
    }
}
