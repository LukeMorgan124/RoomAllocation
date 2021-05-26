using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RoomAllocation.Data;
using RoomAllocation.Models;

namespace RoomAllocation.Pages.Rooms
{
    public class DetailsModel : PageModel
    {
        private readonly RoomAllocation.Data.RoomAllocationContext _context;

        public DetailsModel(RoomAllocation.Data.RoomAllocationContext context)
        {
            _context = context;
        }

        public Room Room { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room = await _context.Rooms.FirstOrDefaultAsync(m => m.RoomID == id);

            if (Room == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
