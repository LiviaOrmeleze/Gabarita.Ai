namespace Gabarita.Ai.Models
{
    public class Questionario
    {
        public Guid QuestionarioId { get; set; }
        public string Pergunta { get; set; }
        public string Resposta { get; set; }
        public Guid MateriasId { get; set; }
        public Materias? Materias { get; set; }
        public Guid TemaId { get; set; }
        public Temas? Temas { get; set; }
    }
}
