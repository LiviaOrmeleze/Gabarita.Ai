﻿namespace Gabarita.Ai.Models
{
    public class Redacao
    {
        public Guid RedacaoId { get; set; }
        public Guid ConteudoId { get; set; }
        public string Texto { get; set; }
        public DateTime DataSubmissao { get; set; }
    }
}
