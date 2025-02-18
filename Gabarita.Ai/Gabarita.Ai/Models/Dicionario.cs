using System.ComponentModel.DataAnnotations;

namespace Gabarita.Ai.Models
{
    public class Dicionario
    {
        public Guid Id { get; set; }
        public string Termo { get; set; }
        public string Definicao { get; set; }
        public CategoriaDicionario Categoria { get; set; } // Usando o enum
        public string? ExemploUso { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;
    }
}
