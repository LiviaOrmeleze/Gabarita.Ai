namespace Gabarita.Ai.Models
{
    public class CalendarioConcurso
    {
        public int CalendarioConcursoId { get; set; }
        public string NomeConcurso { get; set; }
        public DateTime DataInicioInscricao { get; set; }
        public DateTime DataFimInscricao { get; set; }
        public DateTime DataProva { get; set; }
        public string Status { get; set; } // Aberto, Fechado, Em andamento
        public string LinkEdital { get; set; }

    }
}
