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
    public class DetailsModel : PageModel
    {
        private readonly RoomAllocation.Data.RoomAllocationContext _context;

        public DetailsModel(RoomAllocation.Data.RoomAllocationContext context)
        {
            _context = context;
        }

        public ListRoom ListRoom { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ListRoom = await _context.ListRooms
                .Include(l => l.Rooms)
                .Include(l => l.Users).FirstOrDefaultAsync(m => m.ListRoomID == id);

            if (ListRoom == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
