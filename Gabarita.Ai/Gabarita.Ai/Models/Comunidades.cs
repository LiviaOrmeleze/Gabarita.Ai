using Gabarita.Ai.ModelUsuario;

namespace Gabarita.Ai.Models
{
    public class Comunidades
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string Imagem { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public Comunidades()
        {
            Usuarios = new List<Usuario>();
        }
    }
}
