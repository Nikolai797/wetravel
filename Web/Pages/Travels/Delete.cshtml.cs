using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Model;

namespace Web.Pages.Travels
{
    public class DeleteModel : PageModel
    {
        private readonly Data.TravelContext _context;

        public DeleteModel(Data.TravelContext context)
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

            var travel = await _context.Travels.FirstOrDefaultAsync(m => m.Id == id);

            if (travel == null)
            {
                return NotFound();
            }
            else
            {
                Travel = travel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travel = await _context.Travels.FindAsync(id);
            if (travel != null)
            {
                Travel = travel;
                _context.Travels.Remove(Travel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
