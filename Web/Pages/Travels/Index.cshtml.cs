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
    public class IndexModel : PageModel
    {
        private readonly Data.TravelContext _context;

        public IndexModel(Data.TravelContext context)
        {
            _context = context;
        }

        public IList<Travel> Travel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Travel = await _context.Travels
                .Include(t => t.Customer).ToListAsync();
        }
    }
}
