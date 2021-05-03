using CollegeManagementApi.Filter;
using CollegeManagementApi.Models.DTO;
using CollegeManagementApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;
        private readonly IExistenceChecker checker;
        public LoginController(ILoginService loginService, IExistenceChecker checker)
        {
            this.loginService = loginService;
            this.checker = checker;
        }
        //[ServiceFilter(typeof(LogNormalActionFilter))]
        [HttpPost]
        public async Task<ActionResult> Login(UserDTO user)
        {
            if (!await UserExists(user))
                return NotFound(new { loggedIn = false, message = "User doesnt exists", user = user }) ;
            bool loggedIn = await loginService.Login(user);
            if (loggedIn)
                return Ok(new { loggedIn = true, user = user});
            return Ok(new { loggedIn = false, user = user });
        }
        public async Task<bool> UserExists(UserDTO user)
        {
            if (user.Type == "student")
                return await checker.StudentExists(user.Id);
            if (user.Type == "teacher" || user.Type == "admin")
                return await checker.TeacherExists(user.Id);
            return false;
        }
    }
}
