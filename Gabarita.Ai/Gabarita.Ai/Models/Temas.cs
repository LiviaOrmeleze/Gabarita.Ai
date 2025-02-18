namespace Gabarita.Ai.Models
{
    public class Temas
    {
        public Guid TemasId { get; set; }
        public string Niveis { get; set; }
        public string Conteudos { get; set; }

        public Guid MateriasId { get; set; }
        public Materias? Materias { get; set; }
    }
}
