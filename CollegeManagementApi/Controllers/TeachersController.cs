using CollegeManagementApi.Filter;
using CollegeManagementApi.Models;
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
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _repo;
        private readonly INotifyUserService notify;
        public TeachersController(ITeacherRepository _repo,INotifyUserService notify)
        {
            this._repo = _repo;
            this.notify = notify;
        }

        [HttpGet]
        //[ServiceFilter(typeof(LogNormalActionFilter))]
        public async Task<IEnumerable<Teacher>> GetTeachers()
        {
            return await _repo.GetTeachers();
        }

        [HttpGet("{tid}")]
        //[ServiceFilter(typeof(LogNormalActionFilter))]
        public async Task<ActionResult<Teacher>> GetTeachersById(int tid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Teacher t = await _repo.GetTeachersByTeacherId(tid);
            if (t == null)
            {
                return NotFound();
            }
            return await _repo.GetTeachersByTeacherId(tid);
        }

        [HttpGet("school/{sid}")]
        //[ServiceFilter(typeof(LogNormalActionFilter))]
        public async Task<IEnumerable<Teacher>> GetTeachersBySchoolId(int sid)
        {
            return await _repo.GetTeachersBySchoolId(sid);
        }

        [HttpPut("{id}")]
        //[ServiceFilter(typeof(LogNormalActionFilter))]
        public async Task<ActionResult<Teacher>> PutTeacher(int id, Teacher teacher)
        {
            if (teacher.TeacherId != id || !ModelState.IsValid)
                return BadRequest();
            try
            {
                await _repo.PutTeacher(id,teacher);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        [HttpPost]
        // [ServiceFilter(typeof(LogNormalActionFilter))]
        public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Teacher teach = await _repo.PostTeacher(teacher);
            notify.NotifyNewUser(teach);
            return teach;

        }
        [HttpGet("Delete/{id}")]
        // [ServiceFilter(typeof(LogNormalActionFilter))]
        public async Task<ActionResult<Teacher>> DeleteTeacher(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Teacher delete_teacher = await _repo.GetTeachersByTeacherId(id);
            if (delete_teacher == null)
            {
                return NotFound();
            }
            await _repo.DeleteTeacher(delete_teacher);
            return delete_teacher;
        }
    }
}
