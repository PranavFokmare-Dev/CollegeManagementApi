using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementApi.Models
{
    public partial class GroupChat
    {
        public GroupChat()
        {
            GroupPartOfs = new HashSet<GroupPartOf>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<GroupPartOf> GroupPartOfs { get; set; }
    }
}
