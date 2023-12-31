﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly nimporteauth.Data.ApplicationDbContext _context;

        public IndexModel(nimporteauth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Groupe> Groupe { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Groupe != null)
            {
                Groupe = await _context.Groupe.ToListAsync();
            }
        }
    }
}
