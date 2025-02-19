namespace Gabarita.Ai.Models
{
    public class Conteudo
    {
        public Guid ConteudoId { get; set; }
        public Guid CursoId { get; set; }
        public Curso? Curso { get; set; }
        public Guid BibliotecaId { get; set; }
        public Biblioteca? Biblioteca { get; set; }
        public Guid ResumoId { get; set; }
        public Resumo? Resumo { get; set; }
        public Guid FlashCardId { get; set; }
        public FlashCard? FlashCard { get; set; }
        public Guid QuestionarioId { get; set; }
        public Questionario? Questionario { get; set; }
        public Guid OrientacoesId { get; set; }
        public Orientacoes? Orientacoes { get; set; }
        public Guid CronogramaId { get; set; }
        public Cronograma? Cronograma { get; set; }
        public Guid PlanosId { get; set; }
        public Planos? Planos { get; set; }


    }
}
