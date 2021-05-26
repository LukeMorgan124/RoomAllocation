using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomAllocation.Models;

namespace RoomAllocation.Data
{
    public class RoomAllocationContext : DbContext
    {
        public RoomAllocationContext (DbContextOptions<RoomAllocationContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ListRoom> ListRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<ListRoom>().ToTable("ListRoom");
        }
    }
}
