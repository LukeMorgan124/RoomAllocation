using RoomAllocation.Data;
using RoomAllocation.Models;
using System;
using System.Linq;

namespace RoomAllocation.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RoomAllocationContext context)
        {
            //context.Database.EnsureCreated();
            DbInitializer.Initialize(context);

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User {Username = "ac107242", Password = "123", Admin = true}
 
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var rooms = new Room[]
            {
                new Room { RoomNumber = 1, Block = 'A', PeriodOneClass = "11ENG-GRP", PeriodTwoClass = "Empty", PeriodThreeClass = "9DRA-HYR", PeriodFourClass = "12MUS-YBO", PeriodFiveClass = "Empty"}
            };
            context.SaveChanges();
            context.Rooms.AddRange(rooms);

            var listrooms = new ListRoom[]
            {

            };

            context.ListRooms.AddRange(listrooms);
            context.SaveChanges();
        }
    }
}
