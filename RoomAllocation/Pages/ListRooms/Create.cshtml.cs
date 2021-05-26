using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoomAllocation.Data;
using RoomAllocation.Models;

namespace RoomAllocation.Pages.ListRooms
{
    public class CreateModel : PageModel
    {
        private readonly RoomAllocation.Data.RoomAllocationContext _context;

        public CreateModel(RoomAllocation.Data.RoomAllocationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "RoomID");
        ViewData["UserID"] = new SelectList(_context.Set<User>(), "UserID", "UserID");
            return Page();
        }

        [BindProperty]
        public ListRoom ListRoom { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ListRooms.Add(ListRoom);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
