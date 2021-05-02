using CollegeManagementApi.Models.DTO;
using CollegeManagementApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CollegeManagementApi.Models;

namespace CollegeManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisteredController : ControllerBase
    {
        private readonly IRegisterRepository _repo;
        private readonly IExistenceChecker checker;
        public RegisteredController(IRegisterRepository _repo, IExistenceChecker checker)
        {
            this._repo = _repo;
            this.checker = checker;
        }

        [HttpGet("{sid}")]
        public async Task<ActionResult<IEnumerable<RegisteredDTO>>> GetCoursesByStudentId(int sid)
        {

            if (!await checker.StudentExists(sid))
                return NotFound();
            IEnumerable<RegisteredDTO> courses = await _repo.GetCoursesByStudentId(sid);
            return Ok(courses);
        }

        [HttpGet("{sid}/deregister/{reg_id}")]
        public async Task<ActionResult> DeregisterCourseOfStudent(int sid, int reg_id)
        {
            if (!await checker.StudentExists(sid) || !await checker.RegisterExists(reg_id))
                return BadRequest($"Check if student id ({sid}) and register id ({reg_id}) are correct");
            await _repo.DeregisterCourseByStudentId(sid, reg_id);
            return Ok();
        }

        [HttpGet("{sid}/Enroll/{taughtby_id}")]
        public async Task<ActionResult> StudentEnrollCourse(int sid,int taughtby_id)
        {
            if(!await checker.StudentExists(sid) || !await checker.TaughtByExists(taughtby_id))
            {
                string errorMessage = $"Check if student id ({sid}) and taughtby id ({taughtby_id}) are correct";
                return BadRequest(new { registered = false,message=errorMessage }) ;
            }
            if (await checker.RegisterExists(sid, taughtby_id))
                return Ok(new { registered = false, message = "Student already registered that course" });
            await _repo.StudentEnrollCourse(sid, taughtby_id);
            return Ok(new { registered = true, message = $"Student with student id: {sid} enrolled in taught by id: {taughtby_id} " });
        }

        [HttpGet("{regid}/Marks")]
        public async Task<ActionResult<ProjectMark>> GetMarks(int regid)
        {
            if(! await checker.RegisterExists(regid))
                return NotFound($"no such registeration of course exists, Registration id:{regid}");
            if(! await checker.ProjectMarksExists(regid))
                return NotFound($"Marks for this course has not been yet set,Registration id:{regid}");
            return Ok(await _repo.GetProjectMarks(regid));
        }
    }
}
