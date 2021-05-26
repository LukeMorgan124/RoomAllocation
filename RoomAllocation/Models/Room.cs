using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomAllocation.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public char Block { get; set; }
        public string PeriodOneClass { get; set; }
        public string PeriodTwoClass { get; set; }
        public string PeriodThreeClass { get; set; }
        public string PeriodFourClass { get; set; }
        public string PeriodFiveClass { get; set; }
        public ICollection<ListRoom> ListRooms { get; set; }
    }
}
