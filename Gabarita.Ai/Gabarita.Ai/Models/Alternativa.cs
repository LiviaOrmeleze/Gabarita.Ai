namespace Gabarita.Ai.Models
{
    public class Alternativa
    {
        public Guid AlternativaId { get; set; }
        public Guid ConteudoId { get; set; }
        public string Texto { get; set; }
        public bool Correta { get; set; }
    }
}
