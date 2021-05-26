using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomAllocation.Models
{
    public class ListRoom
    {
        public int ListRoomID { get; set; }
        public int RoomID { get; set; }
        public int UserID { get; set; }

        public Room Rooms { get; set; }
        public User Users { get; set; }
    }
}
