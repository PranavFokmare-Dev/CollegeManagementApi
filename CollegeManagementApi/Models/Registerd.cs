using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementApi.Models
{
    public partial class Registerd
    {
        public int RegisterdId { get; set; }
        public int? TaughtById { get; set; }
        public int? StudentId { get; set; }

        public virtual Student Student { get; set; }
        public virtual TaughtBy TaughtBy { get; set; }
    }
}
