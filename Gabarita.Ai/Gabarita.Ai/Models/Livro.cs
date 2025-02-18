namespace Gabarita.Ai.Models
{
    public class Livro
    {
        public Guid LivroId { get; set; }
        public string Titulo { get; set; } = string.Empty; // Título do livro
        public string UrlArquivo { get; set; } = string.Empty; // Link do arquivo (PDF, etc.)
    }
}
