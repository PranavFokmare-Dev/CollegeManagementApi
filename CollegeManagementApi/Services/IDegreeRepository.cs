using CollegeManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Services
{
    public interface IDegreeRepository
    {
        Task<IEnumerable<Degree>> GetDegrees();
    }
    public class DegreeRepository : IDegreeRepository 
    {
        private readonly CollegeManagementContext context;
        public DegreeRepository(CollegeManagementContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Degree>> GetDegrees()
        {
            return await context.Degrees.ToListAsync();
        }
    }

}
