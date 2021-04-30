using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Models.DTO
{
    public class DegreeDTO
    {
        public int DegreeId { get; set; }
        public string DegreeName { get; set; }
        public byte? DegreeDuration { get; set; }

        public DegreeDTO(Degree d)
        {
            if (d != null)
            {
                this.DegreeId = d.DegreeId;
                this.DegreeName = d.DegreeName;
                this.DegreeDuration = d.DegreeDuration;
            }

        }
    }
}
