using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementApi.Models
{
    public partial class Room
    {
        public Room()
        {
            TaughtBies = new HashSet<TaughtBy>();
        }

        public int RoomId { get; set; }
        public byte? FloorNumber { get; set; }
        public string BuildingName { get; set; }
        public byte? RoomNumber { get; set; }

        public virtual ICollection<TaughtBy> TaughtBies { get; set; }
    }
}
