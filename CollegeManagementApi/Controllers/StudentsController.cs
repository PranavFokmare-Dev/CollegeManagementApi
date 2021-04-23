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
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repo;
        public StudentsController(IStudentRepository _repo)
        {
            this._repo = _repo;
        }

        [ServiceFilter(typeof(LogNormalActionFilter))]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _repo.GetStudents();
        }

    }
}
