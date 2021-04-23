using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementApi.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public int? SenderId { get; set; }
        public int? RecieverId { get; set; }
        public DateTime? SentAt { get; set; }
        public int? GroupId { get; set; }

        public virtual GroupChat Group { get; set; }
    }
}
