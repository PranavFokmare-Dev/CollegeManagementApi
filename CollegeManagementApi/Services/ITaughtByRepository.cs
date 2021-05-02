using CollegeManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Services
{
    public interface ITaughtByRepository
    {
        Task<IEnumerable<TaughtBy>> GetTaughtBies(int tid);
        Task RegisterTeacherToCourse(int tid, int cid);
    }
    public class TaughtByRepository:ITaughtByRepository
    {
        private readonly CollegeManagementContext context;
        private readonly IExistenceChecker checker;
        public TaughtByRepository(CollegeManagementContext context,IExistenceChecker checker)
        {
            this.context = context;
            this.checker = checker;
        }
        public async Task<IEnumerable<TaughtBy>> GetTaughtBies(int tid)
        {
            return await context.TaughtBies.Include(tby => tby.Course).Where(tby => tby.TeacherId == tid).ToListAsync();
        }
        public async Task RegisterTeacherToCourse(int tid, int cid)
        {
            if(!await checker.TaughtByExists(tid, cid))
            {
                TaughtBy tby = new TaughtBy();
                tby.CourseId = cid;
                tby.TeacherId = tid;
                await context.TaughtBies.AddAsync(tby);
                await context.SaveChangesAsync();

            }

        }

    }
}
