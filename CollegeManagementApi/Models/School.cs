using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

#nullable disable

namespace CollegeManagementApi.Models
{
    [DataContract]
    public partial class School
    {
        public School()
        {
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        [DataMember]
        public int SchoolId { get; set; }
        [DataMember]
        public string SchoolName { get; set; }
        public int? HodId { get; set; }
        public int? DeanId { get; set; }
        [DataMember]
        public string BuildingName { get; set; }
        [DataMember]
        public virtual Teacher Dean { get; set; }
        [DataMember]
        public virtual Teacher Hod { get; set; }


        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                School s = (School)obj;
                return s.SchoolId == this.SchoolId && s.SchoolName == this.SchoolName && s.BuildingName == this.BuildingName;
            }
        }
        public override int GetHashCode()
        {
            return this.SchoolId;
        }
    }
}
