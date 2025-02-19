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
        public DbSet<Gabarita.Ai.Models.Planos> Planos { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.Questionario> Questionario { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.Redacao> Redacao { get; set; } = default!;

    }
}
