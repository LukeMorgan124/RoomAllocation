using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RoomAllocation.Data;
using RoomAllocation.Models;

namespace RoomAllocation.Pages.ListRooms
{
    public class IndexModel : PageModel
    {
        private readonly RoomAllocation.Data.RoomAllocationContext _context;

        public IndexModel(RoomAllocation.Data.RoomAllocationContext context)
        {
            _context = context;
        }

        public IList<ListRoom> ListRoom { get;set; }

        public async Task OnGetAsync()
        {
            ListRoom = await _context.ListRooms
                .Include(l => l.Rooms)
                .Include(l => l.Users).ToListAsync();
        }
    }
}
