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
        Task<bool> AddStudent(Student student);
        Task<Student> GetStudentById(int id);
        Task UpdateStudent(Student s);
        Task DeleteStudent(Student s);
        bool StudentExists(int id);
        bool TeacherExists(int id);
        Task<Teacher> GetProctorByStudentId(int sid);
        Task SetProctor(int sid, int pid);
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

        public async Task<bool> AddStudent(Student student)
        {
            if(await checkDegree(student.DegreeId) && await checkSchool(student.SchoolId))
            {
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        private async Task<bool> checkDegree(int? id)
        {
            Degree degree =await _context.Degrees.FindAsync(id);
            if (degree == null)
                return false;
            return true;
        }

        private async Task<bool> checkSchool(int? id)
        {
            School s = await _context.Schools.FindAsync(id);
            if (s == null)
                return false;
            return true;
        }
        
        public async Task<Student> GetStudentById(int id)
        {
            Student s = await _context.Students.Include(s => s.Degree).Include(s => s.School).Include(s => s.Proctor).Include(s => s.Proctor.Designation).Include(s => s.Proctor.School).Where(s => s.StudentId == id).FirstOrDefaultAsync();
            return s;
        }

        

        public async Task UpdateStudent(Student student)
        {
            if (!StudentExists(student.StudentId))
                throw new InvalidOperationException($"Student doesnt exist with id {student.StudentId} to update");
            
            int sid = student.StudentId;
            
            Student entityStudent =await _context.Students.FindAsync(sid);
            
            UpdateChangedFeilds(student, entityStudent);

            _context.Entry(entityStudent).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
        private void UpdateChangedFeilds(Student changed, Student old)
        {
            old.DateOfBirth = changed.DateOfBirth;
            old.DegreeId = changed.DegreeId;
            old.Emailid = changed.Emailid;
            old.ImagePath = changed.ImagePath;
            old.Name = changed.Name;
            old.Password = changed.Password;
            old.SchoolId = changed.SchoolId;
            old.YearOfJoining = changed.YearOfJoining;
        }
        public async Task DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<Teacher> GetProctorByStudentId(int sid)
        {
            if (!StudentExists(sid))
                return null;
            Student s = await _context.Students.Include(s=>s.Proctor).Where(s=>s.StudentId == sid).FirstOrDefaultAsync();
            return s.Proctor;
        }


        public async Task SetProctor(int sid,int tid)
        {
            Student student = await _context.Students.FindAsync(sid);
            Teacher proctor = await _context.Teachers.FindAsync(tid);
            student.ProctorId = tid;
            student.Proctor = proctor;
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }



        public bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
        public bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.TeacherId == id);
        }
    }
}
