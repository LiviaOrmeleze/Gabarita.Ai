using System.ComponentModel.DataAnnotations;

namespace Gabarita.Ai.Models
{
    public class Biblioteca
    {
        public Guid BibliotecaId { get; set; }
        public string Name { get; set; } // Nome da biblioteca (ex: "Legislação", "Concursos")
        public Guid LivroId { get; set; } // Livro relacionado
        public Livro? Livro { get; set; }
    }
}
