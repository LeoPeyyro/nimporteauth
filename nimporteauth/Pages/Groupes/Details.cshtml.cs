using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nimporteauth;
using nimporteauth.Data;

namespace nimporteauth.Pages.Groupes
{
    public class DetailsModel : PageModel
    {
        private readonly nimporteauth.Data.ApplicationDbContext _context;

        public DetailsModel(nimporteauth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Groupe Groupe { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Groupe == null)
            {
                return NotFound();
            }

            var groupe = await _context.Groupe.FirstOrDefaultAsync(m => m.Id == id);
            if (groupe == null)
            {
                return NotFound();
            }
            else 
            {
                Groupe = groupe;
            }
            return Page();
        }
    }
}
