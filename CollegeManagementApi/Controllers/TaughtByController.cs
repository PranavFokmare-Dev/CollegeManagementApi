using CollegeManagementApi.Models;
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
    public class TaughtByController : ControllerBase
    {
        private readonly ITaughtByRepository repo;
        private readonly IExistenceChecker checker;
        public TaughtByController(ITaughtByRepository repo,IExistenceChecker checker)
        {
            this.repo = repo;
            this.checker = checker;
        }
        [HttpGet("{tid}")]
        public async Task<ActionResult<IEnumerable<TaughtByDTO>>> GetCoursesTaughtBy(int tid)
        {
            if(!await checker.TeacherExists(tid))
            {
                return NotFound();
            }
            IEnumerable<TaughtBy> TaughtBiesResult = await repo.GetTaughtBies(tid);
            IEnumerable<TaughtByDTO> taughtByDTOs =
            TaughtBiesResult.Select(tby => new TaughtByDTO()
            {
                TaughtById = tby.TaughtById,
                CourseId = (int)tby.CourseId,
                Course = new CourseDTO(tby.Course)
            }) ;
            return Ok(taughtByDTOs);
        }
        [HttpGet("{tid}/Register/{cid}")]
        public async Task<ActionResult> RegisterTeacher(int cid,int tid)
        {
            if(!await checker.CourseExists(cid) || !await checker.TeacherExists(tid))
            {
                return NotFound(new { message = $"Check if course (course id:{cid}) or teacher (teacher id:{tid}) exists" });
            }
            await repo.RegisterTeacherToCourse(tid, cid);
            return Ok();

        }
    }
}
