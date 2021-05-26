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
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
 
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var rooms = new Room[]
            {
            };

            context.Rooms.AddRange(rooms);
            context.SaveChanges();

            var listrooms = new ListRoom[]
            {

            };

            context.ListRooms.AddRange(listrooms);
            context.SaveChanges();
        }
    }
}
