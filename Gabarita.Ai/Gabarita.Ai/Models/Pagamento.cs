namespace Gabarita.Ai.Models
{
    public class Pagamento
    {
        public Guid PagamentoId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid PlanoId { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal Valor { get; set; }
    }
}
