using Gabarita.Ai.ModelUsuario;

namespace Gabarita.Ai.Models
{
    public class ComunidadesUsuario
    {
        public Guid ComunidadesUsuarioId { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public Guid ComunidadesId { get; set; }
        public Comunidades? Comunidade { get; set; }
    }
}
