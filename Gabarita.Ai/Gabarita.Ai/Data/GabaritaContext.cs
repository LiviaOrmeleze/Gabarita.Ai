using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Gabarita.Ai.Models;

namespace Gabarita.Ai.Data
{
    public class GabaritaContext : IdentityDbContext
    {
        public GabaritaContext(DbContextOptions<GabaritaContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Gabarita.Ai.Models.Alternativa> Alternativa { get; set; } = default!;


    }
}
