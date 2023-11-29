using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nimporteauth;
using nimporteauth.Data;

namespace nimporteauth.Pages.Contacts
{
    public class DetailsModel : PageModel
    {
        private readonly nimporteauth.Data.ApplicationDbContext _context;

        public DetailsModel(nimporteauth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Contact Contact { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            IQueryable<Contact> query = _context.Contact
                .Include(x => x.groupe);

            if (id == null || _context.Contact == null)
            {
                return NotFound();
            }

            var contact = await query.FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            else 
            {
                Contact = contact;
            }
            return Page();
        }
    }
}
