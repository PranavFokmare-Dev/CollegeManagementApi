using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementApi.Models
{
    public partial class AssignmentUpload
    {
        public int? RegisterdId { get; set; }
        public DateTime? DueDate { get; set; }
        public string AssignmentName { get; set; }
        public DateTime? UploadDate { get; set; }
        public string Path { get; set; }

        public virtual Registerd Registerd { get; set; }
    }
}
