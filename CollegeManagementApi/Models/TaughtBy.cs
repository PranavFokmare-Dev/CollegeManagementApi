using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementApi.Models
{
    public partial class TaughtBy
    {
        public TaughtBy()
        {
            Registerds = new HashSet<Registerd>();
        }

        public int TaughtById { get; set; }
        public int? TeacherId { get; set; }
        public int? CourseId { get; set; }
        public byte? FilledSeats { get; set; }
        public byte? TotalSeats { get; set; }
        public byte? WaitingSeats { get; set; }
        public int? RoomId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Room Room { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Registerd> Registerds { get; set; }
    }
}
