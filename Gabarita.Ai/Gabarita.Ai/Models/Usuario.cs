using Microsoft.AspNetCore.Identity;

namespace Gabarita.Ai.Models
{
    public class Usuario
    {
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public DateTime DataCriacao { get; set; }
        public string TipoUsuario { get; set; }
        public Guid? ConcursoId { get; set; }
        public Guid? UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
