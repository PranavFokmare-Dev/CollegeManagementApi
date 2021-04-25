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
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepository _repo;
        private readonly IExistenceChecker checker;

        public AttendanceController(IAttendanceRepository _repo, IExistenceChecker checker)
        {
            this._repo = _repo;
            this.checker = checker;
        }

        [HttpGet("{regid}")]
        public async Task<ActionResult<AttendanceRecordsDTO>> GetAttendance(int regid)
        {
            if(!await checker.AttendanceExists(regid))
            {
                return NotFound();
            }
            return await _repo.GetAttendanceRecords(regid);
        }
    }
}
