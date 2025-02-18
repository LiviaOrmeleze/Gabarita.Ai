namespace Gabarita.Ai.Models
{
    public class Desempenho
    {
        public Guid DesempenhoId { get; set; }
        public string MeuNivel { get; set; }
        public string Acertos { get; set; }
        public string Niveis { get; set; } // Exemplo: "Iniciante, Intermediário, Avançado"
        public string Dificuldades { get; set; } // Exemplo: "Matemática, Raciocínio Lógico"
        public string Habilidades { get; set; } // Exemplo: "Leitura rápida, Memorização"

    }
}
