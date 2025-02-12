using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
    }
}
