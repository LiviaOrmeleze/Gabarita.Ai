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
        public DbSet<Gabarita.Ai.Models.Concurso> Concurso { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.Conteudo> Conteudo { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.Cronograma> Cronograma { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.Pagamento> Pagamento { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.Plano> Plano { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.Redacao> Redacao { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.TipoConteudo> TipoConteudo { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.TipoVestibulando> TipoVestibulando { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.Usuario> Usuario { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.Vestibulando> Vestibulando { get; set; } = default!;


    }
}
