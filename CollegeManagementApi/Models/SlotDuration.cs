using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementApi.Models
{
    public partial class SlotDuration
    {
        public string Day { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public byte? SlotId { get; set; }

        public virtual Slot Slot { get; set; }
    }
}
