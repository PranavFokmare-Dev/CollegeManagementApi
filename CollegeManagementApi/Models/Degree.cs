using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

#nullable disable

namespace CollegeManagementApi.Models
{
    [DataContract]
    public partial class Degree
    {
        public Degree()
        {
            Students = new HashSet<Student>();
        }

        public int DegreeId { get; set; }
        [DataMember]
        public string DegreeName { get; set; }
        [DataMember]
        public string DegreeType { get; set; }
        [DataMember]
        public byte? DegreeDuration { get; set; }
        public virtual ICollection<Student> Students { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Degree degree = (Degree)obj;
                return degree.DegreeId == this.DegreeId && degree.DegreeName == this.DegreeName && degree.DegreeType == this.DegreeType && this.DegreeDuration == degree.DegreeDuration;
            }
        }
        public override int GetHashCode()
        {
            return this.DegreeId;
        }
    }
}
