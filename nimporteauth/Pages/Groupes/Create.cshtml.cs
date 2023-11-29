using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using nimporteauth;
using nimporteauth.Data;

namespace nimporteauth.Pages.Groupes
{
    public class CreateModel : PageModel
    {
        private readonly nimporteauth.Data.ApplicationDbContext _context;

        public CreateModel(nimporteauth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Groupe Groupe { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Groupe == null || Groupe == null)
            {
                return Page();
            }

            _context.Groupe.Add(Groupe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
