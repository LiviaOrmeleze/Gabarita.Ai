using Gabarita.Ai.ModelUsuario;

namespace Gabarita.Ai.Models
{
    public class Redacao
    {
        public int RedacaoId { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}

