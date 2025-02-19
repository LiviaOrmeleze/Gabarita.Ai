namespace Gabarita.Ai.Models
{
    public class Concurso
    {
        public Guid ConcursoId { get; set; }
        public string Nome { get; set; }
        public DateTime? DataConcurso { get; set; }
        public Guid? TipoConcursoId { get; set; }
    }
}
