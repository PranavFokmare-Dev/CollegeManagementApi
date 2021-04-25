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
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _repo;
        private readonly IExistenceChecker checker;

        public CoursesController(ICourseRepository _repo,IExistenceChecker checker)
        {
            this._repo = _repo;
            this.checker = checker;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCourses()
        {
            return Ok(await _repo.GetCourses());
        }

        [HttpGet("{cid}/Teachers")]
        public async Task<ActionResult<TaughtByDTO>> GetTeachersByCourseId(int cid)
        {
            if(! await checker.CourseExists(cid))
            {
                return BadRequest($"No course of course id: {cid} exists");
            }
            IEnumerable<TaughtByDTO> taughtbyDTOs=await _repo.GetTeachersByCourseId(cid);
            return Ok(taughtbyDTOs);
        }

    }
}
