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
    public class DetailsModel : PageModel
    {
        private readonly Data.TravelContext _context;

        public DetailsModel(Data.TravelContext context)
        {
            _context = context;
        }

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
    }
}
