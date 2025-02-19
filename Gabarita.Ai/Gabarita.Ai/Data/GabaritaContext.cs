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
        public DbSet<Gabarita.Ai.Models.Biblioteca> Biblioteca { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.CalendarioConcurso> CalendarioConcurso { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.CategoriaMateria> CategoriaMateria { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.Comunidades> Comunidades { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.ComunidadesUsuario> ComunidadesUsuario { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.ConFacu> ConFacu { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.Conteudo> Conteudo { get; set; } = default!;

    }
}
