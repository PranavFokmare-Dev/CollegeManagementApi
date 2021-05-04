using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollegeManagementApi.Models;
using CollegeManagementApi.Services;
using CollegeManagementApi.Models.DTO;

namespace CollegeManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolRepository _repo;

        public SchoolsController(ISchoolRepository _repo)
        {
            this._repo = _repo;
        }

        [HttpGet]
        //[ServiceFilter(typeof(LogNormalActionFilter))]
        public async Task<IEnumerable<School>> GetSchool()
        {
            
            return await _repo.GetSchool();
        }

        [HttpGet("{sid}")]
        //[ServiceFilter(typeof(LogNormalActionFilter))]
        public async Task<ActionResult<School>> GetSchoolById(int sid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            School s = await _repo.GetSchoolById(sid);
            if (s == null)
            {
                return NotFound();
            }
            return await _repo.GetSchoolById(sid);
        }

        [HttpGet("{school_id}/Hod/{teacher_id}")]
        public async Task<ActionResult<School>> SetHod(int school_id, int teacher_id)
        {

            int sid = school_id;
            
            if (!_repo.SchoolExists(school_id) || !_repo.TeacherExists(teacher_id))
                return BadRequest();
            await _repo.SetHod(sid, teacher_id);

            return Ok();
            //return RedirectToAction("GetHod", new { sid = school_id });
        }
        [HttpGet("{school_id}/Dean/{teacher_id}")]
        public async Task<ActionResult<School>> SetDean(int school_id, int teacher_id)
        {

            int sid = school_id;

            if (!_repo.SchoolExists(school_id) || !_repo.TeacherExists(teacher_id))
                return BadRequest();
            await _repo.SetDean(sid, teacher_id);

            return Ok();
            //return RedirectToAction("GetHod", new { sid = school_id });
        }

        [HttpGet("{sid}/Hod")]
        public async Task<ActionResult<School>> GetHod(int sid)
        {
            if (!_repo.SchoolExists(sid))
                return BadRequest();
            School school = await _repo.GetHodBySchoolId(sid);
            if (school == null)
                return NotFound();
            return school;
        }

        [HttpGet("{sid}/Dean")]
        public async Task<ActionResult<School>> GetDean(int sid)
        {
            if (!_repo.SchoolExists(sid))
                return BadRequest();
            School school = await _repo.GetDeanBySchoolId(sid);
            if (school == null)
                return NotFound();
            return school;
        }

        [HttpPut("{id}")]
        //[ServiceFilter(typeof(LogNormalActionFilter))]
        public async Task<ActionResult<School>> PutSchool(int id, School school)
        {
            if (school.SchoolId != id || !ModelState.IsValid)
                return BadRequest();
            try
            {
                await _repo.UpdateSchool(id, school);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        [HttpPost]
        // [ServiceFilter(typeof(LogNormalActionFilter))]
        public async Task<ActionResult> PostSchool(School school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repo.PostSchool(school);
            return Ok();
        }

        [HttpGet("Delete/{sid}")]
        // [ServiceFilter(typeof(LogNormalActionFilter))]
        public async Task<ActionResult<School>> DeleteSchool(int sid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            School delete_school = await _repo.GetSchoolById(sid);
            if (delete_school == null)
            {
                return NotFound();
            }
            await _repo.DeleteSchool(delete_school);
            return delete_school;
        }






    }
}
