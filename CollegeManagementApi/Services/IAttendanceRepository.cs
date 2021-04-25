using CollegeManagementApi.Models;
using CollegeManagementApi.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Services
{
    public interface IAttendanceRepository
    {
        Task<AttendanceRecordsDTO> GetAttendanceRecords(int regid);
    }

    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly CollegeManagementContext _context;

        public AttendanceRepository(CollegeManagementContext context)
        {
            _context = context;
        }


        public async Task<AttendanceRecordsDTO> GetAttendanceRecords(int regid)
        {
            IEnumerable<Attendance> attendanceList= await _context.Attendances.Where(a => a.RegisterdId == regid).ToListAsync();
            AttendanceRecordsDTO attendanceRecordsDTO = ConvertToAttendanceRecordsDTO(attendanceList,regid);
            return attendanceRecordsDTO;
        }

        public AttendanceRecordsDTO ConvertToAttendanceRecordsDTO(IEnumerable<Attendance> attendanceList,int regid)
        {
            AttendanceRecordsDTO records = new AttendanceRecordsDTO();
            records.RegisterdId = regid;
            records.AttendanceRecords = attendanceList.Select(a => new AttendanceDTO { Date = a.Date, Status = a.Status });
            records.AttendancePercentage = GetAttendacePercentage(attendanceList);
            return records;
            
        }
        private double GetAttendacePercentage(IEnumerable<Attendance> attendanceList)
        {
            int totalSessions = attendanceList.Count();
            if (totalSessions == 0)
                return 0;
            int presentSessions = attendanceList.Count();
            double AttendancePercentage = (double)(presentSessions) / totalSessions;
            return AttendancePercentage;
        }
    }
}
