﻿using CollegeManagementApi.Filter;
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
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repo;
        public StudentsController(IStudentRepository _repo)
        {
            this._repo = _repo;
        }

        //[ServiceFilter(typeof(LogNormalActionFilter))]
        // api/Students
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _repo.GetStudents();
        }

        // api/Students/Add
        [HttpPost("Add")]
        public async Task<ActionResult<Student>> AddStudent(Student s)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (await _repo.AddStudent(s))
            {
                return CreatedAtAction("GetStudentById", new { id = s.StudentId }, s);
            }
            else
            {
                return NotFound();
            }
        }

        // api/students/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            Student s = await _repo.GetStudentById(id);
            if (s == null)
                return NotFound();
            return s;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student s)
        {
            if (s.StudentId != id || !ModelState.IsValid)
                return BadRequest();
            try
            {
                await _repo.UpdateStudent(s);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
        [HttpGet("Delete/{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            Student toDeleteStudent = await _repo.GetStudentById(id);
            if (toDeleteStudent == null)
                return NotFound();
            await _repo.DeleteStudent(toDeleteStudent);
            return toDeleteStudent;
        }

        [HttpGet("{sid}/Proctor")]
        public async Task<ActionResult<Teacher>> GetProctor(int sid)
        {
            if (!_repo.StudentExists(sid))
                return BadRequest();
            Teacher proctor = await _repo.GetProctorByStudentId(sid);
            if (proctor == null)
                return NotFound();
            return proctor;
        }

        [HttpGet("{student_id}/Proctor/{proctor_id}")]
        public async Task<ActionResult<Teacher>> SetProctor(int student_id, int proctor_id)
        {

            int pid = proctor_id;
            if (!_repo.StudentExists(student_id) || !_repo.TeacherExists(pid))
                return BadRequest();
            await _repo.SetProctor(student_id, pid);
            return RedirectToAction("GetProctor",new {sid=student_id });
        }
    }
}
