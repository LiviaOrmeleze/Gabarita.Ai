namespace Gabarita.Ai.Models
{
    public class Conteudo
    {
        public Guid ConteudoId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Guid? TipoConteudoId { get; set; }
        public Guid? ConcursoId { get; set; }
        public Guid? VestibulandoId { get; set; }
    }
}
