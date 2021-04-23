using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementApi.Models
{
    public partial class GroupPartOf
    {
        public int GroupId { get; set; }
        public string RegisterNumber { get; set; }

        public virtual GroupChat Group { get; set; }
    }
}
