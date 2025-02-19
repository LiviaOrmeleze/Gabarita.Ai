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
        public DbSet<Gabarita.Ai.Models.ConteudoEscolhido> ConteudoEscolhido { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.Cronograma> Cronograma { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.Desempenho> Desempenho { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.Dicionario> Dicionario { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.FlashCard> FlashCard { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.Livro> Livro { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.Materias> Materias { get; set; } = default!;
        public DbSet<Gabarita.Ai.Models.Orientacoes> Orientacoes { get; set; } = default!;

    }
}
