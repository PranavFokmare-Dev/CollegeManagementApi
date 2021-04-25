using CollegeManagementApi.Models;
using CollegeManagementApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CollegeManagementApi.Services
{
    public interface IRegisterRepository
    {
        Task<IEnumerable<RegisteredDTO>> GetCoursesByStudentId(int sid);
        Task DeregisterCourseByStudentId(int sid, int regid);
        Task StudentEnrollCourse(int sid, int taughtby_id);
        Task<ProjectMark> GetProjectMarks(int regid);
    }
    public class RegisterRepository:IRegisterRepository
    {
        private readonly CollegeManagementContext _context;
        
        public RegisterRepository(CollegeManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RegisteredDTO>> GetCoursesByStudentId(int sid)
        {


            IEnumerable<Registerd> registeredCoursesOfStudent = await _context.Registerds.Where(reg => reg.StudentId == sid).ToListAsync();
            IEnumerable<TaughtBy> taughtBies = await _context.TaughtBies.Include(t => t.Course).Include(t => t.Teacher).ToListAsync();
            return registeredCoursesOfStudent.Join(taughtBies,
                reg=>reg.TaughtById,
                tby=>tby.TaughtById,
                (reg,tby)=>new RegisteredDTO() 
                { course = new CourseDTO(tby.Course),
                    teacher = new TeacherDTO(tby.Teacher),
                    RegisterdId = reg.RegisterdId
                });
        }

        public async Task DeregisterCourseByStudentId(int sid, int regid)
        {
            var register = await _context.Registerds.FindAsync(regid);
            _context.Remove(register);
            await _context.SaveChangesAsync();
        }

        public async Task StudentEnrollCourse(int sid, int taughtby_id)
        {
            Student s = await _context.Students.FindAsync(sid);
            TaughtBy tby = await _context.TaughtBies.FindAsync(taughtby_id);

            Registerd register = new Registerd() { StudentId = sid, TaughtById = taughtby_id, Student = s, TaughtBy = tby };
            await _context.Registerds.AddAsync(register);
            await _context.SaveChangesAsync();
        }

        public async Task<ProjectMark> GetProjectMarks(int regid)
        {
            ProjectMark marks = await _context.ProjectMarks.FindAsync(regid);
            return marks;
        }
    }
}
