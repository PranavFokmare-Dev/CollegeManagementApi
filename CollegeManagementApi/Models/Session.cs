using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementApi.Models
{
    public partial class Session
    {
        public int? TaughtById { get; set; }
        public byte? SlotId { get; set; }

        public virtual Slot Slot { get; set; }
        public virtual TaughtBy TaughtBy { get; set; }
    }
}
