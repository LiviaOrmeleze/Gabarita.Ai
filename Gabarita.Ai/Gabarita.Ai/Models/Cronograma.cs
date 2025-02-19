namespace Gabarita.Ai.Models
{
    public class Cronograma
    {
        public Guid CronogramaId { get; set; }
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
