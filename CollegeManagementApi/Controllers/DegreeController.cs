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
    public class DegreeController : ControllerBase
    {
        private readonly IDegreeRepository repo;
        public DegreeController(IDegreeRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<DegreeDTO>> GetDegrees()
        {
            IEnumerable<Degree> degrees = await repo.GetDegrees();
            return degrees.Select(d => new DegreeDTO(d));
        }
    }
}
