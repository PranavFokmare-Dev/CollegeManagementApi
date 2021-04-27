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

        [HttpGet("{cid}")]
        public async Task<ActionResult<CourseDTO>> GetCourseById(int cid)
        {
            if(!await checker.CourseExists(cid))
            {
                return NotFound($"No Such Course Exists with Course ID {cid}");
            }
            CourseDTO courseDTO = await _repo.GetCourseById(cid);
            return Ok(courseDTO);
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

        [HttpPost("Add")]
        public async Task<ActionResult<CourseDTO>> AddCourse(Course course)
        {
            if(await checker.CourseExists(course.CourseName))
            {
                var response = new { message = "Course already exists", course = course };
                return Ok(response);
            }
            await _repo.AddCourse(course);
            return CreatedAtAction("GetCourseById", new { cid = course.CourseId }, course);
        }

        [HttpPut("Update/{courseId}")]
        public async Task<ActionResult<CourseDTO>> UpdateCourse( int courseId,Course course)
        {
            if(!ModelState.IsValid || ! await checker.CourseExists(courseId) || courseId != course.CourseId)
            {
                return BadRequest();
            }
            await _repo.UpdateCourse(course);
            return RedirectToAction("GetCourseById",new { cid = course.CourseId });
        }

        [HttpDelete("Delete/{courseId}")]
        public async Task<ActionResult> DeleteCourse(int courseId)
        {
            if (!await checker.CourseExists(courseId))
                return NotFound($"Course with the course id {courseId} doesnt exist");
            try
            {
                await _repo.DeleteCourse(courseId);
            }
            catch(Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                return BadRequest($"Cant Delete The course, its used by other entities occured");
            }
            return Ok($"Course with course id {courseId} deleted");
        }

    }
}
