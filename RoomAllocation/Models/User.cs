using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomAllocation.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public int Password { get; set; }
        public bool Admin { get; set; }
        public ICollection<ListRoom> ListRooms { get; set; }
    }
}
