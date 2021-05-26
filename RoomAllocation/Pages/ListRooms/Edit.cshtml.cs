using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoomAllocation.Data;
using RoomAllocation.Models;

namespace RoomAllocation.Pages.ListRooms
{
    public class EditModel : PageModel
    {
        private readonly RoomAllocation.Data.RoomAllocationContext _context;

        public EditModel(RoomAllocation.Data.RoomAllocationContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "RoomID");
           ViewData["UserID"] = new SelectList(_context.Set<User>(), "UserID", "UserID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ListRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListRoomExists(ListRoom.ListRoomID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ListRoomExists(int id)
        {
            return _context.ListRooms.Any(e => e.ListRoomID == id);
        }
    }
}
