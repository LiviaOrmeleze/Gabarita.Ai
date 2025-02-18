using System;
using System.Collections.Generic;
using Gabarita.Ai.ModelUsuario;

namespace Gabarita.Ai.Models
{
    public class Cronograma
    {
        public Guid CronogramaId { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Guid MateriasId { get; set; }
        public Materias? Materias { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public Guid? SemanaId { get; set; }
        public Semana? Semana { get; set; }

    }
}
