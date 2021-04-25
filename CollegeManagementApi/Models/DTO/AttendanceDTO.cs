using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Models.DTO
{
    public class AttendanceRecordsDTO
    {
        public int? RegisterdId { get; set; }
        public double AttendancePercentage { get; set; }
        public IEnumerable<AttendanceDTO> AttendanceRecords { get; set; }
    }
    public class AttendanceDTO
    {
        public DateTime? Date { get; set; }
        public string Status { get; set; }
    }
}
