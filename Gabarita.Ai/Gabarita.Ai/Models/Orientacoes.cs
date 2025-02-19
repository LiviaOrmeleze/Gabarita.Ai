namespace Gabarita.Ai.Models
{
    public class Orientacoes
    {
        public Guid OrientacoesId { get; set; }
        public string Descricao { get; set; }
        public string Observacoes { get; set; }
        public Guid TemasId { get; set; }
        public Temas? Temas { get; set; }
        public string? VideoUrl { get; set; } // Adicionado atributo para armazenar o link do vídeo do YouTube
    }
}
