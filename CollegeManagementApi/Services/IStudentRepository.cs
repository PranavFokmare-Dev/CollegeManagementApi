using CollegeManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Services
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
    }

    public class StudentRepository : IStudentRepository
    {
        private readonly CollegeManagementContext _context;
        public StudentRepository(CollegeManagementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }
    }
}
