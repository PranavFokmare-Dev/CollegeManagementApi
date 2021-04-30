using CollegeManagementApi.Models;
using CollegeManagementApi.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Services
{
    public interface ILoginService
    {

        Task<bool> Login(UserDTO user);

    }

    public interface ILoginRepository
    {
        Task<string> GetStudentPassword(int id);
        Task<string> GetTeacherPassword(int id);
    }
    public class LoginService : ILoginService 
    {

        private readonly ILoginRepository loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        public async Task<bool> Login(UserDTO user)
        {
            string ActualPassword = await GetPassword(user);
            string GivenPassword = user.HashPassword;
            if (ActualPassword == GivenPassword)
                return true;
            return false;
        }
        public async Task<string> GetPassword(UserDTO user)
        {
            switch (user.Type)
            {   
                case ("student"): return await loginRepository.GetStudentPassword(user.Id);
                case ("teacher"): return await loginRepository.GetTeacherPassword(user.Id);
                case ("admin"): return await loginRepository.GetTeacherPassword(user.Id);
            }
            return null;
        }
    }
    public class LoginRepository : ILoginRepository{
        private readonly CollegeManagementContext context;
        public LoginRepository(CollegeManagementContext context)
        {
            this.context = context;
        }
        public async Task<string> GetStudentPassword(int id)
        {
            return await context.Students.Where(s => s.StudentId == id).Select(s => s.Password).FirstOrDefaultAsync();
        }
        public async Task<string> GetTeacherPassword(int id)
        {
            return await context.Teachers.Where(s => s.TeacherId == id).Select(s => s.Password).FirstOrDefaultAsync();
        }
    }
}
