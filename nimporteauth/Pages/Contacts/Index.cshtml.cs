using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using nimporteauth;
using nimporteauth.Data;

namespace nimporteauth.Pages.Contacts
{
    public class IndexModel : PageModel
    {
        private readonly nimporteauth.Data.ApplicationDbContext _context;
        [BindProperty(SupportsGet = true)]
        public bool WithoutGroupOnly { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? GroupId { get; set; }
        public int? numPage { get; set; }
        public SelectList GroupList { get; set; }

        public IndexModel(nimporteauth.Data.ApplicationDbContext context)
        {
            _context = context;
            GroupList = new SelectList(context.Groupe.ToList(), "Id", nameof(Groupe.nom));
        }

        public IList<Contact> Contact { get;set; } = default!;

        public async Task OnGetAsync(int? numPage, string orderByColumn)
        {
            int pageSize = 25;
            ViewData["NumPage"] = numPage ?? 1;
            if (orderByColumn == null)
            {
                orderByColumn = "prenom";
            }
            if (_context.Contact != null)
            {
                IQueryable<Contact> query = _context.Contact
                    .Include(x => x.contactGroupes);

                if (WithoutGroupOnly)
                {
                    query = query.Where(x => x.contactGroupes == null);
                }
                if (GroupId != null)
                {
                    //query = query.Where(x => x.Groupe.Id == GroupId); //.OrderBy(_context.Cont); aucune idée
                }
                //query = query.OrderBy(x => x.prenom);
                query = ApplyOrderBy(query, orderByColumn);
                int totalCount = await query.CountAsync();
                int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
                ViewData["TotalPages"] = totalPages;
                int page = numPage ?? 1;
                page = Math.Max(1, Math.Min(totalPages, page));
                int skip = (page - 1) * pageSize;
                Contact = query.Skip(skip).Take(pageSize).ToList();
            }
        }
        private IQueryable<Contact> ApplyOrderBy(IQueryable<Contact> query, string orderByColumn)
        {
            switch (orderByColumn)
            {
                case "prenom":
                    return query.OrderBy(x => x.prenom);
                case "nom":
                    return query.OrderBy(x => x.nom);
                case "email":
                    return query.OrderBy(x => x.email);
                case "estPro":
                    return query.OrderBy(x => x.estPro);
                case "groupe":
                    return query.OrderBy(x => x.contactGroupes); // TODO: groupe.nom à corriger
                default:
                    return query; // Aucun tri par défaut
            }
        }
    }
}
