using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Model;

namespace Web.Pages.Travels
{
    public class EditModel : PageModel
    {
        private readonly Data.TravelContext _context;

        public EditModel(Data.TravelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Travel Travel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travel =  await _context.Travels.FirstOrDefaultAsync(m => m.Id == id);
            if (travel == null)
            {
                return NotFound();
            }
            Travel = travel;
           ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Travel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelExists(Travel.Id))
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

        private bool TravelExists(int id)
        {
            return _context.Travels.Any(e => e.Id == id);
        }
    }
}
