namespace Gabarita.Ai.Models
{
    public class FlashCard
    {
        public int FlashCardId { get; set; }
        public Guid TemasId { get; set; }
        public Temas? Temas { get; set; }
        public Guid MateriasId { get; set; }
        public Materias? Materias { get; set; }
        public string Pergunta { get; set; }
        public string Resposta { get; set; }
    }
}
