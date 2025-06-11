using Microsoft.AspNetCore.Identity;

namespace Gabarita.Ai.Models
{
    public class Usuario : IdentityUser
    {
        public Usuario() : base()
        { }

        public Guid UsuarioId { get; set; }
        public string? NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }
        public string TipoUsuario { get; set; }
        public Guid? ConcursoId { get; set; }
        public Guid? UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
