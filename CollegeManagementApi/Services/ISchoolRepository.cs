using CollegeManagementApi.Models;
using CollegeManagementApi.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Services
{
    public interface ISchoolRepository
    {
        Task<IEnumerable<School>> GetSchool();
        Task SetHod(int school_id, int teacher_id);
        Task SetDean(int school_id, int teacher_id);
        Task<School> GetHodBySchoolId(int sid);
        Task<School> GetDeanBySchoolId(int sid);
        bool SchoolExists(int id);
        bool TeacherExists(int tid);

    }

    public class SchoolRepository : ISchoolRepository
    {
        private readonly CollegeManagementContext _context;

        public SchoolRepository(CollegeManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<School>> GetSchool()
        {

            return await _context.Schools.Include(s => s.Hod).Include(s => s.Dean).ToListAsync();

        }

        public async Task SetHod(int school_id, int teacher_id)
        {
            School school = await _context.Schools.Include(s => s.Hod).Where(s => s.SchoolId == school_id).FirstOrDefaultAsync();
            Teacher teacher = await _context.Teachers.FindAsync(teacher_id);          

            school.Hod.Name = teacher.Name;
            school.HodId = teacher.TeacherId;

            _context.Entry(school).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task SetDean(int school_id, int teacher_id)
        {
            School school = await _context.Schools.Include(s => s.Dean).Where(s => s.SchoolId == school_id).FirstOrDefaultAsync();
            Teacher teacher = await _context.Teachers.FindAsync(teacher_id);

            school.Dean.Name = teacher.Name;
            school.DeanId = teacher.TeacherId;

            _context.Entry(school).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task<School> GetHodBySchoolId(int sid)
        {
            if (!SchoolExists(sid))
                return null;
            School s = await _context.Schools.Include(s => s.Hod).Where(s => s.SchoolId == sid).FirstOrDefaultAsync();
            return (s);
        }

        public async Task<School> GetDeanBySchoolId(int sid)
        {
            if (!SchoolExists(sid))
                return null;
            School s = await _context.Schools.Include(s => s.Dean).Where(s => s.SchoolId == sid).FirstOrDefaultAsync();
            return (s);
        }


        public bool SchoolExists(int id)
        {
            return _context.Schools.Any(e => e.SchoolId == id);
        }

        public bool TeacherExists(int tid )
        {
            return _context.Teachers.Any(e => e.TeacherId == tid);
        }





    }
}
