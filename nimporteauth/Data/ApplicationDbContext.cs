using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using nimporteauth;

namespace nimporteauth.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<nimporteauth.Contact> Contact { get; set; } = default!;
        public DbSet<nimporteauth.Groupe> Groupe { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ContactGroupe>(opt =>
            {
                opt.HasKey(x => new { x.ContactId, x.GroupeId });
            });
        }
    }
}